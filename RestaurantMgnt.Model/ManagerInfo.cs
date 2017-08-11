using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMgnt.Model
{
    public partial class ManagerInfo
    {
        public int ManagerId { get; set; }
        public string ManagerName { get; set; }
        public string ManagerPassword { get; set; }
        public int ManagerType { get; set; }
    }
}
