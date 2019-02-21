<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Prodadminfo.aspx.cs" Inherits="Prodadminfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<script language="javascript">
    function myOpen(id) {
        window.open("Fotos.aspx?id="+id, "wind"+id,
    "height=760,width=220,status=yes,toolbar=no,menubar=no,location=no,top=0,left=0");
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <tr>
        <td>
            <asp:Panel ID="Panel2" runat="server" Style="margin-bottom: 0px">
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td valign="top" colspan="2">
                            <asp:Label ID="Error2_lb" runat="server" ForeColor="Red"></asp:Label>
                            <asp:SqlDataSource ID="Admininfo_sds" runat="server"></asp:SqlDataSource>
                            <br />
                            <br />
                            <asp:GridView ID="Admininfo_grid" runat="server" AutoGenerateColumns="False" BackColor="White"
                                BorderColor="#441100" BorderStyle="None" BorderWidth="1px" CellPadding="4" EnableModelValidation="True"
                                Style="margin-top: 0px" DataKeyNames="ID" ForeColor="White" 
                                onrowcommand="Admininfo_grid_RowCommand" >
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
                                    <asp:BoundField DataField="Timespent" HeaderText="Время изготовления Дни" HeaderStyle-Width="40px"
                                        ItemStyle-Width="40px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                                    <asp:BoundField DataField="Waranty" HeaderText="Гарантия" HeaderStyle-Width="40px"
                                        ItemStyle-Width="40px" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                                    <asp:BoundField DataField="Selfprice" HeaderText="Себестоимость AZN" HeaderStyle-Width="50px"
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
</asp:Content>
