<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SettingsMenu.ascx.cs"
    Inherits="Webcontrols_HeaderMenu" %>
<%@ OutputCache Duration="10" VaryByParam="*" %>
<div class="SubHeaderLinks">
    <span class="<%= strTab1 %>"><a href="<%=CustomerSupport.Utility.SysResource.HomePath %>manage/Setup.aspx">
        Product/Services </a></span>
        <span class="<%= strTab6 %>"><a href="<%=CustomerSupport.Utility.SysResource.HomePath %>manage/Branding.aspx">
            Branding</a></span> 
        
        <span class="<%= strTab2 %>"><a href="<%=CustomerSupport.Utility.SysResource.HomePath %>manage/People.aspx">
            People</a></span> <%--<span class="<%= strTab3 %>"><a href="<%=CustomerSupport.Utility.SysResource.HomePath %>CustomizeProcess.aspx">
                Process</a></span>--%> <span class="<%= strTab4 %>"><a href="<%=CustomerSupport.Utility.SysResource.HomePath %>manage/SetupTags.aspx">
                    Tags</a></span> <span class="<%= strTab5 %>"><a href="<%=CustomerSupport.Utility.SysResource.HomePath %>manage/WidgetOptions.aspx">
                        Widgets</a></span> <span class="<%= strTab7 %>"><a href="<%=CustomerSupport.Utility.SysResource.HomePath %>manage/SetupCategories.aspx">
                        Categories</a></span>
</div>
