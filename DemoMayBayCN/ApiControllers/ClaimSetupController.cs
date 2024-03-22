using Libs.EF;
using Libs.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DemoMayBayCN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimSetupController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        //private readonly JwtConfig _jwtConfig;
        private readonly IConfiguration _configuration;
        //private readonly TokenValidationParameters _tokenValidationParamnetes;
        private readonly ModelFlightContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<AuthManagermentController> _logger;
        public ClaimSetupController(UserManager<AppUser> userManager, IConfiguration configuration, ModelFlightContext dbContext, RoleManager<IdentityRole> roleManager, ILogger<AuthManagermentController> logger)
        {
            _logger = logger;
            _roleManager = roleManager;
            _userManager = userManager;
            _configuration = configuration;
            _dbContext = dbContext;
            _logger = logger;
        }
        [HttpGet]
        [Route("GetAllClaims")]
        public async Task<IActionResult> GetAllClaims(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                _logger.LogInformation($"The user with {email} does not exist");
                return BadRequest(new
                {
                    error = "User does not exist "
                });
            }
            var userClaims = await _userManager.GetClaimsAsync(user);
            return Ok(userClaims);
        }
        [HttpPost]
        [Route("AddClaimToUSer")]
        public async Task<IActionResult> AddClaimToUser(string email, string claimName, string claimValue)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                _logger.LogInformation($"The user with {email} does not exist");
                return BadRequest(new
                {
                    error = "User does not exist "
                });
            }
            var userClaim = new Claim(claimName, claimValue);
            var result = await _userManager.AddClaimAsync(user, userClaim);
            if (result.Succeeded)
            {
                return Ok(new
                {
                    result = $"User {user.Email} has a claim {claimName} added to them"
                });
            }
            return BadRequest(new
            {
                error = $"Unable to add claim {claimName} to the user {user.Email}"
            });
        }
    }
}
