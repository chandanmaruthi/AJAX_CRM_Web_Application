<%@ Page Language="C#" MasterPageFile="~/manage/Internal.master" Buffer="false"  AutoEventWireup="true"
    CodeFile="Setup.aspx.cs" Inherits="SetupProducts" Title="delightDesk- Fillup your account" %>

<%@ Register Src="~/Webcontrols/HeaderMenu.ascx" TagName="HeaderMenu" TagPrefix="uc1" %>
<%@ Register Src="~/Webcontrols/SettingsMenu.ascx" TagName="SettingsMenu" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <uc1:HeaderMenu ID="HeaderMenu" SetTab="3" runat="server" ShowCorpMenu="true" />
    <uc2:SettingsMenu ID="SettingsMenu" runat="server" SetTab="1" />
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentBody">
    <div class="PageContainer">
        <div class="PageHeader">
            Setup Product/Services <a class="PageLink" onclick="javascript:document.getElementById('divAddProduct').style.display='block';"
                id="lnlAdLead" runat="server">Add New Product/Service offered </a>
        </div>
        <div class="PageSuggestions">
            <%= GetState(CustomerSupport.CustomerSupportPage.UserName) %>
            Mention your offerings here, speficy what you want to sell, how much would you like to 
            make and by within time. 
        </div>
        <div style="width: 300px; background-color: Green; border: solid 1px #cccccc;" runat="server"
            id="divMessage" visible="false">
            <asp:Label runat="server" ID="lblMessage"></asp:Label>
        </div>
        <input type="hidden" id="hdnAccountID" value="<%= strAccountID %>" />
        <input type="hidden" id="hdnSelectProductID" value="" />
        <div id="divAddProduct" style="display: none;">
            <table cellpadding="0" cellspacing="0" border="0" style="background-color: #eeeeee;
                width: 770px;">
                <tr><td colspan=4>
                <div id="divErrorBox" style="display:none;"></div>
                </td></tr>
                <tr>
                    <td align="left">
                        Product Name</td>
                   
                </tr>
                <tr>
                    <td>
                          <div class="Required"></div><input type="text" id="txtProductName" maxlength="100" class="MedInput" tabindex="1" style="float:left;" />
                   <div class="FieldInfo">Provide a descriptive name for the product</div>
                    </td>
                    
                </tr>
                <tr>
                    <td align="left" colspan="6">
                        Product Description</td>
                </tr>
                <tr>
                    <td colspan="6">
                        <input type="text" id="txtProductDesc" maxlength="100" style="width: 600px;" class="MedInput"
                            tabindex="5" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5" align="right">
                        <div class="WaitBox" id="divAddLeadWaitBox" style="display:none;">
                        </div>
                        <a id="lnkDeleteNote" class="StandardFormButton" onclick="javascript:stringval =AjaxAddProduct_Params();ajaxpack.postAjaxRequest('partials/SetupProducts.aspx', stringval, AjaxAddProduct, 'txt');return false;">
                            Add Product</a> , <a id="A1" onclick="javascript:document.getElementById('divAddProduct').style.display='none';return false;">
                                Close</a>
                    </td>
                </tr>
            </table>
        </div>
        <div id="ProductsDiv">
            <asp:Repeater ID="rptrProducts" runat="server">
                <ItemTemplate>
                    <div class="LeadDeck">
                        <div style="width: 700px; height: 20px; float: left">
                         
                                <%# Eval("Product_Name")%>
                            
                        </div>
                        <div style="width: 100px; float: right;">
                        <%--    <a id="lnkEditProduct" onclick="javascript:stringval =AjaxEditProduct_Params();ajaxpack.postAjaxRequest('partials/SetupProducts.aspx', stringval, AjaxEditProduct, 'txt');return false;">
                                Edit </a>,--%> <a id="lnkDeleteProduct" onclick="javascript:var ConfirmDelete= confirm('Warning: You are about to delete a product/service,Are you sure ?');if(ConfirmDelete){document.getElementById('hdnSelectProductID').value='<%# Eval("Product_ID")%>'; stringval =AjaxDeleteProduct_Params();ajaxpack.postAjaxRequest('partials/SetupProducts.aspx', stringval, AjaxDeleteProduct, 'txt');return false;}else{return false;};">
                                    Delete </a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
<div class="LeftContainer">
<div class="HelpContainer">
<div class="HelpHeader">About Products/Services</div>
<div class="HelpContent">
<b>What is Products/Services?</b><br />
Here you mention what you are offering. For Example: you may have "Marraige Floral Decorations"
and "Office-Floral Decorations" . This helps you setup targets for how much  you want to
generate each month/quarter from these services<br />
<b>What are Targets?</b><br />
In targets you define how much you want to make from each service per month/quarter/year. That
way you we can help you stay on track.
</div>
</div>
</div>
    <script type="text/javascript">
    var stringval="";
    function AjaxAddProduct_Params()
    {
        document.getElementById('divAddLeadWaitBox').style.display = 'block';
        var ProductName=document.getElementById('txtProductName').value ;
        var ProductDesc=document.getElementById('txtProductDesc').value ;
       
        var AccountID=document.getElementById('hdnAccountID').value ;
        var poststr = "AccountID=" + encodeURI(AccountID) + "&ProductName=" + encodeURI(ProductName) +"&ProductDesc=" + encodeURI(ProductDesc) +"&Action=A";
       
        //alert(poststr);
         return poststr;
    }

    //Step 2: Define a "callback" function to process the data returned by the Ajax request:
    function AjaxAddProduct()
    {
        var myajax=ajaxpack.ajaxobj
        var myfiletype = ajaxpack.filetype
        document.getElementById('divAddLeadWaitBox').style.display = 'none';
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
                    document.getElementById('ProductsDiv').innerHTML =myajax.responseText;
                    
                    document.getElementById('divErrorBox').innerHTML ='New Product/Service Added';
                    document.getElementById('divErrorBox').className='MessageBox';
                    document.getElementById('divErrorBox').style.display='block';
                    
                    
                    document.getElementById('txtProductName').value = '';
                    document.getElementById('txtProductDesc').value = '' ;
                    document.getElementById('txtConversionRate').value = '' ;
                    document.getElementById('txtTarget').value = '' ;
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
    function AjaxDeleteProduct_Params()
    {
        var ProductID=document.getElementById('hdnSelectProductID').value ;
        var poststr = "ProductID=" + encodeURI(ProductID) + "&Action=D";
       document.getElementById('divAddLeadWaitBox').style.display='block';
        //alert(poststr);
         return poststr;
    }

    //Step 2: Define a "callback" function to process the data returned by the Ajax request:
    function AjaxDeleteProduct()
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
                    document.getElementById('ProductsDiv').innerHTML =myajax.responseText;  
                    document.getElementById('divAddLeadWaitBox').style.display='none';                 

                }
                else
                {  
                     document.getElementById('NewLeadBox').innerHTML=myajax.responseText;
                }
            }
            else alert('problem');
        }
    }
    
    
    </script>

</asp:Content>
