<%@ Page Title="" Language="C#" MasterPageFile="~/manage/Internal.master" AutoEventWireup="true"
    CodeFile="SetupWidget_002.aspx.cs" Inherits="manage_SetupWidget_002" %>
<%@ Register Src="~/Webcontrols/SettingsMenu.ascx" TagName="SettingsMenu" TagPrefix="uc2" %>

<%@ Register Src="~/Webcontrols/HeaderMenu.ascx" TagName="HeaderMenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderInclude" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="Server">
    <uc1:HeaderMenu ID="HeaderMenu" SetTab="3" runat="server" ShowCorpMenu="true" />
     <uc2:SettingsMenu ID="SettingsMenu" runat="server" SetTab="5" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" runat="Server">
    <div class="PageContainer">
        <div class="PageHeader">
            Setup Widget
        </div>
        
        <img src="<%=CustomerSupport.Utility.SysResource.ImagePath %>Widget_002.gif" />
    <table cellpadding="0" cellspacing="0" border="0" width="250" 
                                        id="tblGetCode">
                                        <tr>
                                            <td colspan="10">
                                                <span class="SimpleHeader">Publish Widget on your Web site, Blog Etc</span><br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b>Manual Setup &lt; HTML &gt;</b>
                                            </td>
                                            <td>
                                                <b>WordPress</b>
                                            </td>
                                            <td>
                                                <b>Blogger</b>
                                            </td>
                                            <td>
                                                <b>TypePad</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <textarea style="width: 200px; height: 100px;" id="this<%=strAccountID %>" onclick="javascript:document.getElementById('this<%=strAccountID %>').select();"
                                                    readonly="readonly"><%= strWidgetCode %> </textarea><br />
                                            </td>
                                            <td>
                                                <textarea style="width: 200px; height: 100px;" id="wp<%=strAccountID%>" onclick="javascript:document.getElementById('wp<%=strAccountID %>').select();"
                                                    readonly="readonly"><%= strwpWidgetCode %></textarea>
                                                <br />
                                            </td>
                                            <td>
                                                <form name="BloggerForm" method="POST" action="http://www.blogger.com/add-widget">
                                                <input type="hidden" name="widget.title" value="Blogger Buzz" />
                                                <input type="hidden" name="widget.content" value="<%= strWidgetCode %>" />
                                                <input type="hidden" name="widget.template" value="&lt;data:content/&gt;" />
                                                <input type="hidden" name="infoUrl" value="http://CustomerSupport.com" />
                                                <input type="hidden" name="logoUrl" value="http://CustomerSupport.com/Common/Images/logo.gif" />
                                                <a onclick="javascript:document.BloggerForm.submit();" style="cursor: pointer;">
                                                    <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>add2blogger_lg.gif"
                                                        border="0" />
                                                    Click Here </a>
                                                </form>
                                            </td>
                                            <td>
                                                <form name="TypepadForm" action="https://www.typepad.com/t/app/weblog/design/widgets"
                                                method="post">
                                                <input type="hidden" name="service_key" value="YOUR API KEY HERE" />
                                                <input type="hidden" name="service_name" value="Six Apart" />
                                                <input type="hidden" name="service_url" value="http://www.sixapart.com/" />
                                                <input type="hidden" name="long_name" value="I love Six Apart" />
                                                <input type="hidden" name="short_name" value="i_heart_6a" />
                                                <input type="hidden" name="content" value="<%= strWidgetCode %>" />
                                                <input type="hidden" name="return_url" value="http://www.sixapart.com/" />
                                                <a onclick="javascript:document.TypepadForm.submit();" style="cursor: pointer;">
                                                    <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>typepad.gif" border="0" />
                                                    Click Here</a>
                                                </form>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 11px; font-family: Arial;">
                                                <ol>
                                                    <li>Copy this code [click on code and press ctrl c] </li>
                                                    <li>Place it on your website, blog between the body tags in html</li>
                                                </ol>
                                            </td>
                                            <td style="font-size: 11px; font-family: Arial;">
                                                <ol>
                                                    <li>Copy Code [click on code and press ctrl c]</li>
                                                    <li>Paste in notepad and save as CustomerSupportplugin.php</li>
                                                    <li>Upload to Wordpress directory on your server, under plugins</li>
                                                    <li>Navigate to the plugin section by clicking on the "Plugins" link on the top right</li>
                                                    <li>You will notice a new entry called "delightDeskWidget" </li>
                                                    <li>Click on "Activate" next to the plugin name. This will activate the plugin and now
                                                        you can find the delightDeskWidget in your sidebar.</li>
                                                </ol>
                                            </td>
                                        </tr>
                                    </table>
    
    </div>
    
</asp:Content>
