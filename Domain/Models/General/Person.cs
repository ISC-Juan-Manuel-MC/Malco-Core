using Domain.Models;
using MCC.Domain.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Domain.Models.General
{
    public class Person : BasicModel
    {
        public Person() : base()
        {
        }

        public Guid PersonID { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public PersonGender Gender { get; set; } = PersonGender.Other;
        public string Cellphone { get; set; } = String.Empty;
        public DateOnly Birthday { get; set; }
 

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <description>Female</description>
        /// </item>
        /// <item>
        /// <description>Male</description>
        /// </item>
        /// <item>
        /// <description>Other - When the user does not want to specify the gender.</description>
        /// </item>
        /// </list>
        /// </summary>
        public enum PersonGender
        {
            Female = 1,
            Male = 2,
            Other = 3
        }
    }
}
