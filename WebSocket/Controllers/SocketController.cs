using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebSocket.Controllers
{
    [Produces("application/json")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class SocketController : ControllerBase
    {
        [HttpPost]
        public IActionResult Index(int id)
        {
            var response = id;
            return Ok(response);
        }
    }
}
