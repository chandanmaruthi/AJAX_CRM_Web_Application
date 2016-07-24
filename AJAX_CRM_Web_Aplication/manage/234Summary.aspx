<%@ Page Language="C#" MasterPageFile="~/manage/Internal.master" Buffer="false"  AutoEventWireup="true" CodeFile="234Summary.aspx.cs" Inherits="CustomerSupportSummary" Title="Summary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" Runat="Server">

<asp:Repeater runat=server ID="rptrSummary" >
<HeaderTemplate>
<table>
<tr>
<td><b>Account Holder</b></td>
<td><b>Widgets</b></td>
<td><b>Leads</b></td>
<td><b>Plan</b></td>
<td></td>
</tr>

</HeaderTemplate>
<ItemTemplate>
<tr>
<td><%# Eval("First_Name") %><%# Eval("Last_Name")%></td>
<td><%# Eval("Account_Widgets")%></td>
<td><%# Eval("Account_Leads")%></td>
<td><%# Eval("Subscription_Plan")%></td>
<td></td>
</tr>

</ItemTemplate>
<FooterTemplate>
</table>
</FooterTemplate>
</asp:Repeater>

</asp:Content>
