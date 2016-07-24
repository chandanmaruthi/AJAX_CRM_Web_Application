<%@ Page Language="C#" MasterPageFile="~/SupportCenter/SupportCenterMaster.master"
    Buffer="true" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="SupportCenter_default"
    Title="Support Center" %>
<%@ OutputCache VaryByParam="*" Duration="60" Location="Server" %>
<%@ Register Src="~/SupportCenter/webcontrols/PortalHeaderMenu.ascx" TagName="PortalHeaderMenu"
    TagPrefix="uc1" %>
<%@ Register Src="SupportCenter/webcontrols/RightMenu.ascx" TagName="RightMenu" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="Server">
    <uc1:PortalHeaderMenu ID="PortalHeaderMenu" SetTab="1" runat="server" ShowCorpMenu="false" />

    <script language="javascript">

        function ChangeTab(TabId) {
            document.getElementById('divTab1').className = 'QuestionTabOff';
            document.getElementById('divTab2').className = 'QuestionTabOff';
            document.getElementById('divTab3').className = 'QuestionTabOff';
            document.getElementById('divTab4').className = 'QuestionTabOff';
            document.getElementById(TabId).className = 'QuestionTabOn';
        }
    
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="Server">
    <div class="LeftBox">
        <div style="width: 700px;">
            <input type="hidden" id="hdnBoxId" value="" />
            <input type="hidden" id="hdnAccountId" value="<%= strAccountID %>" />
            <input type="hidden" id="hdnConversationType" value="<%= strConversationType %>" />
            <div style="width: 710px; height: 60px; padding: 5px; background-color: White; background-image: url('common/images/Searchbg.gif');
                background-repeat: repeat-x; border: solid 1px #D1EBFF;">
                <div class="MedLabel" style="height: 29px; color: #77ABD4;">
                    <div style="width: 710px; float: left">
                        Start Typing and your answers will appear instantly</div>
                    <div class="WaitBox" id="divWaitSearch" style="display: none;">
                    </div>
                </div>
                <div style="width: 710px; height: 29px; color: #a0a0a0;">
                    <input id="txtSearch" type="text" class="MedInput" style="width: 710px; float: left;"
                        onchange="javascript:stringval =AjaxSearch_Params(document.getElementById('txtSearch').value);ajaxpack.postAjaxRequest('<%= CustomerSupport.Utility.SysResource.HomePath %>/SupportCenter/SearchResults.aspx', stringval, AjaxSearch, 'txt');document.getElementById('divSearchResults').style.display='block';return false;" />
                    <div style="width: 710px; position: relative; background-color: #ffffff; border: solid 1px #cccccc;
                        float: left;" id="divSearchResults">
                    </div>
                </div>
            </div>
            <div id="divErrorBox" style="display: none;">
            </div>
            <div style="width: 700px; height: 30px; background-color: White;">
                <div id="divTab1" style="margin-left: 10px;" class="QuestionTabOn" onclick="javascript:ChangeTab('divTab1');document.getElementById('hdnConversationType').value='A3351F34-CB58-4940-A452-96F2A0527181';">
                    <a onclick="javascript:document.getElementById('divQbox').style.display='block';"><b>
                        Ask a Question</b> </a>
                </div>
                <div id="divTab2" class="QuestionTabOff" onclick="javascript:ChangeTab('divTab2');document.getElementById('hdnConversationType').value='F43442F1-617A-414D-948B-07CADEE09191';">
                    <b>Give Feedback</b>
                </div>
                <div id="divTab3" class="QuestionTabOff" onclick="javascript:ChangeTab('divTab3');document.getElementById('hdnConversationType').value='F43442F1-617A-414D-948B-07CADEE09191';">
                    <b>Share an Ideas</b>
                </div>
                <div id="divTab4" class="QuestionTabOff" onclick="javascript:ChangeTab('divTab4');document.getElementById('hdnConversationType').value='F43442F1-617A-414D-948B-07CADEE09191';">
                    <b>Give Tips</b>
                </div>
            </div>
            <div class="QBox" id="divQbox" style="height: 110px">
                <%--<div style="float: right">
                    <a onclick="javascript:document.getElementById('divQbox').style.display='none';"><b>
                        Close</b> </a>
                </div>--%>
                <div style="width: 670px; float: left; height: 20px;">
                    How can we help you ?</div>
                <div style="width: 670px; float: left; height: 60px; margin-bottom: 10px;">
                    <textarea class="MedInput" id="txtConversationDesc" style="width: 675px; height: 60px;
                        background-color: #ffffff; border: solid 1px #cccccc;">ask your question 
                        </textarea>
                    <div style="width: 670px; height: 20px; text-align: right;">
                        <a onclick="javascript:document.getElementById('divMoreInfo').style.display='block';this.style.display='none';document.getElementById('divQbox').style.height='210px';">
                            Continue </a>
                    </div>
                </div>
                <div id="divMoreInfo" style="display: none">
                    <div style="width: 470px; float: left; height: 40px; margin-bottom: 10px;">
                        <div style="width: 470px; float: left; height: 20px;">
                            Lets give a nice title</div>
                        <div style="width: 470px; float: left; height: 25px;">
                            <input class="MedInput" type="text" id="txtConversationTitle" style="width: 450px;" />
                        </div>
                    </div>
                    <div style="width: 200px; float: left; height: 40px;">
                        <div style="width: 200px; float: left; height: 20px;">
                            Related to</div>
                        <div style="width: 200px; float: left; height: 25px;">
                            <asp:DropDownList CssClass="MedInput" ID="ddlProducts" runat="server" Style="width: 200px;
                                border: solid 1px #cccccc;" TabIndex="2">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div style="width: 670px; float: left; height: 40px;">
                        <div style="width: 200px; float: left; height: 40px;">
                            <div style="width: 200px; float: left; height: 20px;">
                                Name</div>
                            <div style="width: 200px; float: left; height: 20px;">
                                <input class="MedInput" type="text" id="txtUserName" style="width: 180px;" />
                            </div>
                        </div>
                        <div style="width: 200px; float: left; height: 40px;">
                            <div style="width: 200px; float: left; height: 20px;">
                                Email</div>
                            <div style="width: 200px; float: left; height: 20px;">
                                <input class="MedInput" type="text" id="txtUserEmail" style="width: 180px;" />
                            </div>
                        </div>
                        <div style="width: 120px; float: left; height: 40px;">
                            <div style="width: 120px; float: left; height: 20px;">
                                Are you human ? 3+4 =</div>
                            <div style="width: 120px; float: left; height: 20px;">
                                <input class="MedInput" type="text" id="Text1" style="width: 120px;" />
                            </div>
                        </div>
                        <div style="width: 135px; float: left; height: 40px; padding-left: 15px;">
                            <div style="width: 120px; float: left; height: 15px;">
                            </div>
                            <div class="WaitBox" id="Wait_AddLead" style="display: none;">
                            </div>
                            <div class="BigGreyButton" style="vertical-align: middle;">
                                <a id="lnkAddConversation" onclick="javascript:document.getElementById('hdnBoxId').value='LeadBox<%# Eval("Conversation_ID")%>';stringval =AjaxAddLeads_Params();ajaxpack.postAjaxRequest('<%= CustomerSupport.Utility.SysResource.HomePath %>/supportcenter/partials/SC_HandleConversation.aspx', stringval, AjaxAddLeads, 'txt');return false;">
                                    Save </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="NewLeadBox">
        </div>
        <div style="width: 700px;">
            <div style="width: 700px;">
                <h2>
                    Active Topics</h2>
            </div>
            <asp:Repeater runat="server" ID="rptrHotTopics">
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
                                    <a style="float: left; font-size: 14px;" href="<%# CustomerSupport.Utility.SysResource.HomePath + Eval("Account_Name").ToString()+"/"+Eval("Conversation_Number").ToString()+"/"+ HttpUtility.UrlEncode(Eval("Conversation_Title").ToString()) %>">
                                        <b> <%# Eval("Conversation_Title").ToString().Length > 40 ? Eval("Conversation_Title").ToString().Remove(40) + "..." : Eval("Conversation_Title") %>
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
                                    <%# Eval("Conversation_Type_Name") %>
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
            <div style="width: 700px; float: left;">
                <div style="width: 700px; height: 20px;">
                    <h2>
                        Most Viewed Topics</h2>
                </div>
                <div style="width: 700px;">
                    <asp:Repeater runat="server" ID="rptrMostViewed">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="HotTopics">
                                <div class="PictureBox">
                                    <div class="ProfilePicture">
                                    </div>
                                    <div class="ProfileText">
                                        <%--<%# Eval("User_Name") %>--%></div>
                                </div>
                                <div class="CallOutTopics">
                                    <div style="width: 671px; height: 14px; float: left; background-image: url('<%= CustomerSupport.Utility.SysResource.ImagePath %>callout_top.gif');
                                        background-repeat: no-repeat;">
                                    </div>
                                    <div style="width: 646px; float: left; padding-left: 25px; background-image: url('<%= CustomerSupport.Utility.SysResource.ImagePath %>callout_middle.gif');
                                        background-repeat: repeat-y;">
                                        <div style="width: 500px; height: 20px; float: left; border: solid 0px #dddddd; padding: 2px;">
                                            <a style="float: left; font-size: 14px;" href="<%# CustomerSupport.Utility.SysResource.HomePath + "/"+Eval("Conversation_Number").ToString()+"/"+ HttpUtility.UrlEncode(Eval("Conversation_Title").ToString()) %>">
                                              <b>  <%# Eval("Conversation_Title").ToString().Length > 40 ? Eval("Conversation_Title").ToString().Remove(40) + "..." : Eval("Conversation_Title") %>
                                           </b> </a>
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
                                            <%--<%# Eval("Conversation_Type_Name") %>--%>
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
                        <FooterTemplate>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
    <div class="RightBox">
        <div class="roundcont" style="width: 220px; background-color: #F7FBFF; color: #404040;">
            <div class="roundtop">
                <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>tl.gif" alt="" width="15"
                    height="15" class="corner" style="display: none" />
            </div>
            <p>
                <%= GetState(CustomerSupport.CustomerSupportControl.Welcome_Message).Replace("\n","<br>")%>
                <br />
                <br />
                Customer Support: 342-324-3243<br />
                Technical Support :223-233-2332<br />
            </p>
            <div class="roundbottom">
                <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>bl.gif" alt="" width="15"
                    height="15" class="corner" style="display: none" />
            </div>
        </div>
        <uc2:RightMenu ID="RightMenu1" runat="server" />
    </div>

    <script language="javascript">
        function AjaxAddLeads_Params() {
            document.getElementById('Wait_AddLead').style.display = 'block';

            var ConversationTitle = document.getElementById('txtConversationTitle').value;
            var ConversationDesc = document.getElementById('txtConversationDesc').value;
            var ProductID = document.getElementById('ctl00_Body_ddlProducts').value;
            //var ConversationStatus = document.getElementById('ctl00_ContentBody_ddlConversationStatus').value;
            //var ConversationSeverity = document.getElementById('ctl00_ContentBody_ddlConversationSeverity').value;
            var varConversationType = document.getElementById('hdnConversationType').value;
            var UserName = document.getElementById('txtUserName').value;
            var UserEmail = document.getElementById('txtUserEmail').value;
            //var UserPhone = document.getElementById('txtUserPhone').value;

            var AccountID = document.getElementById('hdnAccountId').value;

            //var LeadProbability=document.getElementById('hdnLeadProbability').value ;

            var poststr = "AccountID=" + encodeURI(AccountID) + "&ConversationType=" + encodeURI(varConversationType) + "&ConversationTitle=" + encodeURI(ConversationTitle) + "&ConversationDesc=" + encodeURI(ConversationDesc) + "&ProductID=" + encodeURI(ProductID) + "&UserName=" + encodeURI(UserName) + "&UserEmail=" + encodeURI(UserEmail) + "&Action=A";

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

                        }
                        else {
                            document.getElementById('NewLeadBox').innerHTML += myajax.responseText;

                            document.getElementById('divErrorBox').innerHTML = 'Message Sent. We will get back to soon';
                            document.getElementById('divErrorBox').className = 'MessageBox';
                            document.getElementById('divErrorBox').style.display = 'block';

                            document.getElementById('Wait_AddLead').style.display = 'none';
                            document.getElementById('txtConversationTitle').value = '';
                            document.getElementById('txtConversationDesc').value = '';
                            document.getElementById('txtUserName').value = '';
                            document.getElementById('txtUserEmail').value = '';
                            //document.getElementById('txtUserPhone').value = '';

                        }

                    }
                    else {
                        document.getElementById('NewLeadBox').innerHTML = myajax.responseText;
                    }
                }
                else alert('problem');
            }
        }

        function AjaxSearch_Params(SearchString) {
            document.getElementById('divWaitSearch').style.display = 'block';

            //var Search = document.getElementById('txtSearch').value;

            var poststr = "st=" + encodeURI(SearchString) + "&PageIndex=0";

            //alert(poststr);
            return poststr;
        }

        //Step 2: Define a "callback" function to process the data returned by the Ajax request:
        function AjaxSearch() {
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

                        }
                        else {
                            document.getElementById('divSearchResults').innerHTML = myajax.responseText;
                            //alert(myajax.responseText);
                            document.getElementById('divWaitSearch').style.display = 'none';

                        }

                    }
                    else {
                        document.getElementById('divSearchResults').innerHTML = myajax.responseText;
                    }
                }
                else alert('problem');
            }
        }
    </script>

</asp:Content>
