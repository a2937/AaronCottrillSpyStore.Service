using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AaronCottrillSpyStore.DAL.Repos.Interfaces;
using AaronCottrillSpyStore.Models.Entities;
using AaronCottrillSpyStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AaronCottrillSpyStore.Service.Controllers
{
    [Route("api/[controller]/{customerId}")]
    public class OrdersController : Controller
    {
        private IOrderRepo Repo { get; set; }
        public OrdersController(IOrderRepo repo)
        {
            Repo = repo;
        }

        public IActionResult GetOrderHistory(int customerId)
        {
            IEnumerable<Order> orderWithTotals = Repo.GetOrderHistory(customerId);
            return orderWithTotals == null ? (IActionResult)NotFound() : Json(orderWithTotals);
        }

        [HttpGet("{orderId}", Name = "GetOrderDetails")]
        public IActionResult GetOrderForCustomer(int customerId, int orderId)
        {
            OrderWithDetailsAndProductInfo orderWithDetails = Repo.GetOneWithDetails(customerId, orderId);
            return orderWithDetails == null ? (IActionResult)NotFound() : Json(orderWithDetails);
        }
    }
}
