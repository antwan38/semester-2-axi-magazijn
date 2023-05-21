using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using System.Diagnostics;
using LogicLayer;
using DataAccessLayer;
using InterfaceLayer;

namespace Presentation.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            HttpContext.Session.Clear();
            return View();
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "User");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("Mail, Password")] LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                int UserDTO;
                UserContainer userContainer = new UserContainer(new UserDAL());
                User user = new User(
                    loginModel.Mail,
                    loginModel.Password,
                    new UserDAL());
                UserDTO dto = user.VerifyLogin();
                try
                { 
                    UserDTO = dto.UserID;
                }
                catch (SqlException e)
                {
                    ModelState.AddModelError(nameof(loginModel.Mail), "Het ingevulde emailadres bestaat al.");
                    return View(loginModel);
                }

                if ( UserDTO == 0)
                {
                    ModelState.AddModelError(nameof(loginModel.Password), "Onjuiste gebruikernaam en/of wachtwoord.");
                    return View(loginModel);
                }
                HttpContext.Session.SetString("UserName", dto.UserName);
                HttpContext.Session.SetInt32("ID", dto.UserID);
                HttpContext.Session.SetInt32("Role", dto.Role);
                return RedirectToAction("Index", "Dashboard");
            }

            ModelState.AddModelError(nameof(loginModel.Password), "Vul alle velden in.");
            return View(loginModel);
        }

    public IActionResult SignUp()
    {
        if (HttpContext.Session.GetInt32("Role") != 1)
        {
            return RedirectToAction("index", "Dashboard");
        }
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SignUp([Bind("UserName, Mail, Password, ValPassword, Role")] AccountModel accountModel)
    {
        try
        {
            if (ModelState.IsValid)
            {
                User user = new User(
                    accountModel.UserName,
                    accountModel.Mail,
                    accountModel.Password,
                    accountModel.Role,
                    new UserDAL());
                int ValState = user.validatePassword();
                switch (ValState)
                {
                    case 1:
                        if (user.RegisterUser())
                        {
                            return RedirectToAction("Index", "Dashboard");
                        }

                        break;

                    case 2:
                        ModelState.AddModelError(nameof(accountModel.Password),
                            "Wachtwoord moet minstens 1 hoofdletter bevatten");
                        return View(accountModel);
                        break;

                    case 3:
                        ModelState.AddModelError(nameof(accountModel.Password),
                            "Wachtwoord moet minstens 5 characters lang zijn");
                        return View(accountModel);
                        break;
                }
            }
        }
        catch (SqlException e)
        {
            ModelState.AddModelError(nameof(accountModel.Mail),
                "Mail al in gebruik");
            return View(accountModel);
        }
        return View(accountModel);
    }
    }

}