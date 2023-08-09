<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_request_cico_wfh_detail.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_request_cico_wfh_detail" %>
<script type="text/javascript">
    function confDelete()
    {
        return confirm("Hapus Request CI/CO WFH ini?");
    }
</script>
<table style="width:100%">
        <tr>
            <td colspan="2" style="background-color:lightgray;font-size:larger;font-weight:500">
                Request CI/CO WFH Detail</td>
            
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
                Tipe Submit :              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblTipeSubmit1" runat="server"></asp:Label>  
            </td>
        </tr>

        <tr>
            <td colspan="2" style="background-color:lightgray">
                Waktu Request CI/CO WFH :              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblTime1" runat="server"></asp:Label>  
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
            <td colspan="2">
                &nbsp;</td>
        </tr>
 
        <tr>
            <td colspan="2">
                <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="cmdDeleteCICOWFHTrx1" runat="server" 
                    Text="Delete Request CI/CO WFH" OnClientClick="if(!confDelete()) return false;" OnClick="cmdDeleteCICOWFHTrx1_Click" />    
            </td>
        </tr>
 
 
 
    </table>
<asp:HiddenField ID="hidCICOTrx1" runat="server" />
<asp:HiddenField ID="hidAppRejDa1" runat="server" />