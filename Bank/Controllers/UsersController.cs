using Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.DTOs;
using Service.Interface;

namespace Bank.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        private readonly BankDbContext dbContext;
        public UsersController(IUserService userService, BankDbContext dbContext)
        {
            this.userService = userService;
            this.dbContext = dbContext;
        }
       
        public async Task<IActionResult> Index()
        {
            var users = await userService.GetAllUserAsync();
            return View(users);
        }
        public async Task<IActionResult> result()
        {
            return View("Create");
        }
        public async Task<IActionResult> Create(UserForCreationDto dto)
        {
            var createdUser = await userService.AddUserAsync(dto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(long id)
        {
            var deletedUser = await userService.DeleteUserAsync(user => user.Id == id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit()
        {
            return View();
        }
        public async Task<IActionResult> Update(long id,UserForCreationDto dto)
        {
            var updatedUser = await userService.UpdateUserAsync(id, dto);
            return RedirectToAction("Index");
        }
    }
}
