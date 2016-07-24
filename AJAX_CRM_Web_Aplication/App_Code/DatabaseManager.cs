#region DotNetNamespaces

using System;
using System.Data;
using System.Data.SqlClient;

#endregion

#region CustomNamespaces

#endregion

namespace CustomerSupport.Data
{
    //---------------------------------------------------------------------------------
    //Namespace Name:JustOnDemand.Data
    //Description:Contains all related functionality for data acess from all sources
    //Created On:
    //Usage Inuctions:
    //Edit History:
    //Change No.    Date    Version     ChangeBy    
    //---------------------------------------------------------------------------------

    public class DatabaseManager
    {
        //---------------------------------------------------------------------------------
        //Class Name:DatabaseManager
        //Description:Contains all related functionality for data acess from DatabaseManager only
        //Created On:
        //Usage Inuctions:
        //Edit History:
        //Change No.    Date    Version     ChangeBy    
        //---------------------------------------------------------------------------------
        private System.Data.SqlClient.SqlConnection GetDatabaseConnection()
        {
            //---------------------------------------------------------------------------------
            //Function Name:OpenDatabaseManagerConnection
            //Description:Opens a new DatabaseManager connection 
            //Created On:
            //Usage Inuctions:
            //Edit History:
            //Change No.    Date    Version     ChangeBy    
            //---------------------------------------------------------------------------------

            string Connectionstring;

            try
            {
                Connectionstring = CustomerSupport.Utility.SysResource.ConnString;
                if (Connectionstring == string.Empty || Connectionstring.Length == 0)
                {
                    throw new ArgumentException("Connection string Empty Or Unable to Fecth Connection string");
                }
                else
                {
                    SqlConnection myConnection = new SqlConnection(Connectionstring);
                    myConnection.Open();
                    return myConnection;

                }
            }
            catch
            {
                throw;
            }


        }

        public bool ExecuteStoredProcedureNoReturn(string ProcedureName,
                                                SqlParameter[] arrSQLParams)
        {
            //---------------------------------------------------------------------------------
            //Function Name:ExecuteStoredProcedureNoReturn
            //Description:
            //Created On:
            //Usage Inuctions:
            //Edit History:
            //Change No.    Date    Version     ChangeBy    
            //---------------------------------------------------------------------------------
            try
            {
                //SqlDataReader objSqlDataReader = null;
                int intResult = 0;


                //Create a Command Object
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Connection = GetDatabaseConnection();

                //Set Stored Procedure Name
                objCommand.CommandText = ProcedureName;


                // assign all parameters with its values
                for (int i = 0; i < arrSQLParams.Length; i++)
                {
                    objCommand.Parameters.Add(arrSQLParams[i]);
                }



                intResult = objCommand.ExecuteNonQuery();
                objCommand.Connection.Close();

                return true;
            }
            catch
            {

                throw;


            }
        }

        public string[] ExecuteStoredProcedureReturnVariables(string ProcedureName,
                                              SqlParameter[] arrSQLParams)
        {
            //---------------------------------------------------------------------------------
            //Function Name:ExecuteStoredProcedureNoReturn
            //Description:
            //Created On:
            //Usage Inuctions:
            //Edit History:
            //Change No.    Date    Version     ChangeBy    
            //---------------------------------------------------------------------------------
            string[] OutputVariables;
            int intNumberofOutputs = 0;
            int j = 0;

            try
            {
                //SqlDataReader objSqlDataReader = null;
                int intResult = 0;

                //Create a Command Object
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Connection = GetDatabaseConnection();

                //Set Stored Procedure Name
                objCommand.CommandText = ProcedureName;


                // assign all parameters with its values

                for (int i = 0; i < arrSQLParams.Length; i++)
                {
                    objCommand.Parameters.Add(arrSQLParams[i]);
                    if (objCommand.Parameters[i].Direction != ParameterDirection.Input)
                    {
                        intNumberofOutputs++;
                    }
                }

                intResult = objCommand.ExecuteNonQuery();
                objCommand.Connection.Close();

                OutputVariables = new string[intNumberofOutputs];

                for (int i = 0; i < arrSQLParams.Length; i++)
                {

                    if (objCommand.Parameters[i].Direction != ParameterDirection.Input)
                    {
                        OutputVariables[j] = objCommand.Parameters[i].Value.ToString();
                        j++;
                    }

                }
                return OutputVariables;
            }
            catch
            {

                throw;
            }
        }

