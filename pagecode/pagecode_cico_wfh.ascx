<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_cico_wfh.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_cico_wfh" %>
 
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
    <tr style="width:50%">
        <td>
            <asp:Label ID="lbl1" runat="server" Text="Date - Time Server : "></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblTimeServer" runat="server"></asp:Label>
        </td>
    </tr>
    <tr style="width:50%">
        <td>
            Last Activity :
        </td>
        <td>
             <asp:Label ID="lblLastActivity" runat="server"></asp:Label>
            <asp:HiddenField ID="hidLastActTime1" runat="server" />
            <asp:HiddenField ID="hidLastAct1" runat="server" />
        </td>
    </tr>
    <tr style="width:50%">
        <td colspan="2">
            <asp:Button ID="cmdRefreshTimeServer" runat="server" CssClass="btn btn-lg btn-primary btn-block"
                Text="Refresh" OnClick="cmdRefreshTimeServer_Click" Width="100%" />
        </td>
    </tr>
</table>
<br />
<br />
<table style="width:100%;text-align:center">
    <tr>
        <td>
          <asp:Button ID="cmdClockIn" runat="server" CssClass="btn btn-lg btn-primary btn-block"
                Text="Clock In" OnClick="cmdClockIn_Click" Width="100%" />
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
            <asp:Button ID="cmdClockOut" runat="server" CssClass="btn btn-lg btn-primary btn-block"
                Text="Clock Out" Width="100%"  OnClick="cmdClockOut_Click"/>
            <ajaxToolkit:ModalPopupExtender ID="mdlCO1" runat="server" BackgroundCssClass="modalBackground" CancelControlID="cmdOverwrite2"
                PopupControlID="panelCO1" TargetControlID="lnk"></ajaxToolkit:ModalPopupExtender>
            <asp:LinkButton runat="server" ID="lnk" CssClass="noDisplay" Text="Click me..." />
           
        </td>
    </tr>
    <tr>
        <td>
          
        </td>
    </tr>
    <tr>
        <td>
        <asp:Label ID="lblStatus" runat="server" Font-Size="Medium"></asp:Label>    
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="text-align:left">
            1. Absensi jenis ini hanya bisa dilakukan oleh Karyawan tertentu. Silahkan menghubungi HRD untuk mengetahui informasi lebih lanjut.<br />
            <br />
            2.Data“Clock In” yang tersimpan hanya satu kali di tanggal yang sama, sedangkan “Clock Out” adalah yang paling terakhir juga di tanggal yang sama
            Contoh : Karyawan CI WFH jam 07:30, maka ybs tidak bisa CI WFH kembali jam 08:00, jika karyawan CO WFH jam 17:00 maka ybs bisa CO WFH 
            kembali jam 18:00 (yang disimpan adalah data terakhir di tanggal yang sama).
            <br />
            <br />
            3.Jika Anda belum melakukan “Clock Out” namun sudah berganti tanggal/hari, “Clock Out” hanya bisa dilakukan melalui “Request Clock Out”.
            Contoh : Karyawan lupa CO WFH di tanggal 1 Agustus, maka data CO hanya bisa diisi melalui Request CO WFH, 
            jika tanggal 2 Agustus ybs akan absen maka langsung klik tombol “Clock In”.
            <br />
            <br />
&nbsp;</td>
    </tr>
</table>
<asp:Panel ID="panelCO1" runat="server" CssClass="modalPopup">
    <asp:UpdatePanel ID="updPanel1" runat="server" RenderMode="Inline" UpdateMode="Conditional">
        <ContentTemplate>
    <table style="width:100%">
        <tr>
            <td colspan="3">
                <asp:Label ID="lblinfo1" runat="server"></asp:Label>
            </td>
        </tr>
         <tr>
            <td colspan="3">
               
            </td>
        </tr>
        <tr>
            <td style="text-align:center">
                <asp:Button ID="cmdOverwrite1" runat="server" Text="Ya" Width="40%" OnClick="cmdOverwrite1_Click" />
            </td>
            <td style="text-align:center">
                <asp:Button ID="cmdOverwrite2" runat="server" Text="Tidak" Width="40%" />
            </td>
            <td style="text-align:center">
                <asp:Button ID="cmdRedir" runat="server" Text="Close" Width="40%" OnClick="cmdRedir_Click" />
            </td>
        </tr>
    </table>
    </ContentTemplate>
  </asp:UpdatePanel>
</asp:Panel>
<asp:HiddenField ID="hidTimeCICO1" runat="server" />
<asp:HiddenField ID="hididTrxCICO1" runat="server" />
 
    