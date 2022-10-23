using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Domain.Models.Security
{
    public class Views : BasicModel
    {
        public Guid ViewID { get; set; } = Guid.Empty;
        public String Name { get; set; } = String.Empty;
        public bool IsEnabled { get; set; } = true;

        public const String
        REGISTRATION = "72a9746c-2d7d-479e-b598-0dae67830550",
        ORGANIZATION = "";

    }
}
