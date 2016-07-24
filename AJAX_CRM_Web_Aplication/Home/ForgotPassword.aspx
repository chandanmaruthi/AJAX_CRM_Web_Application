<%@ Page Language="C#" MasterPageFile="~/home/External.master" AutoEventWireup="true"  Buffer="false"  EnableSessionState="False"
    CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" Title="delightDesk- Forgot Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="Server">
    <asp:Panel ID="RecoverPassword" runat="server">
        <table cellpadding="0" cellspacing="0" align="center" border="0" style="width: 350px;
            height: 250px; font-size: 11px; font-family: Arial; font-weight: normal; color: Black;
            display: block; background-color: #ffffff; margin-top: 100px; margin-bottom: 100px;
            padding-left: 10px; border: solid 5px #cccccc;" runat="server" id="dvLoginArea">
            <tr>
                <td>
                    <span class="MedLabel">Recover Password</span>
                </td>
            </tr>
            <tr>
                <td>
                    <div runat="server" id="divMessage" visible="false">
                        <asp:Label runat="server" ID="lblMessage"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="display: block; float: left; width: 300px; padding: 2px; text-align: left;
                        vertical-align: bottom;">
                        <b>Email ID</b>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="display: block; float: left; width: 300px; padding: 2px; text-align: left;">
                        <asp:TextBox CssClass="MedInput" ID="txtEmail" runat="server" Width="200px"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="display: block; float: left; width: 300px; padding: 2px;">
                        <asp:LinkButton ID="lnkSubmit" runat="server"  CssClass="StandardFormButton" 
                            OnClick="lnkSubmit_Click">
                             Recover Password
                            
                            </asp:LinkButton>
                    </div>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="ChangePassword" runat="server">
        <table cellpadding="0" cellspacing="0" align="center" border="0" style="width: 350px;
            height: 250px; font-size: 11px; font-family: Arial; font-weight: normal; color: Black;
            display: block; background-color: #ffffff; margin-top: 100px; margin-bottom: 100px;
            padding-left: 10px; border: solid 5px #cccccc;" runat="server" id="Table1">
            <tr>
                <td>
                    <span class="MedLabel">Change Password</span>
                </td>
            </tr>
            <tr>
                <td>
                    <div runat="server" id="divCPMessage" visible="false">
                        <asp:Label runat="server" ID="lblCPMessage"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Validation Code</b>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="lblValidationCode"></asp:Label></td>
            </tr>
            
            <tr>
                <td width="100" align="left">
                    <b>Password</b>
                </td>
            </tr>
            <tr>
                <td width="200">
                    <asp:TextBox CssClass="MedInput" TextMode="password" ID="txtPassword" runat="server"
                        Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="100" align="left">
                    <b>Retype Password</b></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox CssClass="MedInput" TextMode="password" ID="txtVerifyPassword" runat="server"
                        Width="200px"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label runat="server" ID="Label1"></asp:Label>
                                        <asp:CustomValidator runat="server" ID="CustomValidator2" ControlToValidate="txtVerifyPassword"
                        OnServerValidate="CheckPasswords" ErrorMessage="Passwords to not match"></asp:CustomValidator>
                    <asp:LinkButton CssClass="FormButton" ID="lnkChangePassword" runat="server" Text="Change Password"
                        OnClick="lnkChangePassword_Click"></asp:LinkButton>
                </td>
            </tr>
        </table>
        
    </asp:Panel>
</asp:Content>
