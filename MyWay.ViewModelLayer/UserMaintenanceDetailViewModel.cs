using Common.DataAdapter.Library;
using MyWay.DataLayer.EntityManager;
using MyWay.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWay.ViewModelLayer
{
    public class UserMaintenanceDetailViewModel : UserMaintenanceListViewModel
    {
        private User _Entity = new User();
        private User _OriginalEntity = new User();

        public User Entity
        {
            get { return _Entity; }
            set
            {
                _Entity = value;
                RaisePropertyChanged("Entity");
            }
        }

        public override void LoadUsers()
        {
            // Load all users
            base.LoadUsers();

            // Set default user
            Entity = Users.FirstOrDefault();
        }

        public override void BeginEdit(bool isAddMode = false)
        {
            // Create a copy in case user wants undo their changes
            base.Clone<User>(Entity, _OriginalEntity);

            if (isAddMode)
            {
                Entity = new User();
            }

            base.BeginEdit(isAddMode);
        }

        public override void CancelEdit()
        {
            base.CancelEdit();

            // Clone Original to Entity object 
            // so each RaisePropertyChanged event fires
            base.Clone<User>(_OriginalEntity, Entity);
        }

        public override bool Save()
        {
            bool ret = false;

            using (UserManager mgr = new UserManager())
            {
                try
                {
                    if (IsAddMode)
                    {
                        RowsAffected = mgr.Insert(Entity);

                        if (RowsAffected > 0)
                        {
                            //ResultText = "Insert Successful. Rows Affected: " + RowsAffected.ToString() + Environment.NewLine + "ProductID: " + Entity.ProductID.ToString();
                            RaisePropertyChanged("Entity");
                        }
                    }
                    else
                    {
                        RowsAffected = mgr.Update(Entity);

                        if (RowsAffected > 0)
                        {
                            //ResultText = "Insert Successful. Rows Affected: " + RowsAffected.ToString() + Environment.NewLine + "ProductID: " + Entity.ProductID.ToString();
                            RaisePropertyChanged("Entity");
                        }
                    }
                }
                catch (ValidationException ex)
                {
                    ValidationFailed(ex);
                }
                catch (Exception ex)
                {
                    PublishException(ex);
                }
            }

            ret = true;

            // Set Original Entity equal to changed entity
            _OriginalEntity = Entity;

            // If new entity, add to view model Users collection
            if (IsAddMode)
            {
                Users.Add(Entity);

            }

            // Set mode back to normal display
            CancelEdit();

            return ret;
        }

        public override bool Delete()
        {
            bool ret = false;
            int index = 0;

            try
            {
                using (UserManager mgr = new UserManager())
                {
                    try
                    {
                        RowsAffected = mgr.Delete(Entity);

                        if (RowsAffected > 0)
                        {
                            ret = true;
                            // Remove from view model collection
                            Users.Remove(Entity);
                            // Calculate the selected entity after deleting
                            if (Users.Count > 0)
                            {
                                index++;
                                if (index > Users.Count)
                                {
                                    index = Users.Count - 1;
                                }
                                Entity = Users[index];
                            }
                            else
                            {
                                Entity = null;
                            }
                            // ResultText = "Delete Successful. Rows Affected: " + RowsAffected.ToString() + Environment.NewLine + "ProductID: " + Entity.ProductID.ToString() + Environment.NewLine + "Return_Value: " + Entity.RETURN_VALUE.ToString();
                            RaisePropertyChanged("Entity");
                        }
                    }
                    catch (Exception ex)
                    {
                        PublishException(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                PublishException(ex);
            }

            return ret;
        }
    }
}
