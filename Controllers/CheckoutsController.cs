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
using ToolManagementApp.Entity;

namespace ToolManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private CheckoutsEntity checkoutEntity;
        public CheckoutsController(IConfiguration configuration)
        {
            _configuration = configuration;
            checkoutEntity = new CheckoutsEntity(configuration);
        }

        [HttpGet]
        public JsonResult Get()
        {
            var checkouts = this.checkoutEntity.GetAll();

            return new JsonResult(checkouts);
        }

        [HttpPost]
        public JsonResult Post(Checkouts checkout)
        {
             this.checkoutEntity.Post(checkout);

            return new JsonResult("Posted Successfully");
        }

        [HttpPut]
        public JsonResult Put(Checkouts checkout)
        {
            this.checkoutEntity.Put(checkout);

            return new JsonResult("Posted Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {                 
            this.checkoutEntity.Delete(id);

            return new JsonResult("Posted Successfully");
        }
    }
}
