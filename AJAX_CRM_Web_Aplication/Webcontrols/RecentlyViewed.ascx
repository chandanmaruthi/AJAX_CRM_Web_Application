<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RecentlyViewed.ascx.cs" Inherits="Webcontrols_Tasks" %>
<div class="LeftSection" >
   <div class="LeftSectionHeader">Recently Viewed:</div>
    <asp:Repeater ID="rptrTasks" runat="server">
        <ItemTemplate>
            
            <div class="LeftRows">
            #<%# Eval("Conversation_Number") %> <a style="text-decoration:underline;" href="<%= CustomerSupport.Utility.SysResource.HomePath %>Leads.aspx?Action=E&ID=<%# Eval("Conversation_ID") %>">
               <%# Eval("Conversation_Title") %></a>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
