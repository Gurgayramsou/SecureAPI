using DbConnection.DAL;
using DbConnection.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DbConnection;
using Newtonsoft.Json;
using Microsoft.Ajax.Utilities;
using System.Web.Script.Serialization;
using System.Web.Http.Results;
using System.Web.Http.Cors;
using System.IdentityModel.Tokens.Jwt;



namespace simpleApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        public static StudentContext connection;
        public ValuesController()
        {
            connection = new StudentContext();
        }
        // GET api/values

        [Authorize(Roles ="poweruser")]
        [HttpGet]
        public JsonResult<string> Get()
        {
            //return JsonConvert.SerializeObject(ValuesController.connection.Students.ToList(),Formatting.Indented, new JsonSerializerSettings()
            //{
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //});

            var serializer = new JavaScriptSerializer();
            connection.Configuration.ProxyCreationEnabled = false;
            return Json(serializer.Serialize(connection.Students.ToList()));
            
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
