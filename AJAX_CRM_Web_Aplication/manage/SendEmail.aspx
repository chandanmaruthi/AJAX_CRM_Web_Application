<%@ Page Language="C#" MasterPageFile="~/manage/Popups.master" Buffer="false"  AutoEventWireup="true" CodeFile="SendEmail.aspx.cs" Inherits="Help" Title="Send Email" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
 <div class="head">
            Send Email
        </div><br /><br />
<span class="Subhead">Message</span> 
<div class="body_textarea">
<textarea id="txtMessage" runat=server style="width:400px;height:200px;font-size:11px;font-family:Arial">Type your message here
</textarea><br />
<asp:LinkButton CssClass="FormButton" ID="lnkSendEmail" runat=server Text="Send Email" OnClick="lnkSendEmail_Click"    ></asp:LinkButton>
<asp:Label runat=server ID="lblMessage"></asp:Label>
</div>
</asp:Content>

