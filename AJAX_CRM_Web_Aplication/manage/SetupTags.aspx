<%@ Page Language="C#" MasterPageFile="~/manage/Internal.master" Buffer="false"  AutoEventWireup="true"
    CodeFile="SetupTags.aspx.cs" Inherits="SetupTags" Title="delightDesk- Fillup your account" %>

<%@ Register Src="~/Webcontrols/HeaderMenu.ascx" TagName="HeaderMenu" TagPrefix="uc1" %>
<%@ Register Src="~/Webcontrols/SettingsMenu.ascx" TagName="SettingsMenu" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <uc1:HeaderMenu ID="HeaderMenu" SetTab="3" runat="server" ShowCorpMenu="true" />
    <uc2:SettingsMenu ID="SettingsMenu" runat="server" SetTab="4" />
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentBody">
    <div class="PageContainer">
        <div class="PageHeader">
            Custom Tags <a class="PageLink" onclick="javascript:document.getElementById('divAddTags').style.display='block';"
                id="lnlAdLead" runat="server">Add New Tag </a>
        </div>
        <div style="width: 300px; background-color: Green; border: solid 1px #cccccc;" runat="server"
            id="divMessage" visible="false">
            <asp:Label runat="server" ID="lblMessage"></asp:Label>
        </div>
            <input type="hidden" id="hdnAccountID" value="<%= strAccountID %>" />
            <input type="hidden" id="hdnSelectTagID" value="" />

        <div id="divAddTags" style="display: none;">
            <table cellpadding="0" cellspacing="0" border="0" style="background-color: #eeeeee;
                width: 770px;">
                 <tr><td>
                <div id="divErrorBox" style="display:none;"></div>
                </td></tr>
                <tr>
                    <td align="left">
                        Name</td>
                </tr>
                <tr>
                    <td>
                    <div class="Required"></div>
                        <input type="text" id="txtName" maxlength="100" class="MedInput" tabindex="1" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5" align="right">
                        <div class="WaitBox" id="divAddTagWaitBox" style="display:none;">
                        </div>
                        <a id="lnkDeleteNote"  class="StandardFormButton" onclick="javascript:stringval =AjaxAddTag_Params();ajaxpack.postAjaxRequest('partials/HandleTags.aspx', stringval, AjaxAddTag, 'txt');return false;">
                            Add Tag</a> , <a id="A1" onclick="javascript:document.getElementById('divAddTags').style.display='none';return false;">
                                Close</a>
                    </td>
                </tr>
            </table>
        </div>
        <div id="TagsDiv">
            <asp:Repeater ID="rptrTags" runat="server">
                <ItemTemplate>
                    <div class="LeadDeck">
                        <div class="MedLabel" style="width: 600px; float: left;">
                            <%# Eval("Tag_Name")%>
                        </div>
                        <div style="width: 100px; float: left;">
                            <a id="lnkDeleteProduct" onclick="javascript:var ConfirmDelete= confirm('Warning: You are about to delete a tag, Are you sure ?');if(ConfirmDelete){document.getElementById('hdnSelectTagID').value='<%# Eval("Tag_ID")%>'; stringval =AjaxDeleteTag_Params();ajaxpack.postAjaxRequest('partials/HandleTags.aspx', stringval, AjaxDeleteTag, 'txt');return false;}else{return false;};">
                                Delete </a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
<div class="LeftContainer">
<div class="HelpContainer">
<div class="HelpHeader">About Custom Tags</div>
<div class="HelpContent">
<b>What are Tags ?</b><br />
Tags are just simple words , you have any word as a tag. For Example. We can 
add "Super Hot", "High Value" as tags.
Tags help you classify leads in your own ways. <br />
<b>How can I use Tags ?</b><br />
Once you have created tags you may 
<ul>
<li>- Add tags to lead</li>
<li>- View leads by tags</li>
</ul>
<br />
<b>Can I Remove Tags Later</b>
You may add and remove tags at any time.   
</div>
</div>
</div>
    <script type="text/javascript">
    var stringval="";
    function AjaxAddTag_Params()
    {
        var Name=document.getElementById('txtName').value ; ;        
        var AccountID=document.getElementById('hdnAccountID').value ;
        var poststr = "AccountID=" + encodeURI(AccountID) + "&Name=" + encodeURI(Name) +"&Action=A";
       
        //alert(poststr);
         return poststr;
    }

    //Step 2: Define a "callback" function to process the data returned by the Ajax request:
    function AjaxAddTag()
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
                    document.getElementById('TagsDiv').innerHTML =myajax.responseText;
                    
                    document.getElementById('divErrorBox').innerHTML ='New Tag Added';
                    document.getElementById('divErrorBox').className='MessageBox';
                    document.getElementById('divErrorBox').style.display='block';
                    
                    document.getElementById('txtName').value = '';
                    }
                    
                    
                    
                    

                }
                else
                {  
                     document.getElementById('NewLeadBox').innerHTML=myajax.responseText;
                }
            }
            else alert('problem');
        }
    }
    function AjaxDeleteTag_Params()
    {
        var TagID=document.getElementById('hdnSelectTagID').value ;
        var poststr = "TagID=" + encodeURI(TagID) + "&Action=D";
        document.getElementById('divAddTagWaitBox').style.display = 'block';
        //alert(poststr);
         return poststr;
    }

    //Step 2: Define a "callback" function to process the data returned by the Ajax request:
    function AjaxDeleteTag()
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
                    document.getElementById('TagsDiv').innerHTML =myajax.responseText;
                    document.getElementById('divAddTagWaitBox').style.display = 'none';                 

                }
                else
                {
                    document.getElementById('NewLeadBox').innerHTML = myajax.responseText;
                    document.getElementById('divAddTagWaitBox').style.display = 'none';                 
                }
            }
            else alert('problem');
        }
    }
    
    
    </script>

</asp:Content>
