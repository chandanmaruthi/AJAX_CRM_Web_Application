<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeadTasks.aspx.cs" Inherits="Partials_LeadTasks" %>


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
                                          <%# (DateTime.Parse(Eval("Task_Date").ToString())).ToString("dd MMM yy")%>
                                        </div>
                                        <div style="width: 410px; height: 15px; display: block; float: left; text-align: left;
                                            overflow-x: hidden; overflow-y: scroll;">
                                            <%# Eval("Task_Desc")%> at <%# Eval("Task_Date")%> : by <%# Eval("User_Name")%>
                                            &nbsp;<a class="SmallFormButton" id="lnkDeleteNote" onclick="javascript:document.getElementById('hdnBoxId').value='TasksBox';stringval =AjaxDeleteTasks_Params('<%= strLeadID%>','<%# Eval("Task_Id") %>');ajaxpack.postAjaxRequest('partials/leadtasks.aspx', stringval, AjaxDeleteTasks, 'txt');return false;">
                                            delete</a>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
    </div>
</body>
</html>
