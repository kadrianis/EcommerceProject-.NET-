using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Projet_2022.Data;
using Projet_2022.Data.IServices;
using Projet_2022.Data.Static;
using Projet_2022.Models.Entities;
using Projet_2022.Models.ViewModels;
using Projet_2022.Views.ViewModels;
using System.Security.Claims;

namespace Projet_2022.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _usermanager;
        private readonly SignInManager<User> _signinmanager;
        private readonly AppDbContext _context;
        public AccountController(UserManager<User> usermanager,
            SignInManager<User> signinmanager,
            AppDbContext context
            )
        {
            _usermanager = usermanager;
            _signinmanager = signinmanager;
            _context = context;
        }
        public IActionResult Login()
        {
            var response = new LoginVM();

            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginvm)
        {
            if (!ModelState.IsValid)
            {
                return (View(loginvm));
            }
            var user = await _usermanager.FindByEmailAsync(loginvm.Email);
            if (user != null)
            {
                var passwordCheck = await _usermanager.CheckPasswordAsync(user, loginvm.Password);
                if (passwordCheck)
                {
                    var result = await _signinmanager.PasswordSignInAsync(user, loginvm.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Product");
                    }
                }
            }
            TempData["Error"] = "Wrong! Try Again";
            return View(loginvm);
        }
        [Authorize(UserRoles.Admin)]
        public async Task<IActionResult> Users()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }
        public IActionResult Register()
        {
            var response = new RegisterVM();

            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registervm)
        {
            if (!ModelState.IsValid)
            {
                return View(registervm);
            }

            var user = await _usermanager.FindByEmailAsync(registervm.Email);
            if (user != null)
            {
                TempData["Error"] = "This Email Adress has already been taken";
                return View(registervm);
            }
            var newUser = new User()
            {
                UserName = registervm.Email,
                FirstName = registervm.FirstName,
                LastName = registervm.LastName,
                Email = registervm.Email,
                City = registervm.City,
                Zipcode = registervm.Zipcode,
                Phone = registervm.Phone,
                Address = registervm.Address,
                EmailVerification = false,
                Employee = false
            };
            var newUserResponse = await _usermanager.CreateAsync(newUser, registervm.Password);
            if (newUserResponse.Succeeded)
            {
                await _usermanager.AddToRoleAsync(newUser, UserRoles.Client);
                var result = await _signinmanager.PasswordSignInAsync(newUser, registervm.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Product");
                }
            }
            return View(registervm);
        }
        [Authorize(UserRoles.Admin)]
        public IActionResult CreateEmployee()
        {
            var response = new CreateEmployeeVM();
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeVM createemployeevm)
        {
            if (!ModelState.IsValid)
            {
                return View(createemployeevm);
            }

            var user = await _usermanager.FindByEmailAsync(createemployeevm.Email);
            if (user != null)
            {
                TempData["Error"] = "This Email Adress has already been taken";
                return View(createemployeevm);
            }
            var newUser = new User()
            {
                UserName = createemployeevm.Email,
                FirstName = createemployeevm.FirstName,
                LastName = createemployeevm.LastName,
                Email = createemployeevm.Email,
                City = createemployeevm.City,
                Zipcode = createemployeevm.Zipcode,
                Phone = createemployeevm.Phone,
                Address = createemployeevm.Address,
                EmailVerification = false,
                RegistrationDate = DateTime.Now,
                HireDate = DateTime.Now,
                Employee = true,
                IdJob = createemployeevm.IdJob,
                Salary = createemployeevm.Salary,
                IdManager = createemployeevm.IdManager

            };
            var newUserResponse = await _usermanager.CreateAsync(newUser, createemployeevm.Password);
            if (newUserResponse.Succeeded)
            {
                {
                    return RedirectToAction("Index", "Product");
                }

            }
            return View(createemployeevm);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signinmanager.SignOutAsync();
            return RedirectToAction("Index", "Product");
        }
        public async Task<IActionResult> Delete()
        {
            await _signinmanager.SignOutAsync();
            var user = await _usermanager.GetUserAsync(User);
            await _usermanager.DeleteAsync(user);
            return RedirectToAction("Index", "Product");
        }
        public async Task<IActionResult> DeleteAccount(string id)
        {
            var user = await _usermanager.FindByIdAsync(id);
            try
            {
                await _usermanager.DeleteAsync(user);
            }
            catch
            {
                var users = _usermanager.Users;
                foreach (var c in users)
                {
                    if (c.IdManager==user.Id)
                    {
                        c.IdManager = null;
                    }
                }
                var orders = _context.Orders;
                foreach (var order in orders)
                {
                    if (order.IdUser==user.Id)
                    {
                        order.IdUser = null;
                    }
                }
                await _context.SaveChangesAsync();
                await _usermanager.DeleteAsync(user);
            }
            return RedirectToAction("Users", "Account");
        }
        public async Task<IActionResult> MyAccount()
        {
            var user = await _usermanager.GetUserAsync(User);

            return View(user);
        }
        public async Task<IActionResult> Conge()
        {
            var user = await _usermanager.GetUserAsync(User);
            user.conge = true;
            return View();
        }
        public async Task<IActionResult> Edit(string Id)
        {
            var user =_usermanager.FindByIdAsync(Id).Result;
            var model = new EditVM()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                City=user.City,
                Zipcode=user.Zipcode,
                Phone = user.Phone,
                Address = user.Address
            };
            return View(Id,model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string id,EditVM editvm)
        {
            var dbuser = await _usermanager.FindByIdAsync(id);

            if (dbuser != null)
            {
                dbuser.FirstName = editvm.FirstName;
                dbuser.LastName = editvm.LastName;
                dbuser.City = editvm.City;
                dbuser.Zipcode = editvm.Zipcode;
                dbuser.Address=editvm.Address;
                dbuser.Phone = editvm.Phone;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Product");
        }
    }
}