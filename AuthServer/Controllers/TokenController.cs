using AuthServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace AuthServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TokenController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        [HttpPost("[action]")]
        public string ValidateUser(ResourceOwnerPassword resourceOwnerPassword)
        {
            using (var client = new HttpClient())
            {
                var postData = new List<KeyValuePair<string, string>>();
                postData.Add(new KeyValuePair<string, string>("username", resourceOwnerPassword.username));
                postData.Add(new KeyValuePair<string, string>("password", resourceOwnerPassword.password));
                postData.Add(new KeyValuePair<string, string>("grant_type", "password"));
                postData.Add(new KeyValuePair<string, string>("client_id", resourceOwnerPassword.client_id));
                postData.Add(new KeyValuePair<string, string>("client_secret", resourceOwnerPassword.client_secret));

                HttpContent content = new FormUrlEncodedContent(postData);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

                var responseResult = client.PostAsync(_configuration["ResourceOwnerPassword"], content).Result;

                return responseResult.Content.ReadAsStringAsync().Result;
            }
        }
        [HttpPost("[action]")]
        public string CreateUser(RegisterUser registerUser)
        {
            using (var client = new HttpClient())
            {
                var postData = new List<KeyValuePair<string, string>>();
                postData.Add(new KeyValuePair<string, string>("email", registerUser.email));
                postData.Add(new KeyValuePair<string, string>("password", registerUser.password));
                postData.Add(new KeyValuePair<string, string>("client_id", registerUser.client_id));
                postData.Add(new KeyValuePair<string, string>("connection", _configuration["connection"]));

                HttpContent content = new FormUrlEncodedContent(postData);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

                var responseResult = client.PostAsync(_configuration["SignupUrl"], content).Result;

                return responseResult.Content.ReadAsStringAsync().Result;
            }
        }
    }
}