﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="targetcatmgmt.aspx.cs" Inherits="targetcatmgmt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .style1
        {
            text-align: center;
        }
    </style>
</head>
<body>
<div class="style1">
    Growing target categories
<body>
    </div>
    <form id="form1" runat="server">
    <p>
&nbsp;&nbsp;&nbsp;
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td class="style2" valign="top">
                    &nbsp;<asp:Label ID="Label1" runat="server" 
                        Text="Target category"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    <asp:TextBox ID="Targetcat_edt" runat="server" Width="104px"></asp:TextBox>
                    <asp:Button ID="add_btn" runat="server" Text="Add" 
                        Width="64px" onclick="add_btn_Click1" />
                    <asp:Label ID="Error_lb" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                </td>
                <td class="style3" valign="top">
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
        </table>
    </p>
    <p>
        <br />
        <asp:GridView ID="Targetcatmgmt_grid" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#441100" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4"  ForeColor="White" 
            Style="margin-top: 0px" Width="876px" AllowPaging="True" 
            DataSourceID="SqlDataSource1" onrowcommand="Targetcatmgmt_grid_RowCommand" 
            onrowupdating="Targetcatmgmt_grid_RowUpdating" DataKeyNames="ID">
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#CC9900" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Target Category" />
                <asp:CommandField ShowEditButton="True" HeaderText="Edit" />
                <asp:ButtonField CommandName="Delete_targetcat" Text="Delete" />
            </Columns>
        </asp:GridView>
    </p>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DBpath %>" 
        SelectCommand="SELECT [ID], [NAME] FROM [TARGETCATEGORY]"></asp:SqlDataSource>
    </form>
</body>
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin.aspx">Back to main page</asp:HyperLink>
    </p>
</body>
</html>
