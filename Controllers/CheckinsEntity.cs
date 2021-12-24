using Microsoft.Extensions.Configuration;
using ToolManagementApp.Entity;

namespace ToolManagementApp.Controllers
{
    internal class CheckinsEntity : ItemsEntity
    {
        public CheckinsEntity(IConfiguration configuration) : base(configuration)
        {
        }
    }
}