        public DataSet ExecuteStoredProcedureReturnVariablesAndRecords(string ProcedureName,
                                      SqlParameter[] arrSQLParams)
        {
            //---------------------------------------------------------------------------------
            //Function Name:ExecuteStoredProcedureReturnVairablesAndRecords
            //Description:
            //Created On:
            //Usage Inuctions:
            //Edit History:
            //Change No.    Date    Version     ChangeBy    
            //---------------------------------------------------------------------------------
            SqlDataAdapter objDataAdapter;
            int intNumberofOutputs = 0;
            try
            {


                //Create a Command Object
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Connection = GetDatabaseConnection();

                //Set Stored Procedure Name
                objCommand.CommandText = ProcedureName;


                // assign all parameters with its values
                if (arrSQLParams != null)
                {
                    for (int i = 0; i < arrSQLParams.Length; i++)
                    {
                        objCommand.Parameters.Add(arrSQLParams[i]);
                        if (objCommand.Parameters[i].Direction != ParameterDirection.Input)
                        {
                            intNumberofOutputs++;
                        }
                    }
                }
                DataSet objDataSet = new DataSet();
                objDataAdapter = new SqlDataAdapter(objCommand);
                objDataAdapter.Fill(objDataSet);
                objCommand.Connection.Close();

                return objDataSet;
            }
            catch
            {

                throw;
            }


        }
        //Create On: 19/01/2007
        //Create By: Chintan Prajapati
        //this function actally returns both output parameter and dataset
        public DataSet ExecuteStoredProcedureReturnVariablesAndRecords1(string ProcedureName,
                                     ref SqlParameter[] arrSQLParams)
        {
            //---------------------------------------------------------------------------------
            //Function Name:ExecuteStoredProcedureReturnVairablesAndRecords
            //Description:
            //Created On:
            //Usage Inuctions:
            //Edit History:
            //Change No.    Date    Version     ChangeBy    
            //---------------------------------------------------------------------------------
            int intNumberofOutputs = 0;
            int j = 0;
            SqlDataAdapter objDataAdapter;
            try
            {

                //Create a Command Object
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Connection = GetDatabaseConnection();

                //Set Stored Procedure Name
                objCommand.CommandText = ProcedureName;


                // assign all parameters with its values
                if (arrSQLParams != null)
                {
                    for (int i = 0; i < arrSQLParams.Length; i++)
                    {
                        objCommand.Parameters.Add(arrSQLParams[i]);
                        if (objCommand.Parameters[i].Direction != ParameterDirection.Input)
                        {
                            intNumberofOutputs++;
                        }
                    }
                }
                DataSet objDataSet = new DataSet();
                objDataAdapter = new SqlDataAdapter(objCommand);
                objDataAdapter.Fill(objDataSet);
                objCommand.Connection.Close();

                for (j = 0; j < intNumberofOutputs; j++)
                {
                    if (objCommand.Parameters[j].Direction != ParameterDirection.Input)
                    {
                        arrSQLParams[j].Value = objCommand.Parameters[j].Value;
                    }
                }


                return objDataSet;
            }
            catch
            {

                throw;
            }
        }

        public string ExecuteScaler(string Query)
        {
            //---------------------------------------------------------------------------------
            //Function Name:ExecuteScaler
            //Description:
            //Created On:
            //Usage Inuctions:
            //Edit History:
            //Change No.    Date    Version     ChangeBy    
            //---------------------------------------------------------------------------------

            try
            {


                //Create a Command Object
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.Text;
                objCommand.Connection = GetDatabaseConnection();

                //Set Stored Procedure Name
                objCommand.CommandText = Query;
                object temp = objCommand.ExecuteScalar();
                if (temp != null)
                    return temp.ToString();
                else
                    return "";

            }
            catch
            {

                throw;
            }


        }

    }
}