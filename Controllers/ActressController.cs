using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Actresses.Models;
namespace Actresses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActressesController : ControllerBase
    {
        Database db = new Database();
        Actress actress = new Actress();

        public List<object> Get()
        {
          return db.getActressData(actress);
        }
    }
}