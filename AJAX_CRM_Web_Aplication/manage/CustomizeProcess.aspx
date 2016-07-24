<%@ Page Language="C#" MasterPageFile="~/manage/Internal.master" Buffer="false"  AutoEventWireup="true"
    CodeFile="CustomizeProcess.aspx.cs" Inherits="CustomizeProcess" Title="delightDesk- Fillup your account" %>

<%@ Register Src="~/Webcontrols/HeaderMenu.ascx" TagName="HeaderMenu" TagPrefix="uc1" %>
<%@ Register Src="~/Webcontrols/SettingsMenu.ascx" TagName="SettingsMenu" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <uc1:HeaderMenu ID="HeaderMenu" SetTab="3" runat="server" ShowCorpMenu="true" />
    <uc2:SettingsMenu ID="SettingsMenu" runat="server" SetTab="3" />
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentBody">
    <div class="PageContainer">
        <div class="PageHeader">
            Lead Flow <a class="PageLink" onclick="javascript:document.getElementById('divAddPeople').style.display='block';"
                id="lnlAdLead" runat="server">Add New Lead Status </a>
        </div>
        <div style="width: 300px; background-color: Green; border: solid 1px #cccccc;" runat="server"
            id="divMessage" visible="false">
            <asp:Label runat="server" ID="lblMessage"></asp:Label>
        </div>
        <input type="hidden" id="hdnAccountID" value="<%= strAccountID %>" />
        <input type="hidden" id="hdnSelectStatusID" value="" />
        <div id="divAddPeople" style="display: none;">
            <table cellpadding="0" cellspacing="0" border="0" style="background-color: #eeeeee;
                width: 770px;">
                 <tr><td colspan=4>
                <div id="divErrorBox" style="display:none;"></div>
                </td></tr>
                <tr>
                    <td align="left">
                        Status Name</td>
                    <td align="left">
                        Percentage Completion
                    </td>
                    <td align="left">
                        Order</td>
                </tr>
                <tr>
                    <td>
                        <input type="text" id="txtStatusName" maxlength="100" class="MedInput" tabindex="1" />
                    </td>
                    <td>
                        <input type="text" id="txtPercentatgeCompletion" maxlength="100" class="MedInput"
                            style="width: 100px;" tabindex="2" />
                    </td>
                    <td>
                        <input type="text" maxlength="15" id="txtOrder" style="width: 100px;" class="MedInput"
                            tabindex="3" />
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="6">
                        Status Description</td>
                </tr>
                <tr>
                    <td colspan="6">
                        <input type="text" id="txtStatusDesc" maxlength="100" style="width: 600px;" class="MedInput"
                            tabindex="4" value="Hi, I have added you to delightDeskfollow this link and login." />
                    </td>
                </tr>
                <tr>
                    <td colspan="5" align="right">
                        <div class="WaitBox" id="divAddLeadWaitBox">
                        </div>
                        <a id="lnkDeleteNote" onclick="javascript:stringval =AjaxAddLeadStatus_Params();ajaxpack.postAjaxRequest('partials/HandleProcess.aspx', stringval, AjaxAddLeadStatus, 'txt');return false;">
                            Add User</a> , <a id="A1" onclick="javascript:document.getElementById('divAddPeople').style.display='none';return false;">
                                Close</a>
                    </td>
                </tr>
            </table>
        </div>
        <div id="divAccountLeads">
            <asp:Repeater ID="rptrAccountLeadStatus" runat="server">
                <ItemTemplate>
                    <div class="LeadDeck">
                        <div class="MedLabel" style="width: 600px; float: left;">
                            <%# Eval("Status_Name")%>
                        </div>
                        <div style="width: 100px; float: left;">
                            <a id="lnkEditProduct" onclick="javascript:stringval =AjaxEditProduct_Params();ajaxpack.postAjaxRequest('partials/HandleProcess.aspx', stringval, AjaxEditProduct, 'txt');return false;">
                                Edit </a>, <a id="lnkDeleteProduct" onclick="javascript:var ConfirmDelete= confirm('Warning: You are about to delete a product/service,Are you sure ?');if(ConfirmDelete){document.getElementById('hdnSelectStatusID').value='<%# Eval("Status_ID")%>'; stringval =AjaxDeleteStatus_Params();ajaxpack.postAjaxRequest('partials/HandleProcess.aspx', stringval, AjaxDeleteStatus, 'txt');return false;}else{return false;};">
                                    Delete </a>
                        </div>
                        <div style="width: 200px; float: left;">
                            e:<%# Eval("Status_Desc")%>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
