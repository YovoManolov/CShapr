<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HelloWorldClientPage.aspx.cs" Inherits="WebApplication1.HelloWorldClientPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td><asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Call Hello World" /></td>
                    <td><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
                </tr>
                 <tr>
                    <td><asp:TextBox ID="tbA" runat="server"></asp:TextBox></td>
                    <td><asp:TextBox ID="tbB" runat="server"></asp:TextBox></td>
                    <td><asp:Button ID="addButton" runat="server" OnClick="add_Click" Text="Add" Width="58px" /></td>
                    <td><asp:Label ID="addLabel" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td><asp:TextBox ID="ctfParamGrad" runat="server"></asp:TextBox></td>
                    <td><asp:Button ID="ctfButton" runat="server" OnClick="ctf_Click" Text="CelsiusToFahrenheit" /></td>
                    <td><asp:Label ID="ctfResult" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td><asp:TextBox ID="ftcParamGrad" runat="server"></asp:TextBox></td>
                    <td><asp:Button ID="ftcButton" runat="server" OnClick="ftc_Click" Text="FahrenheitToCelsius" /></td>
                    <td><asp:Label ID="ftcResult" runat="server" Text=""></asp:Label></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
