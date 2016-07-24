<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WidgetList.ascx.cs" Inherits="Webcontrols_WidgetList" %>
<div class="WidgetListBoxContainer">
    <div style="width: 150px; height: 20px; display: block; float: left;">
        <span class="SimpleHeader">My Widgets</span>
    </div>
    <div style="width: 150px; display: block; float: left;">
        <%= strUpgradeMessage  %>
    </div>
    <div runat="server" ID="lnkAddNewDiv" class="WidgetListBox" style="background-color: #efefef; height: 20px;">
        <asp:LinkButton runat="server" ID="lnkAddNew" Text="Add New Widget" OnClick="lnkAddNew_Click">  Add New Widget <img src="<%= CustomerSupport.Utility.SysResource.ImagePath%>add.png" style="vertical-align:middle;" border="0"  /></asp:LinkButton>
    </div>
    <asp:Repeater runat="server" ID="rptrViewWidgets">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
            <div class="WidgetListBox">
                <div style="width: 125px; height: 16px; float: left">
                    <a href="<%= CustomerSupport.Utility.SysResource.HomePath + "manage/SetupWidget.aspx?Action=Edit&ID=" %><%# Eval("Widget_ID") %>">
                        <span style="font-size: 12px;">
                            <%# Eval("Widget_Name") %>
                        </span></a>
                </div>
                <div style="width: 20px; height: 16px; float: right">
                    <a href="<%= CustomerSupport.Utility.SysResource.HomePath + "manage/SetupWidget.aspx?Action=Delete&ID=" %><%# Eval("Widget_ID") %>"
                        onclick="return confirm('Are you sure you want to delete? Delete cannot be undone.')">
                        <img src="<%= CustomerSupport.Utility.SysResource.ImagePath + "delete.png" %>" alt="Delete"
                            style="vertical-align: middle;" title="Delete" border="0" /></a> </a></div>
                <div style="width: 20px; height: 16px; float: right">
                    <a href="<%= CustomerSupport.Utility.SysResource.HomePath + "manage/SetupWidget.aspx?Action=Edit&ID=" %><%# Eval("Widget_ID") %>">
                        <img src="<%= CustomerSupport.Utility.SysResource.ImagePath + "email_edit.png" %>" style="vertical-align: middle;"
                            alt="Edit" title="Edit" border="0" />
                    </a>
                </div>
            </div>
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
    </asp:Repeater>
</div>
