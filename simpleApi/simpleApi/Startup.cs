using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.BuilderProperties;
using Microsoft.Owin.Extensions;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Owin;

[assembly : OwinStartup(typeof(simpleApi.Startup))]

namespace simpleApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidAudience = System.Configuration.ConfigurationManager.AppSettings["aud"],
                        ValidIssuer = System.Configuration.ConfigurationManager.AppSettings["issuer"],
                        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(System.Configuration.ConfigurationManager.AppSettings["secret_key"])),
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true
                    }
                }
            );
            app.UseStageMarker(PipelineStage.Authenticate);
            
        }
    }

}