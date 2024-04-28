using E_CommerceApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceApp.Controllers
{
    public class HomeController : Controller
    {
        [Route("order")]
        public IActionResult Index(Products product, Order order)
        {
            if (Request.Method == "POST")
            {
                if (ModelState.IsValid == false)
                {
                    string errors = string.Join("\n",
                    ModelState.Values.SelectMany(value =>
                    value.Errors).Select(err =>
                    err.ErrorMessage));

                    return BadRequest(errors);
                }
                Random random = new Random();
                order.OrderNo = random.Next(1, 1000000);
                return new JsonResult(order.OrderNo);
            }
            else 
            {
                return BadRequest("Request Method should be POST");
            }                        
            
        }
    }
}
