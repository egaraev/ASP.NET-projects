<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Customers.aspx.cs" Inherits="Customers" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
    <tr>
        
    <td valign="top" class="style1">
        &nbsp;<asp:LinkButton ID="Users_mgmt" runat="server" PostBackUrl="~/Users.aspx">Управление пользователями</asp:LinkButton> 
        &nbsp;&nbsp;&nbsp;
        
    </td>

  <td valign="top" class="style1">
    <asp:Label         
            ID="Customers_lb" runat="server" Text="Управление покупателями" 
            style="color: #000099"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;

    </td>

     <td valign="top" class="style1">
    <asp:LinkButton ID="Cat_mgmt" runat="server" PostBackUrl="~/Categories.aspx">Категории продукции</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;

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
                    <asp:Label ID="Label1" runat="server" Text="Имя"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label2" runat="server" Text="Фамилия"></asp:Label>
                    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label3" runat="server" Text="Телефон"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label4" runat="server" Text="Адрес"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    <asp:TextBox ID="Name_edt" runat="server" Width="104px"></asp:TextBox>
                    <asp:TextBox ID="Surname_edt" runat="server" Width="94px"></asp:TextBox>
                    <asp:TextBox ID="Phone_edt" runat="server" Width="94px"></asp:TextBox>
                    <asp:TextBox ID="Address_edt" runat="server" Width="170px"></asp:TextBox>
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
                    <asp:GridView ID="Customers_grid" runat="server" AutoGenerateColumns="False" BackColor="White"
                        BorderColor="#441100" BorderStyle="None" BorderWidth="1px" CellPadding="4" EnableModelValidation="True"
                        Style="margin-top: 0px" Width="795px" DataKeyNames="ID" 
                        OnRowCommand="Customers_grid_RowCommand" ForeColor="White">
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <HeaderStyle BackColor="#9900CC" Font-Bold="True" ForeColor="#CCCCFF" />
                        <PagerStyle BackColor="#CC9900" ForeColor="#003399" HorizontalAlign="Left" />
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Name" HeaderText="Имя" />
                            <asp:BoundField DataField="Surname" HeaderText="Фамилия" />
                            <asp:BoundField DataField="Phone" HeaderText="Телефон" />
                            <asp:BoundField DataField="Address" HeaderText="Адрес" />
                            <asp:ButtonField CommandName="Editcustomer" Text="Редактировать" />
                            <asp:ButtonField CommandName="Deletecustomer" Text="Удалить" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
    </asp:Panel>
   
    <asp:Label ID="Error_lb" runat="server" Text="" ForeColor="Red"></asp:Label>
     
    <asp:SqlDataSource ID="Customers_sds" runat="server"></asp:SqlDataSource>
     
    </asp:Content>