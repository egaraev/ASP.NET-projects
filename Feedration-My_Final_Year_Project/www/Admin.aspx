<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Ration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <p>Welcome Admin!</p>
<table border="0" style="width: 724px">
  <tr>
    <td width="294">Please select desired management module </td>
    <td width="240">
        <asp:DropDownList ID="selectmodule_ddl" runat="server" Height="24px" 
            Width="132px">
            <asp:ListItem Value="-1">Select module</asp:ListItem>
            <asp:ListItem Value="1">Users</asp:ListItem>
            <asp:ListItem Value="2">Groups</asp:ListItem>
            <asp:ListItem Value="3">Animal breeds</asp:ListItem>
            <asp:ListItem Value="4">Animal herds</asp:ListItem>
            <asp:ListItem Value="5">Age groups</asp:ListItem>
            <asp:ListItem Value="6">Feeds categories</asp:ListItem>
            <asp:ListItem Value="7">Feeds</asp:ListItem>
            <asp:ListItem Value="8">Weight groups</asp:ListItem>
            <asp:ListItem Value="9">Growing target categories</asp:ListItem>
            <asp:ListItem Value="10">Growing target names</asp:ListItem>
            <asp:ListItem Value="11">Growing target values</asp:ListItem>
            <asp:ListItem Value="12">Growing targets</asp:ListItem>
            <asp:ListItem Value="13">Feed ratio</asp:ListItem>
            <asp:ListItem Value="14">Edible feeds</asp:ListItem>
            <asp:ListItem Value="15">Feeding tables</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="Add_btn" runat="server" OnClick="add_btn_Click" Text="Manage" 
            ValidationGroup="G1" Width="64px" />
      </td>
  </tr>
</table>
<p>&nbsp;</p>


</asp:Content>

