<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProcessWidget_002.aspx.cs"
    Inherits="ProcessWidget" Buffer="false" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>delightDeskWidget</title>
    <style type="text/css">
   
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
    <div style="width: 140px;">
        <div style="background-color: White">
            <asp:Label runat="server" ID="lblConfirmLead" Text="We have recieved your query ,someone will get back to you shortly. "
                Visible="false"></asp:Label></div>
    </div>
    </form>
</body>
</html>
