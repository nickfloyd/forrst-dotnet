using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using forrst_dotnet.Helpers.Enums;
using forrst_dotnet.Helpers;
using Newtonsoft.Json.Linq;

namespace forrst_dotnet.Entities {
    public class Users : List<User> {

        public static User Get(int? id) {
            string json = HttpRequest.GetResponse("text/javascript", HttpMethod.GET, "http://api.forrst.com/api/v1/users/info?id=" + id);
            User user = new User();
            JObject content = JObject.Parse(json);
            JToken result = content["resp"]["user"];
            return JsonConvert.DeserializeObject<User>(result.ToString());
        }

    }

    public class User {
        public int id { get; set; }
        public string username { get; set; }
    }
}
