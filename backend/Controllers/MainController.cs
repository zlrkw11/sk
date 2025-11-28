using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend.Data;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MainController : ControllerBase
    {
        private readonly ISKRepo _repository;

        public MainController(ISKRepo repository)
        {
            _repository = repository;
        }

        [HttpGet("items")]
        public IActionResult GetItems()
        {
            var items = _repository.GetAllItems();
            return Ok(items);
        }
    }
}