<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_trxresign.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_trxresign" %>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<style type="text/css">
    .modalBackground
        {
            background-color: Black;
            /*filter: alpha(opacity=90);*/
            opacity: 0.8;
        }
        .modalPopup
        {
            background-color: #fff;
            border: 3px solid #ccc;
            padding: 10px;  
            width:80%;
        }
         .tblstyle 
        {
             border: 1px solid black;
             border-collapse: collapse;
        }
        .tdstyle 
        {
             border: 1px solid black;
             border-collapse: collapse;
        }
       
    .GridPager a, .GridPager span
    {
        display: block;
        height: 25px;
        width: 25px;
        font-weight: bold;
        text-align: center;
        text-decoration: none;
        font-size : 16px;
    }
    .GridPager a
    {
        background-color: #5D7B9D;
        color: #969696;
        border: 1px solid #969696;
    }
    .GridPager span
    {
        background-color: #A1DCF2;
        color: #000;
        border: 1px solid #3AC0F2;
    }

</style>

<table style="width:100%">
    <tr style="background-color:lightgray;font-weight:500;font-size:30px">
        <td>
            Pengunduran Diri Karyawan - 1</td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            Berlaku untuk karyawan yang mengundurkan diri atas inisiatif sendiri
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
   <table style="width:100%">
            <tr style="background-color:lightgray;font-weight:500">
        <td>
            Nama Karyawan
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblNama1" runat="server"></asp:Label>
        </td>
    </tr>
     <tr style="background-color:lightgray;font-weight:500">
        <td>
            NRP
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblNRP1" runat="server"></asp:Label>
        </td>
    </tr>
     <tr style="background-color:lightgray;font-weight:500">
        <td>
            Posisi
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblPosisi1" runat="server"></asp:Label>
        </td>
    </tr>
     <tr style="background-color:lightgray;font-weight:500">
        <td>
            Status Karyawan
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblStatus1" runat="server"></asp:Label>
        </td>
    </tr>
     <tr style="background-color:lightgray;font-weight:500">
        <td>
            Join Date
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblJoinDate1" runat="server"></asp:Label>
        </td>
    </tr>
     <tr style="background-color:lightgray;font-weight:500">
        <td>
            Entry Tgl.Resign
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="txtDateResign1" runat="server" CssClass="form-control"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="txtDateResign1_CalendarExtender" runat="server" BehaviorID="txtDateResign1_CalendarExtender" TargetControlID="txtDateResign1"
                Format="dd-MMM-yyyy"/>
        </td>
    </tr>
     <tr style="background-color:lightgray;font-weight:500">
        <td>
            <span style="font-size:12px">Tanggal Resign = Tanggal terakhir sebagai karyawan di SERA Group, bukan tanggal terakhir masuk kerja.</span>
        </td>
    </tr>
     <tr>
        <td>
            &nbsp;</td>
    </tr>
     <tr style="background-color:lightgray;font-weight:500">
        <td>
            HRD Confirm :</td>
    </tr>
    <tr>
        <td>
           <asp:Label ID="lblHRConfirm" runat="server"></asp:Label> 
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
    </table>
        </td>
    </tr>
   
    <tr>
        <td>
            <table style="width:100%;border:solid;border-width:2px">
                <tr>
                    <td>
                        Apabila anda ingin melakukan pengajuan pengunduran diri silahkan membaca keterangan syarat dan ketentuan yang berlaku dibawah ini :
                        <asp:HyperLink ID="hytnc1" runat="server" Font-Underline="true" NavigateUrl="#">Syarat & Ketentuan</asp:HyperLink>
                        <ajaxToolkit:ModalPopupExtender ID="hytnc1_ModalPopupExtender" runat="server" BehaviorID="hytnc1_ModalPopupExtender" 
                            TargetControlID="hytnc1" BackgroundCssClass="modalBackground" CancelControlID="CMDClose" PopupControlID="panel1">
                        </ajaxToolkit:ModalPopupExtender>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="cmdNext" runat="server" Width="100%" Text="Next" OnClick="cmdNext_Click" />
        </td>
    </tr>
</table>
<br />
<asp:UpdatePanel ID="upd_hidid1" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<asp:HiddenField ID="hidID1" runat="server" />
</ContentTemplate>
</asp:UpdatePanel>

<asp:Panel ID="panel1" runat="server" CssClass="modalPopup">
    
        <ContentTemplate>
    <table style="width:100%">
        <tr style="width:100%;background-color:lightgray;font-weight:500">
            <td>
              Syarat & Ketentuan Pengunduran Diri
            </td>
        </tr>
        <tr style="width:100%">
            <td>
               Pengunduran diri adalah pemberitahuan sukarela oleh karyawan kepada perusahaan (pemberi kerja) secara tertulis yang menyatakan bahwa karyawan bermaksud mengakhiri hubungan kerja dengan perusahaan. 
               <br /> 
               Terlampir ketentuan yang perlu diperhatikan terkait pengajuan pengunduran diri karyawan di PT Serasi Autoraya :
               <br />
               A. Ketentuan Umum :
               <br />
               a. Karyawan mengajukan surat pengunduran diri ke atasan satu bulan sebelum tanggal efektif resign (one month notice) dan submit di ESS. 
               <br />
               Dalam hal ini surat pengunduran diri adalah berkas awal yang wajib disubmit oleh karyawan di sistem.
               <br />
               b. Karyawan melengkapi seluruh berkas yang disyaratkan.
               <br />
               c. Seluruh kelengkapan berkas wajib disubmit maksimal H-1 sebelum tanggal efektif resign.
               <br />
               <br />
               B. Hak dan kewajiban karyawan resign
               <br />
               a. Uang pisah diberikan kepada karyawan sesuai dengan aturan PKB perusahaan
               <br />
               b. Dana Pensiun Astra diberikan kepada karyawan terhitung sejak berstatus tetap dengan ketentuan :
               <br />
               - Masa kepesertaan < 3 Tahun; mendapatkan pengembalian iuran pekerja dan pengembangannya
               <br />
               - Masa kepesertaan >= 3 Tahun; pengembalian iuran pekerja dan iuran perusahaan beserta pengembangannya
               <br />
               c. Perusahaan berhak melakukan pemotongan uang pisah dan dpa sebagai bagian dari pelunasan hutang karyawan sesuai dengan ketentuan yang diatur oleh perusahaan
               <br />
               d. Uang pisah dan DPA tidak akan diproses apabila seluruh berkas yang dipersyaratkan belum disubmit
               <br />
               e. Nominal atas uang pisah dan dpa yang diterima karyawan adalah gross dan akan dipotong pajak sesuai ketentuan perpajakan 
            </td>
        </tr>
    </table>
    </ContentTemplate>
  
    <br />
    <asp:Button ID="CMDClose" runat="server" Text="Close" />  
    &nbsp;&nbsp;
</asp:Panel>


