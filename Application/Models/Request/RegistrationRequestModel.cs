using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class RegistrationRequestModel
    {
        public string email { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string cellphone { get; set; }
        public string gender { get; set; }
        public string birthday { get; set; }
    }
}
