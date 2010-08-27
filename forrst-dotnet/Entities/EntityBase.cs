using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using forrst_dotnet.Helpers;
using forrst_dotnet.Helpers.Enums;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace forrst_dotnet.Entities {
    public abstract class EntityBase<ItemType> : IEntity where ItemType : EntityBase<ItemType> {
        public string EndPoint { get; set; }
        public Dictionary<string, string> parms = new Dictionary<string, string>();

        virtual public EntityBase<ItemType> GetContent() {
            //TODO: This needs to get objectified
            string json = HttpRequest.GetResponse("text/javascript", HttpMethod.GET, this.BuildUrl());
            JObject content = JObject.Parse(json);
            //This assumes that the class will always follow the resource naming
            string resource = this.GetType().Name.ToLower();

            JToken result = content["resp"][resource];
            return JsonConvert.DeserializeObject<ItemType>(result.ToString());
        }

        //TODO: Needs refactoring
        private string BuildUrl() {
			System.Text.StringBuilder sb = new StringBuilder();
            sb.Append(this.EndPoint);
            
            if (parms.Count > 0) {
                sb.Append("?");

                foreach (var pair in parms) {

                    sb.Append(pair.Key).Append("=").Append(pair.Value.UrlEncode());
                    if (parms.Count > 1) sb.Append("&");
                }
            }

			return sb.ToString();
		}


    }
}
