<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadFile.aspx.cs" Inherits="UploadFile"
    Title="FileUpload" %>

<html>
<head>
    <title>File upload in ASP.NET</title>
    <link href="common/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="common/js/ajaxroutine.js" ></script>
</head>
<body bgcolor="#ffffff" style="font: 8pt verdana;">
 
    <form id="Form1" enctype="multipart/form-data" runat="server">
        <table bgcolor="white">
            <tr>
                <td>
                    Add your photo:</td>
                <td>
                    <input id="uplTheFile" type="file" runat="server" accept="image/gif,image/jpeg"></td><td >
                    <input type="button" id="btnUploadTheFile" value="Upload" onserverclick="btnUploadTheFile_Click"
                        runat="server">
                        <asp:Image runat=server ID="imgWidgetImage" /> 
                </td>
            </tr>
            
            <tr>
                <td colspan=3 ><span id="txtOutput" style="font: 8pt verdana;" runat="server" /></td>
            </tr>
            
        </table>
        
    </form> 
</body>
</html>
