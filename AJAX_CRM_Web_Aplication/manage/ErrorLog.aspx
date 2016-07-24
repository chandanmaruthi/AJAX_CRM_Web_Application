<%@ Page Language="C#" Buffer="false"  MasterPageFile="~/manage/Internal.master" AutoEventWireup="true"
    CodeFile="ErrorLog.aspx.cs" Inherits="ErrorLog" Title="Error Log" %>

<%@ Register Src="~/Webcontrols/HeaderMenu.ascx" TagName="HeaderMenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="Server">
    <uc1:HeaderMenu ID="HeaderMenu" SetTab="1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="Server">
    <div class="PageContainer">
        <div class="PageHeader">
            Error Log: Last 25 errors</div>
        <asp:Repeater runat="server" ID="rptrErrorLog">
            <HeaderTemplate>
                <table style="font-size: 11px; font-family: Arial;" cellpadding="0" cellspacing="0"
                    border="0">
                    <tr>
                        <td width="100px">
                            Time</td>
                        <td width="700px">
                            Error Description</td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td style="font-size: 8px; font-family: Arial; border-bottom: solid 2px #404040;">
                        <%# Eval("Error_Time")%>
                    </td>
                    <td style="font-size: 11px; font-family: Arial; border-bottom: solid 2px #404040;
                        color: Blue;">
                        Error Page:<%# Eval("Page_Name")%><br />
                        Website :
                        <%# Eval("Website_URL")%>
                        <br />
                        <div style="width: 700px; height: 250px; overflow: auto;">
                            <pre><%# Eval("Error_Desc")%></pre>
                        </div>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
