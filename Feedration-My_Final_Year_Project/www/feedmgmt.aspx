<%@ Page Language="C#" AutoEventWireup="true" CodeFile="feedmgmt.aspx.cs" Inherits="feedmgmt" %>

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
            Feeds&nbsp; management</div>
    <form id="form1" runat="server">
    <p>
&nbsp;&nbsp;&nbsp;
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td class="style2" valign="top" style="margin-left: 40px">
                    &nbsp;&nbsp;&nbsp;<asp:Label 
                        ID="Label1" runat="server" Text="Feed name"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Category&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label2" runat="server" Text="Dry matter"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label3" 
                        runat="server" Text="Crude fiber"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label 
                        ID="Label4" runat="server" Text="Energy"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label5" runat="server" Text="Protein"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label6" runat="server" Text="Ca"></asp:Label>
                    &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label7" runat="server" Text="P"></asp:Label>
                    &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    <asp:TextBox ID="Feedname_edt" runat="server" Width="104px"></asp:TextBox>
                    <asp:DropDownList ID="Feedcat_ddl1" runat="server" DataSourceID="SqlDataSource2" 
                        DataTextField="NAME" DataValueField="ID" Width="125px" Height="24px">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:DBpath %>" 
                        SelectCommand="SELECT [ID], [NAME] FROM [FEEDCATEGORY]"></asp:SqlDataSource>
                    <asp:TextBox ID="Drymatter_edt" runat="server" Width="104px"></asp:TextBox>
                    <asp:TextBox ID="Crudefiber_edt" runat="server" Width="104px"></asp:TextBox>
                    <asp:TextBox ID="Energy_edt" runat="server" Width="104px"></asp:TextBox>
                    <asp:TextBox ID="Protein_edt" runat="server" Width="104px"></asp:TextBox>
                    <asp:TextBox ID="Ca_edt" runat="server" Width="104px"></asp:TextBox>
                    <asp:TextBox ID="P_edt" runat="server" Width="104px"></asp:TextBox>
                    <asp:Button ID="add_btn" runat="server" Text="Add" 
                        Width="64px" onclick="add_btn_Click" />
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
        <asp:GridView ID="Feedmgmt_grid" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#441100" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4"  ForeColor="White" 
            Style="margin-top: 0px" Width="876px" AllowPaging="True" 
            DataSourceID="SqlDataSource1" onrowcommand="Feedmgmt_grid_RowCommand" 
            onrowupdating="Feedmgmt_grid_RowUpdating" DataKeyNames="ID">
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#CC9900" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Feed name" />

                <asp:TemplateField Visible="True">
                    <ItemTemplate>
                        <%# Eval("FEEDCATNAME")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="Feedcat_grid_ddl" runat="server" DataSourceID="SqlDataSource2"
                            DataTextField="NAME" DataValueField="ID">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <HeaderTemplate>
                       Feed category
                    </HeaderTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="DRYMATTER" HeaderText="Dry Matter, %" 
                    SortExpression="DRYMATTER" />
                <asp:BoundField DataField="CRUDEFIBER" HeaderText="Crude fiber, %" 
                    SortExpression="CRUDEFIBER" />
                <asp:BoundField DataField="PROTEIN" HeaderText="Protein, kg" 
                    SortExpression="PROTEIN" />
                <asp:BoundField DataField="ENERGY" HeaderText="Energy, Mjoule" 
                    SortExpression="ENERGY" />
                <asp:BoundField DataField="CA" HeaderText="Ca, kg" SortExpression="CA" />
                <asp:BoundField DataField="P" HeaderText="P, kg" SortExpression="P" />
                  <asp:CommandField ShowEditButton="True" HeaderText="Edit" />
                <asp:ButtonField CommandName="Delete_feed" Text="Delete" />
            </Columns>
        </asp:GridView>
    </p>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DBpath %>" 
        
        
        SelectCommand="SELECT FEED.ID, FEED.NAME, FEED.DRYMATTER, FEED.CRUDEFIBER, FEED.PROTEIN, FEED.ENERGY, FEED.CA, FEED.P, FEED.CATEGORYID, FEEDCATEGORY.NAME AS FEEDCATNAME FROM FEED INNER JOIN FEEDCATEGORY ON FEED.CATEGORYID = FEEDCATEGORY.ID"></asp:SqlDataSource>
    </form>
</body>
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin.aspx">Back to main page</asp:HyperLink>
    </p>
</body>
</html>
