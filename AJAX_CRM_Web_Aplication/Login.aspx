<%@ Page Language="C#" MasterPageFile="~/home/External.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="_Default" Title="delightDesk- Login " %>

<asp:Content runat="server" ContentPlaceHolderID="ContentBody">
    <table cellpadding="0" cellspacing="0" align="center" border="0" style="width: 350px;
        height: 275px; font-size: 11px; font-family: Arial; font-weight: normal; color: Black;
        display: block; background-color: #ffffff; margin-top: 100px; margin-bottom: 100px;padding-left:10px;padding-top: 5px;
        border: solid 5px #cccccc;" runat="server" id="dvLoginArea">
        <tr>
            <td>
            <span class="MedLabel">Welcome to CustomerSupport</span>
            </td>
        </tr>
        <tr>
            <td>
                <div style="width: 300px; height: 25px; display: block; float: left; "
                    id="LoginValidationMsg" runat="server" visible="false">
                    <asp:Label CssClass="MessageBox" runat="server" ID="ValidationMessage"></asp:Label></div>
            </td>
        </tr>
        <tr>
            <td>
                <div style="display: block; float: left; width: 300px; padding: 2px; text-align: left;
                    vertical-align: bottom;">
                    <b>Email ID</b> </div>
            </td>
        </tr>
        <tr>
            <td>
                <div style="display: block; float: left; width: 300px; padding: 2px; text-align: left;">
                    <input class="MedInput" type="text" maxlength="200" style="width: 200px" id="txtUserName"
                        runat="server"  />
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div style="display: block; float: left; width: 300px; padding: 2px; text-align: left;
                    vertical-align: bottom;">
                    <b> Password</b> </div>
            </td>
        </tr>
        <tr>
            <td>
                <div style="display: block; float: left; width: 300px; padding: 2px; text-align: left;">
                    <input class="MedInput" type="password" style="width: 200px" maxlength="100" id="txtPassword"
                        runat="server"   />
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div style="display: block; float: left; width: 300px; padding: 2px;">
                    <div style="display: block; float: left; width: 75px; padding: 2px;">
                        <asp:LinkButton runat="server" ID="lnkSignUser" CssClass="login" CausesValidation="false"
                            OnClick="lnkSignUser_Click">
                            <div Class="StandardFormButton">Login</div>
                            
                            </asp:LinkButton></div>
                </div>
            </td>
        </tr>
        <tr>
            <td align=left>
                <div style="width: 300px;  border-top:dotted 1px #cccccc;">
                    <ul><li> New user <a href="<%= CustomerSupport.Utility.SysResource.HomePath %>Home/CreateAccount.aspx"
                        style="text-decoration: underline;">Sign Up</a></li><li> <a href="<%= CustomerSupport.Utility.SysResource.HomePath %>home/ForgotPassword.aspx"
                            style="text-decoration: underline;">Forgot Password?</a></li></ul>
                    
                </div>
            </td>
        </tr>
        
    </table>
    <asp:Label runat="server" ID="lblLoginMessage"></asp:Label>

    <script type="text/javascript" language="javascript">
    
function SetFocusTextBox(Field, InitValue)
{
if (document.getElementById(Field).value == InitValue)
{
document.getElementById(Field).value="";
}
}
function LoseFocusTextBox(Field, InitValue)
{
if (document.getElementById(Field).value == "")
{
document.getElementById(Field).value=InitValue;
}
}


    </script>

</asp:Content>
