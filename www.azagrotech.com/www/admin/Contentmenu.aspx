<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Contentmenu.aspx.cs" Inherits="admin_Contentmenu" %>

<%@ Register Assembly="RadEditor.Net2" Namespace="Telerik.WebControls" TagPrefix="rad" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" cellpadding="10" cellspacing="10" border="0">
            <tr>
                <td style="font-size: xx-large; font-weight: bold;" align="center">
                    Контент
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Error_lb" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="RU_lb" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <rad:RadEditor ID="RU_edt" runat="server" Width="657px" ImagesPaths="~/contentfiles/"
                        UploadImagesPaths="~/contentfiles/" MediaPaths="~/mediacontentfiles/" UploadMediaPaths="~/mediacontentfiles/">
                    </rad:RadEditor>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="AZ_lb" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <rad:RadEditor ID="AZ_edt" runat="server" Width="657px" ImagesPaths="~/contentfiles/"
                        UploadImagesPaths="~/contentfiles/" MediaPaths="~/mediacontentfiles/" UploadMediaPaths="~/mediacontentfiles/">
                    </rad:RadEditor>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Add_btn" runat="server" Text="Добавить" Width="126px" 
                        onclick="Add_btn_Click" />
                    <asp:Button ID="Update_btn" runat="server" Text="Обновить" Width="126px" 
                        OnClick="Update_btn_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" Text="Назад" Width="62px" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
