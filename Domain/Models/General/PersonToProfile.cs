﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.Domain.Models.General
{
    public class PersonToProfile
    {
        public Guid PersonID { get; set; } = Guid.Empty;
        public string ProfileID { get; set; } = String.Empty;

        #region FKs
        public virtual Person? FKPerson { get; set; }
        public virtual Profile? FKProfile { get; set; }
        #endregion

    }
}
