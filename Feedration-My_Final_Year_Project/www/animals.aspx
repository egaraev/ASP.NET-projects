<%@ Page Language="C#" AutoEventWireup="true" CodeFile="animals.aspx.cs" Inherits="animals" %>

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
        Animal herd<body>&nbsp;management</div>
    <form id="form1" runat="server">
    <p>
&nbsp;&nbsp;&nbsp;
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td class="style2" valign="top" style="margin-left: 40px">
                    &nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="Name of herd"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label2" runat="server" 
                        Text="Animal category"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label3" runat="server" 
                        Text="Age group, month"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label5" runat="server" Text="Weight group, kg"></asp:Label>
                    &nbsp;&nbsp;&nbsp; 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    <asp:TextBox ID="Herdname_edt2" runat="server" Width="104px"></asp:TextBox>
                    <asp:DropDownList ID="Animalcat_ddl" runat="server" DataSourceID="SqlDataSource2" 
                        DataTextField="NAME" DataValueField="ID" Width="123px" Height="24px">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:DBpath %>" 
                        SelectCommand="SELECT [ID], [NAME] FROM [ANIMALGROUP]"></asp:SqlDataSource>
                    <asp:DropDownList ID="Animalage_ddl0" runat="server" DataSourceID="SqlDataSource3" 
                        DataTextField="NAME" DataValueField="ID" Width="130px" Height="24px">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:DBpath %>" 
                        SelectCommand="SELECT [ID], [NAME] FROM [ANIMALAGE]"></asp:SqlDataSource>
                    <asp:DropDownList ID="Weight_ddl1" runat="server" DataSourceID="SqlDataSource4" 
                        DataTextField="NAME" DataValueField="ID" Width="125px" Height="24px">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:DBpath %>" 
                        SelectCommand="SELECT [ID], [NAME] FROM [ANIMALWEIGHT]"></asp:SqlDataSource>
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
        <asp:GridView ID="Herdmgmt_grid" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#441100" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4"  ForeColor="White" 
            Style="margin-top: 0px" Width="917px" AllowPaging="True" 
            DataSourceID="SqlDataSource1" DataKeyNames="ID" 
            onrowcommand="Herdmgmt_grid_RowCommand" 
            onrowupdating="Herdmgmt_grid_RowUpdating">
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#CC9900" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="NAME" HeaderText="Name of herd" />
               
               <asp:TemplateField Visible="True">
                    <ItemTemplate>
                        <%# Eval("BREEDNAME")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="Animalcat_grid_ddl" runat="server" DataSourceID="SqlDataSource2"
                            DataTextField="NAME" DataValueField="ID">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <HeaderTemplate>
                       Animal category
                    </HeaderTemplate>
                </asp:TemplateField>


                   <asp:TemplateField Visible="True">
                    <ItemTemplate>
                        <%# Eval("ANIMALAGEID")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="Animalage_grid_ddl" runat="server" DataSourceID="SqlDataSource3"
                            DataTextField="NAME" DataValueField="ID">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <HeaderTemplate>
                       Age group, month
                    </HeaderTemplate>
                </asp:TemplateField>
           


           <asp:TemplateField Visible="True">
                    <ItemTemplate>
                        <%# Eval("WEIGHTNAME")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="Animalweight_grid_ddl" runat="server" DataSourceID="SqlDataSource4"
                            DataTextField="NAME" DataValueField="ID">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <HeaderTemplate>
                       Weight group, kg
                    </HeaderTemplate>
                </asp:TemplateField>
               
    
                 <asp:CommandField ShowEditButton="True" HeaderText="Edit" />
                <asp:ButtonField CommandName="Delete_herd" Text="Delete" />
            </Columns>
        </asp:GridView>
    </p>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DBpath %>" 
        
        
        SelectCommand="SELECT ANIMALS.ID, ANIMALS.NAME, ANIMALS.ANIMALGROUPID, ANIMALS.ANIMALAGEID, ANIMALS.ANIMALWEIGHTID, ANIMALS.ID, ANIMALGROUP.NAME AS BREEDNAME, ANIMALWEIGHT.NAME AS WEIGHTNAME, ANIMALAGE.NAME AS AGENAME FROM ANIMALS INNER JOIN ANIMALGROUP ON ANIMALS.ANIMALGROUPID = ANIMALGROUP.ID INNER JOIN ANIMALWEIGHT ON ANIMALS.ANIMALWEIGHTID = ANIMALWEIGHT.ID INNER JOIN ANIMALAGE ON ANIMALS.ANIMALAGEID = ANIMALAGE.ID"></asp:SqlDataSource>
    </form>
</body>
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin.aspx">Back to main page</asp:HyperLink>
    </p>
</body>
</html>
