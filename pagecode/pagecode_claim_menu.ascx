<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_claim_menu.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_claim_menu" %>
<table style="width:100%;text-align:center">
     <tr style="width:50%">
        <td>
            <asp:ImageButton ID="requestClaimInternet" runat="server" Width="125px" Height="125px" ImageUrl="~/img/internet.png" OnClick="requestClaimInternet_Click" />

        </td>
        <td>

            <asp:ImageButton ID="requestClaimMedical" runat="server" Width="125px" Height="125px" ImageUrl="~/img/medical.jpg" OnClick="requestClaimMedical_Click" />

         </td>
    </tr>
        <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Request Claim Internet WFH" Font-Size="20px" Font-Names="Arial" ></asp:Label>
        </td>
         <td>
            <asp:Label ID="Label3" runat="server" Text="Request Claim Rawat Jalan" Font-Size="20px" Font-Names="Arial" ></asp:Label>
            </td>
    </tr>
       
        <tr>
        <td>
            &nbsp;</td>
         <td>
             &nbsp;</td>
    </tr>

       
        <tr>
        <td>
            <asp:ImageButton ID="requestClaimKacamata" runat="server" Height="125px" ImageUrl="~/img/glasses.png" OnClick="requestClaimKacamata_Click" Width="125px" />
            </td>
         <td>
             &nbsp;</td>
    </tr>

       
        <tr>
        <td>
            <asp:Label ID="Label4" runat="server" Font-Names="Arial" Font-Size="20px" Text="Request Claim Kacamata"></asp:Label>
        </td>
         <td>
             &nbsp;</td>
    </tr>

       
</table>