using MyWay.AppLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWay.Model.Entitys
{
    public class Role : AppEntityBase
    {
        public int RoleId { get; set; } 
        public string RoleName { get; set; }
    }
}
