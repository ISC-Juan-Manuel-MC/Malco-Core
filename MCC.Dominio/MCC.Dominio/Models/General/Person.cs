using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Dominio.Models.General
{
    public class Person
    {
        public Guid PersonID { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = String.Empty;
        public string? SecondName { get; set; } = null;
        public string PatherLastName { get; set; } = String.Empty;
        public string MotherLastName { get; set; } = String.Empty;
        public DateOnly Birthday { get; set; }
        public Guid ActivityLogID { get; set; } = Guid.Empty;

    }
}
