<%@ Page Language="C#" MasterPageFile="~/home/External.master"  EnableViewState="false" AutoEventWireup="true" CodeFile="FAQ.aspx.cs" Inherits="Home_FAQ" Title="Untitled Page"  Buffer="false"  EnableSessionState="False"  %>
<%@ OutputCache VaryByParam="none" Location="Server" Duration="3600" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" Runat="Server">
<style type='text/css'>@import url('http://s3.amazonaws.com/getsatisfaction.com/feedback/feedback.css');</style>
<script src='http://s3.amazonaws.com/getsatisfaction.com/feedback/feedback.js' type='text/javascript'></script>
<script type="text/javascript" charset="utf-8">
  var tab_options = {}
  tab_options.placement = "left";  // left, right, bottom, hidden
  tab_options.color = "#222"; // hex (#FF0000) or color (red)
  GSFN.feedback('http://getsatisfaction.com/CustomerSupport/feedback/topics/new?display=overlay&style=idea', tab_options);
</script>
</asp:Content>

