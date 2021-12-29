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
    public class CheckinsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private CheckinsEntity checkinEntity;
        public CheckinsController(IConfiguration configuration)
        {
            _configuration = configuration;
            checkinEntity = new CheckinsEntity(configuration);
        }

        [HttpGet]
        public JsonResult Get()
        {
            var checkins = this.checkinEntity.GetAll();
            return new JsonResult(checkins);
        }

        [HttpPost]
        public JsonResult Post(Checkins checkin)
        {

            this.checkinEntity.Post(checkin);
            return new JsonResult("Posted Successfully");
        }

        [HttpPut]
        public JsonResult Put(Checkins checkin)
        {
            this.checkinEntity.Put(checkin);
            return new JsonResult("Posted Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            this.checkinEntity.Delete(id);
            return new JsonResult("Posted Successfully");
        }
    }
}
