<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Widget.aspx.cs" Inherits="Widget" %>


<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>delightDeskWidget</title> 
    <style type="text/css">
        input, textarea, select
        {
            border: solid 1px #cccccc;
            font-size: 11px;
            font-family: arial;
        }
        body
        {
            font-size: 11px;
            font-family: arial;
            color: <%= strTextColor %>;
            font-family: arial;
        }
        .WidgetContainer
        {
            width: 136px;
            overflow: hidden;
            background-color: <%= strBackgroundColor %>;
            color: <%= strTextColor %>;
            background-position: 100px 0px;
            border: solid 1px #cccccc;
        }
        .Required
        {
            padding: 2px;
            color: Red;
            font-weight: normal;
        }
        .LabelSections
        {
            width: 120px;
            float: left;
            padding-top: 1px;
            height: 18px;
            font-size: 11px;
        }
        .DDLSections
        {
            width: 120px;
            float: left;
            height: 18px;
        }
        .InputSections
        {
            width: 120px;
            float: left;
            padding-top: 2px;
            height: 18px;
        }
        .WidgetArrow
        {
            width: 10px;
            height: 32px;
            padding: 0px;
            background-image: url('<%= CustomerSupport.Utility.SysResource.ImagePath %>WidgetLayout/Arroewhead.gif');
            background-repeat: no-repeat;
            display: block;
            float: left;
        }
        .WidgetHeader
        {
            width: 139px;
            height: 55px;
            padding: 0px; /*background-image: url('<%= CustomerSupport.Utility.SysResource.ImagePath %>WidgetLayout/WidgetHeader_1.gif');-*/
            background-repeat: no-repeat;
            display: block;
            float: left;
            color: <%= strTitleColor %>;
        }
        .WidgetMiddle
        {
            width: 136px; /*background-image: url('<%= CustomerSupport.Utility.SysResource.ImagePath %>WidgetLayout/WidgetMiddle_1.gif');*/
            background-repeat: repeat-y;
            float: left;
            padding-left: 5px;
        }
        .WidgetFooter
        {
            width: 136px;
            height: 11px;
            padding: 0px; /*background-image: url('<%= CustomerSupport.Utility.SysResource.ImagePath %>WidgetLayout/WidgetFooter_1.gif');*/
            display: block;
            float: left;
        }
        .SecureInfoText
        {
            border: solid 1px #FFCC66;
            width: 120px;
            background-color: #FFFFCC;
            padding: 5px;
            text-align: left;
            font: 11px;
            left: 10px;
            top: 150px;
        }
        .MessageBox
        {
            width: 130px;
            height: 52px;
            float: left;
            padding-top: 5px;
            padding-left: 2px;
            text-align: center;
            margin-bottom: 50px;
            overflow: hidden;
        }
        .ImageBox
        {
            width: 40px;
            border: solid 1px white;
            float: left;
        }
        .ElementSection
        {
            width: 120px;
            float: left;
            margin-top: 5px;
        }
        .ElementInput
        {
            width: 120px;
            float: left;
            padding-top: 2px;
        }
    </style>

    <script type="text/javascript" language="javascript">

        function SetFocusTextBox(Field, InitValue) {
            if (document.getElementById(Field).value == InitValue) {
                document.getElementById(Field).value = "";
            }
        }
        function LoseFocusTextBox(Field, InitValue) {
            if (document.getElementById(Field).value == "") {
                document.getElementById(Field).value = InitValue;
            }
        }
        function submitform() {
            document.CustomerSupportForm.submit();

        }

    </script>

