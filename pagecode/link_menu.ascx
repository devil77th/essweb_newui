<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="link_menu.ascx.cs" Inherits="WebApplication1.pagecode.link_menu" %>
<table style="width:100%;text-align:center">
     <tr style="width:50%">
        <td>
           <%-- <asp:HyperLink ID="linkpkb" runat="server" 
                NavigateUrl="https://serasiautoraya.sharepoint.com/:b:/r/sites/ListData/Shared%20Documents/listext.pdf?csf=1&web=1&e=vay4YL"
                 Target="_blank" ImageUrl="~/img/shakehand.png" ImageWidth="125px" ImageHeight="125px" ></asp:HyperLink>--%>

            <asp:ImageButton ID="linkpkb1" runat="server" ImageUrl="~/img/shakehand.png" Width="125px" Height="125px" OnClick="linkpkb1_Click"   
            OnClientClick="window.open('https://serasiautoraya.sharepoint.com/:b:/s/HRDivisionSite/EVAa0Gj-GztEvRN9JS8mXcQBFX5x1gwglSYQhm0dQ6ogbQ?e=yH9gFI')" />
         
        </td>
        <td>

           <%-- <asp:ImageButton ID="requestClaimMedical" runat="server" Width="125px" Height="125px" 
                ImageUrl="~/img/medical.jpg" OnClick="requestClaimMedical_Click" />--%>
            
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
            <asp:Label ID="Label2" runat="server" Text="Download File PKB" Font-Size="20px" Font-Names="Arial" ></asp:Label>
        </td>
         <td>
            <%--<asp:Label ID="Label3" runat="server" Text="Request Claim Rawat Jalan" Font-Size="20px" Font-Names="Arial" ></asp:Label>--%>
            </td>
    </tr>

       
</table>