using MyWay.AppLayer;
using MyWay.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWay.DataLayer.EntityManager
{
    public class UserManager : AppDataManagerBase
    {
        public List<User> myUserList = new List<User>();

        #region GetAll Method

        public IEnumerable<User> GetAll()
            => GetRecords<User>("SELECT * FROM [dbo].[User]");

        #endregion

        #region Get Method
        public virtual User Get(int userId)
        {
            // Create SQL to get a single row
            SQL = "SELECT * FROM [dbo].[User] WHERE User_ID = @User_ID";

            // Create parameters for counting
            var parameters = new List<IDbDataParameter> 
            {
            // Add parameters for CommandObject
            CreateParameter("User_ID", (object)userId, false)
            };

            // Submit SQL to get a single row from a table
            return GetRecord<User>(SQL, parameters.ToArray());
        }
        #endregion
        #region Insert Method
        public virtual int Insert(User entity)
        {
            // Reset all properties
            Reset();

            // Attempt to validate the data, a ValidationException is thrown if validation rules fail
            Validate<User>(entity);

            // Create SQL to INSERT a row using dynamic SQL
            SQL = "INSERT INTO [dbo].[User](UserFirstName, UserLastName, UserDateOfBirth, UserEmail) ";
            SQL += " VALUES(@User_First_Name, @User_Last_Name, @User_Date_Of_Birth, @User_Email)";

            // Create standard insert parameters
            BuildInsertUpdateParameters(entity);

            // Execute Query and set the IDENTITY property
            RowsAffected = ExecuteNonQuery(true);

            // Get the primary key generated from the SQL Server IDENTITY
            entity.UserId = GetIdentityValue<int>(-1);

            return RowsAffected;
        }
        #endregion
        #region Update Method
        public virtual int Update(User entity)
        {
            // Reset all properties
            Reset();

            // Attempt to validate the data, a ValidationException is thrown if validation rules fail
            Validate<User>(entity);

            // Create SQL to INSERT a row using dynamic SQL
            SQL = "UPDATE [dbo].[User] SET UserFirstName = @User_First_Name, UserLastName = @User_Last_Name, UserDateOfBirth = @User_Date_Of_Birth, UserEmail = @User_Email ";
            SQL += " WHERE UserId = @User_Id";

            // Create standard insert parameters
            BuildInsertUpdateParameters(entity);

            // Execute Query and set the IDENTITY property
            RowsAffected = ExecuteNonQuery(true);

            // Get the primary key generated from the SQL Server IDENTITY
            entity.UserId = GetIdentityValue<int>(-1);

            return RowsAffected;
        }
        #endregion
        #region Delete Method
        public virtual int Delete(User entity)
        {
            // Reset all properties
            Reset();

            // Create SQL to DELETE a row using dynamic SQL
            SQL = "DELETE FROM [dbo].[User] WHERE UserId = @UserId";

            // Add primary parameter to CommandObject
            AddParameter("@UserId", (object)entity.UserId, false);

            // Execute Query and set RowsAffected
            return ExecuteNonQuery();
        }
        #endregion
        /*
         public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public DateTime? UserDateOfBirth { get; set; }
        public string UserEmail { get; set; }
         */

        #region BuildInsertUpdateParameters Method
        protected virtual void BuildInsertUpdateParameters(User entity)
        {
            // Add parameters to CommandObject
            AddParameter("User_First_Name", (object)entity.UserFirstName, false);
            AddParameter("User_Last_Name", (object)entity.UserLastName, false);
            AddParameter("User_Date_Of_Birth", DateTime.Now, false);
            AddParameter("User_Email", (object)entity.UserEmail, false);
        }
        #endregion
    }
}
