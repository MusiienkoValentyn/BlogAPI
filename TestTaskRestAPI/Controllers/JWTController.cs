using System;
using Microsoft.AspNetCore.Mvc;
using TestTaskRestAPI.Interfaces;

namespace TestTaskRestAPI.Authorization
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWTController : ControllerBase
    {
        private IJWT _jwt;

        public JWTController(IJWT jwt)
        {
            _jwt = jwt;
        }

        [HttpPost]
        public IActionResult Login([FromBody]LoginModel login)
        {

            var token = _jwt.Login(login.UserName,login.Password);

            if(token==null||token==String.Empty)
            {
                return BadRequest(new { errorText = "Invalid UserName or password" });
            }

            return Ok(token);

        }


    }
}
