using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using forrst_dotnet.Helpers.Enums;
using forrst_dotnet.Helpers;

namespace forrst_dotnet.Entities {
    public class Users : List<User> {

        public static User Find(int? id) {
            User user = new User();
            user.parms.Add("id", id.ToString());
            return (User)user.GetContent();
        }

        public static User Find(string username) {
            User user = new User();
            user.parms.Add("username", username);
            return (User)user.GetContent();
        }

    }

    public class User : EntityBase<User> {

        public User() {
            base.EndPoint = "http://api.forrst.com/api/v1/users/info";
        }
        
        public int id { get; set; }
        public string username { get; set; }
    }
}
