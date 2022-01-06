using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ToolManagementApp.Models;
using ToolManagementApp.Entity;

namespace ToolManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private ItemsEntity itemEntity;
        public ItemsController(IConfiguration configuration)
        {
            _configuration = configuration;
            itemEntity = new ItemsEntity(configuration);
        }

        [HttpGet]
        public JsonResult Get()
        {
            var items = this.itemEntity.GetAll();
            return new JsonResult(items);
        }

        [HttpPost]
        public JsonResult Post(Items item)
        {
            this.itemEntity.Post(item);
            return new JsonResult("Posted Successfully");
        }

        [HttpPut]
        public JsonResult Put(Items item)
        {
            this.itemEntity.Put(item);
            return new JsonResult("Posted Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            this.itemEntity.Delete(id);
            return new JsonResult("Posted Successfully");
        }
    }
}
