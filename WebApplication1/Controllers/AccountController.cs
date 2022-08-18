using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PL.Helper;
using PL.Models;
using System.Threading.Tasks;

namespace PL.Controllers
{
    public class AccountController : Controller
    {
        public UserManager<ApplicationUser> Manageruser { get; }
        public SignInManager<ApplicationUser> SignInManager { get; }
        public AccountController(UserManager<ApplicationUser> manageruser, SignInManager<ApplicationUser> signInManager)
        {
            Manageruser = manageruser;
            SignInManager = signInManager;
        }



        public IActionResult Register()
        {


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)

        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = registerViewModel.Name,
                    Email = registerViewModel.Email,

                    IsAgree = registerViewModel.IsAgree,

                };
                var result = await Manageruser.CreateAsync(user, registerViewModel.Password);
                if (result.Succeeded)
                    return RedirectToAction(nameof(Login));
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);

            }
            return View(registerViewModel);

        }



        public IActionResult Login()
        {


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var emailuser = await Manageruser.FindByEmailAsync(loginViewModel.Email);
                if (emailuser != null)
                {

                    var password = await Manageruser.CheckPasswordAsync(emailuser, loginViewModel.Password);
                    if (password)
                    {
                        var result = await SignInManager.PasswordSignInAsync(emailuser, loginViewModel.Password, loginViewModel.RememberMe, false);
                        if (result.Succeeded)
                            return RedirectToAction("Index", "Home");
                    }
                }


            }

            return View(loginViewModel);
        }

        public async new Task<IActionResult> SignOut()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));

        }
        public IActionResult ForgetPassword()
        {

              
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetViewModel forgetViewModel)
        {
            if (ModelState.IsValid)
            {

                var emailuser = await Manageruser.FindByEmailAsync(forgetViewModel.Email);
                if (emailuser != null)
                {
                    ModelState.AddModelError(string.Empty, "Email is not existing");
                    var Token = await Manageruser.GeneratePasswordResetTokenAsync(emailuser);
                    var PasswordResetLink = Url.Action("ResetPassword", "Account", new
                    {
                        Email = emailuser.Email,
                        Token = Token,
                        Request.Scheme
                    });
                    var email = new Email()
                    {

                        Title = "Reset Pasword",
                        Body = PasswordResetLink,
                        To= forgetViewModel.Email
                    };
                    EmailSettings.SendEmail(email);
                    return RedirectToAction(nameof(CompleteForgetPassword));

                }
            }
            return View(forgetViewModel);
        }

        public  IActionResult CompleteForgetPassword(ForgetViewModel forgetViewModel)
        {
            return View(forgetViewModel);

        }
        //public IActionResult ResetPassword()
        //{

        //    return View();
        //}


        public     IActionResult ResetPassword(string email, string token)
        {
            //var user = await Manageruser.FindByEmailAsync(email);

            //if (user == null)
            //   return BadRequest();
            //var result = await Manageruser.ResetPasswordAsync();
            return View();

        }

        [HttpPost]

        public async Task <IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {


                var user = await Manageruser.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var result = await Manageruser.ResetPasswordAsync(user, model.Token, model.Password);
                    if (result.Succeeded)
                        return RedirectToAction(nameof(ResetPasswordDone));

                    foreach(var error in result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);


                }

            }
            ModelState.AddModelError(string.Empty, "Invalid Email");

            return View(model); 


        }
    public IActionResult ResetPasswordDone()
        {
            return View();
        }




    }
}





