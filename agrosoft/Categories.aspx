<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Categories.aspx.cs" Inherits="Categories"
    MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td valign="top" class="style1">
                &nbsp;<asp:LinkButton ID="Users_mgmt" runat="server" PostBackUrl="~/Users.aspx">Управление пользователями</asp:LinkButton>
                &nbsp;&nbsp;&nbsp;
            </td>
            <td valign="top" class="style1">
                &nbsp;&nbsp;<asp:LinkButton ID="Customers_mgmt" runat="server" PostBackUrl="~/Customers.aspx">Управление покупателями</asp:LinkButton>&nbsp;&nbsp;
            </td>
            <td valign="top" class="style1">
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Categories_lb" runat="server" Text="Категории продукции" Style="color: #000099"></asp:Label>
            </td>
            <td valign="top" class="style1">
                <asp:LinkButton ID="Products" runat="server" PostBackUrl="~/Products.aspx">Продукты</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td>
                <asp:LinkButton ID="Logout_btn" runat="server" onclick="Logout_btn_Click">Выход</asp:LinkButton>
            </td>
        </tr>
    </table>

    <asp:Panel ID="Panel1" runat="server" Style="margin-bottom: 0px">
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td valign="top" class="style2">
                    <asp:Label ID="Name_lbl" runat="server" Text="Имя"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    <asp:TextBox ID="Name_edt" runat="server" Width="104px"></asp:TextBox>
                </td>
                <td valign="top" class="style3">
                    <br />
                    <asp:Button ID="add_btn" runat="server" Text="Добавить" OnClick="add_btn_Click" Width="64px" />
                    <asp:Button ID="update_btn" runat="server" Text="Обновить" Visible="false" OnClick="update_btn_Click"
                        Width="64px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="cancel_btn" runat="server" Text="Отмена"
                        Visible="false" OnClick="cancel_btn_Click" Width="52px" />
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td valign="top" colspan="2">
                    <asp:Label ID="Error2_lb" runat="server" ForeColor="Red"></asp:Label>
                    <asp:GridView ID="Categories_grid" runat="server" AutoGenerateColumns="False" BackColor="White"
                        BorderColor="#441100" BorderStyle="None" BorderWidth="1px" CellPadding="4" EnableModelValidation="True"
                        Style="margin-top: 0px" Width="795px" DataKeyNames="ID" 
                        OnRowCommand="Categories_grid_RowCommand" ForeColor="White">
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <HeaderStyle BackColor="#9900CC" Font-Bold="True" ForeColor="#CCCCFF" />
                        <PagerStyle BackColor="#CC9900" ForeColor="#003399" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Name" HeaderText="Наименование" />
                            <asp:ButtonField CommandName="Editcategory" Text="Редактировать" />
                            <asp:ButtonField CommandName="Deletecategory" Text="Удалить" />
                        </Columns>
                    </asp:GridView>
                        <asp:SqlDataSource ID="Categories_sds" runat="server"></asp:SqlDataSource>
                </td>
            </tr>
    </asp:Panel>
    
    <asp:Label ID="Error_lb" runat="server" Text="" ForeColor="Red"></asp:Label>







        
        






</asp:Content>
