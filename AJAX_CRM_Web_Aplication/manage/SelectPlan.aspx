<%@ Page Language="C#" MasterPageFile="~/manage/Internal.master" AutoEventWireup="true" Buffer="false" 
    CodeFile="SelectPlan.aspx.cs" Inherits="BuyLeads" Title="delightDesk- Fillup your account" %>
<%@ Register Src="~/Webcontrols/Pricing.ascx" TagName="Pricing" TagPrefix="uc2" %>
<%@ Register Src="~/Webcontrols/HeaderMenu.ascx" TagName="HeaderMenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <uc1:HeaderMenu ID="HeaderMenu" SetTab="2" runat="server" />
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentBody">
 
        <div style="width: 300px; background-color: Green; border: solid 1px #cccccc;" runat="server"
            id="divMessage" visible="false">
            <asp:Label runat="server" ID="lblMessage"></asp:Label>
        </div>
      
            Select Plan
         
      
     
            <div class="HomeInfoImage" style="height: 800px">
                <uc2:Pricing runat=server ID="Pricing" PageAction="ShowCart" />
            </div>
           
            <div runat="server" id="dvSuccess" visible="false">
                <div class="Subhead">
                    Order Confirmation
                </div>
                <div class="body_textarea">
                    You have Successfully Purchased
                    <asp:Label runat="server" ID="lblCreditPurchaseValue"></asp:Label>
                    credits. You now have
                    <asp:Label runat="server" ID="lblCreditBalance"></asp:Label>
                    credits available. <b>Note: </b>Credit balance may show less that purchased credits
                    if there are any upaid credits in your account.
                </div>
            </div>
      
</asp:Content>
