using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using School_Management_System.Data;
using School_Management_System.Data.ViewModels;
using School_Management_System.Helpers;
using School_Management_System.Models;

namespace School_Management_System.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private UserManager<User> userManager;
        private readonly IConfiguration _config;
        private readonly AppDbContext _context;
        public readonly IWebHostEnvironment _webHostEnvironment;
        IHttpContextAccessor _httpContextAccessor;
        public AuthController(
            IWebHostEnvironment webHostEnvironment,
            IMapper mapper,
            UserManager<User> userManager,
            IHttpContextAccessor httpContextAccessor,
            RoleManager<IdentityRole> roleManager,
            IConfiguration _config,
            AppDbContext context
        )
        {
            this._roleManager = roleManager;
            this._mapper = mapper;
            this.userManager = userManager;
            this._config = _config;
            this._webHostEnvironment = webHostEnvironment;
            this._context = context;
            this._httpContextAccessor = httpContextAccessor;
        }
        
        [Authorize(Roles = "admin,school")]
        [HttpPost("register")]
        public async Task<ActionResult> Register(UserForRegister model)
        {
            model.Password = model.Password+"Abc123@";
            User user = await Functions.getCurrentUser(_httpContextAccessor, _context);

            var userToCreate = _mapper.Map<User>(model);
            if (!await _roleManager.RoleExistsAsync(model.Role))
                await _roleManager.CreateAsync(new IdentityRole(model.Role));
            var result = await userManager.CreateAsync(userToCreate, model.Password);
            await userManager.AddToRoleAsync(userToCreate, model.Role);
            await _context.SaveChangesAsync();
            return Ok(userToCreate);
        }


        [Authorize(Roles = "admin,school")]
        [HttpPost("user/delete")]
        public async Task<ActionResult> DeleteUser(UserForDelete userForDelete)
        {
            User user = await _context.Users.FindAsync(userForDelete.UserId);
             _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return Ok(true);
        }


        [HttpPost("/login")]
        public async Task<IActionResult> Login(UserForLogin model)
        {
            var loginUser = await userManager.FindByNameAsync(model.UserName);
            if (loginUser != null&& await userManager.CheckPasswordAsync(loginUser, model.Password+"Abc123@"))
            {
                var userRoles = await userManager.GetRolesAsync(loginUser);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, loginUser.Id),
                    new Claim(ClaimTypes.Name, loginUser.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_config["JWT:Secret"])
                );

                var token = new JwtSecurityToken(
                    issuer: _config["JWT:ValidIssuer"],
                    audience: _config["JWT:ValidAudience"],
                    expires: DateTime.Now.AddDays(100),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(
                        authSigningKey,
                        SecurityAlgorithms.HmacSha256
                    )
                );

                return Ok(
                    new { token = new JwtSecurityTokenHandler().WriteToken(token), loginUser }
                );
            }
            return Unauthorized();
        }
    }
}
