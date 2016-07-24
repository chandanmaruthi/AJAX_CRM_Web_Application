<%@ Page Language="C#" MasterPageFile="~/home/external.master" AutoEventWireup="true"   EnableSessionState="False"
    CodeFile="CreateAccount.aspx.cs" Inherits="_Default" Title="delightDesk- Sign up"
    EnableViewState="false" %>
<asp:Content runat="server" ContentPlaceHolderID="Header">

    <script type="text/javascript" src="../common/js/ajaxroutine.js"></script>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentBody">
<table width="850" align=center><tr><td>
    <div style="width: 400px; font-size: 11px; font-family: Arial; font-weight: normal;
        color: Black; display: block; background-color: #ffffff; margin-left: 100px;
        margin-top: 25px; margin-bottom: 100px; padding-left: 10px; padding-top: 5px;
        border: solid 5px #cccccc; line-height: 1em; float: left;">
        <table width="400px" cellpadding="0" cellspacing="0" align="center" border="0">
            <tr>
                <td colspan="3" align="left" style="padding-bottom: 10px;">
                    <span class="MedLabel">Sign Up </span>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="padding-bottom: 10px;">
                    Setup you account in less than 5 minutes
                </td>
            </tr>
            <tr>
                <td>
                    <div runat="server" id="divMessage" visible="false">
                        <asp:Label runat="server" ID="lblMessage"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="3" width="200" align="Left">
                    <b>Company Name</b> [no spaces]
                </td>
            </tr>
            <tr>
                <td >
                    <div class="Required"></div>
                    
                    <asp:TextBox CssClass="MedInput" runat="server" ID="txtAccountName"           ></asp:TextBox>
                    
                    <div class="FieldInfo">
                    <div id="divAccountNameCheckBox">
                        Your Custom URL
                        <br />
                        http://companyname.cs.com   
                    </div></div><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator4" ControlToValidate="txtEmailID" runat="server" ErrorMessage="required"></asp:RequiredFieldValidator>
                    <asp:CustomValidator runat="server" ID="CustomValidator1" ControlToValidate="txtEmailID"
                        OnServerValidate="ValidateEmailIDs_ServerValidate" ErrorMessage="Invalid EmailID"> </asp:CustomValidator>
                
                </td>
                
               
            </tr>
            <tr>
                <td colspan="3" align="Left">
                    <b>Your Name</b>
                </td>
            </tr>
            <tr>
                <td>
                    <span class="Required"></span><asp:TextBox CssClass="MedInput" runat="server" ID="txtName"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="txtName"
                        runat="server" ErrorMessage="required"></asp:RequiredFieldValidator>
                </td>
               

            </tr>
            <tr>
                <td colspan="3" width="200" align="Left">
                    <b>Email ID</b>
                </td>
            </tr>
            <tr>
                <td >
                     <span class="Required"></span><asp:TextBox CssClass="MedInput" runat="server" ID="txtEmailID"></asp:TextBox>
                     <div class="FieldInfo">
                      <div id="divEmailCheckBox">  This will be your login id</div></div>
                     <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1" ControlToValidate="txtEmailID" runat="server" ErrorMessage="required"></asp:RequiredFieldValidator>
                    <asp:CustomValidator runat="server" ID="ValidateEmailIDs" ControlToValidate="txtEmailID"
                        OnServerValidate="ValidateEmailIDs_ServerValidate" ErrorMessage="Invalid EmailID"> </asp:CustomValidator>
              
                </td>
             
                
            </tr>
            <tr>
                <td colspan="3" align="Left">
                    <b>Password</b>
                </td>
            </tr>
            <tr>
                <td >
                    <span class="Required"></span><asp:TextBox CssClass="MedInput" TextMode="Password" runat="server" ID="txtPassword"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtPassword"
                        runat="server" ErrorMessage="required"></asp:RequiredFieldValidator>
                </td>
               
               
            </tr>
            <tr>
                <td colspan="3" align="Left">
                    <b>Retype Password</b>
                </td>
            </tr>
            <tr>
                <td>
                     <span class="Required"></span><asp:TextBox CssClass="MedInput" TextMode="Password" runat="server" ID="txtRetypePassword"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtRetypePassword"
                        runat="server" ErrorMessage="required"></asp:RequiredFieldValidator>
                    <asp:CustomValidator runat="server" ID="CustomValidator2" ControlToValidate="txtRetypePassword"
                        OnServerValidate="CheckPasswords" ErrorMessage="Passwords to not match"> </asp:CustomValidator>
                </td>
                
                
            </tr>
            <%--<tr>
                <td colspan="3" align="Left">
                    <b>Time Zone</b>
                </td>
            </tr>
            <tr>
                <td width="200" colspan="3">
                    <asp:DropDownList runat="server" ID="ddlTimeZone" CssClass="MedInput">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="ddlTimeZone"
                        runat="server" ErrorMessage="required"></asp:RequiredFieldValidator>
                </td>
            </tr>--%>
            <%--<tr>
                    <td>
                        Contact Email
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtContactEmail"></asp:TextBox><span class="Required">  </span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtName"
                            runat="server" ErrorMessage="required"></asp:RequiredFieldValidator>
                        <asp:CustomValidator runat="server" ID="CustomValidator1" ControlToValidate="txtContactEmail"
                            OnServerValidate="ValidateEmailIDs_ServerValidate" ErrorMessage="Invalid EmailID"> </asp:CustomValidator>
                    </td>
                    <td>
                        <span class="FieldInfo">used to send email alerts for leads</span>
                    </td>
                </tr>--%>
            <tr>
                <td colspan="3" style="border-top: dotted 1px #cccccc;">
                    
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <input type="checkbox" id="chkAcceptTerms" style="vertical-align: middle;" />I agree
                    to the <a href="TermsAndContitions.aspx">Terms of Service </a>and <a href="Privacy.aspx">
                        Privacy Policy</a> <br />If you have questions please <a href="mailto:<%= CustomerSupport.Utility.SysResource.FromID %>?subject=Query Regarding Signup">
                            email support</a> .
                </td>
            </tr>
            <tr><td colspan="4">
            
            <div style="width:375px;height:30px;border:solid 1px #cccccc; background-color:#FFEE9E;line-height:1.3em;font-weight:bold;padding:5px;text-align:center;">
            You have selected a <%= intUserCount %> User Plan. <br />
            Lets start your Free one month trail. 
             </div>
            </td></tr>
            <tr>
                <td colspan="2">
                    <asp:LinkButton runat="server" ID="lnkSave" OnClick="lnkSave_Click" OnClientClick="if(document.getElementById('chkAcceptTerms').checked==false){alert('Terms and Conditions must be accepted');};return document.getElementById('chkAcceptTerms').checked;"> 
                    <div Class="StandardFormButton">Signup</div></asp:LinkButton>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div style="border: solid 0px #cccccc; width: 300px; height: 100px; float: left;
        margin-left: 20px; margin-top: 25px; font-size: 11px; font-family: Arial;">
        <div style="width: 300px; float: left; font-weight: bold;">
            Browser Requirements</div>
        <div style="width: 300px; float: left; font-weight: normal;">
            Any of the following web browsers : IE 7 (PC), Firefox 2 or later
            (Mac, PC, or Linux), Safari 2 or later (Mac).<br />
            <br />
        </div>
        <div style="width: 300px; float: left; font-weight: bold;">
            Can I upgrade, downgrade, or cancel later?</div>
        <div style="width: 300px; float: left; font-weight: normal;">
            Absolutely. This  is a month-to-month service so you can upgrade, downgrade,
            or cancel at any time.<br />
            <br />
        </div>
    </div>
    </td></tr></table>
    
    <script type="text/javascript">
        var stringval = "";

        function AjaxCheckAccountName_Params() {

            var AccountName = document.getElementById('ctl00_ContentBody_txtAccountName').value;
            var poststr = "AccountName=" + encodeURI(AccountName) + "&Action=A";

            //alert(poststr);
            return poststr;
        }

        //Step 2: Define a "callback" function to process the data returned by the Ajax request:
        function AjaxCheckAccountName() {
            var myajax = ajaxpack.ajaxobj
            var myfiletype = ajaxpack.filetype
            //var hdnDivBoxID = document.getElementById('hdnBoxId').value;

            if (myajax.readyState == 4) {
                //if request of file completed
                if (myajax.status == 200 || window.location.href.indexOf("http") == -1) { //if request was successful or running script locally
                    if (myfiletype == "txt") {
                        document.getElementById('divAccountNameCheckBox').innerHTML = myajax.responseText;
                       
                    }
                    else {
                        document.getElementById('divAccountNameCheckBox').innerHTML = myajax.responseText;
                    }
                }
                else alert('problem');
            }
        }

        function AjaxCheckEmail_Params() {

            var Email = document.getElementById('ctl00_ContentBody_txtEmailID').value;
            var poststr = "Email=" + encodeURI(Email) + "&Action=E";

            //alert(poststr);
            return poststr;
        }

        //Step 2: Define a "callback" function to process the data returned by the Ajax request:
        function AjaxCheckEmail() {
            var myajax = ajaxpack.ajaxobj
            var myfiletype = ajaxpack.filetype
            //var hdnDivBoxID = document.getElementById('hdnBoxId').value;

            if (myajax.readyState == 4) {
                //if request of file completed
                if (myajax.status == 200 || window.location.href.indexOf("http") == -1) { //if request was successful or running script locally
                    if (myfiletype == "txt") {
                        document.getElementById('divEmailCheckBox').innerHTML = myajax.responseText;

                    }
                    else {
                        document.getElementById('divEmailCheckBox').innerHTML = myajax.responseText;
                    }
                }
                else alert('problem');
            }
        }
    </script>
</asp:Content>
