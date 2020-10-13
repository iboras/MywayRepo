using MyWay.AppLayer;

namespace MyWay.Model.Entitys
{
    public class MembershipType : AppEntityBase
    {
        public int MembershipTypeId { get; set; }
        public string MembershipTypeName { get; set; }
        public double MembershipTypePrice { get; set; }
        public int MembershipTypeDurationPerWeek { get; set; }
        public int MembershipTypeDurationPerMonth { get; set; }
    }
}
