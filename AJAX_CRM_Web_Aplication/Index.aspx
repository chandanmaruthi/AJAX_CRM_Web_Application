<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs"  EnableSessionState="False" EnableViewState="false"
    Inherits="_Index" EnableEventValidation="false" MasterPageFile="home/External.master"
    Title="Welcome to delightDesk - Customer Service Platfrom, Capture, Repond, publish and serve customer requests" %>

<%@ OutputCache VaryByParam="none" Location="Server" Duration="3600" %>
<%@ Register Src="~/Webcontrols/Pricing.ascx" TagName="Pricing" TagPrefix="uc2" %>
<asp:Content ContentPlaceHolderID="ContentBody" runat="server">
    <div class="ContentBody">
        <div class="HomeInfoContainer">
            <div id="HomeImage1" class="HomeInfoText">

                        
               <div style="width: 360px; height: 80px; margin-bottom: 15px; margin-top: 15px; float: left;
                    text-align: left;">
                    <h1 style="text-align: center; font-weight: bold;">
                        Continous Customer Success
                    </h1>
                </div>
                <div style="width: 360px; height: 50px; float: left; text-align: left; margin-bottom: 15px;">
                    <h2 style="text-align: center;">
                        because you love customers
                    </h2>
                </div>
                <div style="width: 360px; height: 120px; float: left; text-align: left; overflow: hidden;
                    margin-bottom: 10px;">
                    <ul style="font-size: 15px">
                        <li style="line-height: 1.6em;">
                            <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>tick.gif" style="vertical-align: middle;"
                                border="0" />
                            &nbsp; Track your customer feedback on every transaction </li>
                        <li style="line-height: 1.6em;">
                            <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>tick.gif" style="vertical-align: middle;"
                                border="0" />
                            &nbsp; Centrally Address all customer issues</li>
                        <li style="line-height: 1.6em;">
                            <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>tick.gif" style="vertical-align: middle;"
                                border="0" />
                            &nbsp; Let Customers Interact with each other at the Center to </li>
                        <li style="line-height: 1.6em;">
                            <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>tick.gif" style="vertical-align: middle;"
                                border="0" />
                            &nbsp; Let Customers Interact with each other at the Center to </li>
                                  <li style="line-height: 1.6em;">
                            <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>tick.gif" style="vertical-align: middle;"
                                border="0" />
                            &nbsp; Continuously Improve your offerings </li>
                    </ul> 
                </div>
                <div style="width: 354px; height: 63px; float: left; text-align: center; background-image: url(common/images/tryitNowBg.gif);
                    background-repeat: no-repeat;">
                    <a href="<%= CustomerSupport.Utility.SysResource.HomePath %>home/CreateAccount.aspx"
                        style="font-size: 24px; font-weight: bold; font-family: Georgia,Arial; text-decoration: underline;
                        line-height: 1.3em;">Try It Now </a>
                    <br />
                    <a href="<%= CustomerSupport.Utility.SysResource.HomePath %>home/CreateAccount.aspx"
                        style="font-size: 14px; font-weight: bold; font-family: Georgia,Arial; text-decoration: none;
                        line-height: 1.3em;">30 day free Trial, Signup in 60 Seconds </a>
                </div>
            </div>
            <div class="HomeInfoImage">
                <img alt="About" src="<%= CustomerSupport.Utility.SysResource.ImagePath %>Home01.gif"
                    border="0" />
            </div>
        </div>
        <table border="0" cellpadding="0" cellspacing="0">
            <%--        <tr>
                    <td colspan="2" style="padding-top: 10px;">
                        <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>PublishDirectlyBanner.jpg"
                            border="0" alt="Publish delightDeskWidgets directly to popular online platforms" />
                       
                    </td>
                </tr>--%>
            <%--<tr>
                <td style="padding-top: 15px;">
                    
                </td>
                <td style="padding-top: 10px;">
                    <div style="width: 440px">
                        
                        <a href="https://login.salesforce.com/?startURL=%2Fpackaging%2FinstallPackage.apexp%3Fp0%3D04t900000004df2"
                            title="Install the delightDeskSalesforce App">
                            <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>SalesForceBanner.jpg"
                                border="0" alt="Install the delightDeskapp for Salesforce" /></a>
                    </div>
                </td>
            </tr>--%>
            <tr>
                <td valign="top" colspan="2" style="padding-top: 10px;">
                    <span class="SectionHeader">Take A Tour</span>
                    <td>
            </tr>
            <tr>
                <td colspan="2" height="150px" align="center">
                    <div style="width: 190px; height: 130px; float: left;">
                        <a href="<%= CustomerSupport.Utility.SysResource.HomePath %>home/Tour.aspx">
                            <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>Tour/WidgetDesign_Small.gif"
                                border="0" />
                        </a>Customize Your Widgets
                    </div>
                    <div style="width: 190px; height: 130px; float: left;">
                        <a href="<%= CustomerSupport.Utility.SysResource.HomePath %>home/Tour.aspx">
                            <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>Tour/MyLeads_Small.gif"
                                border="0" />
                        </a>Capture, Track, Follow-up with leads
                    </div>
                    <div style="width: 190px; height: 130px; float: left;">
                        <a href="<%= CustomerSupport.Utility.SysResource.HomePath %>home/Tour.aspx">
                            <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>Tour/LeadNotes_small.gif"
                                border="0" />
                        </a>Track Account Activity & closure
                    </div>
                    <div style="width: 190px; height: 130px; float: left;">
                        <a href="<%= CustomerSupport.Utility.SysResource.HomePath %>home/Tour.aspx">
                            <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>Tour/SendEmail_small.gif"
                                border="0" />
                        </a>Interact Securely with Contacts
                    </div>
                    <div style="width: 190px; height: 130px; float: left;">
                        <a href="<%= CustomerSupport.Utility.SysResource.HomePath %>home/Videos.aspx">
                            <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>Tour/Video_Small.gif"
                                border="0" />
                        </a>Quick Video walkthrough
                    </div>
                </td>
            </tr>
            <tr>
                <td valign="top" align="center">
                    <b>Powerful Customer Support Solution</b><br />
                    <span style="background-color: #ffffff">Capture, Respond, Track, Manage Customer Interactions</span><br />
                    <br />
                    <b>Instant Customer Support Portal</b><br />
                    <span style="background-color: #ffffff">Searchable, categorized knowledge system</span><br />
                    <br />
                    <b>Easy to use for you as well as your customer</b><br />
                    <span style="background-color: #ffffff">No learning curve , really simple</span><br />
                    <br />
                    <b>Automalically Creates a Knowledge base</b><br />
                    <span style="background-color: #ffffff">Every Custommer support issue gets added into
                        the knowledge base</span><br />
                    <br />
                    <b>Grows as you Serve</b><br />
                    <span style="background-color: #ffffff">Over time the Knowldge base helps customer serve
                        themselves</span><br />
                    <br />
                    <b>Customer Driven Knowledge Base</b><br />
                    <span style="background-color: #ffffff">Customers can explore, interact and share knowledge
                        in the knowledge base</span><br />
                    <br />
                </td>
                <td width="450px">
                    <%--<div style="width: 500px; height: 100px;">
                        <div style="width: 100px; height: 100px; float: left; padding-top: 5px;">
                            <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>DavidPethrickPhoto.jpg"
                                border="0" />
                        </div>
                        <div style="width: 400px; height: 100px; float: left">
                            <div style="width: 400px; height: 60px; float: left; font-size: 12px;">
                                <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>QuoteStart.gif" style="vertical-align: middle;"
                                    border="0" />
                                delightDeskcertainly works well, It is a fast, easy and painless way to gather
                                contact details reliably from a web page, and then have them stored in an easy to
                                access ...online database
                                <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>QuoteEnd.gif" style="vertical-align: middle;"
                                    border="0" /></div>
                            <div style="width: 400px; height: 15px; float: left; font-family: Arial; font-size: 11px;
                                font-weight: bold; margin-top: 10px;">
                                David Petherick</div>
                            <div style="width: 400px; height: 15px; float: left; font-family: Arial; font-size: 11px;
                                font-weight: normal;">
                                UK Editor at The Next Web</div>
                        </div>
                    </div>
                    <div style="width: 500px; height: 100px; float: left; padding-top: 5px;">
                        <div style="width: 100px; height: 100px; float: left">
                            <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>SameerGuglaniPhoto.jpg"
                                border="0" />
                        </div>
                        <div style="width: 400px; height: 100px; float: left">
                            <div style="width: 400px; height: 60px; float: left; font-size: 12px;">
                                <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>QuoteStart.gif" style="vertical-align: middle;"
                                    border="0" />
                                delightDeskallowed me to create and publish my first widget to word press very
                                quickly & easily. And manage leads a via the full featured lead-manager. 
                                <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>QuoteEnd.gif" style="vertical-align: middle;"
                                    border="0" /></div>
                            <div style="width: 400px; height: 15px; float: left; font-family: Arial; font-size: 11px;
                                font-weight: bold; margin-top: 10px;">
                                Sameer Guglani</div>
                            <div style="width: 400px; height: 15px; float: left; font-family: Arial; font-size: 11px;
                                font-weight: normal;">
                                Morpheus Venture Partners</div>
                        </div>
                    </div>--%>
                  

