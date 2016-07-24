<%@ Page Language="C#" MasterPageFile="~/manage/Internal.master" AutoEventWireup="true"
    CodeFile="ManageLeads.aspx.cs" Inherits="_Default" Title="delightDesk- Manage Leads"
    EnableViewState="false" %>

<%@ Register Src="~/Webcontrols/Filters.ascx" TagName="Filters" TagPrefix="uc5" %>
<%@ Register Src="~/Webcontrols/RecentlyViewed.ascx" TagName="RecentlyViewed" TagPrefix="uc2" %>
<%@ Register Src="~/Webcontrols/OverView.ascx" TagName="OverView" TagPrefix="uc3" %>
<%@ Register Src="~/Webcontrols/HeaderMenu.ascx" TagName="HeaderMenu" TagPrefix="uc1" %>
<asp:Content ContentPlaceHolderID="HeaderInclude" runat="server">

    <script language="JavaScript" type="text/javascript" src="../common/texteditor/wyzz.js"></script>

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <uc1:HeaderMenu ID="HeaderMenu" SetTab="2" runat="server" ShowCorpMenu="true" />
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentBody">
    <div class="PageContainer">
        <div class="PageHeader" id="PageHeader">
            Showing
            <%= strStatusName %>
            Conversations for
            <%= strProductName %>
            <asp:Repeater ID="rptrLeadStatus" runat="server">
                <ItemTemplate>
                    <a style="font-weight:<%# Eval("Status_ID") == GetState(CustomerSupport.CustomerSupportPage.Filter_Product_ID) ? "bold":"normal" %>" href="<%= CustomerSupport.Utility.SysResource.HomePath %>manage/ManageLeads.aspx?Lead_Status=<%# Eval("Status_ID") %>">
                        <%# Eval("Status_Name") %>(<%# Eval("Conversation_Count")%>) </a>
                </ItemTemplate>
            </asp:Repeater>
            <div id="divAddNewConversation_Show" style="width: 122px; float: right;">
                <a onclick="javascript:document.getElementById('divAddLead').style.display='block';document.getElementById('divAddNewConversation_Show').style.display='none';document.getElementById('divAddNewConversation_Hide').style.display='block';"
                    id="lnlAdLead" runat="server" style="text-align: right; background-color: Transparent;">
                    <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>AddNewConversation.gif"
                        style="vertical-align: middle;" border="0" />
                </a>
            </div>
            <div id="divAddNewConversation_Hide" style="width: 122px; float: right; display: none">
                <a onclick="javascript:document.getElementById('divAddLead').style.display='none';document.getElementById('divAddNewConversation_Show').style.display='block';document.getElementById('divAddNewConversation_Hide').style.display='none';"
                    id="A2" runat="server" style="text-align: right; background-color: Transparent;">
                    <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>AddNewConversation_Hide.gif"
                        style="vertical-align: middle;" border="0" />
                </a>
            </div>
        </div>
        <div class="PageSuggestions">
            Hi 
            <%= GetState(CustomerSupport.CustomerSupportPage.UserName) %>, 
            Close these open Conversations as soon as possible
        </div>
        <div class="PageContent">
            <input type="hidden" id="hdnBoxId" value="" />
            <input type="hidden" id="hdnAccountId" value="<%= strAccountId %>" />
            <input type="hidden" id="hdnStarContainer" value="" />
            <input type="hidden" id="hdnStatusContainer" value="" />
            <input type="hidden" id="hdnLeadStatus" value="<%= strLeadStatus %>" />
            <input type="hidden" id="hdnLeadProbability" value="0" />
            <input type="hidden" id="hdnLeadOwner" value="<%= strUserID %>" />
            <div class="Message" runat="server" id="divMessage" visible="false">
                <asp:Label runat="server" ID="lblMessage"></asp:Label>
            </div>
            <input type="hidden" id="hdnSelectedLead" value="" />
            <table class="TableGrid" cellpadding="0" cellspacing="0" width="750px" border="0">
                <tr>
                    <td colspan="3">
                        <table>
                            <tr>
                                <td>
                                    <div style="width: 750px; background-color: #cccccc">
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
                                    <div id="divAddLead" style="display: none; width: 730px; height: 440px; overflow: hidden;">
                                        <table style="background-color: #ffffff; padding: 0px; margin: 0px; border: solid 1px #cccccc;"
                                            cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td colspan="2" style="background-color: #404040;">
                                                    <div style="width: 710px; height: 20px; background-color: #404040; color: White;
                                                        padding: 2px;">
                                                        <div style="width: 500px; float: left; font-size: 12px; font-weight: bold;">
                                                            Add New Conversation</div>
                                                        <div style="width: 75px; float: right; font-size: 12px; font-weight: bold;">
                                                            <a style="color: White;" id="A1" onclick="javascript:document.getElementById('divAddLead').style.display='none';return false;">
                                                                Close</a></div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <div id="divErrorBox" style="display: none;">
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 500px;">
                                                        <tr>
                                                            <td align="Left" colspan="4">
                                                                Title
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <input type="text" id="txtConversationTitle" maxlength="500" class="MedInput" tabindex="1"
                                                                    style="width: 500px;" /> <div class="Required"></div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="Left" colspan="4">
                                                                Description
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="Left" colspan="4" style="background-color: #ffffff;">
                                                                <div class="Required"></div>
