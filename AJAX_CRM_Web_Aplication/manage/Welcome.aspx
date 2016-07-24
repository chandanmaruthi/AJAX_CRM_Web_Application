<%@ Page Language="C#" MasterPageFile="~/manage/Internal.master" AutoEventWireup="true"
    Buffer="false" CodeFile="Welcome.aspx.cs" Inherits="Welcome" Title="Welcome to CustomerSupport" %>

<%@ Register Src="~/Webcontrols/RecentlyViewed.ascx" TagName="RecentlyViewed" TagPrefix="uc2" %>
<%@ Register Src="~/Webcontrols/HeaderMenu.ascx" TagName="HeaderMenu" TagPrefix="uc1" %>
<asp:Content ContentPlaceHolderID="Header" runat="server">
    <uc1:HeaderMenu ID="HeaderMenu" SetTab="1" runat="server" ShowCorpMenu="True" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="Server">
    <div class="PageContainer">
        <div class="PageHeader">
            Welcome to CustomerSupport</div>
        <div style="width: 300px; background-color: Green; border: solid 1px #cccccc;" runat="server"
            id="divMessage" visible="false">
            <asp:Label runat="server" ID="lblMessage"></asp:Label>
        </div>
        <table cellpadding="10px" cellspacing="0px" border="0" align="left" width="750px">
            <tr>
                <td width="375px" align="left">
                    <div class="SectionHeading_Welcome">
                        Conversation Pipleline</div>
                    <div style="background-color: #FAFF93; width: 360px; padding: 3px; font-size: 15px;
                        font-weight: bold; color: #888888; line-height: 1.3em; float: left; margin-bottom: 15px;
                        text-align: center;display:<%= strUnQualifiedLead == "0" ? "none":"block" %>;">
                        You have
                        <%= strUnQualifiedLead %>
                        pending conversations
                    </div>
                    <br />
                    <div style="height: 20px; width: 360px; float: left; margin-bottom: 15px;">
                        <asp:Repeater ID="rptrLeadStatus" runat="server">
                            <ItemTemplate>
                            <div style="text-align:center;padding:2px; width:116px;height:15px;float:left; background-color: <%# Eval("Status_Name").ToString()== "Open" ? "#AEFF8C":"" %><%# Eval("Status_Name").ToString()== "InProgress" ? "#FFFF88":"" %><%# Eval("Status_Name").ToString()=="Closed" ? "#eeeeee":"" %>">
                                <a href="<%= CustomerSupport.Utility.SysResource.HomePath %>manage/ManageLeads.aspx?Lead_Status=<%# Eval("Status_ID") %>">
                                    <%# Eval("Status_Name") %>(<%# Eval("Conversation_Count")%>) </a></div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <asp:Repeater ID="rptrPipleLineSummary" runat="server">
                        <ItemTemplate>
                            <div style="width: 366px; float: left;">
                                <div style="width: 366px; float: left; height: 18px; margin-top: 2px;">
                                    
                                        <b>
                                            <%# Eval("Product_Name")%></b>
                                </div>
                                <div style="width: 366px; float: left; height: 20px;background-color:#F9F7ED;">
                                    <a href="<%= CustomerSupport.Utility.SysResource.HomePath %>manage/manageleads.aspx?Lead_Status=970FE4E1-7589-4E12-9DEA-097E831CE793&Product=<%# Eval("Product_ID")%>">
                                        <div style="padding: 2px; text-align: center; background-color: #AEFF8C; float: left;
                                            width: <%# int.Parse(Eval("Open_Conversation").ToString())!=0?(double.Parse(Eval("Open_Conversation").ToString())/double.Parse(Eval("Total_Conversation").ToString()))*350+30:30 %>px;
                                            height: 15px;">
                                            <%# Eval("Open_Conversation")%>
                                        </div>
                                    </a><a href="<%= CustomerSupport.Utility.SysResource.HomePath %>manage/manageleads.aspx?Lead_Status=8F0B440C-0895-473C-8D4C-577BFA44867B&Product=<%# Eval("Product_ID")%>">
                                        <div style="padding: 2px; text-align: center; background-color: #FFFF88; float: left;
                                            width: <%# int.Parse(Eval("Inprogress_Conversation").ToString())!=0?(double.Parse(Eval("Inprogress_Conversation").ToString())/double.Parse(Eval("Total_Conversation").ToString()))*350+30:30 %>px;
                                            height: 15px;">
                                            <%# Eval("Inprogress_Conversation")%>
                                        </div>
                                    </a><a href="<%= CustomerSupport.Utility.SysResource.HomePath %>manage/manageleads.aspx?Lead_Status=D8A852A8-D29F-4E55-B549-8F7B98E13EC9&Product=<%# Eval("Product_ID")%>">
                                        <div style="padding: 2px; text-align: center; background-color: #eeeeee; float: left;
                                            width: <%# int.Parse(Eval("Closed_Conversation").ToString())!=0?(double.Parse(Eval("Closed_Conversation").ToString())/double.Parse(Eval("Total_Conversation").ToString()))*350+30:30 %>px;
                                            height: 15px;">
                                            <%# Eval("Closed_Conversation")%>
                                        </div>
                                    </a>
                                    <%--<a href="<%= CustomerSupport.Utility.SysResource.HomePath %>manageleads.aspx?Lead_Status=D8A852A8-D29F-4E55-B549-8F7B98E13EC9&Product=<%# Eval("Product_ID")%>">
                                        <div style="padding: 2px; background-color: #7EC8FE; float: left; width: <%# int.Parse(Eval("Won_Leads").ToString())!=0?(double.Parse(Eval("Won_Leads").ToString())/double.Parse(Eval("Total_Leads").ToString()))*350:10 %>px;
                                            height: 15px;">
                                            <%# Eval("Won_Leads")%>
                                        </div>
                                    </a>--%>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td style="height: 50px;">
                                <div class="DateBox">
                                    <div class="MonthPart">
                                        <%= DateTime.Now.ToString("MMM")%>
                                    </div>
                                    <div class="DatePart">
                                        <%= DateTime.Now.ToString("dd")%>
                                    </div>
                                </div>
                                <div class="SectionHeading_Welcome" style="margin-left: 15px; float: left;">
                                    Todays Tasks
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Repeater ID="rptrTasks" runat="server">
                                    <ItemTemplate>
                                        <div style="width: 300px; height: 20px; float: left; padding: 2px;">
                                            <div style="width: 56px; height: 15px; font-size: 12px; float: left; text-align: center;
                                                padding: 2px; vertical-align: middle; background-color: <%# Eval("Status_Name").ToString()== "Open" ? "#AEFF8C":"" %><%# Eval("Status_Name").ToString()== "InProgress" ? "#FFFF88":"" %><%# Eval("Status_Name").ToString()=="Closed" ? "#eeeeee":"" %>" >
                                                #<%# Eval("Conversation_Number") %>
                                                
                                            </div>
                                            <div style="width: 235px; height: 15px; float: left;padding-left:5px;overflow:hidden;">
                                                <a style="text-decoration: underline;" href="<%= CustomerSupport.Utility.SysResource.HomePath %>manage/Leads.aspx?Action=E&ID=<%# Eval("Conversation_ID") %>">
                                                    <%# Eval("Conversation_Title") %></a>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="375px" align="left">
                    <table width="300px">
                    <tr><td> <div class="SectionHeading_Welcome" style="margin-left: 15px; float: left;">
                                    Where do we stand
                                </div></td></tr>
                    <tr><td>
                   
                    </td></tr>
                    </table>
                      <table width="360px">
                    <tr><td> <div class="SectionHeading_Welcome" style="margin-left: 15px; float: left;">
                                    Account Setup
                                </div></td></tr>
                    <tr><td width="360px">
                    <div style="width:360px;float:left;"><div style="width:100px;float:left;"> Categories: <%= strCategories %>, &nbsp;&nbsp;&nbsp;</div><%= strCategories == "0" ? "<div style='width:150px;height:15px;background-color:#FFF1B5;float:left;'>Setup Categories Now</div>" : ""%></div>
                     <div style="width:360px;float:left;"><div style="width:100px;float:left;">Product : <%= strProducts %>&nbsp;&nbsp;&nbsp;</div><%= strProducts == "0" ? "<div style='width:150px;height:15px;background-color:#FFF1B5;float:left;'>Setup Products Now</div>" : ""%></div>
                    
                     <div style="width:360px;float:left;"><div style="width:100px;float:left;">Branding : <%= strBranding %>&nbsp;&nbsp;&nbsp;</div><%= strBranding == "0" ? "<div style='width:150px;height:15px;background-color:#FFF1B5;float:left;'>Customize Branding Now</div>" : ""%></div>
                    
                    </td></tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div class="LeftContainer">
    <div class="PageFilterContainer">
    <div class="PageFilterBox" style="border-right: 0px;">
        <div class="PageFilterHeader" style="background-color: #f5f5f5;">
           <b>Search Conversations</b> </div>
        <div class="PageFilterContent">
        <div style="width:190px;float:left;height:20px;">
        <div style="widows:160px;float:left;height:20px;">
            <input type=text ID="txtSearch" MaxLength="150" Style="width: 160px" onchange="javascript:stringval =AjaxSearch_Params(document.getElementById('txtSearch').value);ajaxpack.postAjaxRequest('<%= CustomerSupport.Utility.SysResource.HomePath %>/manage/InternalSearchResults.aspx', stringval, AjaxSearch, 'txt');return false;" />
            </div>
             <div class="WaitBox" id="divWaitSearch" style="display: none;">
                        </div>
                        </div>
                        <div style="width:180px;position:relative;background-color:#ffffff;border:solid 1px #cccccc;float:left;" id="divSearchResults">
                        
                        </div>
                        
        </div>
    </div></div>
    </div>
    <script type="text/javascript" >
    function AjaxSearch_Params(SearchString) {
        document.getElementById('divWaitSearch').style.display = 'block';
        var poststr = "st=" + encodeURI(SearchString) + "&PageIndex=0";
        return poststr;
    }

    //Step 2: Define a "callback" function to process the data returned by the Ajax request:
    function AjaxSearch() {
        var myajax = ajaxpack.ajaxobj
        var myfiletype = ajaxpack.filetype
        if (myajax.readyState == 4) {
            //if request of file completed
            if (myajax.status == 200 || window.location.href.indexOf("http") == -1) { //if request was successful or running script locally
                if (myfiletype == "txt") {

                    if (myajax.responseText.substring(0, 5) == "ERROR") {
                        document.getElementById('divErrorBox').innerHTML = myajax.responseText;
                        document.getElementById('divErrorBox').style.display = 'block';
                        document.getElementById('divErrorBox').className = 'MessageBox_Warning';

                    }
                    else {
                        
                        document.getElementById('divSearchResults').innerHTML = myajax.responseText;
                        document.getElementById('divWaitSearch').style.display = 'none';

                    }

                }
                else {
                    document.getElementById('divSearchResults').innerHTML = myajax.responseText;
                }
            }
            else alert('problem');
        }
    }
</script>
</asp:Content>
