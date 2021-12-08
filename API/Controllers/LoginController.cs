using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shared;

namespace API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TesteController : ControllerBase
    {
        private readonly ILogger<TesteController> _logger;

        public TesteController(ILogger<TesteController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "ALOUUUUU";
        }
    }

    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly User _user;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
            _user = new User
            {
                Username = "teste",
                Password = "teste"
            };
        }

        [HttpPost]
        public bool Login(User user)
        {
            return _user.Username == user.Username && _user.Password == user.Password;
        }
    }
}
