<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HandleEmails.aspx.cs" Inherits="Partials_HandleEmails" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>LeadNotes</title>
</head>
<body>

<div id="divSendEmail">
<div style="width:400px;height:15px;background-color:#cccccc;border:solid 1px #cccccc;">From:<input type=text id="txtFrom" value="<%= strFromEmail  %>" style="width:300px;" /> </div>
<div style="width:400px;height:15px;background-color:#cccccc;border:solid 1px #cccccc; ">
To: <input type=text id="txtTo" style="width:300px;" value="<%= strToEmail  %>" /></div>
<textarea id="txtEmailBody" style="border:solid 1px #cccccc; height:200px; width:400px;"></textarea>
<div style="width:400px;height:15px;background-color:#cccccc;border:solid 1px #cccccc;">

<div style="width:100px;height:15px;float:left;" id="divSendEmailResult"></div>
<div style="width:100px;height:15px;float:left;" onclick="javascript:stringval =AjaxSendEmail_Params('<%= strLeadID%>');ajaxpack.postAjaxRequest('partials/HandleEmails.aspx', stringval, AjaxSendEmail, 'txt');return false;">Send Email</div>

</div>
</div>
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
                                            &nbsp;<a class="FormButton" id="lnkDeleteNote" onclick="javascript:document.getElementById('hdnBoxId').value='LeadsBox<%= strLeadID %>';stringval =AjaxDeleteNotes_Params('<%= strLeadID %>','<%# Eval("Note_Id") %>');ajaxpack.postAjaxRequest('partials/leadnotes.aspx', stringval, AjaxDeleteNotes, 'txt');return false;">
                                                    delete</a>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
    </div>
</body>
</html>
