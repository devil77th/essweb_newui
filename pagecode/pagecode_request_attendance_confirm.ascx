<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_request_attendance_confirm.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_request_attendance_confirm" %>
<table style="width:100%">
        <tr>
            <td colspan="2" style="background-color:lightgray;font-size:larger;font-weight:500">
                Confirm Request Attendance</td>
            
        </tr>
        <tr>
            <td colspan="2" >
                <br /></td>
        </tr>
        
        <tr>
            <td colspan="2" style="background-color:lightgray">
                Tgl Request Attendance :              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblDateAttendance" runat="server"></asp:Label>  
            </td>
        </tr>

        <tr>
            <td colspan="2" style="background-color:lightgray">
                Jam Request Attendance Mulai :              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblTimeAttendance1" runat="server"></asp:Label>  
            </td>
        </tr>

        <tr>
            <td colspan="2" style="background-color:lightgray">
                Jam Request Attendance Selesai :              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblTimeAttendance2" runat="server"></asp:Label>  
            </td>
        </tr>

        <tr>
            <td colspan="2" style="background-color:lightgray">
                Tipe Request Attendance :              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblTypeAttendance" runat="server"></asp:Label>  
            </td>
        </tr>
 
        <tr>
            <td>
                <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="cmdSubmitAttendance" runat="server" Text="Submit Request" OnClick="cmdSubmitAttendance_Click" />    
            </td>
            <td>
                <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="cmdCancel" runat="server" Text="Cancel Request" OnClick="cmdCancel_Click" />    
            </td>
        </tr>
 
 
 
    </table>
                <asp:HiddenField ID="hid1" runat="server" />
