using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Threading;
//using System.Web.f;
using System.Collections;
using System.IO;
using Lucene.Net.Search;
using Lucene.Net.QueryParsers;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using CustomerSupport;
//using CustomerSupport.Data;
//using CustomerSupport.Utility;

/// <summary>
/// Summary description for Search
/// </summary>
namespace CustomerSupport.Entity
{
    public class Search
    {
        public string sIndexPath;
        public bool created;

        public Search()
        {
            //
            // TODO: Add constructor logic here
            //
            CustomerSupportPage objPage = new CustomerSupportPage();

            sIndexPath = CustomerSupport.Utility.SysResource.SearchDirectory + objPage.GetState(CustomerSupportPage.AccountID);

            
            if (Directory.Exists(sIndexPath) != true)
            {
                Directory.CreateDirectory(sIndexPath);
            }
        }
        public void IsIndexExists(out bool created)
        {
            
            created = false;
            created = IndexReader.IndexExists(sIndexPath);
            //if (!IndexReader.IndexExists(sIndexPath))
            //{
            //    IndexWriter writer = new IndexWriter(sIndexPath,
            //        new StandardAnalyzer(), true);
            //    created = true;
            //    writer.Close();
            //}
        }
        public string SearchIndex(string SearchText, int PageCount, int itemsPerPage)
        {
            IndexSearcher searcher;
            QueryParser oParser;
            //string NewSearch = BuildSearchString(SearchText);
            string NewSearch;
            string sHeader;
            string sSearchQuery;
            StringBuilder sb1 = new StringBuilder();
            Hits oHitColl;
            //string[] ValuesArray;
            DataTable objSearchResult = new DataTable();
            //DataRow objResultRow;
            DataSet objSearchResultDataSet = new DataSet();
            int RowCount = 0;
            //First Search in Title, StoreName
            searcher = new IndexSearcher(sIndexPath);
            oParser = new QueryParser("Conversation_Title", new StandardAnalyzer());
            string strResultTable;

            NewSearch = SearchText;
            sHeader = " OR (Conversation_Desc:" + NewSearch + ")";
            sSearchQuery = "( " + NewSearch + sHeader + ")";
            oHitColl = searcher.Search(oParser.Parse(sSearchQuery));
            strResultTable = "";
            int i = 0;
            if (oHitColl.Length() <= 1)
            {
                strResultTable += "<tr><td colspan=2> no results found  <div style=\"float:right;height:15px;width:50px;background:color:#efefef\"><a onclick=\"javascript:document.getElementById('divSearchResults').style.display='none';\"> close</a></div> </td> </tr>";
            }
            else
            {
                for ( i = 0; i < oHitColl.Length(); i++)
                {
                    Document oDoc = oHitColl.Doc(i);
                    RowCount = i;
                    if (RowCount > PageCount * itemsPerPage && RowCount < (PageCount * itemsPerPage) + itemsPerPage)
                    {
                        //http://localhost/customersupport/Leads.aspx?Action=E&ID=d1bd25d1-daee-4493-8d13-314d4de6de4c
                        strResultTable += "<tr><td><a href='" + CustomerSupport.Utility.SysResource.HomePath + "ch/" + oDoc.Get("Conversation_Number") + "/" + oDoc.Get("Conversation_Title") + "'><b>" + oDoc.Get("Conversation_Title") + "</b></a></td><td>" + "</td><td>" + (oDoc.Get("Conversation_Desc").Length > 100 ? oDoc.Get("Conversation_Desc").Remove(99) : oDoc.Get("Conversation_Desc")) + "</td><td>" + oDoc.Get("ItemUnitPrice") + "," + oDoc.Get("OfferPrice") + "</td><td>" + "</td></true>";

                    }
                }
                strResultTable += "<tr><td colspan=2>"+ i.ToString() +" topics found <div style=\"float:right;height:15px;width:50px;background:color:#efefef\"><a onclick=\"javascript:document.getElementById('divSearchResults').style.display='none';\"> close</a></div> </td> </tr>";
            
            }
            searcher.Close();





            //objSearchResultDataSet.Tables.Add(objSearchResult);
            // strResultTable += "</table>";
            return strResultTable;
        }

