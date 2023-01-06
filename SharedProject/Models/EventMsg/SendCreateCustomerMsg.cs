using Newtonsoft.Json;
using SharedProject.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedProject.Models.EventMsg
{
    public class SendCreateCustomerMsg : IServiceBusEventBase
    {

        [JsonIgnore]
        public string Topic => "Customer";

        [JsonIgnore]
        public string Subject => "CreateCustomer";

        public string Email { get; set; }

        public string Name { get; set; }

        public string ClassName { get; set; }

    }
}
