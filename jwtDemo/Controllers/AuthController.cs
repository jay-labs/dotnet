using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace jwtDemo.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("token")]
        public ActionResult GetToken()
        {
            //security key
            string securityKey = "This_is_sample_key_for_my_project_created_on_17thAug2019";

            //symetric security key
            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

            //signing credentials
            var signingCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256Signature);

            //claims
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role,"Administrator"));
            claims.Add(new Claim(ClaimTypes.Role,"Reader"));
            claims.Add(new Claim("our_custom_cliam","custom value"));
        
            //create token
            var token = new JwtSecurityToken(
                issuer: "jay",
                audience: "readers",
                expires: DateTime.Now.AddHours(1),
                signingCredentials: signingCredentials,
                claims: claims);
                
            //return token
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}