<div id="twtr-profile-widget"></div>
<script src="http://widgets.twimg.com/j/1/widget.js"></script>
<link href="http://widgets.twimg.com/j/1/widget.css" type="text/css" rel="stylesheet">
<script>
new TWTR.Widget({
  profile: true,
  id: 'twtr-profile-widget',
  loop: true,
  width: 200,
  height: 300,
  theme: {
    shell: {
      background: '#d5fa84',
      color: '#ffffff'
    },
    tweets: {
      background: '#ffffff',
      color: '#444444',
      links: '#1985b5'
    }
  }
}).render().setProfile('delightdesk').start();
</script>
                </td>
            </tr>
            <tr>
                <td valign="top" colspan="2">
                    <span class="SectionHeader">Plans and Pricing</span>
                    <td>
            </tr>
            <tr>
                <td colspan="2">
                    <div>
                        <table>
                            <tr>
                                <td rowspan="2" width="650" valign="top">
                                    <a target="#Pricing">
                                        <uc2:Pricing ID="Pricing" runat="server" PageAction="HideCart" />
                                    </a>
                                </td>
                                <td width="200">
                                    Standard Features ..
                                </td>
                            </tr>
                            <tr>
                                <td width="200" valign="top">
                                    <div style="width: 200px">
                                        <ul class="List">
                                            <li><a href="PlanFeatures.aspx#SSLSecurity">SSL Security</a> </li>
                                            <li><a href="PlanFeatures.aspx#SSLSecurity">Customizable Widgets</a></li>
                                            <li><a href="PlanFeatures.aspx#SSLSecurity">Branding</a></li>
                                            <li><a href="PlanFeatures.aspx#SSLSecurity">Custom URL</a></li>
                                            <li><a href="PlanFeatures.aspx#SSLSecurity">Data Backup</a></li>
                                            <li><a href="PlanFeatures.aspx#SSLSecurity">--</a></li>
                                            <li><a href="PlanFeatures.aspx#SSLSecurity">--</a></li>
                                        </ul>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <div style="margin: 0pt; text-align: center;" class="AlertInfo">
                                        <h2 style="font-size: 14px; font-weight: bold; margin-bottom: 0pt;">
                                            Pay as you go , Cancel at any time. No long-term contracts or sign-up/termination
                                            fees.</h2>
                                        <p>
                                            Not sure which plan to choose? Pick any - you can always change it later. All plans
                                            come with an initial <strong>30 day free trial</strong>. <a href="<%= CustomerSupport.Utility.SysResource.HomePath %>home/PricingAndPlans.aspx">Lean More </a> </p>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
