<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HandleCategory.aspx.cs" Inherits="Partials_HandleCategory" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>LeadNotes</title>
</head>
<body>
    <asp:Panel ID="pnlShowTags" runat=server Visible=false>
     <asp:Repeater ID="rptrTags" runat="server">
                    <ItemTemplate>
                       <div style="height: 15px;background-color:#FFE97F;border:solid 1px #FFD11C;margin:2px;padding:2px; float: left">
                                       <%# Eval("Category_Name")%>
                                        &nbsp; <a id="lnkDeleteNote" onclick="javascript:document.getElementById('hdnBoxId').value='divTags';stringval =AjaxDeleteLeadTags_Params('<%= strLeadID%>','<%# Eval("Category_Id") %>');ajaxpack.postAjaxRequest('partials/HandleCategory.aspx', stringval, AjaxDeleteLeadTags, 'txt');return false;">
                                            <img src="<%= CustomerSupport.Utility.SysResource.ImagePath%>delete.png" border=0 style="vertical-align:middle;" /></a>
                                    </div>
                    </ItemTemplate>
                </asp:Repeater>
   </asp:Panel>
   <asp:Panel ID="pnlAddTagsToLead" runat=server Visible=false>
   <asp:Repeater runat="server" ID="rptrLeadTags">
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                
                                <div style="height: 15px;background-color:#FFE97F;border:solid 1px #FFD11C;margin:2px;padding:2px; float: left">
                                       <%# Eval("Category_Name")%>
                                        &nbsp; <a id="lnkDeleteNote" onclick="javascript:document.getElementById('hdnBoxId').value='divTags';stringval =AjaxDeleteLeadTags_Params('<%= strLeadID%>','<%# Eval("Category_Id") %>');ajaxpack.postAjaxRequest('partials/HandleCategory.aspx', stringval, AjaxDeleteLeadTags, 'txt');return false;">
                                            <img src="<%= CustomerSupport.Utility.SysResource.ImagePath%>delete.png" border=0 style="vertical-align:middle;" /></a>
                                    </div>
                                
                            </ItemTemplate>
                        </asp:Repeater>
<br /><br /><u>
Available Tags</u><br />
                        <asp:Repeater runat="server" ID="rptrAllTags">
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                
                                   <div style="height: 15px;background-color:#FFE97F;border:solid 1px #FFD11C;margin:2px;padding:2px; float: left;">
                                       <%# Eval("Category_Name")%>
                                        &nbsp; <a  id="lnkDeleteNote" onclick="javascript:document.getElementById('hdnBoxId').value='divTags';stringval =AjaxAddCategory_Params('<%= strLeadID%>','<%# Eval("Category_Id") %>');ajaxpack.postAjaxRequest('partials/HandleCategory.aspx', stringval, AjaxAddCategory, 'txt');return false;">
                                            <img src="<%= CustomerSupport.Utility.SysResource.ImagePath%>add.png" border=0 style="vertical-align:middle;" /></a>
                                    </div>
                                
                            </ItemTemplate>
                        </asp:Repeater>
   </asp:Panel>
   <asp:Panel ID="pnlViewCategory" runat=server  Visible=false>
   <asp:Repeater ID="rptrViewCategory" runat="server">
                <ItemTemplate>
                    <div class="LeadDeck">
                        <div class="MedLabel" style="width: 600px; float: left;">
                            <%# Eval("Category_Name")%>
                        </div>
                        <div style="width: 100px; float: left;">
                            <a id="lnkDeleteProduct" onclick="javascript:var ConfirmDelete= confirm('Warning: You are about to delete a category,Are you sure ?');if(ConfirmDelete){document.getElementById('hdnSelectTagID').value='<%# Eval("Category_ID")%>'; stringval =AjaxDeleteCategory_Params();ajaxpack.postAjaxRequest('partials/HandleCategory.aspx', stringval, AjaxDeleteCategory, 'txt');return false;}else{return false;};">
                                Delete </a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
   </asp:Panel>
</body>
</html>
