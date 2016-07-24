<%@ Page Language="C#" MasterPageFile="~/manage/Internal.master" AutoEventWireup="true"
    Buffer="false" CodeFile="People.aspx.cs" Inherits="People" Title="delightDesk- Fillup your account" %>

<%@ Register Src="~/Webcontrols/HeaderMenu.ascx" TagName="HeaderMenu" TagPrefix="uc1" %>
<%@ Register Src="~/Webcontrols/SettingsMenu.ascx" TagName="SettingsMenu" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <uc1:HeaderMenu ID="HeaderMenu" SetTab="3" runat="server" ShowCorpMenu="true" />
    <uc2:SettingsMenu ID="SettingsMenu" runat="server" SetTab="2" />
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentBody">
    <div class="PageContainer">
        <div class="PageHeader">
            People
            
            <div runat=server id="divAddUsers" >
             <a class="PageLink" onclick="javascript:document.getElementById('divAddPeople').style.display='block';"
                id="lnlAdLead" runat="server">Add Users </a>
                </div>
        </div>
        <div style="width: 300px; background-color: Green; border: solid 1px #cccccc;" runat="server"
            id="divMessage" visible="false">
            <asp:Label runat="server" ID="lblMessage"></asp:Label>
        </div>
        <input type="hidden" id="hdnAccountID" value="<%= strAccountID %>" />
        <input type="hidden" id="hdnSelectUserID" value="" />
        <div id="divAddPeople" style="display: none;">
            <table cellpadding="0" cellspacing="0" border="0" style="background-color: #eeeeee;
                width: 770px;">
                <tr>
                    <td>
                        <div id="divErrorBox" style="display: none;">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Name *
                    </td>
                    <td align="left">
                        Email *
                    </td>
                    <td align="left">
                        Phone
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="text" id="txtName" maxlength="100" class="MedInput" tabindex="1" />
                    </td>
                    <td>
                        <input type="text" id="txtEmail" maxlength="100" class="MedInput" style="width: 200px;"
                            tabindex="2" />
                    </td>
                    <td>
                        <input type="text" maxlength="15" id="txtPhone" style="width: 200px;" class="MedInput"
                            tabindex="3" />
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="6">
                        Message *
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <input type="text" id="txtMessage" maxlength="100" style="width: 600px;" class="MedInput"
                            tabindex="4" value="Hi, I have added you to deligthDesk follow this link and login." />
                    </td>
                </tr>
                <tr>
                    <td colspan="5" align="right">
                        <div class="WaitBox" id="divAddPeopleWaitBox" style="display: none;">
                        </div>
                        <a id="lnkDeleteNote"  class="StandardFormButton" onclick="javascript:stringval =AjaxAddPeople_Params();ajaxpack.postAjaxRequest('partials/HandlePeople.aspx', stringval, AjaxAddPeople, 'txt');return false;">
                            Add User</a> , <a id="A1" onclick="javascript:document.getElementById('divAddPeople').style.display='none';return false;">
                                Close</a>
                    </td>
                </tr>
            </table>
        </div>
        
        <div style="width:600px;height:20px;background-color:#FFEE9E;float:left;padding:5px;">
        <b>
        You can add upto <asp:Label runat=server ID="lblUserCount"></asp:Label> users to your team.
        </b>
        </div>
        <div id="PeopleDiv" style="width:700px;float:left;">
            <asp:Repeater ID="rptrProducts" runat="server">
                <ItemTemplate>
                    <div style="width: 300px; height: 100px; float: left; background-color: #f5f5f5;
                        border: solid 1px #cccccc; margin: 5px; padding: 5px;">
                        <div class="ProfilePicture">
                        </div>
                        <div class="MedLabel" style="width: 200px; float: left;">
                            <%# Eval("User_F_Name")%>
                        </div>
                        <div style="width: 200px; float: left;">
                            e:<%# Eval("Email_ID")%>
                        </div>
                        <div style="width: 200px; float: left;">
                            p:<%# Eval("Phone_1")%>
                        </div>
                        <div style="width: 100px; float: left;">
                            <a id="lnkEditProduct" onclick="javascript:stringval =AjaxEditProduct_Params();ajaxpack.postAjaxRequest('partials/HandlePeople.aspx', stringval, AjaxEditProduct, 'txt');return false;">
                                Edit </a>, <a id="lnkDeleteProduct" onclick="javascript:var ConfirmDelete= confirm('Warning: You are about to remove an user,Are you sure ?');if(ConfirmDelete){document.getElementById('hdnSelectUserID').value='<%# Eval("User_ID")%>'; stringval =AjaxDeleteProduct_Params();ajaxpack.postAjaxRequest('partials/HandlePeople.aspx', stringval, AjaxDeleteProduct, 'txt');return false;}else{return false;};">
                                    Delete </a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        
    </div>
    <div class="LeftContainer">
        <div class="HelpContainer">
            <div class="HelpHeader">
                About People</div>
            <div class="HelpContent">
                <b>What is People?</b><br />
                Here you can add your sales team to CustomerSupport. Enter their name, their email
                and we will send them an invitation to login.
                <br />
                <b>What are Permissions?</b><br />
                You can assign permissions to your team members. Like who sees what.
            </div>
        </div>
    </div>

    <script type="text/javascript">
        var stringval = "";
        function AjaxAddPeople_Params() {
            document.getElementById('divAddPeopleWaitBox').style.display = 'block';
            var Name = document.getElementById('txtName').value;
            var Email = document.getElementById('txtEmail').value;
            var Phone = document.getElementById('txtPhone').value;
            var Message = document.getElementById('txtMessage').value;
            var AccountID = document.getElementById('hdnAccountID').value;
            var poststr = "AccountID=" + encodeURI(AccountID) + "&Name=" + encodeURI(Name) + "&Message=" + encodeURI(Message) + "&Email=" + encodeURI(Email) + "&Phone=" + encodeURI(Phone) + "&Action=A";

            //alert(poststr);
            return poststr;
        }

        //Step 2: Define a "callback" function to process the data returned by the Ajax request:
        function AjaxAddPeople() {
            var myajax = ajaxpack.ajaxobj
            var myfiletype = ajaxpack.filetype
            //var hdnDivBoxID=document.getElementById('hdnBoxId').value;
            document.getElementById('divAddPeopleWaitBox').style.display = 'none';
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
                            document.getElementById('PeopleDiv').innerHTML = myajax.responseText;

                            document.getElementById('divErrorBox').innerHTML = 'User Added';
                            document.getElementById('divErrorBox').className = 'MessageBox';
                            document.getElementById('divErrorBox').style.display = 'block';


                            document.getElementById('txtName').value = '';
                            document.getElementById('txtEmail').value = '';
                            document.getElementById('txtPhone').value = '';
                        }


                    }
                    else {
                        document.getElementById('NewLeadBox').innerHTML = myajax.responseText;
                    }
                }
                else alert('problem');
            }
        }
        function AjaxDeletePeople_Params() {
            var UserID = document.getElementById('hdnSelectUserID').value;
            var poststr = "UserID=" + encodeURI(UserID) + "&Action=D";
            document.getElementById('divAddLeadWaitBox').style.display = 'block';
            //alert(poststr);
            return poststr;
        }

        //Step 2: Define a "callback" function to process the data returned by the Ajax request:
        function AjaxDeletePeople() {
            var myajax = ajaxpack.ajaxobj
            var myfiletype = ajaxpack.filetype
            //var hdnDivBoxID=document.getElementById('hdnBoxId').value;

            if (myajax.readyState == 4) {
                //if request of file completed
                if (myajax.status == 200 || window.location.href.indexOf("http") == -1) { //if request was successful or running script locally
                    if (myfiletype == "txt") {
                        document.getElementById('PeopleDiv').innerHTML = myajax.responseText;
                        document.getElementById('divAddLeadWaitBox').style.display = 'none';

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
