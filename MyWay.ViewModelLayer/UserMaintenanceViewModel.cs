using MyWay.AppLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWay.ViewModelLayer
{
    public class UserMaintenanceViewModel : UserMaintenanceDetailViewModel
    {
        public UserMaintenanceViewModel() : base()
        {
            DisplayStatusMessage("Maintain Users");
        }
    }
}
