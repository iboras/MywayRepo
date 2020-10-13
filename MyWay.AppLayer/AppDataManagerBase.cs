using Common.DataAdapter.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWay.AppLayer
{
    public class AppDataManagerBase : SqlServerDataManagerBase
    {
        #region Constructor
        /// <summary>
        /// Pass in either a connection string, or the name in 
        /// the &lt;connectionStrings&gt; element that 
        /// contains the connection string.
        /// </summary>
        public AppDataManagerBase() : base("I3_MyWayDB") { }
        #endregion

        public override void AddStandardParameters()
        {
            base.AddStandardParameters();

            if (CommandObject.CommandType == CommandType.StoredProcedure)
            {
                // TODO: Add any standard parameters you have in your 
                //       stored procedures for this application

            }
        }

        public override void GetStandardOutputParameters()
        {
            base.GetStandardOutputParameters();

            if (CommandObject.CommandType == CommandType.StoredProcedure)
            {
                // TODO: Add any standard OUTPUT parameters you have in your 
                //       stored procedures for this application
            }
        }
    }
}
