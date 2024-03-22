using DemoMayBayCN.Models;
using Libs.EF;
using Libs.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DemoMayBayCN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthManagermentController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        //private readonly JwtConfig _jwtConfig;
        private readonly IConfiguration _configuration;
        private readonly TokenValidationParameters _tokenValidationParamnetes;
        private readonly ModelFlightContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<AuthManagermentController> _logger;

        public AuthManagermentController(UserManager<AppUser> userManager, IConfiguration configuration, ModelFlightContext dbContext, RoleManager<IdentityRole> roleManager, ILogger<AuthManagermentController> logger, TokenValidationParameters tokenValidationParamnetes)
        {
            _logger = logger;
            _roleManager = roleManager;
            _userManager = userManager;
            _configuration = configuration;
            _dbContext = dbContext;
            _logger = logger;
            _tokenValidationParamnetes = tokenValidationParamnetes;
        }
        private async Task<List<Claim>> GetAllValidClaims(AppUser user)
        {
            var _option = new IdentityOptions();
            var claims = new List<Claim>
            {
                new Claim("Id",user.Id),
                new Claim(JwtRegisteredClaimNames.Sub,user.Email),
                new Claim(JwtRegisteredClaimNames.Name,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,DateTime.Now.ToUniversalTime().ToString())
            };

            var userClaims = await _userManager.GetClaimsAsync(user);
            claims.AddRange(userClaims);

            var userRoles = await _userManager.GetRolesAsync(user);
            //var userName = await _userManager.GetUserNameAsync(user);
            foreach (var userRole in userRoles)
            {

                var role = await _roleManager.FindByNameAsync(userRole);
                if (role != null)
                {
                    claims.Add(new Claim(ClaimTypes.Role, userRole));
                    //claims.Add(new Claim(ClaimTypes.Name, userName));
                    var roleClaims = await _roleManager.GetClaimsAsync(role);
                    foreach (var roleClaim in roleClaims)
                    {
                        claims.Add(roleClaim);
                    }
                }
            }
            return claims;
        }
        private string RandomStringGeneration(int length)
        {
            var random = new Random();
            var chars = "ABCDEFGHJKLMNOPQRSTUVWXYZ1234567890abcdefghjklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private async Task<RegistrationResponse> GenerateJwtToken(AppUser user)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("JwtConfig:Secret").Value);
            var claims = await GetAllValidClaims(user);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.Add(TimeSpan.Parse(_configuration.GetSection("JwtConfig:ExpireTimeFrame").Value)),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature
                )
            };
            var token = jwtHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtHandler.WriteToken(token);

            HttpContext.Response.Cookies.Append("token", jwtToken, new CookieOptions
            {
                Expires = DateTime.Now.AddDays(7),
                HttpOnly = true,
                Secure = true,
                IsEssential = true,
                SameSite = SameSiteMode.None
            });

            var refeshToken = new RefeshToken()
            {
                JwtId = token.Id,
                Token = RandomStringGeneration(23),
                AddedDate = DateTime.Now,
                ExpiryDate = DateTime.Now.AddMinutes(30),
                IsRevoked = false,
                IsUsed = false,
                UserId = user.Id
            };

            await _dbContext.RefeshToken.AddAsync(refeshToken);
            await _dbContext.SaveChangesAsync();

            return new RegistrationResponse()
            {
                Token = jwtToken,
                RefeshToken = refeshToken.Token,
                Success = true
            };
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterRequest user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(user.Email);

                if (existingUser != null)
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string>()
                        {
                            "Email đã được sử dụng"
                        },
                        Success = false
                    });
                }

                var existingUserName = await _userManager.FindByNameAsync(user.UserName);
                if (existingUserName != null)
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string>()
                        {
                            "UserName đã được sử dụng"
                        },
                        Success = false
                    });

                }

                var newUser = new AppUser() { Email = user.Email, UserName = user.UserName, Address = user.Address, PhoneNumber = user.PhoneNumber, Gender = user.Gender, FullName = user.FullName };
                var isCreated = await _userManager.CreateAsync(newUser, user.Password);
                if (isCreated.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser, "Admin");

                    var jwtToken = await GenerateJwtToken(newUser);
                    return Ok(jwtToken);
                }
                else
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = isCreated.Errors.Select(x => x.Description).ToList(),
                        Success = false
                    });
                }
            }
            else
            {
                return BadRequest(new RegistrationResponse()
                {
                    Success = false,
                    Errors = new List<string>()
                    {
                        "Invalid payload"
                    }
                });
            }
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginRequest user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByNameAsync(user.UserName);
                if (existingUser == null)
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string>()
                        {
                            "Tên đăng nhập chưa tồn tại "
                        },
                        Success = false
                    });
                }
                var isCorrect = await _userManager.CheckPasswordAsync(existingUser, user.Password);
                if (!isCorrect)
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string>()
                        {
                            "Tên đăng nhập hoặc mật khẩu không đúng"
                        },
                        Success = false
                    });
                }
                var jwtToken = await GenerateJwtToken(existingUser);
                return Ok(jwtToken);
            }
            return BadRequest(new RegistrationResponse()
            {
                Errors = new List<string>()
                        {
                            "Invalid payload"
                        },
                Success = false
            });
        }
        [HttpPost]
        [Route("Logout")]
        public IActionResult Logout()
        {
            var cookies = Request.Cookies.Keys;
            foreach(var cookie in cookies)
            {
                Response.Cookies.Delete(cookie);
                
            }
            return Ok(new { status = true ,message="" });
        }
        private async Task<RegistrationResponse> VerifyAndGenerateToken(TokenRequest tokenRequest)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtConfig:Secret").Value);
            var tokenValidationParameter = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = false,
                ClockSkew = TimeSpan.Zero,
                ValidateLifetime = false
            };
            try
            {
                //ko kiểm tra token hết hạn
                //_tokenValidationParamnetes.ValidateLifetime = false;

                //Định dạng của Access Token
                var tokenInVerification = jwtTokenHandler.ValidateToken(tokenRequest.Token, tokenValidationParameter, out var validatedToken);

                // Kiểm tra thuật toán mã hóa
                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
                    if (result == false)
                    {
                        return null;
                    }
                }
                var utcExprityDate = long.Parse(tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

                var expiryDate = UnixTimeStampToDateTime(utcExprityDate);

                if (expiryDate > DateTime.Now)
                {
                    return new RegistrationResponse()
                    {
                        Success = false,
                        Errors = new List<string>()
                        {
                            "Expried token"
                        }
                    };
                }
                var storedToken = await _dbContext.RefeshToken.FirstOrDefaultAsync(x => x.Token == tokenRequest.RefeshToken);
                if (storedToken == null)
                {
                    return new RegistrationResponse()
                    {
                        Success = false,
                        Errors = new List<string>()
                        {
                            "Invalid token"
                        }
                    };
                }
                // Kiểm tra Refresh Token đã sử dụng hay chưa
                if (storedToken.IsUsed)
                {
                    return new RegistrationResponse()
                    {
                        Success = false,
                        Errors = new List<string>()
                        {
                            "Invalid token"
                        }
                    };
                }
                //Kiểm tra Refresh Token đã thu hồi chưa
                if (storedToken.IsRevoked)
                {
                    return new RegistrationResponse()
                    {
                        Success = false,
                        Errors = new List<string>()
                        {
                            "Invalid token"
                        }
                    };
                }
                var jti = tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
                if (storedToken.JwtId != jti)
                {
                    return new RegistrationResponse()
                    {
                        Success = false,
                        Errors = new List<string>()
                        {
                            "the token doenst mateched the saved token"
                        }
                    };
                }
                //Kiểm tra refresh Token còn thời hạn không
                if (storedToken.ExpiryDate < DateTime.Now)
                {
                    return new RegistrationResponse()
                    {
                        Success = false,
                        Errors = new List<string>()
                        {
                            "Expired tokens"
                        }
                    };
                }
                storedToken.IsUsed = true;
                _dbContext.RefeshToken.Update(storedToken);
                await _dbContext.SaveChangesAsync();

                var dbUser = await _userManager.FindByIdAsync(storedToken.UserId);
                return await GenerateJwtToken(dbUser);
            }
            catch (Exception ex)
            {
                return new RegistrationResponse()
                {
                    Success = false,
                    Errors = new List<string>()
                        {
                            "Server error"
                        }
                };
            }
        }

        private DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            var dateTimeVal = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTimeVal = dateTimeVal.AddSeconds(unixTimeStamp).ToUniversalTime();
            return dateTimeVal;
        }
        [HttpPost]
        [Route("RefeshToken")]
        public async Task<IActionResult> RefeshToken(TokenRequest tokenRequest)
        {
            if (ModelState.IsValid)
            {
                var result = await VerifyAndGenerateToken(tokenRequest);
                if (result == null)
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string>()
                        {
                            "Invalid token"
                        },
                        Success = false
                    });
                }
                return Ok(result);

            }
            return BadRequest(new RegistrationResponse()
            {
                Errors = new List<string>()
                {
                    "Invalid parameters"
                },
                Success = false
            });
        }
    }
}
