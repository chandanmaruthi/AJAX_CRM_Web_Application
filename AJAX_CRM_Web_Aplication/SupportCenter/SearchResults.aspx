<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="SearchResults.aspx.cs" Inherits="SearchResults" Buffer="false"  %>
<%@ OutputCache VaryByParam="st;PageIndex" Location="Server" Duration="600" %>
<%@ Register src="~/Webcontrols/ItemSearch.ascx" tagname="ItemSearch" tagprefix="uc1" %>

<uc1:ItemSearch ID="ItemSearch1" runat="server" />

