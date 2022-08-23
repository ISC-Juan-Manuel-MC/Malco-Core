using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Domain.Models.Security
{
    public class ContractSeason : BasicModel
    {
        public ContractSeason() : base()
        {
        }

        public Guid ContractSeasonID { get; set; } = Guid.Empty;
        public Guid ContractID { get; set; } = Guid.Empty;
        public DateOnly StartDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly EndDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public bool IsEnabled { get; set; } = false;
    }
}
