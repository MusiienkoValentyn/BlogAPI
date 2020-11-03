using System;
using BLL;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace TestTaskRestAPI.Authorization
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWTController : ControllerBase
    {
        private IJWTService _jwt;

        public JWTController(IJWTService jwt)
        {
            _jwt = jwt;
        }

        [HttpPost]
        public IActionResult Login([FromBody]UserDTO user)
        {

            var token = _jwt.Login(user);

            if(token==null||token==String.Empty)
            {
                return BadRequest(new { errorText = "Invalid UserName or password" });
            }

            return Ok(token);

        }


    }
}
