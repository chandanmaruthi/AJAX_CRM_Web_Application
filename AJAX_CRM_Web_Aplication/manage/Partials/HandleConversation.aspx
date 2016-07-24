<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HandleConversation.aspx.cs" Inherits="Partials_HandleConversation" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LeadNotes</title>
</head>
<body>
    <asp:Panel ID="pnlNewLeadBox" runat="server" Visible="false">
        
        
    </asp:Panel>
    <asp:Panel ID="pnlReply" runat="server" Visible="false">
<asp:Repeater ID="rptrReplies" runat="server">
                            <ItemTemplate>
                                <div style="width: 750px; border-bottom: solid 1px #efefef; float: left;
                                font-family: Arial; font-size: 11px;">
                                <div style="width: 100px; height: 20px; float: left">
                                    <%# (DateTime.Parse(Eval("Date_Time").ToString())).ToString("dd MMM yy")%>
                                </div>
                                <div style="width: 600px;  float: left">
                                    <div class="<%# Eval("Action_Type")%>">
                                        <%# Eval("Action_Type")%>
                                    </div>
                                    <div style="width: 350px; padding: 2px; float: left">
                                        <%# Eval("Action_Desc")%>
                                    </div>
                                    <div style="width: 150px; padding: 2px; height: 16px; float: right; color: #cccccc;">
                                        : by
                                        <%# Eval("User_Name")%>
                                    </div>
                                </div>
                            </div>
                            </ItemTemplate>
                        </asp:Repeater>
    </asp:Panel>
    <asp:Panel ID="pnlStarContainer" runat="server" Visible="false">
        <div class="StarContainer" id="StarContainer">
            <div class="<% if(intStar >= 1) {Response.Write("StarActive");}else{Response.Write("StarInActive");}; %>"
                onclick="javascript:document.getElementById('hdnStarContainer').value='StarContainer<%= strLeadID%>';stringval =AjaxSetLeadsRating_Params('1','<%= strLeadID%>');ajaxpack.postAjaxRequest('partials/HandleConversation.aspx', stringval, AjaxSetLeadsRating, 'txt');">
            </div>
            <div class="<% if(intStar >= 2) {Response.Write("StarActive");}else{Response.Write("StarInActive");}; %>"
                onclick="javascript:document.getElementById('hdnStarContainer').value='StarContainer<%= strLeadID%>';stringval =AjaxSetLeadsRating_Params('2','<%= strLeadID%>');ajaxpack.postAjaxRequest('partials/HandleConversation.aspx', stringval, AjaxSetLeadsRating, 'txt');">
            </div>
            <div class="<% if(intStar >= 3) {Response.Write("StarActive");}else{Response.Write("StarInActive");}; %>"
                onclick="javascript:document.getElementById('hdnStarContainer').value='StarContainer<%= strLeadID%>';stringval =AjaxSetLeadsRating_Params('3','<%= strLeadID%>');ajaxpack.postAjaxRequest('partials/HandleConversation.aspx', stringval, AjaxSetLeadsRating, 'txt');">
            </div>
            <div class="<% if(intStar >= 4) {Response.Write("StarActive");}else{Response.Write("StarInActive");}; %>"
                onclick="javascript:document.getElementById('hdnStarContainer').value='StarContainer<%= strLeadID%>';stringval =AjaxSetLeadsRating_Params('4','<%= strLeadID%>');ajaxpack.postAjaxRequest('partials/HandleConversation.aspx', stringval, AjaxSetLeadsRating, 'txt');">
            </div>
            <div class="<% if(intStar >= 5) {Response.Write("StarActive");}else{Response.Write("StarInActive");}; %>"
                onclick="javascript:document.getElementById('hdnStarContainer').value='StarContainer<%= strLeadID%>';stringval =AjaxSetLeadsRating_Params('5','<%= strLeadID%>');ajaxpack.postAjaxRequest('partials/HandleConversation.aspx', stringval, AjaxSetLeadsRating, 'txt');">
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlStatusContainer" runat="server" Visible="false">
        <div class="StatusContainer" id="StatusContainer">
            <div class="<% if(strStatusID =="8F0B440C-0895-473C-8D4C-577BFA44867B") {Response.Write("Status_New");}else{Response.Write("Status_New_In");} %>"
                onclick="javascript:document.getElementById('hdnStatusContainer').value='StatusContainer<%= strLeadID%>';stringval =AjaxSetLeadsStatus_Params('8F0B440C-0895-473C-8D4C-577BFA44867B','<%= strLeadID%>');ajaxpack.postAjaxRequest('partials/HandleConversation.aspx', stringval, AjaxSetLeadsStatus, 'txt');">
            </div>
            <div class="<% if(strStatusID  =="32168FF0-CCF8-4D03-A7F0-D35752107FB6") {Response.Write("Status_Qualified");}else{Response.Write("Status_Qualified_In");} %>"
                onclick="javascript:document.getElementById('hdnStatusContainer').value='StatusContainer<%= strLeadID%>';stringval =AjaxSetLeadsStatus_Params('32168FF0-CCF8-4D03-A7F0-D35752107FB6','<%= strLeadID%>');ajaxpack.postAjaxRequest('partials/HandleConversation.aspx', stringval, AjaxSetLeadsStatus, 'txt');">
            </div>
            <div class="<% if(strStatusID  =="FB8681C6-F250-4515-9217-EC55988C4C79") {Response.Write("Status_Quote");}else{Response.Write("Status_Quote_In");} %>"
                onclick="javascript:document.getElementById('hdnStatusContainer').value='StatusContainer<%= strLeadID%>';stringval =AjaxSetLeadsStatus_Params('FB8681C6-F250-4515-9217-EC55988C4C79','<%= strLeadID%>');ajaxpack.postAjaxRequest('partials/HandleConversation.aspx', stringval, AjaxSetLeadsStatus, 'txt');">
            </div>
            <div class="<% if(strStatusID  =="D8A852A8-D29F-4E55-B549-8F7B98E13EC9") {Response.Write("Status_Won");}else{Response.Write("Status_Won_In");} %>"
                onclick="javascript:document.getElementById('hdnStatusContainer').value='StatusContainer<%= strLeadID%>';stringval =AjaxSetLeadsStatus_Params('D8A852A8-D29F-4E55-B549-8F7B98E13EC9','<%= strLeadID%>');ajaxpack.postAjaxRequest('partials/HandleConversation.aspx', stringval, AjaxSetLeadsStatus, 'txt');">
            </div>
        </div>
    </asp:Panel>
</body>
</html>
