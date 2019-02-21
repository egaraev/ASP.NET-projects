<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Fotos.aspx.cs" Inherits="Fotos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<%--    <script type="text/javascript" src="js/prototype.js"></script>
    <script type="text/javascript" src="js/scriptaculous.js?load=effects,builder"></script>
    <script type="text/javascript" src="js/lightbox.js"></script>
    <link rel="stylesheet" href="css/lightbox.css" type="text/css" media="screen" />--%>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Error_lb" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="Hyper1_hl" runat="server" Target="_blank">
                        <asp:Image ID="Foto1_img" runat="server" Visible="False" Width="200px" Height="142px" /></asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="Hyper2_hl" runat="server" Target="_blank">
                        <asp:Image ID="Foto2_img" runat="server" Visible="False" Width="200px" Height="142px" /></asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="Hyper3_hl" runat="server" Target="_blank">
                        <asp:Image ID="Foto3_img" runat="server" Visible="False" Width="200px" Height="142px" /></asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="Hyper4_hl" runat="server" Target="_blank">
                        <asp:Image ID="Foto4_img" runat="server" Visible="False" Width="200px" Height="142px" /></asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="Hyper5_hl" runat="server" Target="_blank">
                        <asp:Image ID="Foto5_img" runat="server" Visible="False" Width="200px" Height="142px" /></asp:HyperLink>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
