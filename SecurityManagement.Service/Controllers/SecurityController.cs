using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SecurityManagement.Service.Controllers
{
    public class SecurityController : ApiController
    {

        [HttpPost]
        public IHttpActionResult Post(string userName, string password)
        {
            string token = string.Empty;
            //authenticate 
            if (DB.Users.Any(p => p.UserName == userName && p.Password == password))
            {
                token = Guid.NewGuid().ToString();
                DB.Tokens.Add(token, DB.Permissions.First(p => p.UserName == userName));
            }
            return Ok<string>(token);
        }

        [HttpGet]
        public UserPermission Get(string token)
        {
            var permission = DB.Tokens[token];
            return permission;
        }
    }


    public static class DB
    {
        public static List<UserDto> Users = new List<UserDto>();
        public static List<UserPermission> Permissions = new List<UserPermission>();
        public static Dictionary<string, UserPermission> Tokens = new Dictionary<string, UserPermission>();
        static DB()
        {
            Users.Add(new UserDto { UserName = "admin", Password = "123" });
            Users.Add(new UserDto { UserName = "guest", Password = "456" });

            Permissions.Add(new UserPermission { UserName = "admin", Operations = new int[] { Operations.RegisterCustomer, Operations.CreateAccount } });
            Permissions.Add(new UserPermission { UserName = "guest", Operations = new int[] { Operations.RegisterCustomer } });
        }
    }

    public class UserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class UserPermission
    {
        public string UserName { get; set; }
        public int[] Operations { get; set; }
    }
}
