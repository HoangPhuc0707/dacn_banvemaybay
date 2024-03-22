using Libs.EF;
using Libs.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoMayBayCN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetupController : ControllerBase
    {
        private readonly ModelFlightContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<SetupController> _logger;
        //public readonly UnitOfWork unitOfWork;
        public SetupController(ModelFlightContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, ILogger<SetupController> logger)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }
        [HttpGet]
        [Route("GettAllRoles")]
        public IActionResult GetAllRoles()
        {
            var roles = _roleManager.Roles.ToList();
            return Ok(roles);
        }
        [HttpPost]
        [Route("CreateRole")]
        public async Task<IActionResult> CreateRole(string name)
        {
            var roleExist = await _roleManager.RoleExistsAsync(name);
            if (!roleExist)
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole(name));

                if (roleResult.Succeeded)
                {
                    _logger.LogInformation($"The Role{name} has been added successfully");
                    return Ok(new { result = $"The Role {name} has been added successfully" });
                }
                else
                {
                    _logger.LogInformation($"The Role{name} has not been added ");
                    return BadRequest(new { error = $"The Role {name} has not been added " });
                }
            }
            return BadRequest(new { error = "Role already exist" });
        }
        [HttpGet]
        [Route("GettAllUsers")]
        public async Task<IActionResult> GettAllUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return Ok(users);
        }
        [HttpPost]
        [Route("AddUserToRole")]
        public async Task<IActionResult> AddUserToRole(string email, string roleName)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                _logger.LogInformation($"The user with the {email} does not exist");
                return BadRequest(new
                {
                    error = "User does not exist"
                });
            }
            var roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                _logger.LogInformation($"The role {email} does not exist");
                return BadRequest(new
                {
                    error = "Role does not exist"
                });
            }
            var result = await _userManager.AddToRoleAsync(user, roleName);
            if (result.Succeeded)
            {
                return Ok(new
                {
                    result = "Success,user has been added to the role"
                });
            }
            else
            {
                _logger.LogInformation($"The user was not to abel to be added to role");
                return BadRequest(new
                {
                    error = "The user was not to abel to be added to role"
                });
            }
        }
        [HttpGet]
        [Route("GetUserRole")]
        public async Task<IActionResult> GetUserRole(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                _logger.LogInformation($"The user with {email} does not exist");
                return Ok(new
                {
                    error = "user does not exist"
                });
            }
            var role = await _userManager.GetRolesAsync(user);
            return Ok(role);
        }
        [HttpPost]
        [Route("RemoveUserFromRole")]
        public async Task<IActionResult> RemoveUserFromRole(string email, string roleName)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                _logger.LogInformation($"The user with {email} does not exist");
                return Ok(new
                {
                    error = "user does not exist"
                });
            }
            var roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                _logger.LogInformation($"The role {email} does not exist");
                return BadRequest(new
                {
                    resutl = "Role does not exist"
                });
            }
            var result = await _userManager.RemoveFromRoleAsync(user, roleName);
            if (result.Succeeded)
            {
                return Ok(new
                {
                    result = $"User{email} has been removed from role{roleName}"
                });
            }
            return BadRequest(new
            {
                error = $"Unable to remove User {email} from role{roleName}"
            });
        }

        //[HttpPost]
        //[Route("CreateUser")]
        //public async Task<IActionResult> CreateUser(UserRegister _user)
        //{
        //    User user = new User
        //    {
        //        UserName = _user.UserName,
        //        Email = _user.Email,
        //    };
        //    var result = await _userManager.CreateAsync(user, _user.Password);

        //    if (result.Succeeded)
        //    {
        //        await userService.CompleteAsync();
        //        return Ok(new { status = true, message = "", data = user });
        //    }
        //    else
        //    {
        //        return BadRequest(new { status = false, errors = result.Errors });
        //    }
        //}

    }
}
