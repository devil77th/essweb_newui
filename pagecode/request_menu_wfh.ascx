<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="request_menu_wfh.ascx.cs" Inherits="WebApplication1.pagecode.request_menu_wfh" %>
<table style="width:100%;text-align:center">
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr style="width:50%">
        <td>
            <%--<asp:ImageButton ID="requestCICOWFH" runat="server" Width="125px" Height="125px" ImageUrl="~/img/approval_cico.png" OnClick="requestCICOWFH_Click" />--%>

            <asp:ImageButton ID="requestAbsenceWFH" runat="server" Width="125px" Height="125px" ImageUrl="~/img/approval_absence.png" OnClick="requestAbsenceWFH_Click" />

        </td>
        <td>
            <p class="x_MsoNormal">
                <b><span style="font-size: 12pt; font-family: &quot;Segoe UI&quot;,&quot;sans-serif&quot;">Informasi : </span></b>
            </p>
            <p class="x_MsoNormal">
                <b><span style="font-size:12pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;">Report absensi WFH hanya bisa diakses melalui SERA-ESS Web. </span></b>
            </p>
            <p class="x_MsoNormal">
                <b><span style="font-size:12pt; font-family:&quot;Segoe UI&quot;,&quot;sans-serif&quot;">Absensi WFH tidak muncul pada report absensi SERA ESS Skyline.</span></b></p>
        </td>
    </tr>
        <tr>
        <td>
            <%--<asp:Label ID="lblapprovalcico" runat="server" Text="CI/CO WFH" Font-Size="20px" Font-Names="Arial" ></asp:Label>--%>
            <asp:Label ID="Label1" runat="server" Text="Request CI/CO WFH" Font-Size="20px" Font-Names="Arial" ></asp:Label>
        </td>
         <td>
             &nbsp;</td>
    </tr>
        <tr>
        <td>
            &nbsp;</td>
         <td>
             &nbsp;</td>
    </tr>
     <tr style="width:50%">
        <td>
            <%--<asp:ImageButton ID="requestClaimInternet" runat="server" Width="125px" Height="125px" ImageUrl="~/img/internet.png" OnClick="requestClaimInternet_Click" />--%>

        </td>
        <td>
            &nbsp;</td>
    </tr>
        <tr>
        <td>
<%--            <asp:Label ID="Label2" runat="server" Text="Request Claim Internet WFH" Font-Size="20px" Font-Names="Arial" ></asp:Label>--%>
        </td>
         <td>
             &nbsp;</td>
    </tr>

       
</table>