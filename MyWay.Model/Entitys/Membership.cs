using MyWay.AppLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWay.Model.Entitys
{
    public class Membership : AppEntityBase
    {
        public int MembershipId { get; set; }
        public int UserFk { get; set; } 
        public int MembershipTypeFk { get; set; } 
        public DateTime RegistrationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double MembershipFee { get; set; } 
        public double MembershipFeeTotal { get; set; }

    }
}
