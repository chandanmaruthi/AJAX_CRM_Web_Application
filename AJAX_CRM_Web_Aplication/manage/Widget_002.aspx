<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Widget_002.aspx.cs"
    Inherits="Widget_002" %>

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
            font-family: arial;
        }
        .WidgetContainer
        {
            width: 600px;
            height: 350px;
            overflow: hidden;
            background-color: #f5f5f5;
            color: #000000;
            background-position: 100px 0px;
            border: solid 1px #eeeeee;
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
            width: 180px;
            float: left;
            padding-top: 2px;
            font-size: 18px;
            height: 25px;
        }
        .WidgetArrow
        {
            width: 10px;
            height: 32px;
            padding: 0px;
            display: block;
            float: left;
        }
        .WidgetHeader
        {
            width: 580px;
            height: 30px;
            padding: 5px; /*background-image: url('<%= CustomerSupport.Utility.SysResource.ImagePath %>WidgetLayout/WidgetHeader_1.gif');-*/
            background-repeat: no-repeat;
            display: block;
            float: left;
            color: #000000;
            font-size: 20px;
        }
        .WidgetMiddle
        {
            width: 580px; /*background-image: url('<%= CustomerSupport.Utility.SysResource.ImagePath %>WidgetLayout/WidgetMiddle_1.gif');*/
            height: 280px;
            background-repeat: repeat-y;
            float: left;
            padding-left: 5px;
        }
        .WidgetFooter
        {
            width: 580px;
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
            height: 20px;
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
            width: 180px;
            float: left;
            padding: 2px;
            padding-bottom: 0px;
        }
        .ElementLabel
        {
            float: left;
            padding: 2px;
            padding-bottom: 0px;
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
    <form id="CustomerSupportForm" name="CustomerSupportForm" method="post" action="<%= CustomerSupport.Utility.SysResource.HomePath %>manage/ProcessWidget_002.aspx">
    <input type="hidden" name="hdnUrl" id="hdnUrl" />
    <input type="hidden" name="hdnAccountID" id="hdnAccountID" value="<%= strAccountID %>" />
    <div id="dvForm" class="WidgetContainer" runat="server">
        <div class="WidgetHeader">
            Hellow World
        </div>
        <div class="WidgetMiddle">
            <asp:Panel runat="server" ID="pnlQuestions">
            </asp:Panel>
            <div class="ElementLabel">
                <asp:Label runat="server" ID="lblMessageTitle" Text="Title" Width="120px"></asp:Label>
            </div>
            <div class="ElementInput" style="width: 580px;">
                <input class="InputSections" type="text" runat="server" id="txtMessageTitle" style="width: 580px;" />
            </div>
            <div class="ElementLabel">
                <asp:Label runat="server" ID="lblMessageDesc" Text="Description" Width="120px"></asp:Label>
            </div>
            <div class="ElementInput" style="width: 580px; height: 150px">
                <input class="InputSections" type="text" runat="server" id="txtMessageDesc" style="width: 580px;
                    height: 150px" />
            </div>
            <div class="ElementInput">
                Name
                <input class="InputSections" type="text" runat="server" id="txtName" value="Name"
                    maxlength="75" /></div>
            <div class="ElementInput">
                Email
                <input class="InputSections" type="text" runat="server" id="txtEmail" value="Email"
                    maxlength="75" /></div>
            <div class="ElementInput">
                Phone
                <input class="InputSections" type="text" runat="server" id="txtPhone" value="Phone"
                    maxlength="75" />
            </div>
            <div style="width: 120px; float: left; padding-top: 5px; padding-left: 10px;">
            </div>
            <div style="width: 120px; float: right; padding-top: 2px;">
                <a href="javascript: submitform()" >
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
    
    </form>
</body>
</html>
