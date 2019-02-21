<%@ Page Language="C#" AutoEventWireup="true" CodeFile="targets.aspx.cs" Inherits="targets" %>

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
    Growing targets<body></div>
    <form id="form1" runat="server">
    <p>
&nbsp;&nbsp;&nbsp;
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td class="style2" valign="top">
                    &nbsp;<asp:Label 
                        ID="Label1" runat="server" 
                        Text="Target task"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;<asp:Label ID="Label2" runat="server" 
                        Text="Target category"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:Label 
                        ID="Label3" runat="server" 
                        Text="Target name"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label4" runat="server" 
                        Text="Target value"></asp:Label>
                    &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    <asp:TextBox ID="Target_edt" runat="server" Width="104px"></asp:TextBox>
                    <asp:DropDownList ID="Targetcat_ddl" runat="server" DataSourceID="SqlDataSource2" 
                        DataTextField="NAME" DataValueField="ID" Width="180px" Height="24px">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:DBpath %>" 
                        
                        SelectCommand="SELECT TARGETINCREASE.ID, TARGETINCREASE.NAME, TARGETINCREASE.TARGETCATEGORYID, TARGETINCREASE.TARGETNAMEID, TARGETINCREASE.TARGETVALUEID, TARGETCATEGORY.NAME AS TARGETCATNAME, TARGETNAME.NAME AS TARGETNAMENAME, TARGETVALUE.NAME AS TARGETVALUENAME FROM TARGETINCREASE INNER JOIN TARGETCATEGORY ON TARGETINCREASE.TARGETCATEGORYID = TARGETCATEGORY.ID INNER JOIN TARGETNAME ON TARGETINCREASE.TARGETNAMEID = TARGETNAME.ID INNER JOIN TARGETVALUE ON TARGETINCREASE.TARGETVALUEID = TARGETVALUE.ID">
                    </asp:SqlDataSource>
                    <asp:DropDownList ID="Targetname_ddl" runat="server" DataSourceID="SqlDataSource4" 
                        DataTextField="NAME" DataValueField="ID" Width="117px" Height="24px">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:DBpath %>" 
                        SelectCommand="SELECT [ID], [NAME] FROM [TARGETNAME]"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:DBpath %>" 
                        SelectCommand="SELECT [ID], [NAME] FROM [TARGETCATEGORY]">
                    </asp:SqlDataSource>
                    <asp:DropDownList ID="targetval_ddl" runat="server" DataSourceID="SqlDataSource3" 
                        DataTextField="NAME" DataValueField="ID" Width="117px" Height="24px">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:DBpath %>" 
                        SelectCommand="SELECT [ID], [NAME] FROM [TARGETVALUE]"></asp:SqlDataSource>
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
        <asp:GridView ID="Targetmgmt_grid" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#441100" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4"  ForeColor="White" 
            Style="margin-top: 0px" Width="876px" AllowPaging="True" 
            DataSourceID="SqlDataSource1" AllowSorting="True" 
            onrowcommand="Targetmgmt_grid_RowCommand" 
            onrowupdating="Targetmgmt_grid_RowUpdating" DataKeyNames="ID">
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#CC9900" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="NAME" HeaderText="Target" />

                <asp:TemplateField Visible="True">
                    <ItemTemplate>
                        <%# Eval("TARGETCATNAME")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="Targetcat_grid_ddl" runat="server" DataSourceID="SqlDataSource2"
                            DataTextField="NAME" DataValueField="ID">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <HeaderTemplate>
                       Target Category
                    </HeaderTemplate>
                </asp:TemplateField>


                   <asp:TemplateField Visible="True">
                    <ItemTemplate>
                        <%# Eval("TARGETNAMENAME")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="Targetname_grid_ddl" runat="server" DataSourceID="SqlDataSource4"
                            DataTextField="NAME" DataValueField="ID">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <HeaderTemplate>
                       Target Name
                    </HeaderTemplate>
                </asp:TemplateField>
           


           <asp:TemplateField Visible="True">
                    <ItemTemplate>
                        <%# Eval("TARGETVALUENAME")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="Targetvalue_grid_ddl" runat="server" DataSourceID="SqlDataSource3"
                            DataTextField="NAME" DataValueField="ID">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <HeaderTemplate>
                       Target Value
                    </HeaderTemplate>
                </asp:TemplateField>

                <asp:CommandField ShowEditButton="True" HeaderText="Edit" />
                <asp:ButtonField CommandName="Delete_target" Text="Delete" />
            </Columns>
        </asp:GridView>
    </p>
    </form>
</body>
    <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin.aspx">Back to main page</asp:HyperLink>
    </p>
</body>
</html>
