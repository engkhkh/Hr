using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hr.Models
{
    public class MenuModels
    {
        public int id { get; set; }
        //public string MainMenuName { get; set; }
        //public int SubMenuId { get; set; }
        public int MainMenuId { get; set; }
        public string SubMenuNamear { get; set; }
        public string SubMenuNameen { get; set; }
        
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public int RoleId { get; set; }
        //public string RoleName { get; set; }
        public string mmodule { get; set; }


    }
}
