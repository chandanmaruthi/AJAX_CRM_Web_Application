<%@ Page Language="C#" MasterPageFile="~/manage/Internal.master" AutoEventWireup="true" Buffer="false" 
    CodeFile="Leads.aspx.cs" Inherits="Leads" Title="Edit Lead" %>

<%@ Register Src="~/Webcontrols/QuickConversationSearch.ascx" TagName="QuickConversationSearch"
    TagPrefix="uc6" %>
<%@ Register Src="~/Webcontrols/HeaderMenu.ascx" TagName="HeaderMenu" TagPrefix="uc1" %>
<asp:Content ID="Content3" ContentPlaceHolderID="HeaderInclude" runat="server">

    <script language="JavaScript" type="text/javascript" src="<%= CustomerSupport.Utility.SysResource.HomePath %>common/texteditor/wyzz.js"></script>

    <script type="text/javascript" src="<%= CustomerSupport.Utility.SysResource.HomePath %>common/js/calendarDateInput.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">
    <uc1:HeaderMenu ID="HeaderMenu" SetTab="2" runat="server" ShowCorpMenu="true" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentBody" runat="Server">
    <div class="PageContainer">
        <div class="PageHeader">
            Update Conversation</div>
        <div class="PageSuggestions">
            <%= GetState(CustomerSupport.CustomerSupportPage.UserName) %>
            check on the lead see if we can setup a call / meeting with them . Leave a note
            so we remember what we did here.
        </div>
        <input type="hidden" id="hdnBoxId" value="" />
        <input type="hidden" id="hdnTasksBoxId" value="" />
        <input type="hidden" id="hdnAccountId" value="<%= strAccountId %>" />
        <input type="hidden" id="hdnStarContainer" value="" />
        <input type="hidden" id="hdnLeadProbability" value="<%= intLeadProbabilty %>" />
        <input type="hidden" id="hdnLeadStatus" value="<%= strLeadStatus %>" />
        <input type="hidden" id="hdnLeadOwner" value="<%= strUserID %>" />
        <input type="hidden" id="hdnStatusContainer" value="" />
        <div id="div1" style="display: block; width: 750px;">
            <table style="background-color: #ffffff;" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="2">
                        <div id="div2" style="display: none;">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0" border="0" style="width: 750px;">
                            <tr>
                                <td colspan="4">
                                    <div class="HotTopics">
                                        <div class="PictureBox">
                                            <div class="ProfilePicture">
                                            </div>
                                            <div class="ProfileText">
                                                <%= strUserName %>
                                            </div>
                                        </div>
                                        <div class="CallOutTopics">
                                            <div style="width: 671px; height: 14px; float: left; background-image: url('<%= CustomerSupport.Utility.SysResource.ImagePath %>callout_top.gif');
                                                background-repeat: no-repeat;">
                                            </div>
                                            <div style="width: 646px; float: left; padding-left: 25px; background-image: url('<%= CustomerSupport.Utility.SysResource.ImagePath %>callout_middle.gif');
                                                background-repeat: repeat-y;">
                                                <div style="width: 500px; float: left; font-size: 14px;">
                                                    <span style="color: #cccccc">on :<%= strCreateDate%>
                                                    <br />
                                                    <b>
                                                        <%= strConversationTitle.Replace("\n", "<br>")%></b><br />
                                                    <br />
                                                    <%= strConversationDesc.Replace("\n", "<br>")%></span>
                                                </div>
                                                <div style="width: 100px; height: 40px; float: right; border: solid 0px #dddddd;">
                                                    <div style="width: 100px; height: 20px; float: left; color: #666666">
                                                        <%= DateTime.Now.Subtract(DateTime.Parse(strCreateDate)).Days > 0 ? DateTime.Now.Subtract(DateTime.Parse(strCreateDate)).Days.ToString() + " days, " : ""%>
                                                        <%= DateTime.Now.Subtract(DateTime.Parse(strCreateDate)).Hours%>
                                                        hrs ago
                                                    </div>
                                                </div>
                                                <div style="width: 500px; height: 14px; float: left; color: #666666; border: solid 0px #dddddd;
                                                    padding: 2px;">
                                                </div>
                                            </div>
                                            <div style="width: 671px; height: 34px; float: left; background-image: url('<%= CustomerSupport.Utility.SysResource.ImagePath %>callout_bottom.gif');
                                                background-repeat: no-repeat;">
                                            </div>
                                        </div>
                                    </div>
                                    <%--<div class="ConversationContainer">
                                        <div class="ConversationTop">
                                        </div>
                                        <div class="ConversationMiddle">
                                            <b>
                                                <div style="background-color: #FF9859; padding: 2px; width: 50px; text-align: center;">
                                                    #<%= strConversationNumber %>
                                                </div>
                                                <%= strConversationTitle %>
                                            </b>created on:<%= strCreateDate%>, related to
                                            <%= strProductDesc %>, Severity
                                            <%= strStatusDesc %>
                                            <br />
                                            <span style="color: #aaaaaa">by
                                                <%= strUserName %>, email:
                                                <%= strUserEmail %>,Phone:
                                                <%= strUserPhone %><br />
                                            </span>
                                            <%= strConversationDesc %><br />
                                        </div>
                                        <div class="ConversationBottom">
                                        </div>
                                    </div>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="Left" colspan="4">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td>
                        <div id="divReplies">
                            <asp:Repeater ID="rptrReplies" runat="server">
                                <ItemTemplate>
                                    <div style="width: 750px; border-bottom: solid 1px #efefef; float: left; font-family: Arial;
                                        font-size: 11px;">
                                        <div style="width: 100px; height: 20px; float: left">
                                            <%# (DateTime.Parse(Eval("Date_Time").ToString())).ToString("dd MMM yy")%>
                                        </div>
                                        <div style="width: 600px; float: left">
                                            <div class="<%# Eval("Action_Type")%>">
                                                <%# Eval("Action_Type")%>
                                            </div>
                                            <div style="width: 350px; padding: 2px; float: left; <%# Eval("Action_Type")== "REPLY" ? "background-color:blue;": "" %>">
                                                <%# Eval("Action_Desc")%>
                                            </div>
                                            <div style="width: 150px; padding: 2px; height: 16px; float: right;">
                                                : by
                                                <%# Eval("User_Name")%>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </td>
                </tr>
             <tr>
                    <td>
                 <div id="divErrorBox" style="display: none;">
                    </div>       
                        <div id="divReply" style="width: 900px; display: block;">
                            <div style="width: 750px; display: block; float: left;">
                                <textarea id="txtReply" style="width: 750px; height: 50px;"></textarea>

                                <script language="javascript1.2">make_wyzz('txtReply','730','200');</script>

                            </div>
                            <div style="width: 750px; height: 50px; display: block; float: left;">
                                Reply to conversation and change status to
                                <asp:DropDownList CssClass="MedInput" ID="ddlStatus" runat="server" Style="width: 150px;"
                                    TabIndex="2">
                                </asp:DropDownList>
                                
                                <input class="StandardFormButton" type=button value="Reply" id="lnkSaveNote" onclick="javascript:updateTextArea('txtReply');document.getElementById('hdnBoxId').value='LeadsBox<%= strConversationID%>';stringval =AjaxReply_Params('<%= strConversationID %>','txtReply','ctl00_ContentBody_ddlStatus');ajaxpack.postAjaxRequest('partials/HandleConversation.aspx', stringval, AjaxReply, 'txt');return false;" />
                                     
                                    
                            </div>
                        </div>
       
  
        </td> </tr> </table>
    </div>
    </div>
    <div class="LeftContainer">
        <div class="LeftSection" style="height: 200px;">
        <div id="divUpdateLeadErrorBox" style="display: none;">
                    </div>       
            <table style="width: 190px; height: 60px; display: block; float: left;">
            
                <tr>
                    <td>
                        <div id="divConversationUpdateStatus">
                        </div>
                        Related to
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList CssClass="MedInput" ID="ddlProducts" runat="server" Style="width: 150px;"
                            TabIndex="2">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Severity
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList CssClass="MedInput" ID="ddlConversationSeverity" runat="server"
                            Style="width: 150px;" TabIndex="2">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Assigned To
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList CssClass="MedInput" ID="ddlUsers" runat="server" Style="width: 150px;"
                            TabIndex="2">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Category
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList CssClass="MedInput" ID="ddlCategory" runat="server" Style="width: 150px;"
                            TabIndex="2">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="width: 50px; height: 20px; display: block; float: right; text-align: left;">
                            <a class="StandardFormButton" id="A1" onclick="javascript:document.getElementById('hdnBoxId').value='LeadsBox<%= strConversationID%>';stringval =AjaxUpdateConversationDetails_Params('<%= strConversationID %>','ctl00_ContentBody_ddlProducts','ctl00_ContentBody_ddlConversationSeverity','ctl00_ContentBody_ddlUsers','ctl00_ContentBody_ddlCategory');ajaxpack.postAjaxRequest('partials/HandleConversation.aspx', stringval, AjaxUpdateConversationDetails, 'txt');return false;">
                                save</a>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div id="divTags" style="width: 200px; border-bottom: solid 1px #efefef; float: left;
                            font-family: Arial; font-size: 11px;">
                            <div style="width: 200px; float: left;">
                                <asp:Repeater runat="server" ID="rptrTags">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div style="height: 15px; background-color: #FFE97F; border: solid 1px #FFD11C; margin: 2px;
                                            padding: 2px; float: left">
                                            <%# Eval("Tag_Name")%>
                                            &nbsp; <a id="lnkDeleteNote" onclick="javascript:document.getElementById('hdnBoxId').value='divTags';stringval =AjaxDeleteLeadTags_Params('<%= strConversationID%>','<%# Eval("Tag_Id") %>');ajaxpack.postAjaxRequest('partials/HandleTags.aspx', stringval, AjaxDeleteLeadTags, 'txt');return false;">
                                                <img src="<%= CustomerSupport.Utility.SysResource.ImagePath%>delete.png" border="0"
                                                    style="vertical-align: middle;" /></a>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div style="width: 200px; float: left;">
                                <u>Available Tags</u><br />
                                <asp:Repeater runat="server" ID="rptrAllTags">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div style="height: 15px; background-color: #efefef; border: solid 1px #cccccc; margin: 2px;
                                            padding: 2px; float: left;">
                                            <%# Eval("Tag_Name")%>
                                            &nbsp; <a id="lnkDeleteNote" onclick="javascript:document.getElementById('hdnBoxId').value='divTags';stringval =AjaxAddTags_Params('<%= strConversationID%>','<%# Eval("Tag_Id") %>');ajaxpack.postAjaxRequest('partials/HandleTags.aspx', stringval, AjaxAddTags, 'txt');return false;">
                                                <img src="<%= CustomerSupport.Utility.SysResource.ImagePath%>add.png" border="0"
                                                    style="vertical-align: middle;" /></a>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div class="LeftSection" style="display: none;">
            <uc6:QuickConversationSearch ID="QuickConversationSearch" runat="server"></uc6:QuickConversationSearch>
        </div>
    </div>

    <script type="text/javascript">


        function AjaxAddLeads_Params(LeadID, NoteID) {

            var LeadName = document.getElementById('ctl00_ContentBody_txtLeadName').value;
            var LeadPhone = document.getElementById('ctl00_ContentBody_txtPhone').value;
            var LeadEmail = document.getElementById('ctl00_ContentBody_txtEmail').value;
            var LeadProduct = document.getElementById('ctl00_ContentBody_ddlProducts').value;
            var LeadNotes = document.getElementById('ctl00_ContentBody_txtDesc').value;
            var AccountID = document.getElementById('hdnAccountId').value;
            var LeadValue = document.getElementById('ctl00_ContentBody_txtLeadValue').value;
            var LeadOwner = document.getElementById('hdnLeadOwner').value;
            var poststr = "AccountID=" + encodeURI(AccountID) + "&LeadOwner=" + encodeURI(LeadOwner) + "&LeadValue=" + encodeURI(LeadValue) + "&LeadName=" + encodeURI(LeadName) + "&LeadPhone=" + encodeURI(LeadPhone) + "&LeadEmail=" + encodeURI(LeadEmail) + "&LeadNotes=" + encodeURI(LeadNotes) + "&LeadProduct=" + encodeURI(LeadProduct) + "&Action=E";

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
                        document.getElementById('NewLeadBox').innerHTML += myajax.responseText;
                        document.getElementById('ctl00_ContentBody_txtLeadName').value = '';
                        document.getElementById('ctl00_ContentBody_txtPhone').value = '';
                        document.getElementById('ctl00_ContentBody_txtEmail').value = '';
                        document.getElementById('ctl00_ContentBody_ddlProducts').value = '';
                        document.getElementById('ctl00_ContentBody_txtNewNotes').value = '';

                        document.getElementById('ctl00_ContentBody_txtLeadValue').value = '';

                    }
                    else {
                        document.getElementById('NewLeadBox').innerHTML = myajax.responseText;
                    }
                }
                else alert('problem');
            }
        }
        function AjaxEditLeads_Params(LeadID) {

            var LeadName = document.getElementById('ctl00_ContentBody_txtLeadName').value;
            var LeadPhone = document.getElementById('ctl00_ContentBody_txtPhone').value;
            var LeadEmail = document.getElementById('ctl00_ContentBody_txtEmail').value;
            var LeadProduct = document.getElementById('ctl00_ContentBody_ddlProducts').value;
            var LeadNotes = document.getElementById('ctl00_ContentBody_txtDesc').value;
            var AccountID = document.getElementById('hdnAccountId').value;
            var LeadValue = document.getElementById('ctl00_ContentBody_txtLeadValue').value;
            var LeadProbability = document.getElementById('hdnLeadProbability').value;
            var LeadStatus = document.getElementById('hdnLeadStatus').value;
            var poststr = "AccountID=" + encodeURI(AccountID) + "&ID=" + encodeURI(LeadID) + "&LeadStatus=" + encodeURI(LeadStatus) + "&LeadValue=" + encodeURI(LeadValue) + "&LeadName=" + encodeURI(LeadName) + "&LeadPhone=" + encodeURI(LeadPhone) + "&LeadEmail=" + encodeURI(LeadEmail) + "&LeadNotes=" + encodeURI(LeadNotes) + "&LeadProduct=" + encodeURI(LeadProduct) + "&LeadProbability=" + encodeURI(LeadProbability) + "&Action=E";

            //alert(poststr);
            return poststr;
        }

        //Step 2: Define a "callback" function to process the data returned by the Ajax request:
        function AjaxEditLeads() {
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

                        }
                        else {
                            document.getElementById('NewLeadBox').innerHTML += myajax.responseText;
                            document.getElementById('divErrorBox').innerHTML = 'Lead Saved';
                            document.getElementById('divErrorBox').className = 'MessageBox';
                            document.getElementById('divErrorBox').style.display = 'block';
                        }

                    }
                    else {
                        document.getElementById('NewLeadBox').innerHTML = myajax.responseText;
                    }
                }
                else alert('problem');
            }
        }

        var stringval = "";

        function AjaxReply_Params(LeadID, NotesTextbox, SelectField) {

            var Reply = document.getElementById(NotesTextbox).value;
            var ConversationStatus = document.getElementById(SelectField).value;
            var AccountID = document.getElementById('hdnAccountId').value;
            var poststr = "ID=" + LeadID + "&AccountID=" + encodeURI(AccountID) + "&Reply=" + encodeURI(escape(Reply)) + "&ConversationStatus=" + encodeURI(ConversationStatus) + "&Action=AR";

            //alert(poststr);
            return poststr;
        }

        //Step 2: Define a "callback" function to process the data returned by the Ajax request:
        function AjaxReply() {
            var myajax = ajaxpack.ajaxobj
            var myfiletype = ajaxpack.filetype
            var hdnDivBoxID = document.getElementById('hdnBoxId').value;

            if (myajax.readyState == 4) {
                //if request of file completed
                if (myajax.status == 200 || window.location.href.indexOf("http") == -1) { //if request was successful or running script locally
                    if (myfiletype == "txt") {
                        document.getElementById('divReplies').innerHTML = myajax.responseText;
                        document.getElementById('txtReply').value = "";
                        document.getElementById('divErrorBox').innerHTML = 'Reply Sent';
                        document.getElementById('divErrorBox').style.display = 'block';
                        document.getElementById('divErrorBox').className = 'MessageBox';
         
                    }
                    else {
                        document.getElementById('divReplies').innerHTML = myajax.responseText;
                        document.getElementById('divErrorBox').innerHTML = 'Some Problem';
                        document.getElementById('divErrorBox').style.display = 'block';
                        document.getElementById('divErrorBox').className = 'MessageBox_Warning';
                    }
                }
                else alert('problem');
            }
        }

     
        function AjaxAddTags_Params(LeadID, TagID) {

            var poststr = "ID=" + LeadID + "&Tag_ID=" + encodeURI(TagID) + "&Action=ATL";

            //alert(poststr);
            return poststr;
        }

        //Step 2: Define a "callback" function to process the data returned by the Ajax request:
        function AjaxAddTags() {
            var myajax = ajaxpack.ajaxobj
            var myfiletype = ajaxpack.filetype
            var hdnDivBoxID = 'divTags';

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

        function AjaxDeleteLeadTags_Params(LeadID, TagID) {

            var poststr = "ID=" + LeadID + "&Tag_ID=" + encodeURI(TagID) + "&Action=DTL";

            //alert(poststr);
            return poststr;
        }

        //Step 2: Define a "callback" function to process the data returned by the Ajax request:
        function AjaxDeleteLeadTags() {
            var myajax = ajaxpack.ajaxobj
            var myfiletype = ajaxpack.filetype
            var hdnDivBoxID = 'divTags';

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



        function AjaxUpdateConversationDetails_Params(LeadID, ProductSelectFeild,SeveritySelectFeild, AssignedToSelectFeild,CategoryID) {

            //var Reply = document.getElementById(NotesTextbox).value;
            //var ConversationStatus = document.getElementById(SelectField).value;
            var AccountID = document.getElementById('hdnAccountId').value;
            var ProductID = document.getElementById(ProductSelectFeild).value;
            var SeverityID = document.getElementById(SeveritySelectFeild).value;
            var AssignedToID = document.getElementById(AssignedToSelectFeild).value;
            var CategoryID=   document.getElementById(CategoryID).value;
            var poststr = "ID=" + LeadID + "&AccountID=" + encodeURI(AccountID) + "&ProductID=" + encodeURI(ProductID) + "&SeverityID=" + encodeURI(SeverityID) + "&AssignedToID=" + encodeURI(AssignedToID) +"&CategoryID=" + encodeURI(CategoryID) +"&Action=ACUD";

            //alert(poststr);
            return poststr;
        }

        //Step 2: Define a "callback" function to process the data returned by the Ajax request:
        function AjaxUpdateConversationDetails() {
            var myajax = ajaxpack.ajaxobj
            var myfiletype = ajaxpack.filetype
            var hdnDivBoxID = document.getElementById('hdnBoxId').value;

            if (myajax.readyState == 4) {
                //if request of file completed
                if (myajax.status == 200 || window.location.href.indexOf("http") == -1) { //if request was successful or running script locally
                    if (myfiletype == "txt") {
                        document.getElementById('divConversationUpdateStatus').innerHTML = myajax.responseText;
                        document.getElementById('divUpdateLeadErrorBox').innerHTML = 'Details Saved';
                        document.getElementById('divUpdateLeadErrorBox').style.display = 'block';
                        document.getElementById('divUpdateLeadErrorBox').className = 'MessageBox';
                        
                    }
                    else {
                        document.getElementById('divConversationUpdateStatus').innerHTML = myajax.responseText;
                        document.getElementById('divUpdateLeadErrorBox').innerHTML = 'Some Problem';
                        document.getElementById('divUpdateLeadErrorBox').style.display = 'block';
                        document.getElementById('divUpdateLeadErrorBox').className = 'MessageBox_Warning';
                   
                    }
                }
                else alert('problem');
            }
        }

    </script>

</asp:Content>
