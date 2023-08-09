<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_request_klaim_kacamata_detail.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_request_klaim_kacamata_detail" %>
<script type="text/javascript">
    function confDelete()
    {
        return confirm("Hapus Request Klaim Kacamata ini?");
    }
</script>
<table style="width:100%">
        <tr>
            <td colspan="2" style="background-color:lightgray;font-size:larger;font-weight:500">
                Request Klaim Kacamata Detail</td>
            
        </tr>
        <tr>
            <td colspan="2" >
                <br /></td>
        </tr>
        
        <tr>
            <td colspan="2" style="background-color:lightgray">
                Claimant Detail :              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblclaimant1" runat="server"></asp:Label>  
            </td>
        </tr>
        <tr>
            <td colspan="2" style="background-color:lightgray">
                Tgl.Klaim :              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lbldateclaim1" runat="server"></asp:Label>  
            </td>
        </tr>



        <tr>
            <td colspan="2" style="background-color:lightgray">
                Frame Detail :              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblframedetail1" runat="server"></asp:Label>  
            </td>
        </tr>

        <tr>
            <td colspan="2" style="background-color:lightgray">
                Lensa Detail :              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lbllensadetail1" runat="server"></asp:Label>  
            </td>
        </tr>
        <tr>
            <td colspan="2" style="background-color:lightgray">
                Deskripsi Klaim :              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lbldescclaim1" runat="server"></asp:Label>  
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
                <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="cmdDelClaimKM" runat="server" 
                    Text="Delete Klaim Kacamata" OnClick="cmdDelClaimKM_Click" OnClientClick="if(!confDelete()) return false;" />    
            </td>
        </tr>
 
 
 
    </table>
<asp:HiddenField ID="hidMedTrx1" runat="server" />
<asp:HiddenField ID="hidAppRejDa1" runat="server" />