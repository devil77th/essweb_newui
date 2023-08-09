<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_request_medical_confirm.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_request_medical_confirm" %>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<style type="text/css">
    .tblStyle {
        width: 300px;
        height: 30px;
    }

    .modalBackground
        {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
        .modalPopup
        {
            background-color: #fff;
            border: 3px solid #ccc;
            padding: 10px;  
            width: 70%;
        }
        .noDisplay
        {
            display: none;
        }
</style>
<table style="width:100%">
        <tr>
            <td colspan="2" style="background-color:lightgray;font-size:larger;font-weight:500">
                Confirm Request Rawat Jalan</td>
            
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
            <td colspan="2" >
            <asp:Label ID="lblNamaPasien" runat="server"></asp:Label>    
            </td>
        </tr>
        
        <tr>
            <td colspan="2" style="background-color:lightgray">
                Tgl Kuitansi :              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblKuida" runat="server"></asp:Label>  
            </td>
        </tr>

        <tr>
            <td colspan="2" style="background-color:lightgray">
                Diagnosa :              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblDiagnosa" runat="server"></asp:Label>  
            </td>
        </tr>

        <tr>
            <td colspan="2" style="background-color:lightgray">
                Jumlah Klaim (Rp.) :              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblJumlahKlaim" runat="server"></asp:Label>  
            </td>
        </tr>
 
        <tr>
            <td>
                <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="cmdSubmitMedical" runat="server" Text="Submit Request" OnClick="cmdSubmitMedical_Click" />    
                <ajaxToolkit:ModalPopupExtender ID="mdlCO1" runat="server" BackgroundCssClass="modalBackground" CancelControlID=""
                PopupControlID="panelCO1" TargetControlID="lnk"></ajaxToolkit:ModalPopupExtender>
                <asp:LinkButton runat="server" ID="lnk" CssClass="noDisplay" Text="Click me..." />
            </td>
            <td>
                <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="cmdCancelMedical" runat="server" Text="Cancel Request" OnClick="cmdCancelMedical_Click" />    
            </td>
        </tr>
 
 
 
    </table>

<asp:Panel ID="panelCO1" runat="server" CssClass="modalPopup">
    <asp:UpdatePanel ID="updPanel1" runat="server" RenderMode="Inline" UpdateMode="Conditional">
        <ContentTemplate>
    <table style="width:100%">
        <tr>
            <td colspan="3" style="text-align:center">
                <asp:Label ID="lblinfo1" runat="server"></asp:Label>
            </td>
        </tr>
         <tr>
            <td colspan="3" style="text-align:center">
               <asp:Label id="lblcodeklaim1" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="text-align:center">
                <asp:Button ID="cmdClosePanel1" runat="server" Text="Close" Width="30%" OnClick="cmdClosePanel1_Click" />
            </td>
        </tr>
    </table>
    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Panel>