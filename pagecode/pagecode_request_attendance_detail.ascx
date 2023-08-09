<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_request_attendance_detail.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_request_attendance_detail" %>
<script type="text/javascript">
    function confDelete()
    {
        return confirm("Hapus Request Attendance ini?");
    }
</script>
<table style="width:100%">
        <tr>
            <td colspan="2" style="background-color:lightgray;font-size:larger;font-weight:500">
                Request Attendance Detail</td>
            
        </tr>
        <tr>
            <td colspan="2" >
                <br /></td>
        </tr>
        
        <tr>
            <td colspan="2" style="background-color:lightgray">
                Tipe :              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblTipe1" runat="server"></asp:Label>  
            </td>
        </tr>
        <tr>
            <td colspan="2" style="background-color:lightgray">
                Tgl.Attendance :              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblTglAtt1" runat="server"></asp:Label>  
            </td>
        </tr>

        <tr>
            <td colspan="2" style="background-color:lightgray">
                Status Request :              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblStatus1" runat="server"></asp:Label>  
            </td>
        </tr>

        <tr>
            <td colspan="2" style="background-color:lightgray">
                Tgl.Create Request :              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblCreda1" runat="server"></asp:Label>  
            </td>
        </tr>
       
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
 
        <tr>
            <td colspan="2">
                <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="cmdDeleteAttTrx1" runat="server" 
                    Text="Delete Request Attendance" OnClientClick="if(!confDelete()) return false;" OnClick="cmdDeleteAttTrx1_Click" />    
            </td>
        </tr>
 
 
 
    </table>
<asp:HiddenField ID="hidAttTrx1" runat="server" />
<asp:HiddenField ID="hidAppRejDa1" runat="server" />