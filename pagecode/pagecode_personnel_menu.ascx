<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_personnel_menu.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_personnel_menu" %>
<br />
<table style="width:100%;text-align:center">
                <tr style="height:200px;width:50%">
                    <td>
                    <asp:ImageButton ID="imgResign" runat="server" Width="125px" Height="125px" ImageUrl="~/img/resign.png" OnClick="imgResign_Click" />    
                    </td>
                    <td>
                    <%--<asp:ImageButton ID="imgWFO" runat="server" Width="125px" Height="125px" ImageUrl="~/img/wfo2.jpg" OnClick="imgWFO_Click" />--%>
                    </td>
                    
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl2" runat="server" Font-Names="Arial" Font-Size="20px" Text="Pengunduran Diri"></asp:Label>
                    </td>
                    <td>
                        <%--<asp:Label ID="lbl3" runat="server" Font-Names="Arial" Font-Size="20px" Text="WFO"></asp:Label>--%>
                    </td>
                    
                </tr>
</table>