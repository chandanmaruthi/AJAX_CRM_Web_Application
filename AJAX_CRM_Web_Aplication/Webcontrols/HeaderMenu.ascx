<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HeaderMenu.ascx.cs" Inherits="Webcontrols_HeaderMenu" %>
<div id="HeaderContainer" class="HeaderContainer">
    <div class="HeaderTopContainer" runat="server">
        <div class="HeaderMessage">
        <a href="<%= CustomerSupport.Utility.SysResource.HomePath +GetState(CustomerSupport.CustomerSupportControl.Account_Name) %>" style="font-size:18px;font-weight:bold;">
            <%= GetState(CustomerSupport.CustomerSupportControl.Header_Text)%>
            </a>
        </div>
        <div class="WelcomeBox" runat="server" id="dvWelcomeBox">
            <asp:Label runat="server" ID="lblWelcomeUser"></asp:Label>
            &nbsp;&nbsp;&nbsp;, <a href="<%= CustomerSupport.Utility.SysResource.HomePath%>manage/ManageAccount.aspx"
                id="A1">My Account</a> ,
            <asp:LinkButton runat="server" ID="lnkSignout" Text="Log Out" CausesValidation="false"
                OnClick="lnkSignout_Click" CssClass="Signout"> </asp:LinkButton>
        </div>
        <div class="WelcomeBox" runat="server" id="divLogin" visible="false">
            <a href="<%= CustomerSupport.Utility.SysResource.HomePath%>login.aspx" id="A3">Company
                Login</a>
        </div>
    </div>
    <div class="HeaderLinks" id="HeaderLinks" runat="server">
        <div id="MenuTabsBox">
            <ul>
                <li><a class="<%= strTab1 %>" href="<%= CustomerSupport.Utility.SysResource.HomePath%>manage/Welcome.aspx"
                    id="Tab1">Overview </a></li>
                <li><a class="<%= strTab2 %>" href="<%= CustomerSupport.Utility.SysResource.HomePath%>manage/ManageLeads.aspx"
                    id="Tab2">Conversations </a></li>
                <li><a class="<%= strTab4 %>" href="<%= CustomerSupport.Utility.SysResource.HomePath%>manage/CreateContent.aspx"
                    id="A9">Create Content</a></li>
                <li><a style="float: right;" target="_blank" class="<%= strTab5 %>" href="<%= CustomerSupport.Utility.SysResource.HomePath %><%= strAccountName %>"
                    id="A2">Support Center </a></li>
                    <a style="float: right;" class="<%= strTab6 %>" href="<%= CustomerSupport.Utility.SysResource.HomePath%>manage/HowTo.aspx"
                    id="A8">How To</a>
                    <li><a style="float: right;" class="<%= strTab3 %>" href="<%= CustomerSupport.Utility.SysResource.HomePath%>manage/Setup.aspx"
                    id="Tab3">Settings</a></li>
               
                
            </ul>
        </div>
    </div>
</div>