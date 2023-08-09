<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="approval_menu.ascx.cs" Inherits="WebApplication1.pagecode.approval_menu" %>
<table style="width:100%;text-align:center">
    <tr style="width:50%">
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:ImageButton ID="approvalCICO" runat="server" Width="125px" Height="125px" ImageUrl="~/img/approval_cico.png" OnClick="approvalCICO_Click" />
        </td>
        <td>
            <asp:ImageButton ID="approval_cicowfh" runat="server" Width="125px" Height="125px" ImageUrl="~/img/wfh.png" OnClick="approval_cicowfh_Click" />
        </td>
    </tr>
        <tr>
        <td>
            <asp:Label ID="lblapprovalcico" runat="server" Text="Approval CI/CO WFO" Font-Size="20px" Font-Names="Arial" ></asp:Label>
        </td>
        <td>
            <asp:Label ID="Label4" runat="server" Text="Approval CI/CO WFH" Font-Size="20px" Font-Names="Arial" ></asp:Label>
        </td>
    </tr>

        <tr>
        <td>
            &nbsp;</td>
    </tr>

      <tr>
        <td>
            <asp:ImageButton ID="approvalOvertime" runat="server" Width="125px" Height="125px" ImageUrl="~/img/overtime.png" OnClick="approvalOvertime_Click" />
        </td>
        <td>
            <asp:ImageButton ID="approvalAbsence" runat="server" Width="125px" Height="125px" ImageUrl="~/img/approval_absence.png" OnClick="approvalAbsence_Click" />
        </td>
    </tr>
    <tr>
         <td>
            <asp:Label ID="Label2" runat="server" Text="Approval Overtime" Font-Size="20px" Font-Names="Arial" ></asp:Label>
        </td>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Approval Absence" Font-Size="20px" Font-Names="Arial" ></asp:Label>
        </td>
    </tr>

        <tr>
        <td>
            &nbsp;</td>
    </tr>

      <tr>
        <td>
            <asp:ImageButton ID="approvalAttendance" runat="server" Width="125px" Height="125px" ImageUrl="~/img/attendance.png" OnClick="approvalAttendance_Click" />
        </td>
        <td>
            <asp:ImageButton ID="approvalClaimInternet" runat="server" Width="125px" Height="125px" 
                ImageUrl="~/img/internet.png" OnClick="approvalClaimInternet_Click" /></td>
    </tr>
    <tr>
         <td>
            <asp:Label ID="Label3" runat="server" Text="Approval Attendance" Font-Size="20px" Font-Names="Arial" ></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblApproveClaimInternet" runat="server" Text="Approval Claim Internet" Font-Size="20px" Font-Names="Arial" ></asp:Label></td>
    </tr>
    <tr>
         <td>
             &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
           <asp:ImageButton ID="approvalovthr" runat="server" Width="125px" Height="125px" 
               ImageUrl="~/img/overtime_hr.png" OnClick="approvalovthr_Click" />
        <td>
            <asp:ImageButton ID="deletecicowfh" runat="server" Width="125px" Height="125px" 
                ImageUrl="~/img/deleteicon.png" OnClick="deletecicowfh_Click" />
        </td>
    </tr>
    <tr>
         <td>
             <asp:Label ID="lblapprovalovthr" runat="server" Text="Approval Overtime HR" Font-Size="20px" Font-Names="Arial" ></asp:Label></td>
        <td>
            <asp:Label ID="lbldeletecicowfh" runat="server" Text="Delete CI/CO WFH" Font-Size="20px" Font-Names="Arial" ></asp:Label>
         </td>
    </tr>
</table>