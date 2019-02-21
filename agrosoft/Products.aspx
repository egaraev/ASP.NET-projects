<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Products"
    MasterPageFile="~/MasterPage.master" %>

<%@ Register TagPrefix="rad" Namespace="Telerik.WebControls" Assembly="RadCalendar.NET2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script language="javascript">
    function myOpen(id) {
        window.open("Fotos.aspx?id=" + id, "wind" + id,
    "height=760,width=220,status=yes,toolbar=no,menubar=no,location=no,top=0,left=0");
    }
</script>
    <table cellpadding="0" cellspacing="0" border="0" width="90%">
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
                <asp:LinkButton ID="Cat_mgmt" runat="server" PostBackUrl="~/Categories.aspx">Категории продукции</asp:LinkButton>
            </td>
            <td valign="top" class="style1">
                <asp:Label ID="Products_lb" runat="server" Text="Продукты" Style="color: #000099"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="Logout_btn" runat="server" OnClick="Logout_btn_Click">Выход</asp:LinkButton>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="5">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td>
                            <asp:Panel ID="Panel1" runat="server" Style="margin-bottom: 0px">
                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                    <tr>
                                        <td valign="top" colspan="2">
                                            <asp:Label ID="Error1_lb" runat="server" ForeColor="Red"></asp:Label>
                                            <br />
                                            <br />
                                            <asp:GridView ID="Admin_grid" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                BorderColor="#441100" BorderStyle="None" BorderWidth="1px" CellPadding="4" EnableModelValidation="True"
                                                Style="margin-top: 0px" DataKeyNames="ID" ForeColor="White" OnRowCommand="Admin_grid_RowCommand">
                                                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                <HeaderStyle BackColor="#9900CC" Font-Bold="True" ForeColor="#CCCCFF" />
                                                <PagerStyle BackColor="#CC9900" ForeColor="#003399" HorizontalAlign="Left" />
                                                <RowStyle BackColor="White" ForeColor="#003399" />
                                                <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="White" />
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>
                                                    <asp:ButtonField CommandName="Info" Text="Подробнее" />
                                                    <asp:BoundField DataField="Categoryname" HeaderText="Категория" HeaderStyle-Width="170px"
                                                        ItemStyle-Width="170px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                                                    <asp:BoundField ApplyFormatInEditMode="True" DataFormatString="{0:d}" HtmlEncode="False"
                                                        DataField="Datesold" HeaderText="Дата продажи" HeaderStyle-Width="150px" ItemStyle-Width="150px"
                                                        HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                                                    <asp:BoundField DataField="Serial" HeaderText="Серийник" HeaderStyle-Width="110px"
                                                        ItemStyle-Width="110px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                                                    <asp:BoundField DataField="Price" HeaderText="Цена" HeaderStyle-Width="120px" ItemStyle-Width="120px"
                                                        HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                                                    <asp:BoundField DataField="Initials" HeaderText="ФИО" HeaderStyle-Width="350px" ItemStyle-Width="350px"
                                                        HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                                                    <asp:ButtonField CommandName="Editproduct" Text="Редактировать" />
                                                    <asp:ButtonField CommandName="Deleteproduct" Text="Удалить" />
                                                </Columns>
                                            </asp:GridView>
                                            <hr />
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="Panel2" runat="server" Style="margin-bottom: 0px">
                                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                    <tr>
                                        <td valign="top" colspan="2">
                                            <asp:Label ID="Error2_lb" runat="server" ForeColor="Red"></asp:Label>
                                            <br />
                                            <br />
                                            <asp:GridView ID="Clients_grid" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                BorderColor="#441100" BorderStyle="None" BorderWidth="1px" CellPadding="4" EnableModelValidation="True"
                                                Style="margin-top: 0px" DataKeyNames="ID" ForeColor="White">
                                                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                <HeaderStyle BackColor="#9900CC" Font-Bold="True" ForeColor="#CCCCFF" />
                                                <PagerStyle BackColor="#CC9900" ForeColor="#003399" HorizontalAlign="Left" />
                                                <RowStyle BackColor="White" ForeColor="#003399" />
                                                <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="White" />
                                                <AlternatingRowStyle BackColor="White" />
                                                <Columns>

                                                                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <input id="Button1" type="button" value="Фото" onclick='myOpen(<%# Eval ("ID") %>);'/>
                                        </ItemTemplate>
                                        <AlternatingItemTemplate>
                                            <input id="Button1" type="button" value="Фото" onclick='myOpen(<%# Eval ("ID") %>);'/>
                                        </AlternatingItemTemplate>
                                    </asp:TemplateField>

                                                    <asp:BoundField DataField="Modelname" HeaderText="Модель" HeaderStyle-Width="50px"
                                                        ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                                                    <asp:BoundField DataField="Category" HeaderText="Категория" HeaderStyle-Width="50px"
                                                        ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                                                    <asp:BoundField ApplyFormatInEditMode="True" DataFormatString="{0:d}" HtmlEncode="False"
                                                        DataField="Datesold" HeaderText="Дата продажи" />
                                                    <asp:BoundField DataField="Timespent" HeaderText="Время изготовления Дни" HeaderStyle-Width="40px"
                                                        ItemStyle-Width="40px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                                                    <asp:BoundField DataField="Price" HeaderText="Цена/AZN" HeaderStyle-Width="50px"
                                                        ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                                                    <asp:BoundField DataField="Selfpriceclient" HeaderText="Себестоимость AZN" HeaderStyle-Width="50px"
                                                        ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                                                    <asp:BoundField DataField="Height" HeaderText="Высота/см" HeaderStyle-Width="50px"
                                                        ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                                                    <asp:BoundField DataField="Weight" HeaderText="Вес/кг" HeaderStyle-Width="50px" ItemStyle-Width="50px"
                                                        HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                                                    <asp:BoundField DataField="Voltage" HeaderText="Напряжение Вольт" HeaderStyle-Width="50px"
                                                        ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                                                    <asp:BoundField DataField="Rpm" HeaderText="Обороты" HeaderStyle-Width="50px" ItemStyle-Width="50px"
                                                        HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                                                    <asp:BoundField DataField="Performance" HeaderText="Производи тельность кг\час" HeaderStyle-Width="50px"
                                                        ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                                                    <asp:BoundField DataField="Enginepower" HeaderText="Мощность Квт" HeaderStyle-Width="50px"
                                                        ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                                                    <asp:BoundField DataField="Hummers" HeaderText="Количество молотков" HeaderStyle-Width="50px"
                                                        ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                                                    <asp:BoundField DataField="Comment" HeaderText="Доп. инфо" HeaderStyle-Width="50px"
                                                        ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="Panel3" runat="server" Style="margin-bottom: 0px">
                                <table cellpadding="0" cellspacing="10" border="0" width="100%">
                                    <tr>
                                        <td class="style2">
                                            <asp:Label ID="Modelname_lb" runat="server" Text="Модель"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Modelname_edt" runat="server" Width="350px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Modelname_edt"
                                                ErrorMessage="*" ValidationGroup="G1"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            <asp:Label ID="Categories_lb" runat="server" Text="Категория"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="Categories_ddl" runat="server" OnDataBound="Categories_ddl_DataBound"
                                                Width="357px" DataSourceID="Categories_sds" DataTextField="NAME" DataValueField="ID">
                                            </asp:DropDownList>
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="Categories_ddl"
                                                ErrorMessage="*" Operator="GreaterThan" Type="Integer" ValidationGroup="G1" ValueToCompare="-1"></asp:CompareValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            <asp:Label ID="Waranty_lb" runat="server" Text="Гарантия"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="Waranty_ddl" runat="server" Width="357px">
                                                <asp:ListItem Value="-1">Выберите кол-во мес.</asp:ListItem>
                                                <asp:ListItem Value="1"></asp:ListItem>
                                                <asp:ListItem Value="2"></asp:ListItem>
                                                <asp:ListItem Value="3"></asp:ListItem>
                                                <asp:ListItem Value="4"></asp:ListItem>
                                                <asp:ListItem Value="5"></asp:ListItem>
                                                <asp:ListItem Value="6"></asp:ListItem>
                                                <asp:ListItem Value="7"></asp:ListItem>
                                                <asp:ListItem Value="8"></asp:ListItem>
                                                <asp:ListItem Value="9"></asp:ListItem>
                                                <asp:ListItem Value="10"></asp:ListItem>
                                                <asp:ListItem Value="11"></asp:ListItem>
                                                <asp:ListItem Value="12"></asp:ListItem>
                                                <asp:ListItem Value="13"></asp:ListItem>
                                                <asp:ListItem Value="14"></asp:ListItem>
                                                <asp:ListItem Value="15"></asp:ListItem>
                                                <asp:ListItem Value="16"></asp:ListItem>
                                                <asp:ListItem Value="17"></asp:ListItem>
                                                <asp:ListItem Value="18"></asp:ListItem>
                                                <asp:ListItem Value="19"></asp:ListItem>
                                                <asp:ListItem Value="20"></asp:ListItem>
                                                <asp:ListItem Value="21"></asp:ListItem>
                                                <asp:ListItem Value="22"></asp:ListItem>
                                                <asp:ListItem Value="23"></asp:ListItem>
                                                <asp:ListItem Value="24"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="Waranty_ddl"
                                                ErrorMessage="*" Operator="GreaterThan" Type="Integer" ValidationGroup="G1" ValueToCompare="-1"></asp:CompareValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            <asp:Label ID="Datesold_lb" runat="server" Text="Дата продажи"></asp:Label>
                                        </td>
                                        <td>
                                            <rad:RadDatePicker ID="Datesold_edt" runat="server" Width="350px" Culture="English (United States)"
                                                Skin="Outlook">
                                                <DateInput Skin="Outlook" ReadOnly="true">
                                                </DateInput>
                                                <Calendar Skin="Outlook">
                                                </Calendar>
                                            </rad:RadDatePicker>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Datesold_edt"
                                                ErrorMessage="*" ValidationGroup="G1"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            <asp:Label ID="Clients_lb" runat="server" Text="ФИО клиента"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="Clients_ddl" runat="server" Width="357px" OnDataBound="Clients_ddl_DataBound"
                                                DataSourceID="Clients_sds" DataTextField="FIO" DataValueField="ID">
                                            </asp:DropDownList>
                                            <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="Clients_ddl"
                                                ErrorMessage="*" Operator="GreaterThan" Type="Integer" ValidationGroup="G1" ValueToCompare="-1"></asp:CompareValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            <asp:Label ID="Serial_lb" runat="server" Text="Серийник"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Serial_edt" runat="server" Width="350px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Serial_edt"
                                                ErrorMessage="*" ValidationGroup="G1"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            <asp:Label ID="Timespent_lb" runat="server" Text="Время изготовления"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Timespent_edt" runat="server" Width="350px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            <asp:Label ID="Price_lb" runat="server" Text="Цена"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Price_edt" runat="server" Width="350px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Price_edt"
                                                ErrorMessage="*" ValidationGroup="G1"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            <asp:Label ID="Selfprice_lb" runat="server" Text="Себестоимость"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Selfprice_edt" runat="server" Width="350px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Selfprice_edt"
                                                ErrorMessage="*" ValidationGroup="G1"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            <asp:Label ID="Selfpriceclient_lb" runat="server" Text="Себестоимость для клиента"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Selfpriceclient_edt" runat="server" Width="350px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Selfpriceclient_edt"
                                                ErrorMessage="*" ValidationGroup="G1"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            <asp:Label ID="Height_lb" runat="server" Text="Высота"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Height_edt" runat="server" Width="350px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            <asp:Label ID="Weight_lb" runat="server" Text="Вес"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Weight_edt" runat="server" Width="350px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            <asp:Label ID="Voltage_lb" runat="server" Text="Напряжение"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Voltage_edt" runat="server" Width="350px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            <asp:Label ID="Rpm_lb" runat="server" Text="Обороты"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Rpm_edt" runat="server" Width="350px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            <asp:Label ID="Performance_lb" runat="server" Text="Производительность"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Performance_edt" runat="server" Width="350px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            <asp:Label ID="Enginepower_lb" runat="server" Text="Мощность"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Enginepower_edt" runat="server" Width="350px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            <asp:Label ID="Hummers_lb" runat="server" Text="Кол-во молотков"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Hummers_edt" runat="server" Width="350px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            <asp:Label ID="Comment_lb" runat="server" Text="Доп. Информация"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Comment_edt" runat="server" Width="350px" Rows="3" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Foto1_lb" runat="server" Text="Фото 1"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:FileUpload ID="Foto1_upl" runat="server" Width="346px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Foto2_lb" runat="server" Text="Фото 2"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:FileUpload ID="Foto2_upl" runat="server" Width="346px" />
                                        </td>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Foto3_lb" runat="server" Text="Фото 3"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:FileUpload ID="Foto3_upl" runat="server" Width="346px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Foto4_lb" runat="server" Text="Фото 4"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:FileUpload ID="Foto4_upl" runat="server" Width="346px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Foto5_lb" runat="server" Text="Фото 5"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:FileUpload ID="Foto5_upl" runat="server" Width="346px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                                <asp:SqlDataSource ID="Categories_sds" runat="server"></asp:SqlDataSource>
                                                <asp:SqlDataSource ID="Clients_sds" runat="server"></asp:SqlDataSource>
                                                <asp:SqlDataSource ID="Admingrid_sds" runat="server"></asp:SqlDataSource>
                                                <asp:SqlDataSource ID="Clientsgrid_sds" runat="server"></asp:SqlDataSource>
                                            </td>
                                            <td valign="top">
                                                <asp:Button ID="Add_btn" runat="server" OnClick="add_btn_Click" Text="Добавить" ValidationGroup="G1"
                                                    Width="64px" />
                                                <asp:Button ID="Update_btn" runat="server" OnClick="update_btn_Click" Text="Обновить"
                                                    ValidationGroup="G1" Visible="false" Width="64px" />
                                                &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Cancel_btn" runat="server" OnClick="cancel_btn_Click"
                                                    Text="Отмена" Visible="false" Width="52px" />
                                            </td>
                                        </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .style1
        {
            width: 657px;
        }
        .style2
        {
            width: 266px;
        }
    </style>
</asp:Content>
