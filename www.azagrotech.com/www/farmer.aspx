<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="farmer.aspx.cs" Inherits="farmer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 267px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <body>
<p>
  <label for="1"></label>
Welcome Farmer
        </p>
<table width="891" border="0">
  <tr>
    <td height="168" align="left" valign="top" class="style1">
                    <asp:Label ID="Label2" runat="server" Text="Stock status"></asp:Label>
        <asp:GridView ID="stock_grid" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#003366" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4"  ForeColor="White" 
            Style="margin-top: 0px" Width="360px" AllowPaging="True" 
            DataSourceID="SqlDataSource1" Height="78px" onrowcommand="stock_grid_RowCommand" 
                        onrowupdating="stock_grid_RowUpdating" DataKeyNames="ID">
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#CC9900" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
            <Columns>
            
                <asp:TemplateField Visible="True">
                    <ItemTemplate>
                        <%# Eval("FEEDNAME")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="Feed_grid_ddl" runat="server" DataSourceID="SqlDataSource2"
                            DataTextField="NAME" DataValueField="ID">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <HeaderTemplate>
                       Feed
                    </HeaderTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="WEIGHT" HeaderText="Weight" 
                    SortExpression="WEIGHT" />
                 <asp:CommandField ShowEditButton="True" HeaderText="Edit" />
                <asp:ButtonField CommandName="Delete_stock" Text="Delete" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DBpath %>">
        </asp:SqlDataSource>
                  
                  
                    <asp:Label ID="Error_lb" runat="server" ForeColor="Red" Visible="False"></asp:Label>
      </td>
    <td width="348" align="left" valign="top"><p>
                    <asp:DropDownList ID="Feedcat_ddl1" runat="server" DataSourceID="SqlDataSource2" 
                        DataTextField="NAME" DataValueField="ID" Width="125px" Height="24px">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DBpath %>" 
            SelectCommand="SELECT [ID], [NAME] FROM [FEED]"></asp:SqlDataSource>
&nbsp;<asp:Label ID="Label3" runat="server" Text="Feed name"></asp:Label>
                    </p>
      <p>
                    <asp:TextBox ID="Feedweight_edt0" runat="server" Width="104px"></asp:TextBox>
                    &nbsp;<asp:Label ID="Label4" runat="server" Text="Kg, feed weight"></asp:Label>
                    </p>
    <p>
                    <asp:Button ID="add_btn" runat="server" Text="Add feeds to stock" 
                        Width="131px" onclick="add_btn_Click1" />
                    </p>
    <p>
                    &nbsp;</p></td>
  </tr>
</table>
        <br />
                    <asp:Label ID="Label7" runat="server" Text="Farm status"></asp:Label>
                    <br />
                    &nbsp;<asp:Label 
            ID="Label18" runat="server" Text="Ration group"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label20" 
            runat="server" Text="Animal Herd"></asp:Label>
                    &nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label13" runat="server" Text="Growing group"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label14" runat="server" Text="Quantity"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                    <br />
                    <asp:TextBox ID="ration_edt" runat="server" Width="104px"></asp:TextBox>
                    <asp:DropDownList ID="animal_ddl" runat="server" DataSourceID="SqlDataSource5" 
                        DataTextField="NAME" DataValueField="ID" 
                        Width="248px" Height="24px" AutoPostBack="True" 
            onselectedindexchanged="animal_ddl_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource5" runat="server"></asp:SqlDataSource>
                    <asp:DropDownList ID="Grow_ddl" runat="server" DataSourceID="SqlDataSource7" 
                        DataTextField="NAME" DataValueField="ID" 
                        Width="160px" Height="24px">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource7" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DBpath %>">
        </asp:SqlDataSource>
                    <asp:TextBox ID="Quantity_edt" runat="server" Width="104px"></asp:TextBox>
                    <asp:Button ID="add_btn1" runat="server" Text="Add" 
                        Width="64px" onclick="add_btn1_Click" />
                <asp:Label ID="Label19" runat="server"></asp:Label>
                <br />
        <asp:GridView ID="Farm_grid" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#3333FF" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4"  ForeColor="White" 
            Style="margin-top: 0px" Width="876px" AllowPaging="True" 
            DataSourceID="SqlDataSource8" DataKeyNames="ID" 
            onrowcommand="farm_grid_RowCommand" onrowupdating="farm_grid_RowUpdating">
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#CC9900" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="RATIONGROUP" HeaderText="Ration group" />
                <asp:BoundField DataField="BREED" HeaderText="Breed group" />
                <asp:BoundField DataField="AGE" HeaderText="Age group" />
                <asp:BoundField DataField="WEIGHT" HeaderText="Weight group" />
                <asp:BoundField DataField="TARGET" HeaderText="Growing target group" />
                <asp:BoundField DataField="QUANTITY" HeaderText="Quantity" 
                    SortExpression="QUANTITY" />
                 
                <asp:ButtonField CommandName="Delete_farm" Text="Delete" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource8" runat="server"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DBpath %>" 
            SelectCommand="SELECT [RATIONGROUP], [ID], [ANIMALSID], [QUANTITY] FROM [FARM]"></asp:SqlDataSource>
        <br />
        <br />