<div class="LeftContainer">
<div class="HelpContainer">
<div class="HelpHeader">About Process </div>
<div class="HelpContent">
<b>What is Customised Process?</b><br />
We have defined a simple business process for you. how ever if you run your business
differently you  may define you processes here. <br />

</div>
</div>
</div>
    <script type="text/javascript">
    var stringval="";
    function AjaxAddLeadStatus_Params()
    {
        var StatusName=document.getElementById('txtStatusName').value ;
        var PercentageCompletion=document.getElementById('txtPercentatgeCompletion').value ;
        var Order=document.getElementById('txtOrder').value ;        
        var StatusDesc=document.getElementById('txtStatusDesc').value ;        
        var AccountID=document.getElementById('hdnAccountID').value ;
        var poststr = "AccountID=" + encodeURI(AccountID) + "&StatusName=" + encodeURI(StatusName) +"&PercentageCompletion=" + encodeURI(PercentageCompletion) + "&Order=" + encodeURI(Order) +"&StatusDesc=" + encodeURI(StatusDesc) + "&Action=A";
       
        //alert(poststr);
         return poststr;
    }

    //Step 2: Define a "callback" function to process the data returned by the Ajax request:
    function AjaxAddLeadStatus()
    {
        var myajax=ajaxpack.ajaxobj
        var myfiletype=ajaxpack.filetype
        //var hdnDivBoxID=document.getElementById('hdnBoxId').value;
        
        if (myajax.readyState == 4)
        { 
            //if request of file completed
            if (myajax.status==200 || window.location.href.indexOf("http")==-1)
            { //if request was successful or running script locally
                if (myfiletype=="txt")
                {
                
                if(myajax.responseText.substring(0,5)=="ERROR")
                    {
                    document.getElementById('divErrorBox').innerHTML =myajax.responseText;
                    document.getElementById('divErrorBox').style.display='block';
                    document.getElementById('divErrorBox').className='MessageBox_Warning';
                    
                    }
                    else
                    {
                    document.getElementById('divAccountLeads').innerHTML =myajax.responseText;
                    
                    document.getElementById('divErrorBox').innerHTML ='New Lead Added';
                    document.getElementById('divErrorBox').className='MessageBox';
                    document.getElementById('divErrorBox').style.display='block';
                    
                       
                    document.getElementById('txtStatusName').value = '';
                    document.getElementById('txtPercentatgeCompletion').value = '' ;
                    document.getElementById('txtOrder').value = '' ;
                    document.getElementById('txtStatusDesc').value = '' ;
                    }
                 
                    

                }
                else
                {  
                     document.getElementById('divAccountLeads').innerHTML=myajax.responseText;
                }
            }
            else alert('problem');
        }
    }
    function AjaxDeleteStatus_Params()
    {
        var Status_ID=document.getElementById('hdnSelectStatusID').value ;
        var poststr = "Status_ID=" + encodeURI(Status_ID) + "&Action=D";
       document.getElementById('divAddLeadWaitBox').style.display='block';
        //alert(poststr);
         return poststr;
    }

    //Step 2: Define a "callback" function to process the data returned by the Ajax request:
    function AjaxDeleteStatus()
    {
        var myajax=ajaxpack.ajaxobj
        var myfiletype=ajaxpack.filetype
        //var hdnDivBoxID=document.getElementById('hdnBoxId').value;
        
        if (myajax.readyState == 4)
        { 
            //if request of file completed
            if (myajax.status==200 || window.location.href.indexOf("http")==-1)
            { //if request was successful or running script locally
                if (myfiletype=="txt")
                {
                    document.getElementById('divAccountLeads').innerHTML =myajax.responseText;  
                    document.getElementById('divAddLeadWaitBox').style.display='none';                 

                }
                else
                {  
                     document.getElementById('divAccountLeads').innerHTML=myajax.responseText;
                }
            }
            else alert('problem');
        }
    }
    
    
    </script>

</asp:Content>
