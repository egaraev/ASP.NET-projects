﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="usermgmt.aspx.cs" Inherits="usermgmt" %>

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
        <body>
        Users&nbsp; management</div>
    <form id="form1" runat="server">
    <p>
        &nbsp;&nbsp;&nbsp;
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td class="style2" valign="top" style="margin-left: 40px">
                    &nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="Login"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label
                        ID="Label7" runat="server" Text="Group"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    <asp:TextBox ID="Login_edt" runat="server" Width="104px"></asp:TextBox>
                    <asp:TextBox ID="Password_edt0" runat="server" Width="104px"></asp:TextBox>
                    <asp:DropDownList ID="Group_ddl" runat="server" DataSourceID="SqlDataSource2" DataTextField="NAME"
                        DataValueField="ID" Width="117px" Height="24px">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DBpath %>"
                        SelectCommand="SELECT [ID], [NAME] FROM [USER_GROUP]"></asp:SqlDataSource>
                    <asp:Button ID="add_btn" runat="server" Text="Add" Width="64px" 
                        onclick="add_btn_Click" />
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
        <asp:GridView ID="Usermgmt_grid" runat="server" AutoGenerateColumns="False" BackColor="White"
            BorderColor="#441100" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="White"
            Style="margin-top: 0px" Width="876px" AllowPaging="True" DataSourceID="SqlDataSource1"
            DataKeyNames="ID" OnRowUpdating="Usermgmt_grid_RowUpdating" 
            onrowcommand="Usermgmt_grid_RowCommand">
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#CC9900" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="LOGIN" HeaderText="Login" />
                <asp:BoundField DataField="PASSWORD" HeaderText="Password" SortExpression="PASSWORD" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <%# Eval("NAME") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="Group_grid_ddl" runat="server" DataSourceID="SqlDataSource3"
                            DataTextField="NAME" DataValueField="ID">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <HeaderTemplate>
                        Group
                    </HeaderTemplate>
                </asp:TemplateField>
                <%--<asp:BoundField DataField="NAME" HeaderText="Group" 
                    SortExpression="NAME" />--%>
                <asp:CommandField ShowEditButton="True" HeaderText="Edit" />
                <%--<asp:ButtonField CommandName="Edit_age" Text="Edit" />--%>
                <asp:ButtonField CommandName="Delete_user" Text="Delete" />
            </Columns>
        </asp:GridView>
    </p>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBpath %>"
        SelectCommand="SELECT USERS.ID, USERS.LOGIN, USERS.PASSWORD, USERS.USER_GROUP_ID, USER_GROUP.NAME FROM USERS INNER JOIN USER_GROUP ON USERS.USER_GROUP_ID = USER_GROUP.ID">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:DBpath %>"
        SelectCommand="SELECT ID, NAME FROM USER_GROUP"></asp:SqlDataSource>
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin.aspx">Back to main page</asp:HyperLink>
    </p>
    </form>
</body>

</html>
