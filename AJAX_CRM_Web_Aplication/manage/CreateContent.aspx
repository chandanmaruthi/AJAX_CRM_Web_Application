<%@ Page Title="" Language="C#" MasterPageFile="~/manage/Internal.master" Buffer="false"  AutoEventWireup="true"
    CodeFile="CreateContent.aspx.cs" Inherits="manage_CreateContent" %>

<%@ Register Src="~/Webcontrols/HeaderMenu.ascx" TagName="HeaderMenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeaderInclude" runat="Server">

    <script language="JavaScript" type="text/javascript" src="../common/texteditor/wyzz.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="Server">
    <uc1:HeaderMenu ID="HeaderMenu" SetTab="4" runat="server" ShowCorpMenu="true" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" runat="Server">
    <input type="hidden" id="hdnBoxId" value="" />
    <input type="hidden" id="hdnAccountId" value="<%= strAccountId %>" />
    <input type="hidden" id="hdnLeadStatus" value="<%= strLeadStatus %>" />
    <input type="hidden" id="hdnOwnerID" value="<%= strUserID %>" />
    <input type="hidden" id="hdnOwnerEmail" value="<%= strUserID %>" />
    <div class="PageContainer">
        <div class="PageHeader">
            Add Content pages
        </div>
        <table style="background-color: #ffffff; padding: 0px; margin: 0px;" cellpadding="0"
            cellspacing="0">
            <tr>
                <td colspan="2">
                    <div id="divErrorBox" style="display: none;">
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="0" border="0" style="width: 750px;">
                        <tr>
                            <td align="Left" colspan="4">
                                Title 
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                  <div class="Required"></div><input type="text" id="txtConversationTitle" maxlength="500" class="MedInput" tabindex="1"
                                    style="width: 750px;" />
                            </td>
                        </tr>
                        <tr>
                            <td align="Left" colspan="4">
                                Description
                            </td>
                        </tr>
                        <tr>
                            <td align="Left" colspan="4" style="background-color: #ffffff;">
                                  <div class="Required"></div><textarea id="txtConversationDesc" style="width: 750px; height: 400px;" tabindex="2"></textarea>

                                <script language="javascript1.2">make_wyzz('txtConversationDesc','750','300');</script>

                            </td>
                        </tr>
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
                                    TabIndex="3">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <input type="text" maxlength="15" class="MedInput" style="width: 100;" id="txtTags"
                                    tabindex="4" />
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="MedInput" Style="width: 200px;"
                                    TabIndex="5">
                                </asp:DropDownList>
                            </td>
                        </tr>
                       <%-- <tr>
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
                                    TabIndex="2">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlConversationSeverity" runat="server" CssClass="MedInput"
                                    Style="width: 200px;" TabIndex="2">
                                </asp:DropDownList>
                            </td>
                        </tr>--%>
                        <tr>
                            <td colspan="5" align="right">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="float: right;">
                        <div class="WaitBox" id="Wait_AddLead" style="display: none;">
                        </div>
                        <input tabindex="6" class="StandardFormButton" type="button" value="Save" id="lnkDeleteNote" onclick="javascript:updateTextArea('txtConversationDesc');document.getElementById('hdnBoxId').value='LeadBox<%# Eval("Conversation_ID")%>';stringval =AjaxAddLeads_Params('<%# Eval("Conversation_ID")%>');ajaxpack.postAjaxRequest('partials/HandleConversation.aspx', stringval, AjaxAddLeads, 'txt');return false;" />
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div class="LeftContainer">
        <div class="HelpContainer">
            <div class="HelpHeader">
                Content</div>
            <div class="HelpContent">
                <b>How to Use ?</b><br />
                Use this page to add content pages that may be of use to your customers<br />
                <b>How will that help?</b><br />
                Your company already has knowledge of what type of questions customers ask. Use
                this page to create, modify and publish this knowledge. This becomes avilable in
                your customer support portal.
            </div>
        </div>
    </div>

    <script type="text/javascript">
        var stringval = "";

        function AjaxAddLeads_Params(LeadID, NoteID) {
            document.getElementById('Wait_AddLead').style.display = 'block';

            var ConversationTitle = document.getElementById('txtConversationTitle').value;
            var ConversationDesc = document.getElementById('txtConversationDesc').value;
            var ProductID = document.getElementById('ctl00_ContentBody_ddlProducts').value;
            var ConversationStatus = 'D8A852A8-D29F-4E55-B549-8F7B98E13EC9';  //document.getElementById('ctl00_ContentBody_ddlConversationStatus').value;
            //var ConversationSeverity = document.getElementById('ctl00_ContentBody_ddlConversationSeverity').value;
            var ConversationCategory = document.getElementById('ctl00_ContentBody_ddlCategory').value;
            
            var UserName = 'System';
            var UserEmail = 'support@delightdesk.com';
            var UserPhone = '';

            var AccountID = document.getElementById('hdnAccountId').value;



            var poststr = "AccountID=" + encodeURI(AccountID) + "&ConversationTitle=" + encodeURI(ConversationTitle) + "&ConversationDesc=" + encodeURI(escape(ConversationDesc)) + "&ProductID=" + encodeURI(ProductID) + "&ConversationStatus=" + encodeURI(ConversationStatus) + "&ConversationCategory=" + encodeURI(ConversationCategory) + "&UserName=" + encodeURI(UserName) + "&UserEmail=" + encodeURI(UserEmail) + "&UserPhone=" + encodeURI(UserPhone) + "&Action=A";

            //alert(poststr);
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
                            
                            document.getElementById('divErrorBox').innerHTML = 'New Lead Added';
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
      
    </script>

</asp:Content>
