<%@ Page Title="" Language="C#" MasterPageFile="~/manage/Internal.master" Buffer="false"
    AutoEventWireup="true" CodeFile="Branding.aspx.cs" Inherits="Branding" %>

<%@ Register Src="~/Webcontrols/HeaderMenu.ascx" TagName="HeaderMenu" TagPrefix="uc1" %>
<%@ Register Src="~/Webcontrols/SettingsMenu.ascx" TagName="SettingsMenu" TagPrefix="uc2" %>
<asp:Content ID="Content3" ContentPlaceHolderID="HeaderInclude" runat="server">

    <script src="<%= CustomerSupport.Utility.SysResource.HomePath%>common/DHTMLcolors/201a.js"
        type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="Server">
    <uc1:HeaderMenu ID="HeaderMenu" SetTab="3" runat="server" ShowCorpMenu="true" />
    <uc2:SettingsMenu ID="SettingsMenu" runat="server" SetTab="6" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" runat="Server">
    <div class="PageContainer">
        <div class="PageHeader">
            Customize Look and Feel
        </div>
        <table>
            <tr>
                <td colspan="2" style="font-size: 15px;">
                    <b>Messages</b>
                </td>
            </tr>
            <tr>
                <td>
                    Welcome Message:
                </td>
                <td>
                    <textarea runat="server" id="txtWelcomeMessage" style="width: 500px; height: 100px;"></textarea>
                </td>
            </tr>
            <tr>
                <td>
                    Header Text
                </td>
                <td>
                    <input runat="server" type="text" id="txtHeader" style="width: 500px;" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="font-size: 15px;">
                    <b>Look and Feel</b>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <table style="width: 300px; float: left;">
                        <tr>
                            <td>
                                Background Color
                            </td>
                            <td>
                                <input runat="server" type="text" id="txtBackgroundColor" maxlength="7" style="width: 75px;
                                    float: left;" />
                                <div id="divBackgroundColor" style="width: 30px; height: 18px; border: solid 1px #cccccc;
                                    background-color: <%= strPBackgroundColor %>; float: left;" onclick="javascript:showColorGrid2('ctl00_ContentBody_txtBackgroundColor','divBackgroundColor');">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Header Color
                            </td>
                            <td>
                                <input runat="server" type="text" id="txtHeaderColor" maxlength="7" style="width: 75px;
                                    float: left;" />
                                <div id="divHeaderColor" style="width: 30px; height: 18px; border: solid 1px #cccccc;
                                    background-color: <%= strHeaderColor %>; float: left;" onclick="javascript:showColorGrid2('ctl00_ContentBody_txtHeaderColor','divHeaderColor');">
                                </div>
                                <div id="colorpicker201" class="colorpicker201">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Active Tab Color
                            </td>
                            <td>
                                <input runat="server" type="text" id="txtActiveTabBgColor" maxlength="7" style="width: 75px;
                                    float: left;" />
                                <div id="divActiveTabBgColor" style="width: 30px; height: 18px; border: solid 1px #cccccc;
                                    background-color: <%= strHeaderColor %>; float: left;" onclick="javascript:showColorGrid2('ctl00_ContentBody_txtActiveTabBgColor','divActiveTabBgColor');">
                                </div>
                                <div id="Div2" class="colorpicker201">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Active Tab Text
                            </td>
                            <td>
                                <input runat="server" type="text" id="txtActiveTabTextColor" maxlength="7" style="width: 75px;
                                    float: left;" />
                                <div id="divActiveTabTextColor" style="width: 30px; height: 18px; border: solid 1px #cccccc;
                                    background-color: <%= strHeaderColor %>; float: left;" onclick="javascript:showColorGrid2('ctl00_ContentBody_txtActiveTabTextColor','divActiveTabTextColor');">
                                </div>
                                <div id="Div4" class="colorpicker201">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Inactive Tab Color
                            </td>
                            <td>
                                <input runat="server" type="text" id="txtInActiveTabBgColor" maxlength="7" style="width: 75px;
                                    float: left;" />
                                <div id="divInActiveTabBgColor" style="width: 30px; height: 18px; border: solid 1px #cccccc;
                                    background-color: <%= strHeaderColor %>; float: left;" onclick="javascript:showColorGrid2('ctl00_ContentBody_txtInActiveTabBgColor','divInActiveTabBgColor');">
                                </div>
                                <div id="Div6" class="colorpicker201">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Inactive Tab Text
                            </td>
                            <td>
                                <input runat="server" type="text" id="txtInActiveTabTextColor" maxlength="7" style="width: 75px;
                                    float: left;" />
                                <div id="divInActiveTabTextColor" style="width: 30px; height: 18px; border: solid 1px #cccccc;
                                    background-color: <%= strHeaderColor %>; float: left;" onclick="javascript:showColorGrid2('ctl00_ContentBody_txtInActiveTabTextColor','divInActiveTabTextColor');">
                                </div>
                                <div id="Div8" class="colorpicker201">
                                </div>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 200px; float: left;">
                        <tr>
                            <td>
                                Toss Me a Wave
                            </td>
                            <td>
                                <img src="<%= CustomerSupport.Utility.SysResource.ImagePath%>Toss_Me_a_Wave_Small.png"
                                    border="0" onclick="javascript:SetTheme('#A4E7FF','#404040','#60BBE7','#404040','#25699B','#404040')" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Toss_Me_a_Wave
                            </td>
                            <td>
                                <img src="<%= CustomerSupport.Utility.SysResource.ImagePath%>Toss_Me_a_Wave_Small.png"
                                    border="0" onclick="javascript:SetTheme('#ffffff','#ffffff','#ffffff','#ffffff','#ffffff','#ffffff')" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Toss_Me_a_Wave
                            </td>
                            <td>
                                <img src="<%= CustomerSupport.Utility.SysResource.ImagePath%>Toss_Me_a_Wave_Small.png"
                                    border="0" onclick="javascript:SetTheme('#ffffff','#ffffff','#ffffff','#ffffff','#ffffff','#ffffff')" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Toss_Me_a_Wave
                            </td>
                            <td>
                                <img src="<%= CustomerSupport.Utility.SysResource.ImagePath%>Toss_Me_a_Wave_Small.png"
                                    border="0" onclick="javascript:SetTheme('#ffffff','#ffffff','#ffffff','#ffffff','#ffffff','#ffffff')" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Toss_Me_a_Wave
                            </td>
                            <td>
                                <img src="<%= CustomerSupport.Utility.SysResource.ImagePath%>Toss_Me_a_Wave_Small.png"
                                    border="0" onclick="javascript:SetTheme('#ffffff','#ffffff','#ffffff','#ffffff','#ffffff','#ffffff')" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Toss_Me_a_Wave
                            </td>
                            <td>
                                <img src="<%= CustomerSupport.Utility.SysResource.ImagePath%>Toss_Me_a_Wave_Small.png"
                                    border="0" onclick="javascript:SetTheme('#ffffff','#ffffff','#ffffff','#ffffff','#ffffff','#ffffff')" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    Logo[jpg files only]
                </td>
                <td>
                    <input runat="server" style="height: 20px; border: solid 1px #cccccc;" id="uplTheFile"
                        type="file" runat="server" accept="image/gif,image/jpeg">
                    <span id="txtOutput" style="font: 8pt verdana;" runat="server" />
                    <asp:Image runat="server" ID="imgWidgetImage" />
                    Add your picture with a welcome note
                </td>
            </tr>
            <tr>
                <td>
                    URL
                </td>
                <td>
                    www.helpstation.com/<input type="text" id="txtURL" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right">
                    <asp:LinkButton ID="lnkSave" runat="server" OnClick="lnkSave_Click">
                <div class="StandardFormButton">Save</div>                
                    </asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    <script language="javascript">
       
        function SetTheme(BgColor, FontColor, ActiveTabBgColor, ActiveTabTextColor, InActiveTabBgColor, InActiveTabTextColor)
        {
            document.getElementById('ctl00_ContentBody_txtBackgroundColor').value = BgColor; document.getElementById('divBackgroundColor').style.bgcolor = BgColor;
            document.getElementById('ctl00_ContentBody_txtHeaderColor').value = FontColor; document.getElementById('divHeaderColor').style.bgcolor = FontColor;
            document.getElementById('ctl00_ContentBody_txtActiveTabBgColor').value = ActiveTabBgColor; document.getElementById('divActiveTabBgColor').style.bgcolor = ActiveTabBgColor;
            document.getElementById('ctl00_ContentBody_txtActiveTabTextColor').value = ActiveTabTextColor; document.getElementById('divActiveTabTextColor').style.bgcolor = ActiveTabTextColor;
            document.getElementById('ctl00_ContentBody_txtInActiveTabBgColor').value = InActiveTabBgColor; document.getElementById('divInActiveTabBgColor').style.bgcolor = InActiveTabBgColor;
            document.getElementById('ctl00_ContentBody_txtInActiveTabTextColor').value = InActiveTabTextColor; document.getElementById('divInActiveTabTextColor').style.bgcolor = InActiveTabTextColor;        
        }
    
    </script>
</asp:Content>
