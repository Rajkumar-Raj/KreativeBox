using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;

namespace CreativeBox.Data.DataAccess
{
    public class DataAccessHelper
    {
        #region Local Variables
        KreativeBoxEntities _KreativeBoxEntities;
        // Pointer to an external unmanaged resource. 
        private IntPtr _handle;
        // Other managed resource this class uses. 
        private readonly Component _component = new Component();
        // Track whether Dispose has been called. 
        #endregion

        #region Properties
        /// <summary>
        /// Gets/Sets the SOAEntities Object
        /// </summary>
        public KreativeBoxEntities KreativeBoxEntities { get { return _KreativeBoxEntities; } set { _KreativeBoxEntities = value; } }
        #endregion

        #region Constructor & Destructor
        public DataAccessHelper(IntPtr handle)
        {
            _handle = handle;
        }

        /// <summary>
        /// Initialization of DataAccess from dynamic Database Connection String
        /// </summary>
        public DataAccessHelper()
        {
            const string providerName = "System.Data.SqlClient";
            var providerString = Convert.ToString(ConfigurationManager.AppSettings["KreativeBoxEntities"]);
            var entityBuilder = new EntityConnectionStringBuilder
            {
                Provider = providerName,
                ProviderConnectionString = providerString,
                Metadata = @"res://*/KreativeBoxDB.csdl|
                                res://*/KreativeBoxDB.ssdl|
                                res://*/KreativeBoxDB.msl"
            };
            _KreativeBoxEntities = new KreativeBoxEntities(entityBuilder.ToString());
        }

        #endregion
    }

    public partial class KreativeBoxEntities
    {
        public KreativeBoxEntities(string strConnection)
            : base(strConnection)
        {

        }

        public DataTable FilleTable(SqlCommand cmdFillTable)
        {
            try
            {
                var cnFillTable = new SqlConnection(Database.Connection.ConnectionString);
                cmdFillTable.Connection = cnFillTable;

                var adpFillTable = new SqlDataAdapter(cmdFillTable);

                var dtFillTable = new DataTable();
                adpFillTable.Fill(dtFillTable);

                return dtFillTable;
            }
            catch
            {
                return null;
            }
        }
    }
}
