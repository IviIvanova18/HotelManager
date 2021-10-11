using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotelReservationsManager.Data;
using Microsoft.AspNetCore.Identity;
using System;

namespace HotelReservationsManager.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly HotelReservationsManagerDbContext context;

        private readonly RoleManager<IdentityRole> roleManager;

        public HomeController(HotelReservationsManagerDbContext context, RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            //IdentityRole userRole = new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "User" };
            //IdentityRole adminRole = new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "Admin" };

            //await this.roleManager.CreateAsync(userRole);
            //await this.roleManager.CreateAsync(adminRole);


            if (this.User.Identity.IsAuthenticated)
            {
                //List<ProductHomeViewModel> models = await this.context.Products
                //    .Select(product => new ProductHomeViewModel
                //    {
                //        Id = product.Id,
                //        Name = product.Name,
                //        Price = product.Price,
                //        Description = product.Description
                //    })
                //    .ToListAsync();

                return this.View("HomeAdmin");
            }

            return View();
        }

    }
}
