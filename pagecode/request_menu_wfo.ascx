<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="request_menu_wfo.ascx.cs" Inherits="WebApplication1.pagecode.request_menu_wfo" %>
<table style="width:100%;text-align:center">
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr style="width:50%">
        <td>
            <asp:ImageButton ID="requestCICO" runat="server" Width="125px" Height="125px" ImageUrl="~/img/approval_cico.png" OnClick="requestCICO_Click" />

        </td>
        <td>
            <asp:ImageButton ID="requestAbsence" runat="server" Width="125px" Height="125px" ImageUrl="~/img/approval_absence.png" OnClick="requestAbsence_Click" />
        </td>
    </tr>
        <tr>
        <td>
            <asp:Label ID="lblapprovalcico" runat="server" Text="Request CI/CO WFO" Font-Size="20px" Font-Names="Arial" ></asp:Label>
        </td>
         <td>
            <asp:Label ID="Label1" runat="server" Text="Request Absence" Font-Size="20px" Font-Names="Arial" ></asp:Label>
        </td>
    </tr>

        <tr>
        <td>
            &nbsp;</td>
    </tr>

    <tr>
         <td>
             &nbsp;</td>
    </tr>

     <tr>
        <td>
            <asp:ImageButton ID="requestAttendance" runat="server" Width="125px" Height="125px" ImageUrl="~/img/attendance.png" OnClick="requestAttendance_Click" />
        </td>
          <td>
           <asp:ImageButton ID="requestOvertime" runat="server" Width="125px" Height="125px" ImageUrl="~/img/reqovertime.png" OnClick="requestOvertime_Click" />    
          </td>
    </tr>
    <tr>
         <td>
            <asp:Label ID="Label3" runat="server" Text="Request Attendance" Font-Size="20px" Font-Names="Arial" ></asp:Label>
        </td>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Request Overtime" Font-Size="20px" Font-Names="Arial" ></asp:Label>
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
         <%--<asp:ImageButton ID="claimmedical" runat="server" Width="125px" Height="125px" ImageUrl="~/img/medical.jpg" OnClick="claimmedical_Click"/>--%>    
         </td>
        <td>
            &nbsp;</td>
    </tr>

    
    <tr>
         <td>
     <%--       <asp:Label ID="lblclaimmedical" runat="server" Text="Klaim Rawat Jalan" Font-Size="20px" Font-Names="Arial"></asp:Label>
     --%>        </td>
        <td>
            &nbsp;</td>
    </tr>

    
    <tr>
         <td>
             &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>

    
    <tr>
         <td>
             &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>