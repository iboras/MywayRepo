using MyWay.AppLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWay.Model.Entitys
{
    public class User : AppEntityBase
    {
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public DateTime? UserDateOfBirth { get; set; }
        public string UserEmail { get; set; }
        /// <summary>
        /// Foreign key for ROLE table    
        /// </summary>
        public int RoleFK { get; set; }
    }
}
