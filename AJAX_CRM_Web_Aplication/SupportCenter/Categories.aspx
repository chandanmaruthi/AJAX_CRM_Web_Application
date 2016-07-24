<%@ Page Title="" Language="C#" MasterPageFile="~/SupportCenter/SupportCenterMaster.master"
    Buffer="false" AutoEventWireup="true" CodeFile="Categories.aspx.cs" Inherits="SupportCenter_Categories" %>

<%@ OutputCache VaryByParam="*" Duration="60" Location="Server" %>
<%@ Register Src="~/SupportCenter/webcontrols/PortalHeaderMenu.ascx" TagName="PortalHeaderMenu"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="Server">
    <uc1:PortalHeaderMenu ID="HeaderMenu" SetTab="2" runat="server" ShowCorpMenu="false" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="Server">
    <div class="LeftBox">
        <div id="divAllCategoriesHeader" runat="server" style="height: 20px; float: left;
            width: 750px; margin-bottom: 10px; margin-top: 5px;">
            <span style="font-family: Georgia,Arial; color: #404040; font-size: 18px;">
                <%= strCategoryName %></span>
        </div>
        <div style="float: left; width: 750px; margin-bottom: 10px; margin-top: 5px;">
            <asp:Repeater ID="rptrMainTopicCategories" runat="server">
                <HeaderTemplate>
                    <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li style="line-height:1.4em;width:400px;background-color:#f5f5f5;margin:2px;padding:3px;"><a href="<%=CustomerSupport.Utility.SysResource.HomePath %>SupportCenter/Categories.aspx?Category=<%# Eval("Category_id") %>"
                        style="font-size: 14px;">
                        <%# Eval("Category_Name") %>(<%# Eval("Conversation_Count")%>) </a></li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul></FooterTemplate>
            </asp:Repeater>
           
        </div>
        <div style="width: 750px; background-color: #cccccc">
            <div id="divSpecificCategoriesHeader" runat="server" style="height: 20px; float: left;
                width: 750px; margin-bottom: 10px; margin-top: 5px;">
                <span style="font-family: Georgia,Arial; color: #404040; font-size: 18px;"><a href="<%= CustomerSupport.Utility.SysResource.HomePath %>/SupportCenter/Categories.aspx">
                    <span style="font-family: Georgia,Arial; color: #404040; font-size: 18px;">Categories</span>
                </a>-
                    <%= strCategoryName %></span>
            </div>
            <asp:Label runat="server" ID="lblSearchMessage" Visible="false"></asp:Label>
            <table cellpadding="0" cellspacing="0" border="0" align="right" style="height: 15px;">
                <tr>
                    <td>
                        <a href="<%= strFirstLink %>" title="First">
                            <asp:Image runat="server" ID="imgFirst" Style="border: 0" />
                        </a>
                    </td>
                    <td>
                        <a href="<%= strPrevLink %>" title="Prev">
                            <asp:Image runat="server" ID="imgPrev" Style="border: 0" />
                        </a>
                    </td>
                    <td>
                        Showing
                        <%=intResultStart%>
                        -<%=intResultEnd%>
                        of
                        <%=intTotalLeads%>
                        Leads
                    </td>
                    <td>
                        <a href="<%= strNextLink %>" title="Next">
                            <asp:Image runat="server" ID="imgNext" Style="border: 0" />
                        </a>
                    </td>
                    <td>
                        <a href="<%= strLastLink %>" title="Last">
                            <asp:Image runat="server" ID="imgLast" Style="border: 0" />
                        </a>
                    </td>
                </tr>
            </table>
        </div>
        <asp:Repeater ID="rptrLeads" runat="server">
            <ItemTemplate>
                <div class="HotTopics">
                    <div class="PictureBox">
                        <div class="ProfilePicture">
                        </div>
                        <div class="ProfileText">
                            <%# Eval("User_Name") %></div>
                    </div>
                    <div class="CallOutTopics">
                        <div style="width: 671px; height: 14px; float: left; background-image: url('<%= CustomerSupport.Utility.SysResource.ImagePath %>callout_top.gif');
                            background-repeat: no-repeat;">
                        </div>
                        <div style="width: 646px; float: left; padding-left: 25px; background-image: url('<%= CustomerSupport.Utility.SysResource.ImagePath %>callout_middle.gif');
                            background-repeat: repeat-y;">
                            <div style="width: 500px; height: 20px; float: left; border: solid 0px #dddddd; padding: 2px;">
                                <a style="float: left; font-size: 14px;" href="<%# CustomerSupport.Utility.SysResource.HomePath + Eval("Account_Name")+ "/"+Eval("Conversation_Number").ToString()+"/"+ HttpUtility.UrlEncode(Eval("Conversation_Title").ToString()) %>">
                                    <b>
                                        <%# Eval("Conversation_Title").ToString().Length > 40 ? Eval("Conversation_Title").ToString().Remove(40) + "..." : Eval("Conversation_Title") %>
                                    </b></a>
                                <%--<a id="linkShowConversation_Desc<%# Eval("Conversation_ID") %>" style="cursor: pointer;
                                    float: left;" onclick="javascript:document.getElementById('Conversation_Desc<%# Eval("Conversation_ID") %>').style.display='block';document.getElementById('linkShowConversation_Desc<%# Eval("Conversation_ID") %>').style.display='none';document.getElementById('linkHideConversation_Desc<%# Eval("Conversation_ID") %>').style.display='block';">
                                    &nbsp;&nbsp;&nbsp; more ...</a> <a style="display: none; float: left; cursor: pointer;"
                                        id="linkHideConversation_Desc<%# Eval("Conversation_ID") %>" onclick="javascript:document.getElementById('Conversation_Desc<%# Eval("Conversation_ID") %>').style.display='none';document.getElementById('linkHideConversation_Desc<%# Eval("Conversation_ID") %>').style.display='none';document.getElementById('linkShowConversation_Desc<%# Eval("Conversation_ID") %>').style.display='block';">
                                        &nbsp;&nbsp;&nbsp;Less </a>--%>
                            </div>
                            <div style="width: 100px; height: 40px; float: right; border: solid 0px #dddddd;">
                                <div style="width: 100px; height: 15px; float: left; color: #666666;">
                                    <b>
                                        <%# Eval("Status_name") %></b>
                                </div>
                                <div style="width: 100px; height: 15px; float: left; color: #666666;">
                                    <b>
                                        <%# Eval("Messages_Count") %>
                                        Replies</b>
                                </div>
                                <div style="width: 100px; height: 15px; float: left; color: #666666">
                                    <b>
                                        <%# DateTime.Now.Subtract(DateTime.Parse(Eval("Create_Date").ToString())).Days >0 ? DateTime.Now.Subtract(DateTime.Parse(Eval("Create_Date").ToString())).Days.ToString() +" days, " : "" %>
                                        <%# DateTime.Now.Subtract(DateTime.Parse(Eval("Create_Date").ToString())).Hours%>
                                        hrs ago</b>
                                </div>
                            </div>
                            <div id="Conversation_Desc<%# Eval("Conversation_ID") %>" style="width: 500px; padding: 2px;
                                float: left; border: solid 0px #dddddd; padding: 2px;">
                                <%# Eval("Conversation_Desc").ToString().Length > 80 ? Server.HtmlEncode(Eval("Conversation_Desc").ToString().Remove(80)) + " [ more ]" : Server.HtmlEncode(Eval("Conversation_Desc").ToString())%>
                                <%-- <%# Eval("Conversation_Type_Name") %>--%>
                            </div>
                            <%--<div style="width: 500px; height: 20px; float: left; color: #666666; border: solid 0px #dddddd;
                                padding: 2px;">
                            </div>--%>
                        </div>
                        <div style="width: 671px; height: 14px; float: left; background-image: url('<%= CustomerSupport.Utility.SysResource.ImagePath %>callout_bottom.gif');
                            background-repeat: no-repeat;">
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
         <div id="divNoRecordsFound" runat="server"  class="InfoBox">
            No Topics Found, Ask a New Question <a href=""> Click Here</a>
            </div>
    </div>
    <div class="RightBox">
        <div style="width: 200px; border: solid 0px #cccccc; margin: 2px; float: left;">
            <div style="width: 200px;">
                <h2>
                    Categories</h2>
            </div>
            <div style="width: 180px; padding: 2px;">
                <asp:Repeater ID="rptrRightTopicCategories" runat="server">
                    <HeaderTemplate>
                        <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li><a href="<%=CustomerSupport.Utility.SysResource.HomePath %>SupportCenter/Categories.aspx?Category=<%# Eval("Category_id") %>"
                            style="font-size: 14px;">
                            <%# Eval("Category_Name") %>(<%# Eval("Conversation_Count")%>) </a></li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul></FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
