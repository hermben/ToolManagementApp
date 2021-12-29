using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ToolManagementApp.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using ToolManagementApp.Entity;

namespace ToolManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemTypesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        private ItemTypesEntity itemTypesEntity;

        public object ItemTypesEntity { get; private set; }

        public ItemTypesController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
            itemTypesEntity = new ItemTypesEntity(configuration);
        }

        [HttpGet]
        public JsonResult Get()
        {
            var ItemTypes = this.itemTypesEntity.GetAll();
            return new JsonResult(ItemTypes);
        }

        [HttpPost]
        public JsonResult Post(ItemTypes itemtyp)
        {
            this.itemTypesEntity.Post(itemtyp);
            return new JsonResult("Posted Successfully");
        }

        [HttpPut]
        public JsonResult Put(ItemTypes itemtype)
        {

            this.itemTypesEntity.Put(itemtype);
            return new JsonResult("Posted Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            this.itemTypesEntity.Delete(id);
            return new JsonResult("Posted Successfully");
        }
    }
}
