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
        protected Guid ActivityLogID { get; set; } = Guid.Empty;

        public ActivityLog? ActivityLog { get; set; } = null;


        //public ActivityLog? ActivityLog 
        //{ 
        //    get => ActivityLog; 
        //    set
        //    {
        //        if(value != ActivityLog)
        //        {
        //            if (value != null)
        //            {
        //                ActivityLogID = value.ActivityLogID;
        //            }
        //            else
        //            {
        //                ActivityLogID = Guid.Empty;
        //            }
        //            ActivityLog = value;
        //        }
        //    }
        //}

        public BasicModel()
        {
            this.ActivityLog = new ActivityLog();
        }
    }
}
