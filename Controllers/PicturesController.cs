using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Actresses.Models;
namespace Actresses.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        Database db = new Database();
        public List<string> Get()
        {
            List<string> pictures = db.getPictures();
            return pictures;
        }
    }
}
