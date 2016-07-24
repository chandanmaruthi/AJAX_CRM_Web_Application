<%@ Page Language="C#" MasterPageFile="~/manage/Internal.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="ManageAccount.aspx.cs" Inherits="_Default" Buffer="false"    
    Title="delightDesk- Manage My Account" %>

<%@ Register Src="~/Webcontrols/Pricing.ascx" TagName="Pricing" TagPrefix="uc2" %>
<%@ Register Src="~/Webcontrols/HeaderMenu.ascx" TagName="HeaderMenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <uc1:HeaderMenu ID="HeaderMenu" SetTab="5" runat="server" ShowCorpMenu="true" />
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentBody">
    <div class="PageContainer">
        <div class="PageHeader">
            Manage Account</div>
        
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td colspan="8">
                            <div class="Message" runat="server" id="divMessage" visible="false">
                                <asp:Label runat="server" ID="lblMessage"></asp:Label>
                            </div>
                            <div class="Subhead">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Full Name
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtName"></asp:TextBox><span class="Required">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="txtName"
                                runat="server" ErrorMessage="required"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Email ID
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtEmailID" Enabled="false"></asp:TextBox><span class="Required">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtEmailID"
                                runat="server" ErrorMessage="required"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <span class="FieldInfo">your email id will be your login id</span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Contact Phone
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtPhone"></asp:TextBox>
                        </td>
                        <td>
                            <span class="FieldInfo">used to send sms alerts for leads. </span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Contact Email
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtContactEmail"></asp:TextBox><span class="Required">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtName"
                                runat="server" ErrorMessage="required"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <span class="FieldInfo">used to send email alerts for leads</span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            SalesForce Org Id
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtSalesForceOrgId"></asp:TextBox>
                        </td>
                        <td>
                            <span class="FieldInfo">Access delightDeskDirectly in Sales Force. Enter your Salesforce
                                Organization ID</span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:LinkButton CssClass="login" runat="server" ID="lnkSave" OnClick="lnkSave_Click"> Save </asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            Have a Coupon Redeem it Now ! <a href="<%=CustomerSupport.Utility.SysResource.HomePath %>RedeemCoupon.aspx">
                                <b>click here</b></a>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <div class="Subhead">
                                Your Subcription Plan :
                                <label id="lblPlan" runat="server">
                                </label>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            <div class="HomeInfoImage">
                                <uc2:Pricing ID="Pricing" runat="server" PageAction="ShowCart" />
                            </div>
                        </td>
                    </tr>
                </table>
         
    </div>
</asp:Content>
