using Common;
using Framework.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SSOManagement.Controllers
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }


    public class SecurityController : ApiController
    {

        [HttpPost]
        public string Post(LoginModel model)
        {
            string token = string.Empty;
            //authenticate 
  
            if (DB.Users.Any(p => p.UserName == model.UserName && p.Password == model.Password))
            {
                token = Guid.NewGuid().ToString();
                DB.Tokens.Add(token, DB.Permissions.First(p => p.UserName == model.UserName));
            }
            return token;
        }

        [HttpGet]
        public SecurityToken Get(string token)
        {
            var permission = DB.Tokens[token];
            return permission;
        }
    }


    public static class DB
    {
        public static List<UserDto> Users = new List<UserDto>();
        public static List<SecurityToken> Permissions = new List<SecurityToken>();
        public static Dictionary<string, SecurityToken> Tokens = new Dictionary<string, SecurityToken>();
        static DB()
        {
            Users.Add(new UserDto { UserName = "admin", Password = "123" });
            Users.Add(new UserDto { UserName = "guest", Password = "456" });

            Permissions.Add(new SecurityToken { UserName = "admin",Role="Admin", Operations = new int[] { Operations.RegisterCustomer, Operations.CreateAccount } });
            Permissions.Add(new SecurityToken { UserName = "guest", Role = "Guest", Operations = new int[] { Operations.RegisterCustomer } });
        }
    }

    public class UserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }


}
