<%@ Page Language="C#" MasterPageFile="~/home/External.master" AutoEventWireup="true" Buffer="false"  EnableViewState="false"  EnableSessionState="False"
    CodeFile="Tour.aspx.cs" Inherits="Home_Tour" Title="Take A Tour" %>
<%@ OutputCache VaryByParam="none" Location="Server" Duration="3600" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="Server">
    <table width="100%" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td>
                <div class="Subhead">
                    Take a Tour
                </div>
            </td>
        </tr>
        <tr>
            <td align="center">
                <div class="TourSubHeading">
                    Customize and Publish Widgets</div>
            </td>
        </tr>
        <tr>
            <td align="center">
                <div style="border: solid 1px #cccccc;width:750px;overflow:hidden; ">
                    <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>Tour/WidgetDesign.gif" border="0" />
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <ol>
                    <li>Create customized widgets for your website, let each section talk to your visitors</li>
                    <li>Create as many widgets you like specific to context and message </li>
                    <li>Add questions that qualify the lead </li>
                    <li>Publish Leads Widgets to Blogger, Wordpress, Typepad, and any website, blog or social network</li>
                </ol>
            </td>
        </tr>
        <tr>
            <td align="center">
                <div class="TourSubHeading">
                    Generate and Manage Leads</div>
            </td>
        </tr>
        <tr>
            <td align="center">
                <div style="border: solid 1px #cccccc;width:750px;overflow:hidden; ">
                    <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>Tour/MyLeads.gif" border="0" /></div>
            </td>
        </tr>
        <tr>
            <td>
            
                <ol>
                    <li>All your leads from multiple websites, blogs etc are centrally captured in your lead manager</li>
                    <li>You receive an instant alert when a lead is generated </li>
                    <li>Who is it, What is he interested in, Where is he from . All the questions are provided for each lead</li>
                </ol>
            </td>
        </tr>
        <tr>
            <td align="center">
                <div class="TourSubHeading">
                    Keep Track of Account Activities</div>
            </td>
        </tr>
        <tr>
            <td align="center">
                <div style="border: solid 1px #cccccc;width:750px;overflow:hidden; ">
                    <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>Tour/LeadNotes.gif" border="0" /></div>
            </td>
        </tr>
        <tr>
            <td>
            
                <ol>
                    <li>Keep notes of your activities</li>
                    <li>You sent out a quote, you had a call, you met the client</li>
                    <li>Followup you leads and track every lead to closure</li>
                </ol>
            </td>
        </tr>
        <tr>
            <td align="center">
                <div class="TourSubHeading">
                    Interact Securely With Clients</div>
            </td>
        </tr>
        <tr>
            <td align="center">
                <div style="border: solid 1px #cccccc;width:750px;overflow:hidden; ">
                    <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>Tour/SendEmail.gif" border="0" /></div>
            </td>
        </tr>
        <tr><td>
        
                <ol>
                    <li>Your clients can contact you without sharing their email/phone with you</li>
                    <li>Get in touch with such clients securely via CustomerSupport. </li>
                    <li>Create trust with your clients and convert leads to business</li>
                </ol>
        </td></tr>
    </table>
</asp:Content>
