using CreativeBox.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreativeBox.Data.BusinessLogic
{
    public class BaseBusinessManager
    {
        #region Properties
        /// <summary>
        /// Gets the DataAccessHelper for further database operations.
        /// </summary>
        public DataAccessHelper DataAccessHelper => new DataAccessHelper();

        #endregion
    }
}
