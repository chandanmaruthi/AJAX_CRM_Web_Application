<%@ Page Language="C#" MasterPageFile="~/manage/Internal.master" AutoEventWireup="true" Buffer="false" 
    CodeFile="RedeemCoupon.aspx.cs" Inherits="RedeemCoupon" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="Server">
<div style="width: 300px; background-color: Green; border: solid 1px #cccccc; color: White;"
        runat="server" id="divMessage" visible="false">
        <asp:Label runat="server" ID="lblMessage"></asp:Label>
    </div>
    <table cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td colspan="3">
                <div class="Subhead">
                    Redeem Coupon
                </div>
            </td>
        </tr>
        <tr>
            <td>
                Have A Coupon ?</td>
            <td>
                <asp:TextBox TextMode="SingleLine" runat="server" ID="txtCouponCode"></asp:TextBox>
            </td>
            <td>
                <span class="FieldInfo">If you have a coupon code enter it here </span>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:LinkButton CssClass="FormButton" runat="server" ID="lnkRedeem" Text="Redeem" OnClick="lnkRedeem_Click"></asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>
