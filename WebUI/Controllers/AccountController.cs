using DomainModels.Entities;
using DomainModels.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class AccountController : Controller
    {
        protected SignInManager<User> signInManager;
        protected UserManager<User> userManager;
        protected RoleManager<Role> roleManager;
        protected IUnitOfWork uow;

        public AccountController(IUnitOfWork _uow,
                                 SignInManager<User> _signInManager,
                                 UserManager<User> _userManager,
                                 RoleManager<Role> _roleManager)
        {
            uow = _uow;
            signInManager = _signInManager;
            roleManager = _roleManager;
            userManager = _userManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            //user : User@123456789
            //admin :Admin@123456789

            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(model.Username, model.Password, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    User user = await userManager.FindByNameAsync(model.Username);
                    if (await userManager.IsInRoleAsync(user, "Admin"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    else if (await userManager.IsInRoleAsync(user, "User"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "User" });
                    }
                }
            }
            return View();
        }

        public IActionResult SignUp()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Name = model.Name,
                    UserName = model.Username,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                };

                IdentityResult result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    Role role = await roleManager.FindByNameAsync("User");
                    //Role role = await roleManager.FindByNameAsync("Admin");
                    if (role != null)
                    {
                        IdentityResult res = await userManager.AddToRoleAsync(user, role.Name);
                        if (res.Succeeded)
                        {
                            return RedirectToAction("SuccessRegister");
                        }
                    }
                }
            }
            return View();
        }

        public IActionResult SuccessRegister()
        {
            return View();
        }

        public IActionResult UnAuthorize()
        {
            return View();
        }

        public IActionResult SignOut()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}