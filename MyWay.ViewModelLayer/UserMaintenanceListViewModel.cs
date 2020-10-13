using Common.DataAdapter.Library;
using MyWay.DataLayer.EntityManager;
using MyWay.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWay.ViewModelLayer
{
    public class UserMaintenanceListViewModel : ViewModelAddEditDeleteBase
    {
        #region Fields

        private ObservableCollection<User> _users = new ObservableCollection<User>();
        private ObservableCollection<Role> _roles = new ObservableCollection<Role>();

        #endregion

        public ObservableCollection<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<Role> Roles
        {
            get
            {
                return _roles;
            }
            set
            {
                _roles = value;
                RaisePropertyChanged();
            }
        }

        public virtual void LoadUsers()
        {
            //SampleDbContext db = null;
            using (var mgr = new UserManager())
            {
                try
                {
                    AddToCollection(Users, mgr.GetAll());
                    RowsAffected = mgr.RowsAffected;
                    //ResultText = "Rows Affected: " + RowsAffected.ToString();
                }
                catch (Exception ex)
                {
                    PublishException(ex);
                }
            }
            using (var mgr = new RoleManager())
            {
                try
                {
                    AddToCollection(Roles, mgr.GetAll());
                    RowsAffected = mgr.RowsAffected;
                    //ResultText = "Rows Affected: " + RowsAffected.ToString();
                }
                catch (Exception ex)
                {
                    PublishException(ex);
                }
            }

        }

        /// <summary>
        /// Adds <paramref name="items"/> to a given <paramref name="collection"/>
        /// </summary>
        /// <typeparam name="T">Types of items</typeparam>
        /// <param name="collection">Collection to add to</param>
        /// <param name="items">Items to add</param>
        private static void AddToCollection<T>(ObservableCollection<T> collection, IEnumerable<T> items)
        {
            if (items is null || collection is null)
                return;

            foreach (var item in items)
                collection.Add(item);
        }
    }
}
