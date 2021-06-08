using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.Models
{
    [Keyless]
    public class ViewModelRoleWithOther
    {
        //public Cemp Cemps { get; set; }
        public MenuModels MenuModels { get; set; }

        public Roles Roles { get; set; }
        public MainMenue MainMenue { get; set; }
    }
}
