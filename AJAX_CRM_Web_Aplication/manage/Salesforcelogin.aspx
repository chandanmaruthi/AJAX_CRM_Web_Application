<%@ Page Language="C#" MasterPageFile="~/manage/Internal.master" AutoEventWireup="true" Buffer="false" 
    CodeFile="Salesforcelogin.aspx.cs" Inherits="Salesforcelogin" Title="delightDeskSaleForceGateway" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="Server">
  
            <div style="width: 500px; height: 300px; background-color: #F7FFC9" runat="server"
                id="dvNotRegistered">
                <table>
                    <tr>
                        <td>
                         
                                You Have Not Yet Configured delightDeskFor Salesforce
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <ol>
                                <li>[PS: Salesforce Integration is available for Standard and Power Plans] </li>
                                <li>Signup/Login to delightDesk</li>
                                <li>Go to "MyAccount" Tab</li>
                                <li>Enter your Saleforce Organization ID and Save
                                    <br />
                                    Your Organization id is <b>
                                        <asp:Label ID="lblOrdId" runat="server"></asp:Label></b> </li>
                                <li>Add the delightDeskApp to your account in Salesforce</li>
                                <li>Click on the delightDeskTab in Salesforce, you are automatically logged in</li>
                            </ol>
                        </td>
                    </tr>
                </table>
            </div>
     
</asp:Content>
