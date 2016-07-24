<%@ Page Language="C#" MasterPageFile="~/manage/Internal.master" Buffer="false" AutoEventWireup="true"
    CodeFile="SetupWidget.aspx.cs" Inherits="_Default" Title="delightDesk- Setup Widgets"
    ValidateRequest="false" %>

<%@ Register Src="~/Webcontrols/WidgetList.ascx" TagName="WidgetList" TagPrefix="uc1" %>
<%@ Register Src="~/Webcontrols/HeaderMenu.ascx" TagName="HeaderMenu" TagPrefix="uc1" %>
<%@ Register Src="~/Webcontrols/SettingsMenu.ascx" TagName="SettingsMenu" TagPrefix="uc2" %>
<asp:Content ID="Content3" ContentPlaceHolderID="HeaderInclude" runat="server">

    <script src="<%= CustomerSupport.Utility.SysResource.HomePath%>common/DHTMLcolors/201a.js"
        type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <uc1:HeaderMenu ID="HeaderMenu" SetTab="3" runat="server" ShowCorpMenu="true" />
    <uc2:SettingsMenu ID="SettingsMenu" runat="server" SetTab="5" />
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentBody">
    <div class="PageContainer">
        <div class="PageHeader">
            View Widgets
            <asp:LinkButton runat="server" ID="lnkAddNew" Text="Add New Widget" OnClick="lnkAddNew_Click">  Add New Widget <img src="<%= CustomerSupport.Utility.SysResource.ImagePath%>add.png" style="vertical-align:middle;" border="0"  /></asp:LinkButton>
        </div>
        <table cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td colspan="5" align="center">
                    <div class="Message" runat="server" id="divMessage" visible="false">
                        <asp:Label runat="server" ID="lblMessage"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel runat="server" ID="pnlAddEditWidget" Visible="false">
                        <table width="750px" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td width="500px">
                                    <table width="450px" cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td align="left" colspan="2">
                                                <asp:Label ID="Label6" runat="server" Text="Widget Name" Width="100px"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <div class="Required">
                                                    *</div>
                                                <asp:TextBox CssClass="MedInput" runat="server" ID="txtWidgetName" Width="220px"
                                                    MaxLength="200"></asp:TextBox><div class="FieldInfo">
                                                        Identifiable Name
                                                    </div>
                                                <asp:RequiredFieldValidator ErrorMessage="required" ID="RequiredFieldValidator1"
                                                    ControlToValidate="txtWidgetName" runat="server"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="2">
                                                <asp:Label ID="Label2" runat="server" Text="Title Message" Width="100px"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <span class="Required">*</span>
                                                <asp:TextBox CssClass="MedInput" runat="server" ID="txtHeaderMessage" Width="220px"
                                                    MaxLength="43"></asp:TextBox>
                                                <div class="FieldInfo">
                                                    appears in the callout</div>
                                                <asp:RequiredFieldValidator ErrorMessage="required" ID="RequiredFieldValidator2"
                                                    ControlToValidate="txtHeaderMessage" runat="server"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="2">
                                                Select your theme <a href="#" onclick="javascript:RefreshWidget();return false;">refresh</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table style="width: 400px;">
                                                    <tr>
                                                        <td>
                                                            Title
                                                        </td>
                                                        <td>
                                                            <input type="text" id="txtTitle" runat="server" maxlength="7" style="width: 75px" />
                                                        </td>
                                                        <td>
                                                            <div id="divTitle" runat="server" style="width: 16px; height: 16px; border: solid 1px #cccccc;
                                                                background-color: #ffffff;" onclick="javascript:showColorGrid2('ctl00_ContentBody_txtTitle','ctl00_ContentBody_divTitle');">
                                                            </div>
                                                        </td>
                                                        <td rowspan="4">
                                                            <div id="colorpicker201" class="colorpicker201">
                                                            </div>
                                                            <div class="FieldInfo">
                                                                Click on the box to select colors</div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Background
                                                        </td>
                                                        <td>
                                                            <input type="text" id="txtBackground" runat="server" maxlength="7" style="width: 75px" />
                                                        </td>
                                                        <td>
                                                            <div id="divBackground" runat="server" style="width: 16px; height: 16px; border: solid 1px #cccccc;
                                                                background-color: #ffffff;" onclick="javascript:showColorGrid2('ctl00_ContentBody_txtBackground','ctl00_ContentBody_divBackground');">
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Text
                                                        </td>
                                                        <td>
                                                            <input type="text" id="txtText" runat="server" maxlength="7" style="width: 75px" />
                                                        </td>
                                                        <td>
                                                            <div id="divText" runat="server" style="width: 16px; height: 16px; border: solid 1px #cccccc;
                                                                background-color: #ffffff;" onclick="javascript:showColorGrid2('ctl00_ContentBody_txtText','ctl00_ContentBody_divText');">
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            URL
                                                        </td>
                                                        <td>
                                                            <input type="text" id="txtURL" runat="server" maxlength="7" style="width: 75px" />
                                                        </td>
                                                        <td>
                                                            <div id="divURL" runat="server" style="width: 16px; height: 16px; border: solid 1px #cccccc;
                                                                background-color: #ffffff;" onclick="javascript:showColorGrid2('ctl00_ContentBody_txtURL','ctl00_ContentBody_divURL');">
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <input type="hidden" id="hdnSelectedLayout" value="0" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="2">
                                                Add your photo: [Only jpg files]
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <input style="height: 20px; border: solid 1px #cccccc; float: left;" id="uplTheFile"
                                                    type="file" runat="server" accept="image/gif,image/jpeg"><div class="FieldInfo">
                                                        Add your picture with a welcome note</div>
                                                <asp:Image runat="server" ID="imgWidgetImage" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <span id="txtOutput" style="font: 8pt verdana;" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="2">
                                                <asp:Label ID="Label5" runat="server" Text="Thank you Message" Width="100px"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <span class="Required">*</span>
                                                <asp:TextBox CssClass="MedInput" runat="server" ID="txtFooterMessage" Width="220px"
                                                    MaxLength="100"></asp:TextBox>
                                                <div class="FieldInfo">
                                                    Displayed after submit</div>
                                                <asp:RequiredFieldValidator ErrorMessage="required" ID="RequiredFieldValidator5"
                                                    ControlToValidate="txtFooterMessage" runat="server"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Panel ID="pnlQuestions" runat="server">
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="right">
                                                <%--<span class="SimpleHeader">Custom Fields</span>--%>
                                                <div style="height: 20px; text-align: right;">
                                                    <a runat="server" id="lnkAddNewQuestion">Add New Question
                                                        <img src="<%= CustomerSupport.Utility.SysResource.ImagePath%>add.png" border="0" /></a></div>
                                                <div class="FieldInfo">
                                                    Ask relavant questions</div>
                                                <input type="hidden" id="hdnQuestionCount" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="lblNoQuestions" CssClass="StandardFormButton" runat="server" Text="Save Widget and add questions"
                                                    Visible="false"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="right">
                                                
                                                <asp:LinkButton CssClass="StandardFormButton" runat="server" ID="lnkAddEditWidget"
                                                    Text="Save Widget" OnClick="lnkAddEditWidget_Click"></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="250px">
                                    <div style="width: 200px; height: 400px; float: left; overflow-x: hidden; overflow-y: auto;
                                        background-color: #f5f5f5; text-align: center; border: solid 1px #f5f5f5; padding: 5px;">
                                        <div style="width: 200px; height: 25px; float: left">
                                            <span class="SimpleHeader">Preview: [save to see changes] </span>
                                        </div>
                                        <div style="width: 200px; height: 25px; float: left; text-align: left;">
                                            <a href="#" onclick="javascript:RefreshWidget();return false;">
                                                <img src="<%= CustomerSupport.Utility.SysResource.ImagePath%>arrow_rotate_clockwise.png"
                                                    style="vertical-align: middle;" border="0" />
                                                refresh</a></div>
                                        <%= strDemoWidgetCode %>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <div style="width: 750px; height: 20px; padding: 5px; color: #404040; font-size: 18px;
                                        background-color: #f5f5f5; border: solid 1px #cccccc;">
                                        Get Code
                                        <div style="float: right">
                                            <a id="lnkShow" style="float: left;" onclick="javascript:document.getElementById('tblGetCode').style.display='block';document.getElementById('lnkShow').style.display='none';document.getElementById('lnkHide').style.display='block';">
                                                Show</a> <a id="lnkHide" style="display: none; float: left;" onclick="javascript:document.getElementById('tblGetCode').style.display='none';document.getElementById('lnkShow').style.display='block';document.getElementById('lnkHide').style.display='none';">
                                                    Hide</a>
                                        </div>
                                    </div>
                                    <table cellpadding="0" cellspacing="0" border="0" width="250" style="display: none;"
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
                                                <textarea style="width: 200px; height: 100px;" id="this<%=Request["ID"] %>" onclick="javascript:document.getElementById('this<%=Request["ID"].ToString() %>').select();"
                                                    readonly="readonly"><%= strWidgetCode %> </textarea><br />
                                            </td>
                                            <td>
                                                <textarea style="width: 200px; height: 100px;" id="wp<%=Request["ID"]%>" onclick="javascript:document.getElementById('wp<%=Request["ID"].ToString() %>').select();"
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
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>
    <div class="LeftContainer">
        <div class="HelpContainer">
            <div class="HelpHeader">
                About Widgets
            </div>
            <div class="HelpContent">
                <b>What are Widgets?</b><br />
                delightDeskhelps you collect leads from your website/blog and other online sources
                too. Just setup your widget and place them on your web site/blog and see the leads
                flow into delightDesk
                <br />
            </div>
        </div>
        <div class="LeftSection">
            <uc1:WidgetList runat="server" ID="WidgetList" />
        </div>
    </div>

    <script type="text/javascript">
        function RefreshWidget() {
            document.getElementById('iframeDemo').contentDocument.location.reload(true);
        }

        document.getElementById('ctl00_ContentBody_divTitle').style.backgroundColor = document.getElementById('ctl00_ContentBody_txtTitle').value;
        document.getElementById('ctl00_ContentBody_divBackground').style.backgroundColor = document.getElementById('ctl00_ContentBody_txtBackground').value;
        document.getElementById('ctl00_ContentBody_divText').style.backgroundColor = document.getElementById('ctl00_ContentBody_txtText').value;
        document.getElementById('ctl00_ContentBody_divURL').style.backgroundColor = document.getElementById('ctl00_ContentBody_txtURL').value;
    </script>

</asp:Content>
