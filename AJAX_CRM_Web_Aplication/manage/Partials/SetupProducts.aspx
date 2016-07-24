<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetupProducts.aspx.cs" Inherits="Partials_SetupProducts" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>LeadNotes</title>
</head>
<body>
    <div>
     <asp:Repeater ID="rptrProducts" runat="server">
                    <ItemTemplate>
                        <div class="LeadDeck">
                            <div class="MedLabel" style="width:200px;float:left;">
                                <%# Eval("Product_Name")%>
                            </div>
                          
                            <div  style="width:100px;float:left;">
                              <a id="lnkEditProduct" onclick="javascript:stringval =AjaxEditProduct_Params();ajaxpack.postAjaxRequest('partials/SetupProducts.aspx', stringval, AjaxEditProduct, 'txt');return false;">
                                Edit </a> , 
                              <a id="lnkDeleteProduct" onclick="javascript:var ConfirmDelete= confirm('Warning: You are about to delete a product/service,Are you sure ?');if(ConfirmDelete){document.getElementById('hdnSelectProductID').value='<%# Eval("Product_ID")%>'; stringval =AjaxDeleteProduct_Params();ajaxpack.postAjaxRequest('partials/SetupProducts.aspx', stringval, AjaxDeleteProduct, 'txt');return false;}else{return false;};">
                                Delete </a>  
                            </div>
                             <div style="width:600px;float:left;">
                             <%# Eval("Product_Desc")%>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
    </div>
</body>
</html>
