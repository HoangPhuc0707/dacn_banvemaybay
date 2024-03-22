using DemoMayBayCN.Areas.Admin.ModelView;
using DemoMayBayCN.Controllers;
using Libs.Entity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoMayBayCN.Areas.Admin.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "DepartmentPolicy")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<UsersController> _logger;
        public UsersController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, ILogger<UsersController> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }
        [HttpGet]
        [Route("GettAllUsers")]
        public async Task<IActionResult> GettAllUsers()
        {
            //var users = await _userManager.Users.ToListAsync();
            //return Ok(users);
            var users = await _userManager.Users
            .Select(user => new
            {
                user.Id,
                user.UserName,
                user.Email,
                user.Gender,
                user.Address,
                user.FullName,
                Roles = _userManager.GetRolesAsync(user).Result
            }).ToListAsync();
            return Ok(new { status = true, message = "", data = users });
        }
        [HttpGet]
        [Route("GettAllRoles")]
        public IActionResult GetAllRoles()
        {
            var roles = _roleManager.Roles.ToList();

            return Ok(new { status = true, message = "", data = roles });
        }
        [HttpGet]
        [Route("GetRoles")]
        public async Task<IActionResult> GetRoles(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            return Ok(new { status = true, messgae = "", data = role });
        }
        [HttpPost]
        [Route("CreateRole")]
        public async Task<IActionResult> CreateRole([FromBody] RoleRequest role)
        {
            var roleExist = await _roleManager.RoleExistsAsync(role.RoleName);
            if (!roleExist)
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole(role.RoleName));

                if (roleResult.Succeeded)
                {
                    _logger.LogInformation($"The Role{role.RoleName} has been added successfully");
                    return Ok(new { result = $"The Role {role.RoleName} has been added successfully" });
                }
                else
                {
                    _logger.LogInformation($"The Role{role.RoleName} has not been added ");
                    return BadRequest(new { error = $"The Role {role.RoleName} has not been added " });
                }
            }
            return BadRequest(new { error = "Role already exist" });
        }
        [HttpPut]
        [Route("EditRole/{id}")]
        public async Task<IActionResult> EditRole(string id, RoleRequest user)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                role.Name = user.RoleName;
                var roleResult = await _roleManager.UpdateAsync(role);
                if (roleResult.Succeeded)
                {
                    _logger.LogInformation($"The Role with ID {id} has been renamed to {role.Name} successfully");
                    return Ok(new { result = $"The Role with ID {id} has been renamed to {role.Name} successfully" });
                }
                else
                {
                    _logger.LogError($"Failed to update the Role with ID {id} name");
                    return BadRequest(new { error = $"Failed to update the Role with ID {id} name" });
                }
            }
            else
            {
                _logger.LogError($"Role with ID {id} not found");
                return NotFound(new { error = $"Role with ID {id} not found" });
            }
        }
        [HttpDelete]
        [Route("RemoveRole/{id}")]
        public async Task<IActionResult> RemoveRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                var roleResult = await _roleManager.DeleteAsync(role);
                if (roleResult.Succeeded)
                {
                    _logger.LogInformation($" Delete {id} successfully ");
                    return Ok(new { result = $" Delete {id} successfully " });
                }
                else
                {
                    _logger.LogError($"Failed to delete the Role with ID {id}");
                    return BadRequest(new { error = $"Failed to delete the Role with ID {id}" });
                }
            }
            else
            {
                _logger.LogError($"Role with ID {id} not found");
                return NotFound(new { error = $"Role with ID {id} not found" });
            }
        }
        [HttpGet]
        [Route("GetUser")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                _logger.LogInformation($"The user with {id} does not exist");
                return Ok(new
                {
                    error = "user does not exist"
                });
            }
            var fullName = user.FullName;
            return Ok(new { status = true, message = "", data = fullName });
        }
        [HttpPut]
        [Route("EditRoleName/{id}")]
        public async Task<IActionResult> EditRole(string id,UserRequest user)
        {
            var users = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                _logger.LogInformation($"The user with {id} does not exist");
                return Ok(new
                {
                    error = "user does not exist"
                });
            }
            var role = await _roleManager.FindByIdAsync(user.roleId);
            var userRoles = await _userManager.GetRolesAsync(users);
            await _userManager.RemoveFromRolesAsync(users, userRoles);

            // Thêm vai trò mới cho người dùng
            await _userManager.AddToRoleAsync(users, role.Name);

            // Cập nhật các thay đổi
            await _userManager.UpdateAsync(users);
            return Ok(new { status = true, message = "Sửa thành công" });
        }
        [HttpGet]
        [Route("GetPersonal")]
        public async Task<IActionResult> GetPersonal()
        {
            var userId = User.Claims.Where(x => x.Type == "Id").FirstOrDefault()?.Value;
            var user = await _userManager.FindByIdAsync(userId);
            return Ok(new { status = true, message = "", data = user });
        }
        [HttpPut]
        [Route("EditPersonal")]
        public async Task<IActionResult> EditPersonal(PersonalRequest person)
        {
            var userId = User.Claims.Where(x => x.Type == "Id").FirstOrDefault()?.Value;
            var user = await _userManager.FindByIdAsync(userId);
            user.FullName = person.FullName;
            user.PhoneNumber = person.PhoneNumber;
            user.Email = person.Email;
            user.Gender = person.Gender;
            user.Address = person.Address;
            await _userManager.UpdateAsync(user);
            return Ok(new { status = true, message = "Sửa thành công" });
        }
    }
}
