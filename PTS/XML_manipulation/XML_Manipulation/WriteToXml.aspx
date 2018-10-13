<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WriteToXml.aspx.cs" Inherits="XML_Manipulation.WriteToXml" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Read_XML</title>
<style>
    body{
        background-image: url("images/maxresdefault.jpg");
    }
    table#pageStructureTable {
        width: 100%;
        height: 100%;
    }
    gridView{
        margin-top: 0;
    }
    button#loadXmlButtonId {
        margin-top: 0;
        margin-left: 30px;
    }

    .auto-style1 {
        width: 141px;
    }

    .auto-style2 {
        width: 141px;
        height: 115px;
    }
    .auto-style3 {
        height: 115px;
    }

</style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <table id="pageStructureTable">
               <tr>
                   <td style="vertical-align:top; padding-left: 30px;" class="auto-style2">
                       <asp:Button ID="AddInfoButtonId" runat="server" Text="Добави" OnClick="loadXmlButtonId_Click" />
                   </td>
                   <td style="vertical-align:top; " class="auto-style3">
                        <table>
                            <tr>
                                <td><b>Currency:</b></td>
                                <td><b>Rate:</b></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="CurrencyTbId" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="RateTbId" runat="server"></asp:TextBox>
                                </td>
                            </tr>

                        </table>
                    </td>
               </tr>
            
            </table>
          
        </div>
    </form>
</body>
</html>