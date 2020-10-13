using MyWay.AppLayer;

namespace MyWay.Model.Entitys
{
    public class Account : AppEntityBase
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public string AccountPasswordSalt { get; set; }
        public string AccountPasswordHash { get; set; }
        public int UserFK { get; set; }  
    }
}
