<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Pricing.ascx.cs" Inherits="Webcontrols_Pricing" %>
<table width="750px" cellpadding="0" cellspacing="0" border="0" align="center">
    <tr>
        <td class="PlanHeader">
            <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>Plan_25.gif" border=0 />
        </td>
        <td class="PlanHeader">
            <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>Plan_10.gif" border=0 />
        </td>
        <td class="PlanHeader">
            <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>Plan_5.gif" border=0 />
        </td>
        <td class="PlanHeader">
            <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>Plan_2.gif" border=0 />
        </td>
        <td class="PlanHeader">
            <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>Plan_1.gif" border=0 />
        </td>
    </tr>
    <tr>
        <td class="PlanItems">
            <h2>
                $475/Month</h2>
        </td>
        <td class="PlanItems">
            <h2>
                $190/Month</h2>
        </td>
        <td class="PlanItems">
            <h2>
                $95/Month</h2>
        </td>
        <td class="PlanItems">
            <h2>
                $38/Month</h2>
        </td>
        <td class="PlanItems">
            <h2>
                $19/Month
                </h2>
        </td>
    </tr>
    <tr>
        <td class="PlanItems" valign=bottom>
            <a href="<%= CustomerSupport.Utility.SysResource.HomePath %>Home/CreateAccount.aspx?Plan=25">
                <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>Signup.gif" border="0" />
            </a>
        </td>
        <td class="PlanItems" valign=bottom>
            <div id="sPlanC" runat="server" visible="false">
                <a href="<%= CustomerSupport.Utility.SysResource.HomePath %>Home/CreateAccount.aspx?Plan=10">
                    <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>Signup.gif" border="0" /></a>
            </div>
            <div id="PlanC" runat="server" visible="false">Pay with Paypal
              </form>
  <form action="https://www.paypal.com/cgi-bin/webscr" method="post">
                    <input type="hidden" name="cmd" value="_s-xclick">
                    <input type="hidden" name="hosted_button_id" value="4521330">
                    <input type="image" src="https://www.paypal.com/en_US/i/btn/btn_subscribeCC_LG_global.gif"
                        border="0" name="submit" alt="PayPal - The safer, easier way to pay online."
                        style="height: 47px; width: 122px; border: 0px;">
                        
                    <img alt="" border="0" src="https://www.paypal.com/en_US/i/scr/pixel.gif" width="1"
                        height="1">
                </form>
            </div>
        </td>
        <td class="PlanItems" valign=bottom>
            <div id="sPlanB" runat="server" visible="false">
                <a href="<%= CustomerSupport.Utility.SysResource.HomePath %>Home/CreateAccount.aspx?Plan=5">
                    <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>Signup.gif" border="0" /></a>
            </div>
            <div id="PlanB" runat="server" visible="false">Pay with Paypal
                <form action="https://www.paypal.com/cgi-bin/webscr" method="post">
                    <input type="hidden" name="cmd" value="_s-xclick">
                    <input type="hidden" name="hosted_button_id" value="4521304">
                    <input type="image" src="https://www.paypal.com/en_US/i/btn/btn_subscribeCC_LG_global.gif"
                        border="0" name="submit" alt="PayPal - The safer, easier way to pay online."
                        style="height: 47px; width: 122px; border: 0px;">
                    <img alt="" border="0" src="https://www.paypal.com/en_US/i/scr/pixel.gif" width="1"
                        height="1">
                </form>
            </div>
        </td>
        <td class="PlanItems" valign=bottom>
            <div id="sPlanA" runat="server" visible="false">
                <a href="<%= CustomerSupport.Utility.SysResource.HomePath %>Home/CreateAccount.aspx?Plan=2">
                    <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>Signup.gif" border="0" /></a>
            </div>
            <div id="PlanA" runat="server" visible="false">Pay with Paypal
                <form action="https://www.paypal.com/cgi-bin/webscr" method="post">
                    <input type="hidden" name="cmd" value="_s-xclick">
                    <input type="hidden" name="hosted_button_id" value="4521283">
                    <input type="image" src="https://www.paypal.com/en_US/i/btn/btn_subscribeCC_LG_global.gif"
                        border="0" name="submit" alt="PayPal - The safer, easier way to pay online."
                        style="height: 47px; width: 122px; border: 0px;">
                    <img alt="" border="0" src="https://www.paypal.com/en_US/i/scr/pixel.gif" width="1"
                        height="1">
                </form>
            </div>
        </td>
        <td class="PlanItems" valign=bottom>
        <div id="sPlanF" runat="server" visible="false">
        <a href="<%= CustomerSupport.Utility.SysResource.HomePath %>Home/CreateAccount.aspx?Plan=1">
                <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>Signup.gif" border="0" /></a>
        </div><div id="PlanF" runat="server" visible="false">
            <a href="<%= CustomerSupport.Utility.SysResource.HomePath %>Welcome.aspx">
                <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>Signup.gif" border="0" /></a></div>
        </td>
    </tr>
   
</table>

