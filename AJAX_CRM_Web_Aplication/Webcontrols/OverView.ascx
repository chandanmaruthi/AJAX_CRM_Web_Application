<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OverView.ascx.cs" Inherits="Webcontrols_Tasks" %>
<div class="LeftSection">
   <div class="LeftSectionHeader">Snapshot</div>
    <asp:Repeater ID="rptrOverview" runat="server">
        <ItemTemplate>
            <div class="LeftRows">
                
                <a href="<%= CustomerSupport.Utility.SysResource.HomePath %>manageleads.aspx?Product=<%# Eval("Product_ID") %>">
                <%# Eval("Product_Name") %>(<%# Eval("Open_Conversation")%>)</a>
                
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
