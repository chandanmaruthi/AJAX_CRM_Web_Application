<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeadNotes.aspx.cs" Inherits="Partials_LeadNotes" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>LeadNotes</title>
</head>
<body>

    <div>
    <asp:Repeater runat="server" ID="rptrChild">
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div style="width: 750px; border-bottom: solid 1px #cccccc; display: block; background-color: #ffffff;
                                        height: 15px; display: block; padding-top: 5px; overflow: hidden;">
                                        <div style="width: 150px; height: 15px; display: block; float: left; text-align: left;">
                                          <%# (DateTime.Parse(Eval("Date").ToString())).ToString("dd MMM yy")%>
                                        </div>
                                        <div style="width: 410px; height: 15px; display: block; float: left; text-align: left;
                                            overflow-x: hidden; overflow-y: scroll;">
                                            <%# Eval("Note_Desc")%>: by <%# Eval("User_Name")%>
                                            &nbsp;<a class="FormButton" id="lnkDeleteNote" onclick="javascript:document.getElementById('hdnBoxId').value='LeadsBox<%= strConversationID %>';stringval =AjaxDeleteNotes_Params('<%= strConversationID %>','<%# Eval("Note_Id") %>');ajaxpack.postAjaxRequest('partials/leadnotes.aspx', stringval, AjaxDeleteNotes, 'txt');return false;">
                                                    delete</a>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
    </div>
</body>
</html>
