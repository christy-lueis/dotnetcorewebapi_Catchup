using CommonApiServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommonApiServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthentication _authentication { get; set; }
        public AuthenticationController(IAuthentication authentication)
        {
            _authentication = authentication;
        }
    }
}
