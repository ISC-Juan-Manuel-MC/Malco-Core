using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Security
{
    public class JWTModel
    {
        public Guid AppID { get; set; }
        public Guid OrganizationID { get; set; }
        public String ProfileID { get; set; } = String.Empty;

        public static JWTModel GetFakeModel()
        {
            return new JWTModel
            {
                OrganizationID = new Guid("c7a16dc2-a636-4470-853b-63b7eae217b3"),
                AppID = new Guid("eee7a126-1eeb-48d3-b965-6606fdeec701"),
                ProfileID = "jmaldonado@malco-corporate.com"
                /*
                    Person - 7f6c0aed - cf90 - 4557 - a0d0 - c509a1b57178
                    Activity - 572db106 - e5cc - 4abb - b081 - aa058c73bdce
                    view - 72a9746c - 2d7d - 479e-b598 - 0dae67830550
                */
            };


        }
    }
}
