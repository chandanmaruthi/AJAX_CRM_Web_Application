<%@ Page Title="" Language="C#" MasterPageFile="~/manage/Internal.master" AutoEventWireup="true"
    CodeFile="WidgetOptions.aspx.cs" Inherits="manage_WidgetOptions" %>
<%@ Register Src="~/Webcontrols/HeaderMenu.ascx" TagName="HeaderMenu" TagPrefix="uc1" %>
<%@ Register Src="~/Webcontrols/SettingsMenu.ascx" TagName="SettingsMenu" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderInclude" runat="Server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="Server">
  <uc1:HeaderMenu ID="HeaderMenu" SetTab="3" runat="server" ShowCorpMenu="true" />
 <uc2:SettingsMenu ID="SettingsMenu" runat="server" SetTab="5" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" runat="Server">
<div class="PageContainer">
        <div class="PageHeader">
            Custom Tags 
        </div>
          <div style="width: 200px; height: 150px; float: left; border: solid 1px #eeeeee;
        margin: 5px;">
        <div style="width: 190px; height: 60px; float: left; border: solid 1px #eeeeee; margin: 5px;overflow:hidden;">
        <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>widget_002_small.gif" border="0" />
        </div>
        <div style="width: 190px; height: 60px; float: left; border: solid 0px #eeeeee; margin: 5px;">
        Capture Customers Issues, Suggestions Etc
        
        <a href="<%= CustomerSupport.Utility.SysResource.HomePath %>manage/SetupWidget_002.aspx" >Click Here</a>
        </div>
    </div>
    <div style="width: 200px; height: 150px; float: left; border: solid 1px #eeeeee;
        margin: 5px;">
        <div style="width: 190px; height: 60px; float: left; border: solid 1px #eeeeee; margin: 5px;overflow:hidden;">
        <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>widget_001_small.gif" border="0" />
        
        </div>
        <div style="width: 190px; height: 60px; float: left; border: solid 0px #eeeeee; margin: 5px;">
        Interact with your customers are you will with customized widgets
        <a href="<%= CustomerSupport.Utility.SysResource.HomePath %>manage/SetupWidget.aspx" >Click Here</a>
        
        </div>
    </div>
    <div style="width: 200px; height: 150px; float: left; border: solid 1px #eeeeee;
        margin: 5px;">
        <div style="width: 190px; height: 60px; float: left; border: solid 1px #eeeeee; margin: 5px;overflow:hidden;">
        <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>widget_003_small.gif" border="0" />
        
        </div>
        <div style="width: 190px; height: 60px; float: left; border: solid 0px #eeeeee; margin: 5px;">
        Collect Feedback on services
        <a href="<%= CustomerSupport.Utility.SysResource.HomePath %>manage/SetupWidget_003.aspx" >Click Here</a>
        
        
        </div>
    </div>
        
        </div>
  
</asp:Content>
