using Microsoft.AspNetCore.Mvc;

namespace Dish_Discovery.Web.MVC.Controllers
{
    [Route("authors")]
    public class AuthorsController : Controller
    {
        [HttpGet("details")]
        public IActionResult Details(Guid id)
        {
            return this.Ok(id);
        }
    }
}
