<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CallRestWS.aspx.cs" Inherits="RESTExercise.CallRestWS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 497px">
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
            <table>
                <tr>
                    <td><asp:Button ID="xmlContentButtonId" Width="90px" runat="server" Text="XML Content" OnClick="xmlContentButtonId_Click" /></td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                    <td>&nbsp</td>
                </tr>
                <tr>
                    <td>
                       <asp:Button ID="AddButtonId"  Width="90px" runat="server" Text="Add" OnClick="AddButtonId_Click"/>
                    </td>
                    <td>Id:</td>
                    <td>
                        <asp:TextBox ID="AddIdTextBoxId" runat="server" Width="60px"></asp:TextBox>
                    </td>
                    <td>Value:</td>
                    <td>
                        <asp:TextBox ID="AddValueTextBoxId" runat="server"></asp:TextBox>
                    </td>
                    <td>&nbsp</td>
                </tr>
                <tr>
                    <td>
                       <asp:Button ID="UpdateButtonId" Width="90px" runat="server" Text="Update" OnClick="UpdateButtonId_Click"/>
                    </td>
                    <td>Id:</td>
                    <td>
                        <asp:TextBox ID="UpdateIdTextBoxId" runat="server" Width="60px"></asp:TextBox>
                    </td>
                    <td>Value:</td>
                    <td>
                        <asp:TextBox ID="UpdateValueTextBoxId" runat="server"></asp:TextBox>
                    </td>
                    <td>

                        <asp:CheckBox ID="deleteFlagId" runat="server" Text="delete flag" />
                    </td>
                </tr>
            </table>
                    </td>
                </tr>
                <tr><td></td></tr>
                <tr>
                    <td>
                        <asp:Literal ID="literalXmlContentId" runat="server"></asp:Literal>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
