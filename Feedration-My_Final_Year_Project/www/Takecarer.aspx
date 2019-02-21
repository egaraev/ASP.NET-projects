<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Takecarer.aspx.cs" Inherits="Takecarer" %>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 230px;
        }
        .style3
        {
            width: 298px;
        }
        .style4
        {
            width: 365px;
        }
        .style5
        {
            color:Red; 
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>Welcome takecarer!</p>
<table width="100%" border="1">
  <tr>
    <td class="style2"><p>Please select animals herd</p></td>
    <td class="style4">
                    <asp:DropDownList ID="herd_ddl1" runat="server" DataSourceID="SqlDataSource1" 
                        DataTextField="NAME" DataValueField="ID" 
            Height="24px" AutoPostBack="True" 
                        onselectedindexchanged="herd_ddl1_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
      </td>
    <td class="style3">&nbsp;</td>
  </tr>
  <tr>
    <td class="style3">&nbsp;</td>
  </tr>
  <tr>
    <td class="style2">Please select growing target</td>
    <td class="style4">
                    <asp:DropDownList ID="Growgrp_ddl3" runat="server" DataSourceID="SqlDataSource3" 
                        DataTextField="NAME" DataValueField="ID" 
            Height="24px">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DBpath %>">
        </asp:SqlDataSource>
      </td>
    <td class="style3">&nbsp;&nbsp; </td>
  </tr>
  <tr>
    <td class="style3">&nbsp;</td>
  </tr>
  <tr>
    <td class="style3">&nbsp;</td>
  </tr>
  <tr>
    <td class="style2">Please select animals keeping group</td>
    <td class="style4">
        <asp:DropDownList ID="keepgrp_ddl" runat="server" Height="24px" 
            Width="89px">
            <asp:ListItem Value="true">Stalled</asp:ListItem>
            <asp:ListItem Value="false">Grasing</asp:ListItem>
        </asp:DropDownList>
        </td>
    <td class="style3">&nbsp;</td>
  </tr>
  <tr>
    <td class="style2">Please select season</td>
    <td class="style4">
        <asp:DropDownList ID="season_ddl0" runat="server" Height="24px" 
            Width="80px">
            <asp:ListItem Value="true">Warm</asp:ListItem>
            <asp:ListItem Value="false">Cold</asp:ListItem>
        </asp:DropDownList>
                    </td>
    <td class="style3">&nbsp;</td>
  </tr>
  <tr>
    <td class="style2">Please type quantity</td>
    <td class="style4">
                    <asp:TextBox ID="Quantity_edt1" runat="server" Width="104px"></asp:TextBox>
                    </td>
    <td class="style3">
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
  </tr>
  <tr>
    <td class="style2">Please select feed type and weight</td>
    <td class="style4">
                    <asp:DropDownList ID="Weightgrp_ddl9" runat="server" DataSourceID="SqlDataSource5" 
                        DataTextField="NAME" DataValueField="ID" Width="101px" 
            Height="24px">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
            ConnectionString="<%$ ConnectionStrings:DBpath %>" 
            SelectCommand="SELECT [ID], [NAME] FROM [FEED]"></asp:SqlDataSource>
                    <asp:TextBox ID="Quantity_edt2" runat="server" Width="104px"></asp:TextBox>
                    &nbsp;</td>
    <td class="style3"><span style="color: red"> <asp:Literal ID="error0_lb" runat="server"></asp:Literal></span>&nbsp;</td></td>
  </tr>
  <asp:Panel runat="server" ID="Panel1" Visible="false">
    <tr>
    <td class="style2">Please select feed type and weight</td>
    <td class="style4">
                    <asp:DropDownList ID="Weightgrp_ddl1" runat="server" DataSourceID="SqlDataSource5" 
                        DataTextField="NAME" DataValueField="ID" Width="101px" 
            Height="24px">
                    </asp:DropDownList>
                  
                    <asp:TextBox ID="TextBox1" runat="server" Width="104px"></asp:TextBox>
                    &nbsp;</td>
    <td class="style3">
     <span style="color: red">   <asp:Literal ID="error1_lb" runat="server"></asp:Literal></span>&nbsp;</td>
  </tr>
  </asp:Panel>
  <asp:Panel runat="server" ID="Panel2" Visible="false">
    <tr>
    <td class="style2">Please select feed type and weight</td>
    <td class="style4">
                    <asp:DropDownList ID="Weightgrp_ddl2" runat="server" DataSourceID="SqlDataSource5" 
                        DataTextField="NAME" DataValueField="ID" Width="101px" 
            Height="24px">
                    </asp:DropDownList>
                   
                    <asp:TextBox ID="TextBox2" runat="server" Width="104px"></asp:TextBox>
                    &nbsp;</td>
    <td class="style3">
      <span style="color: red">  <asp:Literal ID="error2_lb" runat="server"></asp:Literal></span></td>
  </tr>
  </asp:Panel>
  <asp:Panel runat="server" ID="Panel3" Visible="false">
    <tr>
    <td class="style2">Please select feed type and weight</td>
    <td class="style4">
                    <asp:DropDownList ID="Weightgrp_ddl3" runat="server" DataSourceID="SqlDataSource5" 
                        DataTextField="NAME" DataValueField="ID" Width="101px" 
            Height="24px">
                    </asp:DropDownList>
                
        
                    <asp:TextBox ID="TextBox3" runat="server" Width="104px"></asp:TextBox>
                    &nbsp;</td>
    <td class="style3">
       <span style="color: red"> <asp:Literal ID="error3_lb" runat="server"></asp:Literal></span>&nbsp;</td>
  </tr>
  </asp:Panel>
  <asp:Panel runat="server" ID="Panel4" Visible="false">
    <tr>
    <td class="style2">Please select feed type and weight</td>
    <td class="style4">
                    <asp:DropDownList ID="Weightgrp_ddl4" runat="server" DataSourceID="SqlDataSource5" 
                        DataTextField="NAME" DataValueField="ID" Width="101px" 
            Height="24px">
                    </asp:DropDownList>
               
                    <asp:TextBox ID="TextBox4" runat="server" Width="104px"></asp:TextBox>
                    &nbsp;</td>
    <td class="style3">
       <span style="color: red"> <asp:Literal ID="error4_lb" runat="server"></asp:Literal></span>&nbsp;</td>
  </tr>
  </asp:Panel>
  <asp:Panel runat="server" ID="Panel5" Visible="false">
    <tr>
    <td class="style2">Please select feed type and weight</td>
    <td class="style4">
                    <asp:DropDownList ID="Weightgrp_ddl5" runat="server" DataSourceID="SqlDataSource5" 
                        DataTextField="NAME" DataValueField="ID" Width="101px" 
            Height="24px">
                    </asp:DropDownList>
     
                    <asp:TextBox ID="TextBox5" runat="server" Width="104px"></asp:TextBox>
                    &nbsp;</td>
    <td class="style3">
      <span style="color: red">  <asp:Literal ID="error5_lb" runat="server"></asp:Literal></span>&nbsp;</td>
  </tr>
  </asp:Panel>
  <tr>
    <td class="style2">Add other feeds
                    <asp:Button ID="add_btn" runat="server" Text="Add" 
                        Width="64px" onclick="add_btn_Click" />
                    </td>
    <td class="style4">
        <asp:Button ID="remove_btn" runat="server" onclick="remove_btn_Click" 
            Text="Remove feed" />
      </td>
    <td class="style3">&nbsp;</td>
  </tr>
</table>
<p>&nbsp;</p>
<table width="200" border="1">
  <tr>
    <td>
                    <asp:Button ID="calc_btn0" runat="server" Text="Calculate" 
                        Width="100px" onclick="calc_btn0_Click" />
                    </td>
  </tr>
</table>
<p>
    <br />
    
    </p>
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
<p>&nbsp;</p>
<p>&nbsp;</p>

</asp:Content>

