<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PortalHeaderMenu.ascx.cs"
    Inherits="PortalHeaderMenu" %>
    <style type=text/css>
     Body
     {
                 color:<%= GetState(CustomerSupport.CustomerSupportControl.Header_Text)%>;

         }
    .MenuTab
    {
     /*   background-color:<%= GetState(CustomerSupport.CustomerSupportControl.InActive_Tab_Bg_Color)%>;
        */
        
    }
    .MenuTabActive
    {/*
        background-color:<%= GetState(CustomerSupport.CustomerSupportControl.Active_Tab_Bg_Color)%>;
        */
    }
    #HeaderLinks .MenuTab a, a:link, a:visited
    {
        color:<%= GetState(CustomerSupport.CustomerSupportControl.InActive_Tab_Text_Color)%>;
        font-size:14px;
    }
    #HeaderLinks .MenuTabActive a, a:link, a:visited
    {
        color:<%= GetState(CustomerSupport.CustomerSupportControl.Active_Tab_Text_Color)%>;
    }
    </style>
<div id="HeaderContainer" class="P_HeaderContainer" style="background-color:<%= GetState(CustomerSupport.CustomerSupportControl.Background_Color)%>;height:60px;">
    <div class="P_HeaderTopContainer" id="divIntHeader" runat="server">
    <div runat=server id="divLogo" style="width:150px;height:50px;float:left;overflow:hidden;" visible="false">
    <asp:Image runat=server ID="imgLogo" Border="0" />
    </div>
        
            <div class="WelcomeBox" runat="server" id="dvWelcomeBox" style="font-size:18px;">
                <asp:Label runat="server" ID="lblWelcomeUser" ></asp:Label>
                &nbsp;&nbsp;&nbsp;, <a href="<%= CustomerSupport.Utility.SysResource.HomePath%>manage/ManageAccount.aspx"
                    id="A1">My Account</a> ,
                <asp:LinkButton runat="server" ID="lnkSignout" Text="Log Out" CausesValidation="false"
                    OnClick="lnkSignout_Click" CssClass="Signout"> </asp:LinkButton>
            </div>
            <div class="WelcomeBox" style="float:right;" runat="server" id="divLogin" visible="false">
                <a href="<%= CustomerSupport.Utility.SysResource.HomePath%>login.aspx" id="A3">Company
                    Login</a>
            </div>
            <div class="HeaderMessage">
                 <a style="font-size:18px;" href="<%= CustomerSupport.Utility.SysResource.HomePath +GetState(CustomerSupport.CustomerSupportControl.Account_Name) %>">
            <%= GetState(CustomerSupport.CustomerSupportControl.Header_Text)%>
            </a>
            </div>
            
        <div class="HeaderLinks" id="HeaderLinks" runat="server" style="height:20px;width:400px;float:left;">
        <div id="divPMenuTabs">
            <a class="<%= strTab1 %>" href="<%= CustomerSupport.Utility.SysResource.HomePath + GetState(CustomerSupport.CustomerSupportControl.Account_Name) %>"
                id="A4">Home |</a><a class="<%= strTab2 %>" href="<%= CustomerSupport.Utility.SysResource.HomePath%>SupportCenter/Products.aspx"
                    id="A5">Products |</a><a class="<%= strTab3 %>" href="<%= CustomerSupport.Utility.SysResource.HomePath%>SupportCenter/Categories.aspx"
                        id="A6">Categories </a>
        </div>
    </div>
    </div>
    
</div>
