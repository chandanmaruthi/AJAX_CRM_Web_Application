<%@ Page Language="C#" MasterPageFile="~/home/external.master" AutoEventWireup="true" EnableViewState="false"  Buffer="false"  EnableSessionState="False"
    CodeFile="PricingAndPlans.aspx.cs" Inherits="PricingAndPlans" Title="Pricing and Plans" %>
<%@ OutputCache VaryByParam="none" Location="Server" Duration="3600" %>
<%@ Register Src="~/Webcontrols/Pricing.ascx" TagName="Pricing" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="Server">
    <table width="800" cellpadding="0" cellspacing="0" border="0" >
        <tr>
            <td>
                <div class="Subhead">
                    Pricing And Plans
                </div>
            </td>
        </tr>
        <tr>
            <td align="center">
                
                    <uc2:Pricing ID="Pricing" runat="server" PageAction="HideCart" />
                
            </td>
        </tr>
        <tr>
            <td style="padding-top: 15px;">
                <b>What is the free account?</b>
            </td>
        </tr>
        <tr>
            <td>
                With a free account you get 1 Widget and lead Alerts. You can use your widgets in
                any numbers of sites, web pages and blogs. You can use the free account untill you
                feel you need more widgets so you can have customized context specific interactions
                with your visitors. Also the premium accounts provide complete lead information
                in the email alert itself.
            </td>
        </tr>
        <tr>
            <td style="padding-top: 15px;">
                <b>Can I change from the free plan later?</b>
            </td>
        </tr>
        <tr>
            <td>
                Yes, you can upgrade to a paid plan at anytime from the "My Account" link in your
                delightDeskaccount.
            </td>
        </tr>
        <tr>
            <td style="padding-top: 15px;">
                <b>Can I cancel my subscription at anytime?</b>
            </td>
        </tr>
        <tr>
            <td>
                If you wish to cancel your account, you can email us at <%= CustomerSupport.Utility.SysResource.FromID %> at
                any time during your term.
            </td>
        </tr>
        <tr>
            <td style="padding-top: 15px;">
                <b>What payment methods do you offer at this time?</b>
            </td>
        </tr>
        <tr>
            <td>
                All payments are made via Paypal. Your can pay via Visa, Master and other payment
                methods that you have register for with paypal.
                <br />
                <br />
                About Paypal:<br />
                "PayPal has received more than 20 awards for excellence from the internet industry
                and the business community -most recently the 2006 Webby Award for Best Financial
                Services Site and the 2006 Webby People's Voice Award for Best Financial Services
                Site. Located in San Jose, California, PayPal was founded in 1998"
                Visit Paypal at: http://www.paypal.com/
            </td>
        </tr>
        <tr>
            <td style="padding-top: 15px;">
                <b>What are the requirements to optimally use CustomerSupport?</b>
            </td>
        </tr>
        <tr>
            <td>
            delightDeskhas been tested on most popular browser platforms like Microsoft IE, Mozilla Firefox,
            Apple Safari and Google Chrome. 
            </td>
        </tr>
        <tr>
            <td style="padding-top: 15px;">
                <b>Do you offer a discount for non-profit organizations?</b>
            </td>
        </tr>
    </table>
</asp:Content>
