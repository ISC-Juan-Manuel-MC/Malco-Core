using MCC.Domain.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class BasicModel
    {
        protected Guid ActivityLogID { get; set; } = Guid.NewGuid();

        public ActivityLog ActivityLog 
        { 
            get => ActivityLog; 
            set
            {
                ActivityLog = value;
                if (ActivityLog != null)
                {
                    ActivityLogID = ActivityLog.ActivityLogID;
                } else
                {
                    ActivityLogID = Guid.Empty;
                }
            }
        }

        public BasicModel()
        {
            this.ActivityLog = new ActivityLog();
        }
    }
}
