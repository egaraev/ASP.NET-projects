<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 566px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="1" width="100%">
            <tr>
                <td align="right" class="style1">
                    <asp:Label ID="Login_lb" runat="server" Text="Login : "></asp:Label>&nbsp;&nbsp;&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="Login_edt" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="style1">
                    <asp:Label ID="Password_lb" runat="server" Text="Password : "></asp:Label>&nbsp;&nbsp;&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="Password_edt" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="Button1" runat="server" Text="Enter" Width="90px" 
                        onclick="Button1_Click" />
                    <asp:Label ID="Error_lb" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