</head>
<body>
    <form id="CustomerSupportForm" name="CustomerSupportForm" method="post" action="<%= CustomerSupport.Utility.SysResource.HomePath %>manage/ProcessLead.aspx">
    <input type="hidden" name="hdnUrl" id="hdnUrl" />
    <input type="hidden" name="hdnEmail" id="hdnEmail" value="<%= strRespEmail %>" />
    <input type="hidden" name="hdnWidgetID" id="hdnWidgetID" value="<%= strWidgetID %>" />
    <input type="hidden" name="hdnQuestionCount" id="Hidden1" value="<%= strQuestionCount %>" />
    <input type="hidden" name="hdnWidgetName" id="hdnWidgetName" value="<%= strWidgetName %>" />
    <div id="dvForm" class="WidgetContainer" runat="server">
        <div class="WidgetHeader">
            <div class="MessageBox">
                <div class="ImageBox" runat="server" id="imgPicture">
                    <img src="<%= CustomerSupport.Utility.SysResource.UserData %>userimages/<%= strAccountID %>/<%= strImageFileName %>"
                        border="0" />
                </div>
                <div id="lblHeader">
                    <%= strHeader %>
                </div>
            </div>
            <asp:Label ID="lblMsg" runat="server" CssClass="Required" Visible="false"></asp:Label>
        </div>
        <div class="WidgetMiddle">
            <asp:Panel runat="server" ID="pnlQuestions">
            </asp:Panel>
            <div class="ElementLabel">
                <asp:Label runat="server" ID="Label1" Text="How can we help you" Width="120px"></asp:Label>
            </div>
            <div class="ElementInput">
                <input class="InputSections" type="text" runat="server" id="txtMessage" style="width: 120px; height: 40px" />
            </div>
            <div class="ElementInput">
                <input class="InputSections" type="text" runat="server" id="txtName" value="Name"
                    maxlength="75" onfocus="javascript:SetFocusTextBox('txtName', 'Name');return false;"
                    onblur="javascript:LoseFocusTextBox('txtName', 'Name');return false;" /></div>
            <div class="ElementInput">
                <input class="InputSections" type="text" runat="server" id="txtEmail" value="Email"
                    maxlength="75" onfocus="javascript:SetFocusTextBox('txtEmail', 'Email');return false;"
                    onblur="javascript:LoseFocusTextBox('txtEmail', 'Email');return false;" /></div>
            <div class="ElementInput">
                <input class="InputSections" type="text" runat="server" id="txtPhone" value="Phone"
                    maxlength="75" onfocus="javascript:SetFocusTextBox('txtPhone', 'Phone');return false;"
                    onblur="javascript:LoseFocusTextBox('txtPhone', 'Phone');return false;" />
            </div>
            <div style="width: 120px; float: left; padding-top: 5px; padding-left: 5px; height: 35px;
                overflow: hidden;">
                <input type="checkbox" id="chkHideEmail" runat="server" style="vertical-align: middle;
                    border: 0px;" />
                <div style="width: 16px; height: 16px; float: left;" onclick="javascript:document.getElementById('SecureInfo').style.display='block';">
                    <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>lock.gif" style="vertical-align: middle"
                        border="0" /></div>
                select to keep your contact info private
                <div id="SecureInfo" style="display: none; position: absolute; color: black;" class="SecureInfoText">
                    Check this box to interact securely via CustomerSupport. The reciepient will not
                    be able to see your email/phone. They may contact you securely via CustomerSupport
                    . <a href="#" onclick="javascript:document.getElementById('SecureInfo').style.display='none';">
                        Close X </a>
                </div>
            </div>
            <div style="width: 120px; float: left; padding-top: 5px; padding-left: 10px;">
            </div>
            <div style="width: 120px; float: left; padding-top: 2px; text-align: center;">
                <a href="javascript: submitform()">
                    <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>widgetlayout/contactus.gif"
                        border="0" /></a>
            </div>
        </div>
        <div style="font-family: Arial; font-size: 10px; float: right;">
            powered by <a href="http://www.delightdesk.com" target="_blank">delightDesk</a></div>
        <div class="WidgetFooter">
            &nbsp;
        </div>
    </div>
    <div style="width: 140px;">
        <div style="background-color: White">
            <asp:Label runat="server" ID="lblConfirmLead" Text="We have recieved your query ,someone will get back to you shortly. "
                Visible="false"></asp:Label></div>
    </div>



    </form>
</body>
</html>
