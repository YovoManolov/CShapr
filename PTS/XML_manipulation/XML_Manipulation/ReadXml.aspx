<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReadXml.aspx.cs" Inherits="XML_Manipulation.ReadXml" %>

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
        width: 342px;
    }

</style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <table id="pageStructureTable">
               <tr style="height:auto;">
                   <td style="vertical-align:top; padding-left: 30px;" class="auto-style1">
                       <asp:Button ID="loadXmlButtonId" runat="server" Text="Зареди XML от WEB" OnClick="loadXmlButtonId_Click" />
                   </td>
                   <td style="vertical-align:top; ">

                        <asp:GridView ID="gridViewCurrencyId" CssClass="gridView" runat="server"  AutoGenerateColumns="false" >

                        <Columns>

                            <asp:TemplateField ItemStyle-Width="30px" HeaderText="Currency">

                                <ItemTemplate>

                                    <asp:Label runat="server"

                                      Text='<%#Eval("Currency")%>'></asp:Label>

                                </ItemTemplate>

                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="30px" HeaderText="Rate">

                                <ItemTemplate>

                                    <asp:Label ID="lbl_Rate_id" runat="server"

                                      Text='<%#Eval("Rate")%>'></asp:Label>

                                </ItemTemplate>

                            </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                   </td>
                   
               </tr>
               <tr> <%--Втори ред --%>
                   <td  style="vertical-align:top; padding-left: 30px;" class="auto-style1">
                        <asp:Button ID="AddDataButtonId" runat="server" Text="Добави данни" OnClick="AddDataButtonId_Click" />
                   </td>
                   <td>

                   </td>
               </tr>
            </table>
          
        </div>
    </form>
</body>
</html>
