using Microsoft.AspNetCore.Mvc;

namespace BrightBuckle.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        [HttpGet]
        [Route("/getName")]
        public void GetName() {
        }
    }
}
