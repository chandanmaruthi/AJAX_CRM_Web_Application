<%@ Page Language="C#" MasterPageFile="~/home/External.master" AutoEventWireup="true" EnableViewState="false"  Buffer="false"  EnableSessionState="False"
    CodeFile="ContactUs.aspx.cs" Inherits="Home_ContactUs" Title="delightDesk- Contact Us" %>
<%@ OutputCache VaryByParam="none" Location="Server" Duration="3600" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="Server">
    <div class="body_textarea">
        <table width="600px" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <div class="Subhead">
                        Contact Us:
                        <br />
                        <br />
                        Ofcourse we use delightDeskfor all our web customer relationship
                        management
                    </div>
                    <br />
                    <div class="Subhead">If you want to Speak to Us, Call us at</div>
                    Phone: USA 213-814-1036<br />
                    <br />
                    <div class="Subhead">You can also email us at</div>
                    Email: <%= CustomerSupport.Utility.SysResource.FromID %><br />
                    <br />
                </td>
                <td>
                    <iframe width='170px' frameborder='0' height='370px' style='overflow: hidden; border: solid 0px;'
                        src='http://www.CustomerSupport.com/Widget.aspx?id=d827ed33-2199-4887-bc93-f78392373414&Show=V'
                        allowtransparency='true'></iframe>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
