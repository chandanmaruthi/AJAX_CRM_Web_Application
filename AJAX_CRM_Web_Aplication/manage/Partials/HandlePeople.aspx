<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HandlePeople.aspx.cs" Inherits="Partials_HandlePeople" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>LeadNotes</title>
</head>
<body>
    <div>
     <asp:Repeater ID="rptrProducts" runat="server">
                    <ItemTemplate>
                          <div style="width:300px;height:100px;float:left;background-color:#f5f5f5;border:solid 1px #cccccc; margin:5px;padding:5px;">
                        <div class="ProfilePicture"></div>
                        
                        <div class="MedLabel" style="width: 200px; float: left;">
                            <%# Eval("User_F_Name")%>
                        </div>
                        <div style="width: 200px; float: left;">
                            e:<%# Eval("Email_ID")%>
                        </div>
                        <div style="width: 200px; float: left;">
                            p:<%# Eval("Phone_1")%>
                        </div>
                        <div style="width: 100px; float: left;">
                            <a id="lnkEditProduct" onclick="javascript:stringval =AjaxEditProduct_Params();ajaxpack.postAjaxRequest('partials/HandlePeople.aspx', stringval, AjaxEditProduct, 'txt');return false;">
                                Edit </a>, <a id="lnkDeleteProduct" onclick="javascript:var ConfirmDelete= confirm('Warning: You are about to delete a product/service,Are you sure ?');if(ConfirmDelete){document.getElementById('hdnSelectUserID').value='<%# Eval("User_ID")%>'; stringval =AjaxDeleteProduct_Params();ajaxpack.postAjaxRequest('partials/HandlePeople.aspx', stringval, AjaxDeleteProduct, 'txt');return false;}else{return false;};">
                                    Delete </a>
                        </div>
                        
                        
                    </div>
                    </ItemTemplate>
                </asp:Repeater>
    </div>
</body>
</html>
