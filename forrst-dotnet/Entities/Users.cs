using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace forrst_dotnet.Entities {
    public class Users {

        public static User Get(int? id) {
            return new User();
        }

    }

    public class User {
        public int ID { get; set; }
        public string UserName { get; set; }
    }
}
