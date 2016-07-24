<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Filters.ascx.cs" Inherits="Webcontrols_Filters" %>
<div class="PageFilterContainer">
    <div class="PageFilterBox" style="border-right: 0px;">
        <div class="PageFilterHeader" style="background-color: #f5f5f5;">
           <b>Search Conversations</b> </div>
        <div class="PageFilterContent">
            <input type=text ID="txtSearch" MaxLength="150" Style="width: 130px" onchange="javascript:stringval =AjaxSearch_Params(document.getElementById('txtSearch').value);ajaxpack.postAjaxRequest('<%= CustomerSupport.Utility.SysResource.HomePath %>/manage/InternalSearchResults.aspx', stringval, AjaxSearch, 'txt');return false;" />
            <div style="width:180px;position:relative;background-color:#ffffff;border:solid 1px #cccccc;float:left;" id="divSearchResults"></div>
             <div class="WaitBox" id="divWaitSearch" style="display: none;">
                        </div>
                        
        </div>
    </div>
    <div class="ShowHideFilter" id="lblShowFilters" onclick="javascript:document.getElementById('divFilterContainer').style.display='block';document.getElementById('lblShowFilters').style.display='none';document.getElementById('lblHideFilters').style.display='block';">
        Show Filter</div>
    <div class="ShowHideFilter" id="lblHideFilters" onclick="javascript:document.getElementById('divFilterContainer').style.display='none';document.getElementById('lblShowFilters').style.display='block';document.getElementById('lblHideFilters').style.display='none';"
        style="display: none;">
        Hide Filter</div>
    <div id="divFilterContainer"  >
        <div class="PageFilterBox">
            <div class="PageFilterHeader" style="background-color: #f5f5f5;">
                <b>By Offering</b>
            </div>
            <div class="PageFilterContent">
                <div id="divProductFilterList" style="width: 175px;height:200px; overflow-x: hidden; overflow-y: auto;
                    padding: 2px; z-index: 10; float: left;">
                    <a href="<%= CustomerSupport.Utility.SysResource.HomePath %>manage/manageleads.aspx?Product=">
                        <div style="width: 150px; height: 15px; padding: 2px; float: left; font-weight: <%# strProductID == "" ? "bold":"normal" %>;background-color: <%= strProductID == "" ? "#E1FF96": "#ffffff" %>">
                            All
                        </div>
                    </a>
                    <asp:Repeater ID="rptrProductsFilter" runat="server">
                        <ItemTemplate>
                            <a href="<%= CustomerSupport.Utility.SysResource.HomePath %>manage/manageleads.aspx?Product=<%# Eval("Product_ID") %>">
                                <div style="width: 150px; height: 15px; padding: 2px; float: left; font-weight: <%# strProductID == Eval("Product_ID").ToString() ? "bold":"normal" %>;background-color: <%# strProductID == Eval("Product_ID").ToString() ? "#E1FF96":"" %>;">
                                    <%# Eval("Product_Name") %>
                                </div>
                            </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <div class="PageFilterBox">
            <div class="PageFilterHeader" style="background-color: #f5f5f5;">
                <b>By Category</b>
            </div>
            <div class="PageFilterContent">
                <div id="divFilterCategoryList" style="width: 175px;height:200px; overflow-x: hidden; overflow-y: auto;
                    padding: 2px; z-index: 10; float: left;">
                    <a href="<%= CustomerSupport.Utility.SysResource.HomePath %>manage/manageleads.aspx?Tag=">
                        
                        <div style="width: 150px; height: 15px; padding: 2px; float: left; font-weight: <%# Eval("Category_id").ToString()  == "" ? "bold": "normal" %>;background-color: <%= strCategoryID  == "" ? "#E1FF96": "#ffffff" %>">
                            All
                        </div>
                    </a>
                    <asp:Repeater runat="server" ID="rptrCategoryFilter">
                        <ItemTemplate>
                            <a href="<%= CustomerSupport.Utility.SysResource.HomePath %>manage/manageleads.aspx?Category=<%# Eval("Category_ID") %>">
                                <div style="width: 150px; height: 15px; padding: 2px; float: left; font-weight: <%# Eval("Category_id").ToString()  == strCategoryID ? "bold": "normal" %>;background-color: <%# strCategoryID == Eval("Category_id").ToString() ? "#E1FF96":"#ffffff"%>;">
                                    <%# Eval("Category_Name") %>
                                </div>
                            </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <div class="PageFilterBox">
            <div class="PageFilterHeader" style="background-color: #f5f5f5;">
                <b>By Custom Tags</b>
            </div>
            <div class="PageFilterContent">
               
                    <div id="divFilterTagList" style="width: 175px;height:200px; overflow-x: hidden; overflow-y: auto;
                        padding: 2px; float: left;">
                        <a href="<%= CustomerSupport.Utility.SysResource.HomePath %>manage/manageleads.aspx?Tag=">
                            <div style="width: 150px; height: 15px; padding: 2px; float: left; font-weight: <%# Eval("tag_id").ToString()  == "" ? "bold": "normal" %>;background-color: <%= strTagID  == "" ? "#E1FF96": "#ffffff" %>">
                                All
                            </div>
                        </a>
                        <asp:Repeater runat="server" ID="rptrTags">
                            <ItemTemplate>
                                <a href="<%= CustomerSupport.Utility.SysResource.HomePath %>manage/manageleads.aspx?Tag=<%# Eval("Tag_ID") %>">
                                    <div style="width: 150px; height: 15px; padding: 2px; float: left; font-weight: <%# Eval("tag_id").ToString()  == strTagID ? "bold": "normal" %>;background-color: <%# strTagID == Eval("tag_id").ToString() ? "#E1FF96":"#ffffff"%>;">
                                        <%# Eval("Tag_Name") %>
                                    </div>
                                </a>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
               
            </div>
        </div>
    </div>
</div>
<script type="text/javascript" >
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