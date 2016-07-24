<%@ Page  Language="C#" MasterPageFile="~/SupportCenter/SupportCenterMaster.master"  Buffer="false" AutoEventWireup="true"
    CodeFile="Topic.aspx.cs" Inherits="SupportCenter_Topic"  %>

<%@ OutputCache VaryByParam="*" Duration="60" Location="Server" %>
<%@ Register Src="~/SupportCenter/webcontrols/PortalHeaderMenu.ascx" TagName="PortalHeaderMenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="Server">
    <uc1:PortalHeaderMenu ID="HeaderMenu" SetTab="1" runat="server" ShowCorpMenu="false" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="Server">
    <div class="LeftBox">
        <input type="hidden" id="hdnBoxId" value="" />
        <input type="hidden" id="hdnAccountId" value="<%= strAccountId %>" />
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
                    <div style="width: 500px; float: left;font-size:14px;">
                        <span style="color: #cccccc">on :<%= strCreateDate%></span>
                        <br />
                        <b>
                        <%= strConversationTitle.Replace("\n", "<br>")%></b><br /><br />
                        <%= strConversationDesc.Replace("\n", "<br>")%></span>
                        
                    </div>
                    <div style="width: 100px; height: 40px; float: right; border: solid 0px #dddddd;">
                        <div style="width: 100px; height: 20px; float: left; color: #666666">
                            <%= DateTime.Now.Subtract(DateTime.Parse(strCreateDate)).Days > 0 ? DateTime.Now.Subtract(DateTime.Parse(strCreateDate)).Days.ToString() + " days, " : ""%>
                            <%= DateTime.Now.Subtract(DateTime.Parse(strCreateDate)).Hours%>
                            hrs ago
                        </div>
                    </div>
                    <div style="width: 500px; height: 20px; float: left; color: #666666; border: solid 0px #dddddd;
                        padding: 2px;">
                    </div>
                </div>
                <div style="width: 671px; height: 14px; float: left; background-image: url('<%= CustomerSupport.Utility.SysResource.ImagePath %>callout_bottom.gif');
                    background-repeat: no-repeat;">
                </div>
            </div>
        </div>
        <div id="divReplies">
            <asp:Repeater ID="rptrReplies" runat="server">
                <ItemTemplate>
                    <div class="HotTopics">
                        <div class="PictureBox">
                            <div class="ProfilePicture">
                            </div>
                            <div class="ProfileText">
                                <%# Eval("User_Name") %>
                                <%# Eval("Official").ToString() == "True" ? "<div style=\"background-color:green;color:white;\"> <b>Official</b></div>" : ""%>
                            </div>
                        </div>
                        <div class="CallOutTopics">
                            <div style="width: 671px; height: 14px; float: left; background-image: url('<%= CustomerSupport.Utility.SysResource.ImagePath %>callout_top.gif');
                                background-repeat: no-repeat;">
                            </div>
                            <div style="width: 646px; float: left; padding-left: 25px; background-image: url('<%= CustomerSupport.Utility.SysResource.ImagePath %>callout_middle.gif');
                                background-repeat: repeat-y;">
                                <div style="width: 500px; float: left;">
                                    <span style="color: #cccccc">on :<%# Eval("Reply_Date")%></span>
                                    <br />
                                    <%# Eval("Reply_Message").ToString().Replace("\n","<br>")%></span>
                                </div>
                                <div style="width: 100px; height: 40px; float: right; border: solid 0px #dddddd;">
                                    <div style="width: 100px; height: 20px; float: left; color: #666666">
                                        <%# DateTime.Now.Subtract(DateTime.Parse(Eval("Reply_Date").ToString())).Days > 0 ? DateTime.Now.Subtract(DateTime.Parse(Eval("Reply_Date").ToString())).Days.ToString() + " days, " : ""%>
                                        <%# DateTime.Now.Subtract(DateTime.Parse(Eval("Reply_Date").ToString())).Hours%>
                                        hrs ago
                                    </div>
                                </div>
                                <div style="width: 500px; height: 20px; float: left; color: #666666; border: solid 0px #dddddd;
                                    padding: 2px;">
                                </div>
                            </div>
                            <div style="width: 671px; height: 14px; float: left; background-image: url('<%= CustomerSupport.Utility.SysResource.ImagePath %>callout_bottom.gif');
                                background-repeat: no-repeat;">
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="roundcont" style="width: 740px; background-color: #F7FBFF; color: #404040;">
            <div class="roundtop">
                <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>tl.gif" alt="" width="15"
                    height="15" class="corner" style="display: none" />
            </div>
            <p>
              
            <div style="width: 740px; height: 170px; padding:10px;">
                <div style="width: 740px; height: 20px; float: left">
                    Message</div>
                <div style="width: 740px; height: 100px; float: left">
                    <textarea class="MedInput" id="txtMessage" style="width: 650px; height: 85px; border: solid 1px #cccccc;"></textarea>
                </div>
                <div style="width: 240px; height: 20px; float: left">
                    Name
                </div><div style="width: 240px; height: 20px; float: left">
                    Email
                </div> <div style="width: 240px; height: 20px; float: left">
                    Are you human ? lets see, what is 2+2
                </div>
                <div style="width: 240px; height: 20px; float: left">
                    <input type="text" id="txtUserName" />
                </div>
                
                <div style="width: 240px; height: 20px; float: left">
                    <input type="text" id="txtEmail" />
                </div>
               
                <div style="width: 240px; height: 20px; float: left">
                    <input type="text" id="txtAnswer" />
                </div>
                <div style="width: 700px; height: 20px; float: left;text-align:right;">
                <a class="FormButton" id="lnkReply" onclick="javascript:document.getElementById('hdnBoxId').value='LeadsBox<%= strConversationID%>';stringval =AjaxReply_Params('<%= strConversationID %>');ajaxpack.postAjaxRequest('<%= CustomerSupport.Utility.SysResource.HomePath %>/supportcenter/partials/SC_HandleConversation.aspx', stringval, AjaxReply, 'txt');return false;">
                    Reply</a></div>
            </div>
       
            </p>
            <div class="roundbottom">
                <img src="<%= CustomerSupport.Utility.SysResource.ImagePath %>bl.gif" alt="" width="15"
                    height="15" class="corner" style="display: none" />
            </div>
        </div>
        
    </div>
    <div class="RightBox">
        <div style="width: 200px; float: left; padding-left: 20px; overflow: hidden;">
            <div style="width: 220px; padding-top: 3px; float: left;">
                <span style="font-size: 22px; line-height: 1.2em;">
                    <%= strMessagesCount%>
                    Replies<br />
                    <%= strViewedCount%>
                    Views </span>
            </div>
           
            <a target="_blank" style="width: 220px; text-decoration: none; font-size: 11px; font-family: Arial;
                color: #2A4956;">Share on other sites</a><br>
            <div style="border-top-style: solid; padding-top: 3px; border-top-width: 1px; border-top-color: #2A4956;
                float: left;">
                <%-- <a rel="nofollow" style="text-decoration: none;" href="http://www.mister-wong.de/"
                onclick="window.open('http://www.mister-wong.de/index.php?action=addurl&amp;bm_url='+encodeURIComponent(location.href)+'&amp;bm_notice=&amp;bm_description='+encodeURIComponent(document.title)+'&amp;bm_tags=');return false;"
                title="Bookmark to: Mr. Wong">
                <img style="padding-bottom: 1px;" src="<%= CustomerSupport.Utility.SysResource.ImagePath %>SocialBookmarkIcons/wong_trans.gif"
                    alt="Bookmark to: Mr. Wong" name="wong" border="0" id="wong">
            </a><a rel="nofollow" style="text-decoration: none;" href="http://www.webnews.de/"
                onclick="window.open('http://www.webnews.de/einstellen?url='+encodeURIComponent(document.location)+'&amp;title='+encodeURIComponent(document.title));return false;"
                title="Bookmark to: Webnews">
                <img style="padding-bottom: 1px;" src="<%= CustomerSupport.Utility.SysResource.ImagePath %>SocialBookmarkIcons/webnews_trans.gif"
                    alt="Bookmark to: Webnews" name="Webnews" border="0" id="Webnews">
            </a><a rel="nofollow" style="text-decoration: none;" href="http://www.icio.de/" onclick="window.open('http://www.icio.de/add.php?url='+encodeURIComponent(location.href));return false;"
                title="Bookmark to: Icio">
                <img style="padding-bottom: 1px;" src="<%= CustomerSupport.Utility.SysResource.ImagePath %>SocialBookmarkIcons/icio_trans.gif"
                    alt="Bookmark to: Icio" name="Icio" border="0" id="Icio">
            </a><a rel="nofollow" style="text-decoration: none;" href="http://www.oneview.de/"
                onclick="window.open('http://www.oneview.de/quickadd/neu/addBookmark.jsf?URL='+encodeURIComponent(location.href)+'&amp;title='+encodeURIComponent(document.title));return false;"
                title="Bookmark to: Oneview">
                <img style="padding-bottom: 1px;" src="<%= CustomerSupport.Utility.SysResource.ImagePath %>SocialBookmarkIcons/oneview_trans.gif"
                    alt="Bookmark to: Oneview" name="Oneview" border="0" id="Oneview">
            </a><a rel="nofollow" style="text-decoration: none;" href="http://www.linkarena.com/"
                onclick="window.open('http://linkarena.com/bookmarks/addlink/?url='+encodeURIComponent(location.href)+'&amp;title='+encodeURIComponent(document.title)+'&amp;desc=&amp;tags=');return false;"
                title="Bookmark to: Linkarena">
                <img style="padding-bottom: 1px;" src="<%= CustomerSupport.Utility.SysResource.ImagePath %>SocialBookmarkIcons/linkarena_trans.gif"
                    alt="Bookmark to: Linkarena" name="Linkarena" border="0" id="Linkarena">
            </a><a rel="nofollow" style="text-decoration: none;" href="http://www.favoriten.de/"
                onclick="window.open('http://www.favoriten.de/url-hinzufuegen.html?bm_url='+encodeURIComponent(location.href)+'&amp;bm_title='+encodeURIComponent(document.title));return false;"
                title="Bookmark to: Favoriten">
                <img style="padding-bottom: 1px;" src="<%= CustomerSupport.Utility.SysResource.ImagePath %>SocialBookmarkIcons/favoriten_trans.gif"
                    alt="Bookmark to: Favoriten" name="Favoriten" border="0" id="Favoriten">
            </a><a rel="nofollow" style="text-decoration: none;" href="http://social-bookmarking.seekxl.de/"
                onclick="window.open('http://social-bookmarking.seekxl.de/?add_url='+encodeURIComponent(location.href)+'&amp;title='+encodeURIComponent(document.title));return false;"
                title="Bookmark to: Seekxl">
                <img style="padding-bottom: 1px;" src="<%= CustomerSupport.Utility.SysResource.ImagePath %>SocialBookmarkIcons/seekxl_trans.gif"
                    alt="Bookmark to: Seekxl" name="Seekxl" border="0" id="Seekxl">
            </a><a style="text-decoration: none;" href="http://www.favit.de/" onclick="window.open('http://www.favit.de/submit.php?url='+(document.location.href));return false;"
                title="Bookmark to: Favit">
                <img style="padding-bottom: 1px;" src="<%= CustomerSupport.Utility.SysResource.ImagePath %>SocialBookmarkIcons/favit_trans.gif"
                    alt="Bookmark to: Favit" name="Favit" border="0" id="Favit">
            </a><a rel="nofollow" style="text-decoration: none;" href="http://www.linksilo.de"
                onclick="window.open('http://www.linksilo.de/index.php?area=bookmarks&amp;func=bookmark_new&amp;addurl='+encodeURIComponent(location.href)+'&amp;addtitle='+encodeURIComponent(document.title));return false;"
                title="Bookmark to: Linksilo">
                <img style="padding-bottom: 1px;" src="<%= CustomerSupport.Utility.SysResource.ImagePath %>SocialBookmarkIcons/linksilo_trans.gif"
                    alt="Bookmark to: Linksilo" name="Linksilo" border="0" id="Linksilo"></a>
           <a rel="nofollow" style="text-decoration: none;" href="http://www.readster.de/" onclick="window.open('http://www.readster.de/submit/?url='+encodeURIComponent(document.location)+'&amp;title='+encodeURIComponent(document.title));return false;"
                title="Bookmark to: Readster">
                <img style="padding-bottom: 1px;" src="<%= CustomerSupport.Utility.SysResource.ImagePath %>SocialBookmarkIcons/readster_trans.gif"
                    alt="Bookmark to: Readster" name="Readster" border="0" id="Readster"></a>
            <a rel="nofollow" style="text-decoration: none;" href="http://yigg.de/" onclick="window.open('http://yigg.de/neu?exturl='+encodeURIComponent(location.href));return false"
                title="Bookmark to: Yigg">
                <img style="padding-bottom: 1px;" src="<%= CustomerSupport.Utility.SysResource.ImagePath %>SocialBookmarkIcons/yigg_trans.gif"
                    alt="Bookmark to: Yigg" name="Yigg" border="0" id="Yigg">
            </a><a rel="nofollow" style="text-decoration: none;" href="http://www.folkd.com/" onclick="window.open('http://www.folkd.com/submit/'+(dokument.location.href));return false;"
                title="Bookmark to: Folkd">
                <img style="padding-bottom: 1px;" src="<%= CustomerSupport.Utility.SysResource.ImagePath %>SocialBookmarkIcons/folkd_trans.gif"
                    alt="Bookmark to: Folkd" name="Folkd" border="0" id="Folkd">
            </a><a rel="nofollow" style="text-decoration: none;" href="http://www.blinkbits.com/"
                onclick="window.open('http://www.blinkbits.com/bookmarklets/save.php?v=1&amp;title='+encodeURIComponent(document.title)+'&amp;source_url='+encodeURIComponent(location.href)+'&amp;source_image_url=&amp;rss_feed_url=&amp;rss_feed_url=&amp;rss2member=&amp;body=');return false;"
                title="Bookmark to: Blinkbits">
                <img style="padding-bottom: 1px;" src="<%= CustomerSupport.Utility.SysResource.ImagePath %>SocialBookmarkIcons/blinkbits_trans.gif"
                    alt="Bookmark to: Blinkbits" name="Blinkbits" border="0" id="Blinkbits">
            </a> --%><a rel="nofollow" style="text-decoration: none;" href="http://digg.com/"
                onclick="window.open('http://digg.com/submit?phase=2&amp;url='+encodeURIComponent(location.href)+'&amp;bodytext=&amp;tags=&amp;title='+encodeURIComponent(document.title));return false;"
                title="Bookmark to: Digg">
                <img style="padding-bottom: 1px;" src="<%= CustomerSupport.Utility.SysResource.ImagePath %>SocialBookmarkIcons/digg_trans.gif"
                    alt="Bookmark to: Digg" name="Digg" border="0" id="Digg">
            </a><a rel="nofollow" style="text-decoration: none;" href="http://del.icio.us/" onclick="window.open('http://del.icio.us/post?v=2&amp;url='+encodeURIComponent(location.href)+'&amp;notes=&amp;tags=&amp;title='+encodeURIComponent(document.title));return false;"
                title="Bookmark to: Del.icio.us">
                <img style="padding-bottom: 1px;" src="<%= CustomerSupport.Utility.SysResource.ImagePath %>SocialBookmarkIcons/del_trans.gif"
                    alt="Bookmark to: Del.icio.us" name="Delicious" border="0" id="Delicious">
            </a><a rel="nofollow" style="text-decoration: none;" href="http://www.facebook.com/"
                onclick="window.open('http://www.facebook.com/sharer.php?u='+encodeURIComponent(location.href)+'&amp;t='+encodeURIComponent(document.title));return false;"
                title="Bookmark to: Facebook">
                <img style="padding-bottom: 1px;" src="<%= CustomerSupport.Utility.SysResource.ImagePath %>SocialBookmarkIcons/facebook_trans.gif"
                    alt="Bookmark to: Facebook" name="Facebook" border="0" id="Facebook">
            </a><a rel="nofollow" style="text-decoration: none;" href="http://reddit.com/" onclick="window.open('http://reddit.com/submit?url='+encodeURIComponent(location.href)+'&amp;title='+encodeURIComponent(document.title));return false;"
                title="Bookmark to: Reddit">
                <img style="padding-bottom: 1px;" src="<%= CustomerSupport.Utility.SysResource.ImagePath %>SocialBookmarkIcons/reddit_trans.gif"
                    alt="Bookmark to: Reddit" name="Reddit" border="0" id="Reddit">
            </a><a rel="nofollow" style="text-decoration: none;" href="http://www.stumbleupon.com/"
                onclick="window.open('http://www.stumbleupon.com/submit?url='+encodeURIComponent(location.href)+'&amp;title='+encodeURIComponent(document.title));return false;"
                title="Bookmark to: StumbleUpon">
                <img style="padding-bottom: 1px;" src="<%= CustomerSupport.Utility.SysResource.ImagePath %>SocialBookmarkIcons/stumbleupon_trans.gif"
                    alt="Bookmark to: StumbleUpon" name="StumbleUpon" border="0" id="StumbleUpon">
            </a><a rel="nofollow" style="text-decoration: none;" href="http://slashdot.org/"
                onclick="window.open('http://slashdot.org/bookmark.pl?url='+encodeURIComponent(location.href)+'&amp;title='+encodeURIComponent(document.title));return false;"
                title="Bookmark to: Slashdot">
                <img style="padding-bottom: 1px;" src="<%= CustomerSupport.Utility.SysResource.ImagePath %>SocialBookmarkIcons/slashdot_trans.gif"
                    alt="Bookmark to: Slashdot" name="Slashdot" border="0" id="Slashdot">
            </a><a rel="nofollow" style="text-decoration: none;" href="http://www.furl.net/"
                onclick="window.open('http://www.furl.net/storeIt.jsp?u='+encodeURIComponent(location.href)+'&amp;keywords=&amp;t='+encodeURIComponent(document.title));return false;"
                title="Bookmark to: Furl">
                <img style="padding-bottom: 1px;" src="<%= CustomerSupport.Utility.SysResource.ImagePath %>SocialBookmarkIcons/furl_trans.gif"
                    alt="Bookmark to: Furl" name="Furl" border="0" id="Furl">
            </a><a rel="nofollow" style="text-decoration: none;" href="http://www.blinklist.com/"
                onclick="window.open('http://www.blinklist.com/index.php?Action=Blink/addblink.php&amp;Description=&amp;Tag=&amp;Url='+encodeURIComponent(location.href)+'&amp;Title='+encodeURIComponent(document.title));return false;"
                title="Bookmark to: Blinklist">
                <img style="padding-bottom: 1px;" src="<%= CustomerSupport.Utility.SysResource.ImagePath %>SocialBookmarkIcons/blinklist_trans.gif"
                    alt="Bookmark to: Blinklist" name="Blinklist" border="0" id="Blinklist">
            </a><a rel="nofollow" style="text-decoration: none;" href="http://www.technorati.com/"
                onclick="window.open('http://technorati.com/faves?add='+encodeURIComponent(location.href)+'&amp;tag=');return false;"
                title="Bookmark to: Technorati">
                <img style="padding-bottom: 1px;" src="<%= CustomerSupport.Utility.SysResource.ImagePath %>SocialBookmarkIcons/technorati_trans.gif"
                    alt="Bookmark to: Technorati" name="Technorati" border="0" id="Technorati">
            </a><a rel="nofollow" style="text-decoration: none;" href="http://www.newsvine.com/"
                onclick="window.open('http://www.newsvine.com/_wine/save?popoff=1&amp;u='+encodeURIComponent(location.href)+'&amp;tags=&amp;blurb='+encodeURIComponent(document.title));return false;"
                title="Bookmark to: Newsvine">
                <img style="padding-bottom: 1px;" src="<%= CustomerSupport.Utility.SysResource.ImagePath %>SocialBookmarkIcons/newsvine_trans.gif"
                    alt="Bookmark to: Newsvine" name="Newsvine" border="0" id="Newsvine">
            </a>
            </div>
        </div>
    </div>

    <script type="text/javascript">




        var stringval = "";

        function AjaxReply_Params(LeadID) {



            var Reply = document.getElementById('txtMessage').value;
            var ConversationStatus = ''; //document.getElementById(SelectField).value;
            var AccountID = document.getElementById('hdnAccountId').value;
            var UserName = document.getElementById('txtUserName').value;
            var UserEmail = document.getElementById('txtEmail').value;
            var HumanAnswer = document.getElementById('txtAnswer').value;



            var poststr = "ID=" + LeadID + "&AccountID=" + encodeURI(AccountID) + "&Reply=" + encodeURI(Reply) + "&UserName=" + encodeURI(UserName) + "&UserEmail=" + encodeURI(UserEmail) + "&ConversationStatus=" + encodeURI(ConversationStatus) + "&Action=AR";

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
                        //document.getElementById('txtReply').value = "";
                    }
                    else {
                        document.getElementById('divReplies').innerHTML = myajax.responseText;
                    }
                }
                else alert('problem');
            }
        }

           
    </script>

</asp:Content>
