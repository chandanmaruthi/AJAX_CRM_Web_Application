﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SupportCenter/SupportCenterMaster.master" AutoEventWireup="true" CodeFile="Suggestions.aspx.cs" Inherits="manage_Suggestions" Buffer="false"  %>
<%@ Register Src="~/SupportCenter/webcontrols/PortalHeaderMenu.ascx" TagName="PortalHeaderMenu" TagPrefix="uc1" %>

<%@ OutputCache VaryByParam="*" Duration="60" Location="Server" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" Runat="Server">
<uc1:PortalHeaderMenu ID="HeaderMenu" SetTab="3" runat="server" ShowCorpMenu="false" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" Runat="Server">
</asp:Content>