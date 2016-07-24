<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <iframe width='170px' frameborder='0' height='300px' style='overflow: hidden; border:solid 0px #ffffff;
                float: left;' src='<%= CustomerSupport.Utility.SysResource.HomePath %>widget.aspx?id=<%= Request["id"].ToString() %>&Show=V'>
            </iframe>
        </div>
    </form>
</body>
</html>
