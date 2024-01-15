using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Web.Http.Cors;

namespace simpleApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TokenIssuerController: ApiController
    {
        public string getToken(string username) {
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(System.Configuration.ConfigurationManager.AppSettings["secret_key"]));
            var credential = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256);

            var header = new JwtHeader(credential);

            var claims = new[] { new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, "Ram"), new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Role ,"Admin"), new System.Security.Claims.Claim(JwtRegisteredClaimNames.UniqueName, username) };

            var payload = new JwtPayload(
                issuer : System.Configuration.ConfigurationManager.AppSettings["issuer"],audience : System.Configuration.ConfigurationManager.AppSettings["aud"],claims:claims,notBefore:null,expires:DateTime.Now.AddMinutes(60),issuedAt:DateTime.Now
                );

            var token = new JwtSecurityToken(header, payload);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();


            return handler.WriteToken(token);
        }

        [HttpGet]
        public string Get() {
            return getToken("krishna");
        }
    }
}
