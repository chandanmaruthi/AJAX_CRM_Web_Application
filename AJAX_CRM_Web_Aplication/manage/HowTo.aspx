<%@ Page Title="" Language="C#" MasterPageFile="~/manage/Internal.master" AutoEventWireup="true"
    CodeFile="HowTo.aspx.cs" Inherits="manage_HowTo" %>

<%@ Register Src="~/Webcontrols/HeaderMenu.ascx" TagName="HeaderMenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderInclude" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="Server">
    <uc1:HeaderMenu ID="HeaderMenu" SetTab="6" runat="server" ShowCorpMenu="True" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" runat="Server">
    <div class="PageContainer">
        <div class="PageHeader">
            How To
            <%-- <div style="width: 142px; height: 29px; position: relative; left: 280px; top: -20px;">
                <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>FindMeHere.gif" />
            </div>--%>
        </div>
        <h1 style="text-align: center;">
            Welcome to delightDesk</h1>
        <div style="float: left; margin-bottom: 15px; background-color: #FFF7D6; border-top: dotted 1px #cccccc;
            border-bottom: dotted 1px #cccccc; padding: 5px;">
            <div class="PictureBox">
                <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>Chandan.jpg" style="height: 50px;
                    width: 50px;" />
            </div>
            <div style="font-family: Times New Roman; font-size: 15px; line-height: 1.2em;">
                Hi
                <%= GetState(CustomerSupport.CustomerSupportPage.UserName)%>,
                <br />
                Congratulations on chosing delightDesk. We hope to make customer engagement a delightful
                experience for you. Visit help.delightdesk.com to clarify any queries or issues
                you may face.
                <br />
                <br />
                <span style="float: right">Regards,<br />
                    Chandan Maruthi, <b>delightDesk</b><br />
                </span>
            </div>
        </div>
        <div style="width: 750px; height: 20px; background-color: #f5f5f5;border:solid 1px #cccccc; font-weight: bold;float:left;padding:5px;">
            First Things first
        </div>
          <div style="width: 750px; background-color: #ffffff;border:solid 1px #cccccc; font-weight: bold;float:left;padding:5px;">
        <a href="<%= CustomerSupport.Utility.SysResource.HomePath %>manage/CreateContent.aspx" style="font-size: 14px;
            font-weight: bold; color: #0094FF">Create Content</a><br />
       Add Topics, Frequently Asked Questions and Tutorials .
        <br />
        <br />
        
          <a href="<%= CustomerSupport.Utility.SysResource.HomePath %>manage/Setup.aspx" style="font-size: 14px;
            font-weight: bold; color: #0094FF">Upload Content</a><br />
        Upload your content in excel,csv format
        <br />
        <br />      


<a href="<%= CustomerSupport.Utility.SysResource.HomePath %>manage/SetupWidget.aspx"
            style="font-size: 14px; font-weight: bold; color: #0094FF">Collect Customer Queries And Feedback</a><br />
        Direct your help/support links on your website to <a href="<%= CustomerSupport.Utility.SysResource.HomePath + GetState(CustomerSupport.CustomerSupportControl.Account_Name) %>">
            <%= CustomerSupport.Utility.SysResource.HomePath + GetState(CustomerSupport.CustomerSupportControl.Account_Name) %>
        </a>
        <br />
        <i>you can also </i>
        <br />
        Place customized delightDesk widgets anywhere on your website
        <br />
        <br />

        </div>
        <div style="width: 750px; height: 20px; background-color: #f5f5f5;border:solid 1px #cccccc; font-weight: bold;float:left;padding:5px;">
            Lets Also
        </div>
          <div style="width: 750px; background-color: #ffffff;border:solid 1px #cccccc; font-weight: bold;float:left;padding:5px;">
             
        <a href="<%= CustomerSupport.Utility.SysResource.HomePath %>manage/Branding.aspx"
            style="font-size: 14px; font-weight: bold; color: #0094FF">Change Look and Feel
        </a>
        <br />
        Customize your customer support with your logo, colors, messages etc<br />
        <br />
        <a href="<%= CustomerSupport.Utility.SysResource.HomePath %>manage/People.aspx" style="font-size: 14px;
            font-weight: bold; color: #0094FF">Add People </a>
        <br />
        Invite your Team to delightDesk<br />
        <br />
        <a href="<%= CustomerSupport.Utility.SysResource.HomePath %>manage/Setup.aspx" style="font-size: 14px;
            font-weight: bold; color: #0094FF">Add Products</a><br />
        Add your Products so you can track queries by product
        <br />
        <br />
        <a href="<%= CustomerSupport.Utility.SysResource.HomePath %>manage/SetupCategories.aspx"
            style="font-size: 14px; font-weight: bold; color: #0094FF">Add Categories</a><br />
        Classify topics by categories<br />
        <br />
        <a href="<%= CustomerSupport.Utility.SysResource.HomePath %>manage/SetupTags.aspx"
            style="font-size: 14px; font-weight: bold; color: #0094FF">Add tags</a><br />
        Classify topics by custom defined tags<br />
        <br />
 
        </div>
          </div>
</asp:Content>