        public string SearchIndexInternal(string SearchText, int PageCount, int itemsPerPage)
        {
            IndexSearcher searcher;
            QueryParser oParser;
            //string NewSearch = BuildSearchString(SearchText);
            string NewSearch;
            string sHeader;
            string sSearchQuery;
            StringBuilder sb1 = new StringBuilder();
            Hits oHitColl;
            //string[] ValuesArray;
            DataTable objSearchResult = new DataTable();
            //DataRow objResultRow;
            DataSet objSearchResultDataSet = new DataSet();
            int RowCount = 0;
            //First Search in Title, StoreName
            searcher = new IndexSearcher(sIndexPath);
            oParser = new QueryParser("Conversation_Title", new StandardAnalyzer());
            string strResultTable;

            NewSearch = SearchText;
            sHeader = " OR (Conversation_Desc:" + NewSearch + ")";
            sSearchQuery = "( " + NewSearch + sHeader + ")";
            oHitColl = searcher.Search(oParser.Parse(sSearchQuery));
            strResultTable = "";

            if (oHitColl.Length() == 0)
            {
                strResultTable += "<tr><td colspan=2> no results found </tr>";
            }
            for (int i = 0; i < oHitColl.Length(); i++)
            {
                Document oDoc = oHitColl.Doc(i);
                RowCount = i;
                if (RowCount > PageCount * itemsPerPage && RowCount < (PageCount * itemsPerPage) + itemsPerPage)
                {
                    //http://localhost/customersupport/Leads.aspx?Action=E&ID=d1bd25d1-daee-4493-8d13-314d4de6de4c
                    strResultTable += "<tr><td><a href='" + CustomerSupport.Utility.SysResource.HomePath + "manage/Leads.aspx?Action=E&ID=" + oDoc.Get("Conversation_ID") + "'><b>" + oDoc.Get("Conversation_Title") + "</b></a></td><td>" + "</td></tr><tr><td>" + (oDoc.Get("Conversation_Desc").Length > 100 ? oDoc.Get("Conversation_Desc").Remove(99) : oDoc.Get("Conversation_Desc")) + "</td><td></tr>";

                }

               
            }
            searcher.Close();





            //objSearchResultDataSet.Tables.Add(objSearchResult);
            // strResultTable += "</table>";
            return strResultTable;
        }



        public void CreateIndex()
        {
            IndexWriter writer = new IndexWriter(sIndexPath, new StandardAnalyzer(), true);
            CustomerSupportPage objPage = new CustomerSupportPage();
            DataSet objDataForIndex;
            objDataForIndex = GetDataForIndex(objPage.GetState(CustomerSupportPage.AccountID));
            int i;
            if (objDataForIndex.Tables[0].Rows.Count > 0)
            {
                for (i = 0; i < objDataForIndex.Tables[0].Rows.Count; i++)
                {
                    IndexDocument(ref writer,
                        objDataForIndex.Tables[0].Rows[i]["Conversation_ID"].ToString(),
                        objDataForIndex.Tables[0].Rows[i]["Conversation_Title"].ToString(),
                        objDataForIndex.Tables[0].Rows[i]["Conversation_Desc"].ToString(),
                        objDataForIndex.Tables[0].Rows[i]["Conversation_Status"].ToString(),
                        objDataForIndex.Tables[0].Rows[i]["Conversation_Severity"].ToString(),
                        objDataForIndex.Tables[0].Rows[i]["Conversation_Number"].ToString(),
                        objDataForIndex.Tables[0].Rows[i]["Is_Public"].ToString(),
                        objDataForIndex.Tables[0].Rows[i]["Reply_Message"].ToString());

                }
            }

            writer.Optimize();
            writer.Close();

        }
        delegate string MethodDelegate();

        private void IndexDocument(ref IndexWriter writer, string sConversationID, string sConversationTitle, string sConversationDesc, string sConversationStatus, string sConversationSeverity, string sConversationNumber, string sIsPublic, string sConversationReplyMessage)
        {
            Document doc = new Document();

            doc.Add(new Field("Conversation_ID", sConversationID, Field.Store.YES, Field.Index.TOKENIZED));
            doc.Add(new Field("Conversation_Title", sConversationTitle, Field.Store.YES, Field.Index.UN_TOKENIZED));
            doc.Add(new Field("Conversation_Desc", sConversationDesc, Field.Store.YES, Field.Index.TOKENIZED));
            doc.Add(new Field("Conversation_Status", sConversationStatus, Field.Store.YES, Field.Index.TOKENIZED));
            doc.Add(new Field("Conversation_Severity", sConversationSeverity, Field.Store.YES, Field.Index.TOKENIZED));
            doc.Add(new Field("Conversation_Number", sConversationNumber, Field.Store.YES, Field.Index.TOKENIZED));
            doc.Add(new Field("Is_Public", sIsPublic, Field.Store.YES, Field.Index.TOKENIZED));
            doc.Add(new Field("Reply_Message", sConversationReplyMessage, Field.Store.YES, Field.Index.TOKENIZED));
            writer.AddDocument(doc);

        }

        public void CreateIndexCallBack()
        {
            //do nothing
        }


        public DataSet GetDataForIndex(string strAccountID)
        {
            CustomerSupport.Data.DatabaseManager objDataManager = new CustomerSupport.Data.DatabaseManager();
             System.Data.SqlClient.SqlParameter[] arrSQLParams = new System.Data.SqlClient.SqlParameter[1];

            //Method Logic
          
              
              
            try
            {
                arrSQLParams[0] = new SqlParameter("@Account_ID", strAccountID);

                return objDataManager.ExecuteStoredProcedureReturnVariablesAndRecords(CustomerSupport.Data.Procedure.SP_Get_Data_For_Index,
                    arrSQLParams);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
