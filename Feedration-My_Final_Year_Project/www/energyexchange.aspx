<%@ Page Language="C#" AutoEventWireup="true" CodeFile="energyexchange.aspx.cs" Inherits="energyexchange" %>

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
            Energy exchange&nbsp; management</div>
    <form id="form1" runat="server">
    <p>
&nbsp;&nbsp;&nbsp;
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td class="style2" valign="top" style="margin-left: 40px">
                    &nbsp; 
                    <asp:Label ID="Label3" 
                        runat="server" Text="Animal herd"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;<asp:Label ID="Label2" runat="server" Text="Target"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" Text="Energy necessity"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:Label ID="Label4" runat="server" Text="Dry matter"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label5" 
                        runat="server" Text="Crude fiber"></asp:Label>
                    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label6" 
                        runat="server" Text="Protein"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label 
                        ID="Label7" runat="server" Text="Ca"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:Label 
                        ID="Label8" runat="server" Text="P"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    <asp:DropDownList ID="Herd_ddl" runat="server" DataSourceID="SqlDataSource2" 
                        DataTextField="NAME" DataValueField="ID">
                    </asp:DropDownList>
                    <asp:DropDownList ID="Target_ddl" runat="server" DataSourceID="SqlDataSource3" 
                        DataTextField="NAME" DataValueField="ID">
                    </asp:DropDownList>
                    <asp:TextBox ID="Energy_edt" runat="server" Width="104px"></asp:TextBox>
                    <asp:TextBox ID="Drymatter_edt" runat="server" Width="104px"></asp:TextBox>
                    <asp:TextBox ID="Crudefiber_edt" runat="server" Width="104px"></asp:TextBox>
                    <asp:TextBox ID="Protein_edt" runat="server" Width="104px"></asp:TextBox>
                    <asp:TextBox ID="Ca_edt" runat="server" Width="104px"></asp:TextBox>
                    <asp:TextBox ID="P_edt" runat="server" Width="104px"></asp:TextBox>
                    <asp:Button ID="add_btn" runat="server" Text="Add" 
                        Width="64px" onclick="add_btn_Click" />
                  
                  
                    <asp:Label ID="Error_lb" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:DBpath %>" 
                        SelectCommand="SELECT [ID], [NAME] FROM [ANIMALS]"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:DBpath %>" 
                        SelectCommand="SELECT [ID], [NAME] FROM [TARGETINCREASE]">
                    </asp:SqlDataSource>
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
        <asp:GridView ID="Energymgmt_grid" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#441100" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4"  ForeColor="White" 
            Style="margin-top: 0px" Width="876px" AllowPaging="True" 
            DataSourceID="SqlDataSource1" DataKeyNames="ID" 
            onrowcommand="Energymgmt_grid_RowCommand" 
            onrowupdating="Energymgmt_grid_RowUpdating">
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#CC9900" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
            <Columns>


                    <asp:TemplateField Visible="True">
                    <ItemTemplate>
                        <%# Eval("ANIMALSNAME")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="Animalcat_grid_ddl" runat="server" DataSourceID="SqlDataSource3"
                            DataTextField="NAME" DataValueField="ID">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <HeaderTemplate>
                       Animal herd
                    </HeaderTemplate>
                </asp:TemplateField>


                
                    <asp:TemplateField Visible="True">
                    <ItemTemplate>
                        <%# Eval("TARGETINCREASENAME")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="Targetcat_grid_ddl" runat="server" DataSourceID="SqlDataSource2"
                            DataTextField="NAME" DataValueField="ID">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <HeaderTemplate>
                       Target
                    </HeaderTemplate>
                </asp:TemplateField>


                <asp:BoundField DataField="ENERGY" HeaderText="Energy necessity" />
                <asp:BoundField DataField="DRYMATTER" HeaderText="Dry matter" />
                <asp:BoundField DataField="CRUDEFIBER" HeaderText="Crudefiber" 
                    SortExpression="CRUDEFIBER" />
                <asp:BoundField DataField="PROTEIN" HeaderText="Protein" 
                    SortExpression="PROTEIN" />
                <asp:BoundField DataField="CA" HeaderText="CA" SortExpression="CA" />
                <asp:BoundField DataField="P" HeaderText="P" SortExpression="P" />
                 <asp:CommandField ShowEditButton="True" HeaderText="Edit" />
                <asp:ButtonField CommandName="Delete_energy" Text="Delete" />
            </Columns>
        </asp:GridView>
    </p>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DBpath %>" 
        
        
        
        SelectCommand="SELECT ENERGYCHANGE.ID, ENERGYCHANGE.TARGETINCREASEID, ENERGYCHANGE.ANIMALSID, ANIMALS.NAME AS ANIMALSNAME, TARGETINCREASE.NAME AS TARGETINCREASENAME, ENERGYCHANGE.DRYMATTER, ENERGYCHANGE.CRUDEFIBER, ENERGYCHANGE.PROTEIN, ENERGYCHANGE.ENERGY, ENERGYCHANGE.CA, ENERGYCHANGE.P FROM ENERGYCHANGE INNER JOIN TARGETINCREASE ON ENERGYCHANGE.TARGETINCREASEID = TARGETINCREASE.ID INNER JOIN ANIMALS ON ENERGYCHANGE.ANIMALSID = ANIMALS.ID"></asp:SqlDataSource>
    </form>
</body>
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin.aspx">Back to main page</asp:HyperLink>
    </p>
</body>
</html>
