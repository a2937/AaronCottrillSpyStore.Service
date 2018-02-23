using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AaronCottrillSpyStore.DAL.Repos.Interfaces;
using AaronCottrillSpyStore.Models.ViewModels.Base;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AaronCottrillSpyStore.Service.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private ICategoryRepo Repo { get; set; }
        private IProductRepo ProductRepo { get; set; }

        public CategoryController(ICategoryRepo repo, IProductRepo productRepo)
        {
            Repo = repo;
            ProductRepo = productRepo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Repo.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = Repo.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Json(item);
        }

        [HttpGet("{categoryId}/products")]
        public IEnumerable<ProductAndCategoryBase> GetProductsForCategory(int categoryId)
            => ProductRepo.GetProductsForCategory(categoryId).ToList();
    }
}
