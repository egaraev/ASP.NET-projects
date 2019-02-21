<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style3
        {
            height: 60px;
        }
        .style4
        {
            height: 61px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td valign="top" class="style3">
                    RU
                    <br />
                    <asp:TextBox ID="NameRU_edt" runat="server"></asp:TextBox>
                </td>
                <td valign="top" class="style3">
                    AZ
                    <br />
                    <asp:TextBox ID="NameAZ_edt" runat="server"></asp:TextBox>
                </td>
                <td valign="top" class="style3">
                    <br />
                    <asp:Button ID="Add_btn" runat="server" Text="Добавить" 
                        onclick="Add_btn_Click" />
                    <asp:Button ID="Update_btn" runat="server" Text="Обновить" Visible="false" 
                        onclick="Update_btn_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Cancel_btn" runat="server" Text="Отмена" Visible="false" 
                        onclick="Cancel_btn_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="Error_lb" runat="server" ForeColor="Red"></asp:Label>
                    <asp:GridView ID="Headers_grid" runat="server" AutoGenerateColumns="False" BackColor="White"
                        BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" EnableModelValidation="True"
                        OnRowCommand="Headers_grid_RowCommand" OnRowDataBound="Headers_grid_RowDataBound"
                        DataKeyNames="ID" EmptyDataText="Ни одного заголовка" Style="margin-right: 0px"
                        Width="800px">
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <Columns>
                            <asp:BoundField DataField="NAMERU" HeaderText="RU" />
                            <asp:BoundField DataField="NAMEAZ" HeaderText="AZ" />
                            <asp:ButtonField CommandName="Add1" HeaderText="Добавить подменю"
                                Text="Добавить" />
                            <asp:ButtonField CommandName="Content" HeaderText="Добавить наполнение"
                                Text="Наполнение" />
                            <asp:ButtonField CommandName="Edit1" Text="Редактировать" />
                            <asp:ButtonField CommandName="Delete1" Text="Удалить" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="Headers_sds" runat="server"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Panel ID="Panel1" runat="server" Visible="False">
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td valign="top" class="style3">
                                    RU
                                    <br />
                                    <asp:TextBox ID="NameRU2_edt" runat="server"></asp:TextBox>
                                </td>
                                <td valign="top" class="style3">
                                    AZ
                                    <br />
                                    <asp:TextBox ID="NameAZ2_edt" runat="server"></asp:TextBox>
                                </td>
                                <td valign="top" class="style3">
                                    <br />
                                    <asp:Button ID="add2_btn" runat="server" Text="Добавить" 
                                        onclick="add2_btn_Click" />
                                    <asp:Button ID="update2_btn" runat="server" Text="Обновить" Visible="false" 
                                        onclick="update2_btn_Click" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="cancel2_btn" runat="server" Text="Отмена" Visible="false" 
                                        onclick="cancel2_btn_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" colspan="3">
                                    <asp:Label ID="Error2_lb" runat="server" ForeColor="Red"></asp:Label>
                                    <asp:GridView ID="Menu_grid" runat="server" AutoGenerateColumns="False" BackColor="White"
                                        BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" EnableModelValidation="True"
                                        Style="margin-top: 0px" Width="795px" onrowcommand="Menu_grid_RowCommand" DataKeyNames="ID">
                                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                        <RowStyle BackColor="White" ForeColor="#003399" />
                                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                        <Columns>
                                            <asp:BoundField DataField="NAMERU" HeaderText="RU" />
                                            <asp:BoundField DataField="NAMEAZ" HeaderText="AZ" />
                                            <asp:ButtonField CommandName="Content" HeaderText="Добавить наполнение"
                                                Text="Наполнение" />
                                            <asp:ButtonField CommandName="Edit1" Text="Редактировать" />
                                            <asp:ButtonField CommandName="Delete1" Text="Удалить" />
                                        </Columns>
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="Menu_sds" runat="server"></asp:SqlDataSource>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
