<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RightMenu.ascx.cs" Inherits="Webcontrols_RightMenu" %>
<%@ OutputCache VaryByParam="*" Duration="60" %>
<div style="width: 180px; border: solid 0px #cccccc; margin: 2px; float: left;">
    <div style="width: 200px;">
        <h2>
            Products</h2>
    </div>
    <div style="width: 180px; padding: 2px;">
        <asp:Repeater ID="rptrProducts" runat="server">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <div style="height: 40px; width: 200px; float: left; margin: 5px;">
                        <div style="height: 40px; width: 40px; float: left; background-color: #cccccc;">
                        </div>
                        <div style="height: 40px; width: 140px; float: left; margin-left: 5px">
                            <div style="height: 20px; width: 140px; float: left;">
                                <a href="<%=CustomerSupport.Utility.SysResource.HomePath %>supportcenter/products.aspx?product=<%# Eval("Product_id") %>"
                                    style="font-size: 14px;">
                                    <%# Eval("Product_Name") %>
                                </a>
                            </div>
                            <div style="height: 20px; width: 150px; float: left;">
                                <%# Eval("Product_Desc") %>
                            </div>
                        </div>
                    </div>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul></FooterTemplate>
        </asp:Repeater>
    </div>
</div>
<div style="width: 200px; border: solid 0px #cccccc; margin: 2px; float: left;">
    <div style="width: 200px;">
        <h2>
            Categories</h2>
    </div>
    <div style="width: 180px; padding: 2px;">
        <asp:Repeater ID="rptrTopicCategories" runat="server">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li><a href="<%=CustomerSupport.Utility.SysResource.HomePath %>supportcenter/Categories.aspx?Category=<%# Eval("Category_id") %>"
                    style="font-size: 14px;">
                    <%# Eval("Category_Name") %>(<%# Eval("Conversation_Count")%>) </a></li>
            </ItemTemplate>
            <FooterTemplate>
                </ul></FooterTemplate>
        </asp:Repeater>
    </div>
</div>
<div style="width: 200px; border: solid 0px #cccccc; margin: 2px; float: left;">
    <div style="width: 200px;">
        <h2>
            Popular Stuff</h2>
    </div>
    <div style="width: 200px; padding: 2px;">
        <asp:Repeater ID="rptrTags" runat="server">
            <ItemTemplate>
                <div style="width: 50px; height: 15px; float: left; text-align: center; background-image: url('common/images/tag_orange.png');
                    background-repeat: no-repeat; margin: 3px; text-align: left; padding-left: 20px;">
                    <a href="<%=CustomerSupport.Utility.SysResource.HomePath %>supportcenter/show.aspx?Tag=<%# Eval("Tag_id") %>">
                        <%# Eval("Tag_Name")%></a></div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
