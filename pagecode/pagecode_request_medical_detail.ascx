<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_request_medical_detail.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_request_medical_detail" %>
<script type="text/javascript">
    function confDelete()
    {
        return confirm("Hapus Request Klaim Rawat Jalan ini?");
    }
</script>
<table style="width:100%">
        <tr>
            <td colspan="2" style="background-color:lightgray;font-size:larger;font-weight:500">
                Request Medical Detail</td>
            
        </tr>
        <tr>
            <td colspan="2" >
                <br /></td>
        </tr>
        
        <tr>
            <td colspan="2" style="background-color:lightgray">
                Nama Pasien :              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblPasien1" runat="server"></asp:Label>  
            </td>
        </tr>

        <tr>
            <td colspan="2" style="background-color:lightgray">
                Diagnosa :              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblDiagnosa1" runat="server"></asp:Label>  
            </td>
        </tr>

        <tr>
            <td colspan="2" style="background-color:lightgray">
                Jumlah (Rp.) :              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblJumlah1" runat="server"></asp:Label>  
            </td>
        </tr>

        <tr>
            <td colspan="2" style="background-color:lightgray">
                Tgl-Kuitansi :              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblKuiDa1" runat="server"></asp:Label>  
            </td>
        </tr>
        <tr>
            <td colspan="2" style="background-color:lightgray">
                Status :              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblStatus1" runat="server"></asp:Label>  
            </td>
        </tr>
        <tr>
            <td colspan="2" style="background-color:lightgray">
                Alasan (apabila di-reject) :              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblReject1" runat="server"></asp:Label>  
            </td>
        </tr>
 
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
 
        <tr>
            <td colspan="2">
                <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="cmdDeleteMedTrx1" runat="server" 
                    Text="Delete Klaim Rawat Jalan" OnClick="cmdDeleteMedTrx1_Click" OnClientClick="if(!confDelete()) return false;" />    
            </td>
        </tr>
 
 
 
    </table>
<asp:HiddenField ID="hidMedTrx1" runat="server" />
<asp:HiddenField ID="hidAppRejDa1" runat="server" />