<table width="489" border="0">
  <tr>
    <td width="226">
                    <asp:Label ID="Label8" runat="server" Text="Select ration group"></asp:Label>
                    </td>
    <td width="172">
                    <asp:DropDownList ID="Grow_ddl5" runat="server" DataSourceID="SqlDataSource3" 
                        DataTextField="RATIONGROUP" DataValueField="RATIONGROUP" 
                        Width="125px" Height="24px">
                    </asp:DropDownList>
                    </td>
    <td width="69">&nbsp;</td>
  </tr>
  <tr>
    <td>
                    <asp:Label ID="Label9" runat="server" Text="Select season"></asp:Label>
                    </td>
    <td>
        <asp:DropDownList ID="season_ddl0" runat="server" Height="24px" 
            Width="80px">
            <asp:ListItem Value="true">Warm</asp:ListItem>
            <asp:ListItem Value="false">Cold</asp:ListItem>
        </asp:DropDownList>
                    </td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td>
                    <asp:Label ID="Label15" runat="server" Text="Keeping group"></asp:Label>
                    </td>
    <td>
        <asp:DropDownList ID="keepgrp_ddl" runat="server" Height="24px" 
            Width="89px">
            <asp:ListItem Value="true">Stalled</asp:ListItem>
            <asp:ListItem Value="false">Grasing</asp:ListItem>
        </asp:DropDownList>
                    </td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td>
                    <asp:Label ID="Label17" runat="server" Text="Growing Target"></asp:Label>
                    </td>
    <td>
                    <asp:DropDownList ID="Grow_ddl6" runat="server" DataSourceID="SqlDataSource10" 
                        DataTextField="NAME" DataValueField="ID" 
                        Width="160px" Height="24px">
                    </asp:DropDownList>
                    </td>
    <td>
        <asp:SqlDataSource ID="SqlDataSource10" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DBpath %>" 
            SelectCommand="SELECT [NAME], [ID] FROM [TARGETINCREASE]">
        </asp:SqlDataSource>
      </td>
  </tr>
    <tr>
        <td>
                    &nbsp;</td>
    </tr>
    <tr>
        <td>
                    <asp:Button ID="calc_btn0" runat="server" Text="Calculate" 
                        Width="64px" onclick="calc_btn0_Click" />
                    </td>
    </tr>
