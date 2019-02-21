<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Animalfeedmgmt.aspx.cs" Inherits="animalfeedmgmt" %>

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
    <body>Edible feeds</div>
    <form id="form1" runat="server">
    <p>
&nbsp;&nbsp;&nbsp;
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td class="style2" valign="top">
                    &nbsp;<asp:Label 
                        ID="Label2" runat="server" 
                        Text="Animal"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:Label 
                        ID="Label3" runat="server" 
                        Text="Feed"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    <asp:DropDownList ID="Animal_ddl" runat="server" DataSourceID="SqlDataSource2" 
                        DataTextField="NAME" DataValueField="ID" Width="180px" Height="24px">
                    </asp:DropDownList>
                    <asp:DropDownList ID="Feed_ddl" runat="server" DataSourceID="SqlDataSource3" 
                        DataTextField="NAME" DataValueField="ID" Width="117px" Height="24px">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:DBpath %>" 
                        SelectCommand="SELECT [ID], [NAME] FROM [ANIMALGROUP]">
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:DBpath %>" 
                        SelectCommand="SELECT [ID], [NAME] FROM [FEED]"></asp:SqlDataSource>
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
        <asp:GridView ID="Animalfeedmgmt_grid" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#441100" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4"  ForeColor="White" 
            Style="margin-top: 0px" Width="876px" AllowPaging="True" 
            DataSourceID="SqlDataSource1" AllowSorting="True" 
            onrowcommand="Animalfeedmgmt_grid_RowCommand" 
            onrowupdating="Animalfeedmgmt_grid_RowUpdating" DataKeyNames="ID">
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#CC9900" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
            <Columns>

                <asp:TemplateField Visible="True">
                    <ItemTemplate>
                        <%# Eval("ANIMALGROUP")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="Animal_grid_ddl" runat="server" DataSourceID="SqlDataSource2"
                            DataTextField="NAME" DataValueField="ID">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <HeaderTemplate>
                       Animal name
                    </HeaderTemplate>
                </asp:TemplateField>


                   <asp:TemplateField Visible="True">
                    <ItemTemplate>
                        <%# Eval("FEEDNAME")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="Feed_grid_ddl" runat="server" DataSourceID="SqlDataSource3"
                            DataTextField="NAME" DataValueField="ID">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <HeaderTemplate>
                       Feed name
                    </HeaderTemplate>
                </asp:TemplateField>
           


                <asp:CommandField ShowEditButton="True" HeaderText="Edit" />
                <asp:ButtonField CommandName="Delete_animalfeed" Text="Delete" />
            </Columns>
        </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:DBpath %>" 
                        
                        
            
            
            SelectCommand="SELECT ANIMALFEEDTYPE.ID, ANIMALFEEDTYPE.FEEDID, ANIMALFEEDTYPE.ANIMALGROUPID, ANIMALGROUP.NAME AS ANIMALGROUP, FEED.NAME AS FEEDNAME FROM ANIMALFEEDTYPE INNER JOIN ANIMALGROUP ON ANIMALFEEDTYPE.ANIMALGROUPID = ANIMALGROUP.ID INNER JOIN FEED ON ANIMALFEEDTYPE.FEEDID = FEED.ID">
                    </asp:SqlDataSource>
    </p>
    </form>
</body>
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin.aspx">Back to main page</asp:HyperLink>
    </p>
</body>
</html>
