using System;
using System.Data;
using System.Data.SqlClient;
using CustomerSupport.Data;
using CustomerSupport.Utility;

/// <summary>
/// Summary description for WidgetLayout
/// </summary>
namespace CustomerSupport.Data
{
    public class WidgetLayout
    {
        public WidgetLayout()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet GetWidgetLayouts()
        {

            //Define Objects
            CustomerSupport.Data.DatabaseManager objDataManager = new DatabaseManager();
            System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[0];
            DataSet ds;

            //Method Logic
            try
            {


                ds = objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords(Procedure.SP_GET_WIDGET_LAYOUT,
                     arrSQLParams);

                //intProductCount = int.Parse(arrSQLParams[2].Value.ToString());
                return ds;
            }
            catch
            {

                throw;
            }
        }
    }
}