</table>
<p>&nbsp;</p>
<table width="920" height="112" border="1">
  <tr>
    <td width="261" valign="top"><p>Ration structure:</p>
      <table width="261" border="1">
        <tr>
          <td width="158">Feed type</td>
          <td width="87">Percent</td>
        </tr>
          <asp:Literal ID="ratio_lb" runat="server"></asp:Literal>
       
      </table></td>
    <td width="504"><table width="439" border="1">
      <tr>
        <td width="106">Feed</td>
        <td width="85">Daily need in energy and dry matter</td>
        <td width="41">
            <asp:Label ID="co_lb" runat="server"></asp:Label>
          </td>
        <td width="51">
            <asp:Label ID="ro_lb" runat="server"></asp:Label>
          </td>
        <td width="55"><asp:Label ID="su_lb" runat="server"></asp:Label></td>
        <td width="61">Overquota</td>
      </tr>
      <tr>
        <td>exchange energy</td>
        <td><asp:Label ID="ec_energy" runat="server"></asp:Label></td>
        <td><asp:Label ID="co_energy" runat="server"></asp:Label></td>
        <td><asp:Label ID="ro_energy" runat="server"></asp:Label></td>
        <td><asp:Label ID="su_energy" runat="server"></asp:Label></td>
        <td><asp:Label ID="oq_energy" runat="server"></asp:Label></td>
      </tr>
      <tr>
        <td>protein</td>
        <td><asp:Label ID="ec_protein" runat="server"></asp:Label></td>
        <td><asp:Label ID="co_protein" runat="server"></asp:Label></td>
        <td><asp:Label ID="ro_protein" runat="server"></asp:Label></td>
        <td><asp:Label ID="su_protein" runat="server"></asp:Label></td>
        <td><asp:Label ID="oq_protein" runat="server"></asp:Label></td>
      </tr>
      <tr>
        <td>crude fiber</td>
        <td><asp:Label ID="ec_crudefiber" runat="server"></asp:Label></td>
        <td><asp:Label ID="co_crudefiber" runat="server"></asp:Label></td>
        <td><asp:Label ID="ro_crudefiber" runat="server"></asp:Label></td>
        <td><asp:Label ID="su_crudefiber" runat="server"></asp:Label></td>
        <td><asp:Label ID="oq_crudefiber" runat="server"></asp:Label></td>
      </tr>
      <tr>
        <td>Ca</td>
        <td><asp:Label ID="ec_ca" runat="server"></asp:Label></td>
        <td><asp:Label ID="co_ca" runat="server"></asp:Label></td>
        <td><asp:Label ID="ro_ca" runat="server"></asp:Label></td>
        <td><asp:Label ID="su_ca" runat="server"></asp:Label></td>
        <td><asp:Label ID="oq_ca" runat="server"></asp:Label></td>
      </tr>
      <tr>
        <td>P</td>
        <td><asp:Label ID="ec_p" runat="server"></asp:Label></td>
        <td><asp:Label ID="co_p" runat="server"></asp:Label></td>
        <td><asp:Label ID="ro_p" runat="server"></asp:Label></td>
        <td><asp:Label ID="su_p" runat="server"></asp:Label></td>
        <td><asp:Label ID="oq_p" runat="server"></asp:Label></td>
      </tr>
      <tr>
        <td>Total per animal</td>
        <td>&nbsp;</td>
        <td><asp:Label ID="co_weight" runat="server"></asp:Label></td>
        <td><asp:Label ID="ro_weight" runat="server"></asp:Label></td>
        <td><asp:Label ID="su_weight" runat="server"></asp:Label></td>
        <td><asp:Label ID="oq_weight" runat="server"></asp:Label></td>
      </tr>
    </table></td>
    <td width="208" valign="top"><p>Total: </p>
      <table width="200" border="1">
        <tr>
          <td>Feeds</td>
          <td>Weight</td>
        </tr>
      
          <asp:Literal ID="total_lb" runat="server"></asp:Literal>
      </table></td>
  </tr>
</table>
<p>
    <asp:SqlDataSource ID="SqlDataSource9" runat="server"></asp:SqlDataSource>
        </p>
<p>&nbsp;</p>
</body>

</asp:Content>

