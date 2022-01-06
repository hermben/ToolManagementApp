using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ToolManagementApp.Models;
using ToolManagementApp.Entity;

namespace ToolManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubItemsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private SubItemsEntity subItemsEntity;
        public SubItemsController(IConfiguration configuration)
        {
            _configuration = configuration;
            subItemsEntity = new SubItemsEntity(configuration);
        }

        [HttpGet]
        public JsonResult Get()
        {
            var subItems = this.subItemsEntity.GetAll();
            return new JsonResult(subItems);
        }

        [HttpPost]
        public JsonResult Post(SubItems subitem)
        {
            this.subItemsEntity.Post(subitem);
            return new JsonResult("Posted Successfully");
        }

        [HttpPut]
        public JsonResult Put(SubItems subitem)
        {
            this.subItemsEntity.Put(subitem);
            return new JsonResult("Posted Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            this.subItemsEntity.Delete(id);
            return new JsonResult("Posted Successfully");
        }
    }
}