<textarea id="txtConversationDesc" style="width: 500px; height: 190px;" tabindex="2"></textarea>
                                                                <script language="javascript1.2">make_wyzz('txtConversationDesc','500','140');</script>

                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <table style="width: 210px;">
                                                        <tr>
                                                            <td>
                                                                Name
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <input type="text" id="txtUserName" maxlength="100" class="MedInput" tabindex="3"
                                                                    style="width: 190px;" /><div class="Required"></div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Email 
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <input type="text" id="txtUserEmail" maxlength="100" class="MedInput" tabindex="4"
                                                                    style="width: 190px;" /><div class="Required"></div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Phone: [optional]
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <input type="text" id="txtUserPhone" maxlength="100" class="MedInput" tabindex="5"
                                                                    style="width: 200px;" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <table>
                                                        <tr>
                                                            <td align="Left">
                                                                Related to
                                                            </td>
                                                            <td align="Left">
                                                                Tags [Optional]
                                                            </td>
                                                            <td align="Left">
                                                                Category
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="ddlProducts" runat="server" CssClass="MedInput" Style="width: 200px;"
                                                                    TabIndex="6">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <input type="text" maxlength="15" class="MedInput" style="width: 100;" id="txtTags"
                                                                    tabindex="7" />
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="MedInput" Style="width: 200px;"
                                                                    TabIndex="8">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="Left">
                                                                Status
                                                            </td>
                                                            <td align="Left">
                                                                Severity
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:DropDownList ID="ddlConversationStatus" runat="server" CssClass="MedInput" Style="width: 200px;"
                                                                    TabIndex="9">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlConversationSeverity" runat="server" CssClass="MedInput"
                                                                    Style="width: 200px;" TabIndex="10">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <div style="float: right;">
                                                        <div class="WaitBox" id="Wait_AddLead" style="display: none;">
                                                        </div>
                                                        <input tabindex="11" class="StandardFormButton" type="button" value="Save" id="lnkDeleteNote" onclick="javascript:updateTextArea('txtConversationDesc');document.getElementById('hdnBoxId').value='LeadBox<%# Eval("Conversation_ID")%>';stringval =AjaxAddLeads_Params('<%# Eval("Conversation_ID")%>');ajaxpack.postAjaxRequest('partials/HandleConversation.aspx', stringval, AjaxAddLeads, 'txt');return false;" />
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div id="NewLeadBox">
                                    </div>
                                    <asp:Repeater ID="rptrLeads" runat="server" OnItemDataBound="rptrLeads_ItemDataBound">
                                        <HeaderTemplate>
                                            <tr>
                                                <td>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="ConversationListBox" id="LeadBox<%# Eval("Conversation_ID") %>">
                                                <div class="ConversationListContainer">
                                                    <div class="ConversationTitle">
                                                        <div style="height: 20px; width: 630px; float: left">
                                                            <div style="height: 30px; width: 60px; font-size: 12px; float: left; text-align: center; padding: 2px; vertical-align: middle; background-color: <%# Eval("Status_Name").ToString()== "Open" ? "#D8FEC8":"" %><%# Eval("Status_Name").ToString()== "InProgress" ? "#FFF83F":"" %><%# Eval("Status_Name").ToString()=="Closed" ? "#eeeeee":"" %>">
                                                                #<%# Eval("Conversation_Number") %>
                                                                <span style="color: #888888;">
                                                                    <%# Eval("Status_Name") %></span>
                                                            </div>
                                                            <div style="height: 20px; width: 550px; font-size: 12px; float: left; padding: 2px;
                                                                vertical-align: middle;">
                                                                <a style="float: left;" href="<%= CustomerSupport.Utility.SysResource.HomePath %>manage/Leads.aspx?Action=E&ID=<%# Eval("Conversation_ID")%>">
                                                                    <span class="LeadName">
                                                                        <%# Eval("Conversation_Title") %>
                                                                    </span></a><a id="lnlShowQuick<%# Eval("Conversation_ID")%>" class="PageLink" style="display: block;
                                                                        float: left; width: 75px;" onclick="javascript:document.getElementById('divReply<%# Eval("Conversation_ID") %>').style.display='block';document.getElementById('divProgress<%# Eval("Conversation_ID") %>').style.display='none';document.getElementById('lnlShowQuick<%# Eval("Conversation_ID")%>').style.display='none';document.getElementById('lnlHideQuick<%# Eval("Conversation_ID")%>').style.display='block';">
                                                                        quick reply </a><a id="lnlHideQuick<%# Eval("Conversation_ID")%>" class="PageLink"
                                                                            style="display: none; float: left; width: 75px;" onclick="javascript:document.getElementById('divReply<%# Eval("Conversation_ID") %>').style.display='none';document.getElementById('divProgress<%# Eval("Conversation_ID") %>').style.display='none';document.getElementById('lnlShowQuick<%# Eval("Conversation_ID")%>').style.display='block';document.getElementById('lnlHideQuick<%# Eval("Conversation_ID")%>').style.display='none';">
                                                                            hide quick reply</a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div style="width: 630px; height: 20px; float: left; border-right: solid 0px #cccccc;
                                                        overflow: hidden;">
                                                        <div style="height: 20px; width: 600px; float: left; padding-left: 70px; color: #A0A0A0;">
                                                            <span style="float: left;">by
                                                                <%# Eval("User_Name") %>,
                                                                <%# Eval("Messages_Count") %>
                                                                Replies,
                                                                <%# DateTime.Now.Subtract(DateTime.Parse(Eval("Create_Date").ToString())).Days >0 ? DateTime.Now.Subtract(DateTime.Parse(Eval("Create_Date").ToString())).Days.ToString() +" days, " : "" %>
                                                                <%# DateTime.Now.Subtract(DateTime.Parse(Eval("Create_Date").ToString())).Hours%>
                                                                hrs ago, </span>
                                                        </div>
                                                    </div>
                                                    <div style="width: 500px; height: 20px; float: left; border-right: solid 0px #cccccc;
                                                        overflow: hidden;">
                                                        <%# Eval("Conversation_Desc").ToString().Length > 150 ? Eval("Conversation_Desc").ToString().Substring(0, 150) + "....." : Eval("Conversation_Desc").ToString()%>
                                                    </div>
                                                    <div id="divNotes<%# Eval("Conversation_ID") %>" style="background-color: #E2F9E3;
                                                        width: 500px; height: 20px; display: none; float: left;">
                                                    </div>
                                                    <div id="divReply<%# Eval("Conversation_ID") %>" style="width: 750px; height: 20px;
                                                        float: left; display: none;">
                                                        <div style="width: 500px; height: 20px; float: left">
                                                            <input class="MedInput" type="text" id="txtReply<%# Eval("Conversation_ID") %>" style="width: 500px;
                                                                height: 20px; color: #cccccc;" value="Send a quick Reply" onclick="javascript:this.style.color='#000000';this.value='';" />
                                                        </div>
                                                        <div style="width: 75px; height: 15px; display: block; float: left; padding-left: 5px;">
                                                            <select class="MedInput" id="ddlStatus<%# Eval("Conversation_ID") %>" style="width: 75px;">
                                                                <option id="Option1" value="970FE4E1-7589-4E12-9DEA-097E831CE793">Open</option>
                                                                <option id="Option2" value="8F0B440C-0895-473C-8D4C-577BFA44867B">In Progress</option>
                                                                <option id="Option3" value="D8A852A8-D29F-4E55-B549-8F7B98E13EC9">Closed</option>
                                                            </select>
                                                        </div>
                                                        <div class="WaitBox" id="Wait_QuickReply" style="display: none;">
                                                        </div>
                                                        <div style="width: 75px; height: 15px; display: block; float: left; padding-left: 5px;">
                                                            <a class="FormButton" id="lnkSaveNote" onclick="javascript:document.getElementById('hdnBoxId').value='divNotes<%# Eval("Conversation_ID") %>';stringval =AjaxQuickReply_Params('<%# Eval("Conversation_ID") %>','txtReply<%# Eval("Conversation_ID") %>','ddlStatus<%# Eval("Conversation_ID") %>');ajaxpack.postAjaxRequest('partials/HandleConversation.aspx', stringval, AjaxQuickReply, 'txt');document.getElementById('divReply<%# Eval("Conversation_ID")%>').style.display='none'; return false;">
                                                                Save</a></div>
                                                    </div>
                                                </div>
                                                <div style="width: 100px; height: 60px; border: solid 0px #404040; float: right;">
                                                    <div style="width: 100px; height: 20px; float: left; text-align: center;">
                                                        <%# Eval("Product_Name")%>
                                                    </div>
                                                    <div style="width: 100px; height: 20px; float: left; border-right: solid 0px #cccccc;
                                                        text-align: center;">
                                                        <a id="lnkDeleteConversation" onclick="javascript:var ConfirmDelete= confirm('Warning: You are about to delete a lead,Are you sure ?');if(ConfirmDelete){document.getElementById('hdnBoxId').value='LeadBox<%# Eval("Conversation_ID")%>';stringval =AjaxDeleteLeads_Params('<%# Eval("Conversation_ID")%>');ajaxpack.postAjaxRequest('partials/HandleConversation.aspx', stringval, AjaxDeleteLeads, 'txt');return false;}else{return false};">
                                                            <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>bin_empty.gif" style="vertical-align: middle;"
                                                                border="0" />Delete</a>
                                                    </div>
                                                </div>
                                            </div>
                                            </div> </div>
                                            <div id="<%# Eval("Conversation_ID") %>" style="display: none;">
                                            </div>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </td></tr>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="LeftContainer">
        <uc5:Filters ID="Filters" runat="server"></uc5:Filters>
    </div>

    <script type="text/javascript" language="JavaScript">
        function ShowEdit(LeadId) {
            if (document.getElementById(LeadId).style.display == 'block') {
                document.getElementById(LeadId).style.display = 'none';
                document.getElementById('lnkView' + LeadId).className = 'ExpandLead';

            }
            else {
                document.getElementById(LeadId).style.display = 'block';
                document.getElementById('lnkView' + LeadId).className = 'ContractLead';

            }
        }

    </script>

    <script type="text/javascript">
        var stringval = "";
        function AjaxQuickReply_Params(LeadID, NotesTextbox, SelectField) {
            document.getElementById('Wait_QuickReply').style.display = 'block';
            var Reply = document.getElementById(NotesTextbox).value;
            var Status = document.getElementById(SelectField).value;
            var AccountID = document.getElementById('hdnAccountId').value;

            var poststr = "ID=" + LeadID + "&AccountID=" + encodeURI(AccountID) + "&Reply=" + encodeURI(Reply) + "&Status=" + encodeURI(Status) + "&Action=QR";

            //alert(poststr);
            return poststr;
        }

        //Step 2: Define a "callback" function to process the data returned by the Ajax request:
        function AjaxQuickReply(Wait_QuickReply) {
            var myajax = ajaxpack.ajaxobj
            var myfiletype = ajaxpack.filetype
            var hdnDivBoxID = document.getElementById('hdnBoxId').value;

            if (myajax.readyState == 4) {
                //if request of file completed
                if (myajax.status == 200 || window.location.href.indexOf("http") == -1) { //if request was successful or running script locally
                    document.getElementById('Wait_QuickReply').style.display = 'none';
                    if (myfiletype == "txt") {
                        document.getElementById(hdnDivBoxID).innerHTML = 'Quick Reply Sent';
                        document.getElementById(hdnDivBoxID).style.display = 'block';
                    }
                    else {
                        document.getElementById(hdnDivBoxID).innerHTML = myajax.responseText;
                    }
                }
                else {
                    document.getElementById('Wait_QuickReply').style.display = 'none';
                    alert('problem');
                }
            }
        }
        function AjaxDeleteNotes_Params(LeadID, NoteID) {

            //var LeadNotes=document.getElementById(NotesTextbox).value ;
            //var LeadStatus=document.getElementById(SelectField).value ;
            var poststr = "ID=" + encodeURI(LeadID) + "&NoteID=" + encodeURI(NoteID) + "&Action=D";

            //alert(poststr);
            return poststr;
        }

        //Step 2: Define a "callback" function to process the data returned by the Ajax request:
        function AjaxDeleteNotes() {
            var myajax = ajaxpack.ajaxobj
            var myfiletype = ajaxpack.filetype
            var hdnDivBoxID = document.getElementById('hdnBoxId').value;

            if (myajax.readyState == 4) {
                //if request of file completed
                if (myajax.status == 200 || window.location.href.indexOf("http") == -1) { //if request was successful or running script locally
                    if (myfiletype == "txt") {
                        document.getElementById(hdnDivBoxID).innerHTML = myajax.responseText;
                    }
                    else {
                        document.getElementById(hdnDivBoxID).innerHTML = myajax.responseText;
                    }
                }
                else alert('problem');
            }
        }
        function AjaxDeleteLeads_Params(LeadID, NoteID) {

            //var LeadNotes=document.getElementById(NotesTextbox).value ;
            //var LeadStatus=document.getElementById(SelectField).value ;
            var poststr = "ID=" + encodeURI(LeadID) + "&Action=D";

            //alert(poststr);
            return poststr;
        }

        //Step 2: Define a "callback" function to process the data returned by the Ajax request:
        function AjaxDeleteLeads() {
            var myajax = ajaxpack.ajaxobj
            var myfiletype = ajaxpack.filetype
            var hdnDivBoxID = document.getElementById('hdnBoxId').value;

            if (myajax.readyState == 4) {
                //if request of file completed
                if (myajax.status == 200 || window.location.href.indexOf("http") == -1) { //if request was successful or running script locally
                    if (myfiletype == "txt") {
                        document.getElementById(hdnDivBoxID).style.display = 'none';
                    }
                    else {
                        document.getElementById(hdnDivBoxID).innerHTML = myajax.responseText;
                    }
                }
                else alert('problem');
            }
        }
        function AjaxAddLeads_Params(LeadID, NoteID) {
            document.getElementById('Wait_AddLead').style.display = 'block';

            var ConversationTitle = document.getElementById('txtConversationTitle').value;
            var ConversationDesc = document.getElementById('txtConversationDesc').value;
            var ProductID = document.getElementById('ctl00_ContentBody_ddlProducts').value;
            var ConversationStatus = document.getElementById('ctl00_ContentBody_ddlConversationStatus').value;
            var ConversationSeverity = document.getElementById('ctl00_ContentBody_ddlConversationSeverity').value;
            var ConversationCategory = document.getElementById('ctl00_ContentBody_ddlCategory').value;

            var UserName = document.getElementById('txtUserName').value;
            var UserEmail = document.getElementById('txtUserEmail').value;
            var UserPhone = document.getElementById('txtUserPhone').value;

            var AccountID = document.getElementById('hdnAccountId').value;



            var poststr = "AccountID=" + encodeURI(AccountID) + "&ConversationTitle=" + encodeURI(ConversationTitle) + "&ConversationDesc=" + encodeURI(escape(ConversationDesc)) + "&ProductID=" + encodeURI(ProductID) + "&ConversationStatus=" + encodeURI(ConversationStatus) + "&ConversationSeverity=" + encodeURI(ConversationSeverity) + "&ConversationCategory=" + encodeURI(ConversationCategory) + "&UserName=" + encodeURI(UserName) + "&UserEmail=" + encodeURI(UserEmail) + "&UserPhone=" + encodeURI(UserPhone) + "&Action=A";


            return poststr;
        }

        //Step 2: Define a "callback" function to process the data returned by the Ajax request:
        function AjaxAddLeads() {
            var myajax = ajaxpack.ajaxobj
            var myfiletype = ajaxpack.filetype
            var hdnDivBoxID = document.getElementById('hdnBoxId').value;

            if (myajax.readyState == 4) {
                //if request of file completed
                if (myajax.status == 200 || window.location.href.indexOf("http") == -1) { //if request was successful or running script locally
                    if (myfiletype == "txt") {

                        if (myajax.responseText.substring(0, 5) == "ERROR") {
                            document.getElementById('divErrorBox').innerHTML = myajax.responseText;
                            document.getElementById('divErrorBox').style.display = 'block';
                            document.getElementById('divErrorBox').className = 'MessageBox_Warning';
                            document.getElementById('Wait_AddLead').style.display = 'none';

                        }
                        else {
                            document.getElementById('NewLeadBox').innerHTML += myajax.responseText;

                            document.getElementById('divErrorBox').innerHTML = 'New Conversation Added';
                            document.getElementById('divErrorBox').className = 'MessageBox';
                            document.getElementById('divErrorBox').style.display = 'block';

                            document.getElementById('Wait_AddLead').style.display = 'none';
                            document.getElementById('txtConversationTitle').value = '';
                            document.getElementById('txtConversationDesc').value = '';
                            document.getElementById('txtUserName').value = '';
                            document.getElementById('txtUserEmail').value = '';
                            document.getElementById('txtUserPhone').value = '';

                        }

                    }
                    else {
                        document.getElementById('NewLeadBox').innerHTML = myajax.responseText;
                    }
                }
                else alert('problem');
            }
        }
        function AjaxSetLeadsRating_Params(StarVal, LeadID) {

            //var LeadNotes=document.getElementById(NotesTextbox).value ;
            //var LeadStatus=document.getElementById(SelectField).value ;
            var poststr = "ID=" + encodeURI(LeadID) + "&Stars=" + encodeURI(StarVal) + "&Action=S";

            //alert(poststr);
            return poststr;
        }

        //Step 2: Define a "callback" function to process the data returned by the Ajax request:
        function AjaxSetLeadsRating() {
            var myajax = ajaxpack.ajaxobj
            var myfiletype = ajaxpack.filetype
            var hdnDivBoxID = document.getElementById('hdnStarContainer').value;

            if (myajax.readyState == 4) {
                //if request of file completed
                if (myajax.status == 200 || window.location.href.indexOf("http") == -1) { //if request was successful or running script locally
                    if (myfiletype == "txt") {

                        document.getElementById(hdnDivBoxID).innerHTML = myajax.responseText;
                    }
                    else {
                        document.getElementById(hdnDivBoxID).innerHTML = myajax.responseText;
                    }
                }
                else alert('problem');
            }
        }
        function AjaxSetLeadsStatus_Params(StatusVal, LeadID) {

            //var LeadNotes=document.getElementById(NotesTextbox).value ;
            //var LeadStatus=document.getElementById(SelectField).value ;
            var poststr = "ID=" + encodeURI(LeadID) + "&Status=" + encodeURI(StatusVal) + "&Action=ST";

            //alert(poststr);
            return poststr;
        }

        //Step 2: Define a "callback" function to process the data returned by the Ajax request:
        function AjaxSetLeadsStatus() {
            var myajax = ajaxpack.ajaxobj
            var myfiletype = ajaxpack.filetype
            var hdnDivBoxID = document.getElementById('hdnStatusContainer').value;

            if (myajax.readyState == 4) {
                //if request of file completed
                if (myajax.status == 200 || window.location.href.indexOf("http") == -1) { //if request was successful or running script locally
                    if (myfiletype == "txt") {

                        document.getElementById(hdnDivBoxID).innerHTML = myajax.responseText;
                    }
                    else {
                        document.getElementById(hdnDivBoxID).innerHTML = myajax.responseText;
                    }
                }
                else alert('problem');
            }
        }
        function AjaxEditTasks_Params(LeadID, TasksTextbox, SelectField) {

            var Tasks = document.getElementById(TasksTextbox).value;
            var TaskDate = document.getElementById('orderdate').value;

            var poststr = "ID=" + LeadID + "&Task=" + encodeURI(Tasks) + "&Date=" + encodeURI(TaskDate) + "&Action=A";

            //alert(poststr);
            return poststr;
        }

        //Step 2: Define a "callback" function to process the data returned by the Ajax request:
        function AjaxEditTasks() {
            var myajax = ajaxpack.ajaxobj
            var myfiletype = ajaxpack.filetype
            var hdnDivBoxID = document.getElementById('hdnBoxId').value;

            if (myajax.readyState == 4) {
                //if request of file completed
                if (myajax.status == 200 || window.location.href.indexOf("http") == -1) { //if request was successful or running script locally
                    if (myfiletype == "txt") {
                        document.getElementById(hdnDivBoxID).innerHTML = 'Task Added';
                    }
                    else {
                        document.getElementById(hdnDivBoxID).innerHTML = '';
                    }
                }
                else alert('problem');
            }
        }
    </script>

    <%--    <script type="text/javascript">

var todaydate=new Date()
var curmonth=todaydate.getMonth()+1 //get current month (1-12)
var curyear=todaydate.getFullYear() //get current year

document.write(buildCal(curmonth ,curyear, "main", "month", "daysofweek", "days", 1));
    </script>
--%>
</asp:Content>
