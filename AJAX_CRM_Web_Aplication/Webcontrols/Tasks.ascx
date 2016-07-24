<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Tasks.ascx.cs" Inherits="Webcontrols_Tasks" %>
<div style="border: solid 1px #0094FF; background-color: #ffffff; width: 150px; padding: 5px;
    margin: 2px;">
    <div style="width: 150px; height: 15px; font-size: 18px; color: #0094FF">
        Upcomming:</div>
    <asp:Repeater ID="rptrTasks" runat="server">
        <ItemTemplate>
            <div style="width: 150px; height: 35px; border-bottom: dotted 1px #cccccc; font-size: 11px;
                font-family: Arial;">
                <div style="width: 100px; height: 20px; overflow: hidden; float: left;">
                    <%# Eval("Task_Desc") %>
                </div>
                <div style="width: 150px; height: 15px; overflow: hidden; float: left;font-size:6px;color:#cccccc;text-align:right;">
                    <%# Eval("Task_Date", "{0:hh:mm tt dd-MMM}")%>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
