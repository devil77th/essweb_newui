<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="request_menu.ascx.cs" Inherits="WebApplication1.pagecode.request_menu" %>
<table style="width:100%;text-align:center">
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr style="width:50%">
        <td>
            <asp:ImageButton ID="imgWFH" runat="server" Width="125px" Height="125px" ImageUrl="~/img/wfh.png" OnClick="imgWFH_Click" />

        </td>
        <td>
        <asp:ImageButton ID="imgreqcico" runat="server" Width="125px" Height="125px" ImageUrl="~/img/approval_cico.png" OnClick="imgreqcico_Click" />    
        </td>
    </tr>
        <tr>
        <td>
            <asp:Label ID="Label4" runat="server" Text="WFH" Font-Size="20px" Font-Names="Arial" ></asp:Label>
        </td>
         <td>
         
            <asp:Label ID="Label5" runat="server" Text="Request CI/CO WFO" Font-Size="20px" Font-Names="Arial" ></asp:Label>
         
            </td>
    </tr>
        <tr>
        <td>
            &nbsp;</td>
         <td>
             &nbsp;</td>
    </tr>
    <tr style="width:50%">
        <td>
            <asp:ImageButton ID="imgreqabsence" runat="server" Width="125px" Height="125px" ImageUrl="~/img/approval_absence.png" OnClick="imgreqabsence_Click" />

        </td>
        <td>
            <asp:ImageButton ID="imgreqattendance" runat="server" Width="125px" Height="125px" ImageUrl="~/img/attendance.png" OnClick="imgreqattendance_Click" />
        </td>
    </tr>
        <tr>
        <td>
            <asp:Label ID="lblapprovalcico" runat="server" Text="Request Absence" Font-Size="20px" Font-Names="Arial" ></asp:Label>
        </td>
         <td>
            <asp:Label ID="Label1" runat="server" Text="Request Attendance" Font-Size="20px" Font-Names="Arial" ></asp:Label>
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
            <asp:ImageButton ID="requestReportAbsence" runat="server" Width="125px" Height="125px" ImageUrl="~/img/reportabsence.png" OnClick="requestReportAbsence_Click" />
        </td>
          <td>
            <asp:ImageButton ID="requestReportAbsenceWFH" runat="server" Width="125px" Height="125px" ImageUrl="~/img/reportabsencewfh.png" OnClick="requestReportAbsenceWFH_Click" />
        </td>
    </tr>
    <tr>
         <td>
           <asp:Label ID="Label3" runat="server" Text="Report Absensi WFO" Font-Size="20px" Font-Names="Arial" ></asp:Label>
        &nbsp;</td>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Report Absensi WFH" Font-Size="20px" Font-Names="Arial" ></asp:Label>
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
    
    
    <tr>
         <td>
             &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>