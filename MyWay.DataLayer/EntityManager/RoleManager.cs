using MyWay.AppLayer;
using MyWay.Model.Entitys;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MyWay.DataLayer.EntityManager
{
    public class RoleManager : AppDataManagerBase
    {
        public List<Role> myRoleList = new List<Role>();

        #region GetAll Method
        public ObservableCollection<Role> GetAll()
        {
            myRoleList = GetRecords<Role>("SELECT * FROM [dbo].[Role]");
            ObservableCollection<Role> obsCollection = new ObservableCollection<Role>(myRoleList);
            // Submit SQL to get rows from a table
            return obsCollection;
        }
        #endregion
    }
}
