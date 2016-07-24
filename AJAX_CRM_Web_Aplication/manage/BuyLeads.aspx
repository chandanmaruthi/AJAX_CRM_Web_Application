<%@ Page Language="C#" MasterPageFile="~/manage/Internal.master" AutoEventWireup="true" Buffer="false" 
    CodeFile="BuyLeads.aspx.cs" Inherits="BuyLeads" Title="delightDesk- Fillup your account" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentBody">
    
        <div style="width: 300px; background-color: Green; border: solid 1px #cccccc;" runat="server"
            id="divMessage" visible="false">
            <asp:Label runat="server" ID="lblMessage"></asp:Label>
        </div>
       
            Add Credits
     
            <table cellpadding="0" cellspacing="0" border="0" width="600px">
                <tr class="TableHeader">
                    <td style="width: 150px;">
                        Package</td>
                    <td style="width: 300px;">
                        What you get</td>
                    <td style="width: 100px;">
                        Cost</td>
                    <td style="width: 100px;">
                        Buy Now</td>
                </tr>
                <tr class="Table_Row" style="height:50px">
                    <td>
                        Quick Update Package</td>
                    <td>
                        You get 20 lead credits worth $10 charged at 50 cents a lead</td>
                    <td>
                        <b>$10 USD</b></td>
                    <td>
                        <form action="https://www.paypal.com/cgi-bin/webscr" method="post">
                            <input type="hidden" name="cmd" value="_s-xclick">
                            <input type="hidden" name="hosted_button_id" value="3646326">
                            <input style="border: 0px;" type="image" src="https://www.paypal.com/en_US/i/btn/btn_buynowCC_LG_global.gif"
                                border="0" name="submit" alt="PayPal - The safer, easier way to pay online.">
                            <img alt="" border="0" src="https://www.paypal.com/en_US/i/scr/pixel.gif" width="1"
                                height="1">
                        </form>
                    </td>
                </tr>
                <tr class="Table_Row" style="height:50px">
                    <td>
                        Economy Package</td>
                    <td>
                        Save $10USD immediately with this package. Your get 120 Leads worth $60USD at just
                        $49USD.
                    </td>
                    <td>
                        <b>$49 USD</b></td>
                    <td>
                        <form action="https://www.paypal.com/cgi-bin/webscr" method="post">
                            <input type="hidden" name="cmd" value="_s-xclick">
                            <input type="hidden" name="hosted_button_id" value="3646595">
                            <input style="border: 0px;" type="image" src="https://www.paypal.com/en_US/i/btn/btn_buynowCC_LG_global.gif"
                                border="0" name="submit" alt="PayPal - The safer, easier way to pay online.">
                            <img alt="" border="0" src="https://www.paypal.com/en_US/i/scr/pixel.gif" width="1"
                                height="1">
                        </form>
                    </td>
                </tr>
                <tr class="Table_Row" style="height:50px">
                    <td>
                        Deluxe Package</td>
                    <td>
                        Save a whoping 25 dollars and Get 250 Leads for just $100 USD .</td>
                    <td>
                        <b>$99USD</b></td>
                    <td>
                        <form action="https://www.paypal.com/cgi-bin/webscr" method="post">
                            <input type="hidden" name="cmd" value="_s-xclick">
                            <input type="hidden" name="hosted_button_id" value="3646623">
                            <input style="border: 0px;" type="image" src="https://www.paypal.com/en_US/i/btn/btn_buynowCC_LG_global.gif"
                                border="0" name="submit" alt="PayPal - The safer, easier way to pay online.">
                            <img alt="" border="0" src="https://www.paypal.com/en_US/i/scr/pixel.gif" width="1"
                                height="1">
                        </form>
                    </td>
                </tr>
            </table>
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
