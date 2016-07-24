<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HandleCreateAccount.aspx.cs" Inherits="Partials_HandleCreateAccount" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>LeadNotes</title>
</head>
<body>
    <asp:Panel ID="pnlCheckAccountName" runat=server Visible=false>
    <div class="CheckNotOk" runat="server" visible="false" id="divAccountNameTaken">Name Taken, Use Another Name</div>
    <div class="CheckOk" runat="server"  visible="false"  id="divAccountNameAvailable">Name Available</div>
    
   </asp:Panel>
   <asp:Panel ID="pnlCheckEmail" runat=server Visible=false>
   <div   class="CheckNotOk" runat="server"  visible="false" id="divEmailTaken">Email Taken, Use Another Email</div>
    <div  class="CheckOk" runat="server"   visible="false" id="divEmailAvailable">Email Available</div>
   </asp:Panel>
   
</body>
</html>
 