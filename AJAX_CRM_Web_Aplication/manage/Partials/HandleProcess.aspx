<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HandleProcess.aspx.cs" Inherits="Partials_HandleProcess" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>LeadNotes</title>
</head>
<body>
    <div>
     <asp:Repeater ID="rptrAccountLeadStatus" runat="server">
                    <ItemTemplate>
                        <div class="LeadDeck">
                            <div class="MedLabel" style="width:600px;float:left;">
                                <%# Eval("Status_Name")%>
                            </div>
                        
                           
                            <div  style="width:100px;float:left;">
                              <a id="lnkEditProduct" onclick="javascript:stringval =AjaxEditProduct_Params();ajaxpack.postAjaxRequest('partials/HandleProcess.aspx', stringval, AjaxEditProduct, 'txt');return false;">
                                Edit </a> , 
                              <a id="lnkDeleteProduct" onclick="javascript:var ConfirmDelete= confirm('Warning: You are about to delete a product/service,Are you sure ?');if(ConfirmDelete){document.getElementById('hdnSelectStatusID').value='<%# Eval("Status_ID")%>'; stringval =AjaxDeleteStatus_Params();ajaxpack.postAjaxRequest('partials/HandleProcess.aspx', stringval, AjaxDeleteStatus, 'txt');return false;}else{return false;};">
                                Delete </a>  
                            </div>
                                <div  style="width:200px;float:left;">
                                e:<%# Eval("Status_Desc")%>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
    </div>
</body>
</html>
