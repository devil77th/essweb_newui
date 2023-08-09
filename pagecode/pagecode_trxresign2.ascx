<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_trxresign2.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_trxresign2" %>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<script type="text/javascript">
    function confDeleteDokResign()
    {
        return confirm("Delete Uploaded Dokumen Resign?");
    }

    function confDeleteDokDPA()
    {
        return confirm("Delete Uploaded Dokumen DPA?");
    }

    function confResign()
    {
        return confirm("Konfirmasi proses Resign?");
    }
</script>
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

<table style="width:100%;text-align:center;" class="tblstyle">
    <tr style="background-color:lightgray;font-weight:500;font-size:30px;text-align:left">
        <td colspan="6">
            Pengunduran Diri Karyawan - 2</td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr style="background-color:lightgray;font-weight:500">
        <td colspan="6" style="text-align:left" class="tdstyle">
            A. Dokumen Resign
        </td>
    </tr>
    <tr style="background-color:lightgray;font-weight:500">
        <td class="tdstyle">
            Berkas yang harus dilengkapi :
        </td>
        <td class="tdstyle">
            <table style="width:100%">
            <tr>
                <td colspan="3" style="text-align:center" class="tdstyle">
                    Karyawan yang harus mengisi :
                </td>
            </tr>
            <tr>
                <td class="tdstyle">
                    Karyawan Kontrak
                </td>
                <td class="tdstyle">
                    Karyawan Tetap
                </td>
                <td class="tdstyle">
                    Karyawan Probation
                </td>
            </tr>
            </table>
        </td>
        <td class="tdstyle">
            Keterangan
        </td>
        <td class="tdstyle">
            Format Dokumen
        </td>
        <td class="tdstyle">
            Upload
        </td>
        <td class="tdstyle">
            Dokumen Upload
        </td>
    </tr>
    <asp:UpdatePanel ID="upd_ResignLetter2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <tr>
        <td class="tdstyle">
            1. Surat Pengunduran Diri
        </td>
        <td class="tdstyle">
            <table style="width:100%">
            <tr>
                <td>
                    <img src="../img/yes.png" />
                </td>
                <td>
                     <img src="../img/yes.png" />
                </td>
                <td>
                     <img src="../img/yes.png" />
                </td>
            </tr>
            </table>
        </td>
        <td class="tdstyle">
            a. Surat pengunduran diri wajib ditanda-tangani oleh atasan langsung
            <br />
            b. Surat pengunduran diri disubmit satu bulan sebelum tanggal efektif resign (one month notice)
        </td>
        <td class="tdstyle">
           &nbsp;
        </td>
        
        <td class="tdstyle">
            <table style="width:100%;text-align:left">
            <tr>
                <td>
                    <asp:FileUpload ID="fu_ResignLetter1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                   <asp:Button ID="cmdUpload_ResignLetter1" runat="server" Text="Upload" OnClick="cmdUpload_ResignLetter1_Click" />
                </td>
            </tr>
            </table>
        </td>
        <td class="tdstyle">
             <asp:HyperLink ID="hyUpd_ResignLetter" runat="server" Target="_blank" Font-Underline="true"></asp:HyperLink>
        </td>
    </tr>
    </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="upd_ClrSheet2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
     <tr style="background-color:lightsteelblue">
        <td class="tdstyle">
            2. Clearance Sheet
        </td>
        <td class="tdstyle">
            <table style="width:100%;">
            <tr>
                <td>
                    <img src="../img/yes.png" />
                </td>
                <td>
                     <img src="../img/yes.png" />
                </td>
                <td>
                     <img src="../img/yes.png" />
                </td>
            </tr>
            </table>
        </td>
        <td class="tdstyle">
           Maksimal submit H-1 dari tanggal resign
        </td>
        <td class="tdstyle">
           <asp:HyperLink ID="hy_ClrSheet" runat="server" Target="_blank" Font-Underline="true">Form Clearance Sheet</asp:HyperLink>
        </td>
        <td class="tdstyle">
            <table style="width:100%;text-align:left">
            <tr>
                <td>
                    <asp:FileUpload ID="fu_ClrSheet1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                   <asp:Button ID="cmdUpload_ClrSheet1" runat="server" Text="Upload" OnClick="cmdUpload_ClrSheet1_Click" />
                </td>
            </tr>
            </table>
        </td>
        <td class="tdstyle">
            <asp:HyperLink ID="hyUpd_ClrSheet" runat="server" Target="_blank" Font-Underline="true"></asp:HyperLink>
        </td>
    </tr>
    </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="upd_ExitSurvey" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <tr>
        <td class="tdstyle">
           3. Exit Survey
        </td>
        <td class="tdstyle">
            <table style="width:100%">
            <tr>
                <td>
                    <img src="../img/yes.png" />
                </td>
                <td>
                     <img src="../img/yes.png" />
                </td>
                <td>
                     <img src="../img/yes.png" />
                </td>
            </tr>
            </table>
        </td>
        <td class="tdstyle">
            Lembar yang diisi oleh karyawan (bersifat rahasia) dan hanya akan diterima langsung oleh personnel HR
        </td>
        <td class="tdstyle">
          <asp:HyperLink ID="hy_ExitSurvey" runat="server" Target="_blank" Font-Underline="true" NavigateUrl="#">Form Exit Survey</asp:HyperLink>
        </td>
        <td class="tdstyle">
            <table style="width:100%;text-align:left">
            <tr>
                <td>
                    <asp:FileUpload ID="fu_ExitSurvey1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                   <asp:Button ID="cmdUpload_ExitSurvey1" runat="server" Text="Upload" OnClick="cmdUpload_ExitSurvey1_Click" />
                </td>
            </tr>
            </table>
        </td>
        <td class="tdstyle">
            <asp:HyperLink ID="hyUpd_ExitSurvey" runat="server" Target="_blank" Font-Underline="true"></asp:HyperLink>
        </td>
    </tr>
    </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="upd_FormKoperasi" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
     <tr style="background-color:lightsteelblue">
        <td class="tdstyle">
            4. Form Keluar anggota koperasi
        </td>
        <td class="tdstyle">
            <table style="width:100%;">
            <tr>
                <td>
                    <img src="../img/yes.png" />
                </td>
                <td>
                     <img src="../img/yes.png" />
                </td>
                <td>
                     <img src="../img/yes.png" />
                </td>
            </tr>
            </table>
        </td>
        <td class="tdstyle">
           Form diisi untuk proses pencairan iuran anggota koperasi yang sudah dibayarkan melalui potongan payroll setiap bulannya.
        </td>
        <td class="tdstyle">
           <asp:HyperLink ID="hy_FormKoperasi" runat="server" Target="_blank" Font-Underline="true" NavigateUrl="#">Form Keluar Anggota Kop.SERA</asp:HyperLink>
        </td>
        <td class="tdstyle">
            <table style="width:100%;text-align:left">
            <tr>
                <td>
                    <asp:FileUpload ID="fu_AnggotaKoperasi1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                   <asp:Button ID="cmdUpload_AnggotaKoperasi1" runat="server" Text="Upload" OnClick="cmdUpload_AnggotaKoperasi1_Click" />
                </td>
            </tr>
            </table>
        </td>
        <td class="tdstyle">
            <asp:HyperLink ID="hyUpd_FormKoperasi" runat="server" Target="_blank" Font-Underline="true"></asp:HyperLink>
        </td>
    </tr>
    </ContentTemplate>
    </asp:UpdatePanel>
    <tr>
        <td style="text-align:right" colspan="6">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="text-align:right" colspan="6">
            <asp:Button ID="cmdDeleteDokResign1" runat="server" Text="Delete Dokumen Resign" OnClick="cmdDeleteDokResign1_Click"
                 OnClientClick="if(!confDeleteDokResign()) return false;"/>
        </td>
    </tr>
</table>
<br />
<br />
<table style="width:100%;text-align:center;" class="tblstyle">
    <tr style="background-color:lightgray;font-weight:500">
        <td colspan="6" style="text-align:left" class="tdstyle">
            B. Dokumen DPA
        </td>
    </tr>
    <tr style="background-color:lightgray;font-weight:500">
        <td class="tdstyle">
            Berkas yang harus dilengkapi :
        </td>
        <td class="tdstyle">
            <table style="width:100%">
            <tr>
                <td colspan="3" style="text-align:center" class="tdstyle">
                    Karyawan yang harus mengisi :
                </td>
            </tr>
            <tr>
                <td class="tdstyle">
                    Karyawan Kontrak
                </td>
                <td class="tdstyle">
                    Karyawan Tetap
                </td>
                <td class="tdstyle">
                    Karyawan Probation
                </td>
            </tr>
            </table>
        </td>
        <td class="tdstyle">
            Keterangan
        </td>
        <td class="tdstyle">
            Format Dokumen
        </td>
        <td class="tdstyle">
            Upload
        </td>
        <td class="tdstyle">
            Dokumen Upload
        </td>
    </tr>
    <asp:UpdatePanel ID="upd_FormPensiun" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <tr>
        <td class="tdstyle">
            1. Klaim Manfaat Pensiun
        </td>
        <td class="tdstyle">
            <table style="width:100%">
            <tr>
                <td>
                    <img src="../img/no.png" />
                </td>
                <td>
                     <img src="../img/yes.png" />
                </td>
                <td>
                     <img src="../img/no.png" />
                </td>
            </tr>
            </table>
        </td>
        <td class="tdstyle">
            Diisi oleh karyawan yang berstatus tetap
        </td>
        <td class="tdstyle">
           <asp:HyperLink ID="hy_FormPensiun" runat="server" Target="_blank" Font-Underline="true" NavigateUrl="#">Form Klaim Pensiun</asp:HyperLink>
        </td>
        <td class="tdstyle">
            <table style="width:100%;text-align:left">
            <tr>
                <td>
                    <asp:FileUpload ID="fu_ManfaatPensiun1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                   <asp:Button ID="cmdUpload_ManfaatPensiun1" runat="server" Text="Upload" OnClick="cmdUpload_ManfaatPensiun1_Click" />
                </td>
            </tr>
            </table>
        </td>
        <td>
            <asp:HyperLink ID="hyUpd_FormPensiun" runat="server" Target="_blank" Font-Underline="true"></asp:HyperLink>
        </td>
    </tr>
    </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="upd_KTPNPWP" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
     <tr style="background-color:lightsteelblue">
        <td class="tdstyle">
            2. Fotocopy KTP dan NPWP
        </td>
        <td class="tdstyle">
            <table style="width:100%;">
            <tr>
                <td>
                    <img src="../img/no.png" />
                </td>
                <td>
                     <img src="../img/yes.png" />
                </td>
                <td>
                     <img src="../img/no.png" />
                </td>
            </tr>
            </table>
        </td>
        <td class="tdstyle">
           Bagi karyawan yang belum/tidak mempunyai NPWP maka potongan pajak atas dana DPA menjadi lebih besar 20% dari tarif normal.
        </td>
        <td class="tdstyle">
           
        </td>
        <td class="tdstyle">
            <table style="width:100%;text-align:left">
            <tr>
                <td>
                    <asp:FileUpload ID="fu_KTPNPWP" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                   <asp:Button ID="cmdUpload_KTPNPWP" runat="server" Text="Upload" OnClick="cmdUpload_KTPNPWP_Click" />
                </td>
            </tr>
            </table>
        </td>
        <td>
            <asp:HyperLink ID="hyUpd_KTPNPWP" runat="server" Target="_blank" Font-Underline="true"></asp:HyperLink>
        </td>
    </tr>
     </ContentTemplate>
     </asp:UpdatePanel>
    <asp:UpdatePanel ID="upd_KlaimDPLK" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <tr>
        <td class="tdstyle">
           3. Form DPLK (Bumiputera)
        </td>
        <td class="tdstyle">
            <table style="width:100%">
            <tr>
                <td>
                    <img src="../img/no.png" />
                </td>
                <td>
                     <img src="../img/yes.png" />
                </td>
                <td>
                     <img src="../img/no.png" />
                </td>
            </tr>
            </table>
        </td>
        <td class="tdstyle">
            Pada format dokumen terdapat tiga sheet, mohon untuk dilengkapi dan dilampirkan kembali (disatukan dalam satu folder kemudian di zip)
        </td>
        <td class="tdstyle">
           <asp:HyperLink ID="hy_KlaimDPLK" runat="server" Target="_blank" Font-Underline="true">Form DPLK</asp:HyperLink>
        </td>
        <td class="tdstyle">
            <table style="width:100%;text-align:left">
            <tr>
                <td>
                    <asp:FileUpload ID="fu_DPLK1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                   <asp:Button ID="cmdUpload_DPLK1" runat="server" Text="Upload" OnClick="cmdUpload_DPLK1_Click" />
                </td>
            </tr>
            </table>
        </td>
        <td>
            <asp:HyperLink ID="hyUpd_KlaimDPLK" runat="server" Target="_blank" Font-Underline="true"></asp:HyperLink>
        </td>
    </tr>
    </ContentTemplate>
    </asp:UpdatePanel>
     <tr style="background-color:lightsteelblue">
        <td class="tdstyle">
            4. Surat Kuasa
        </td>
        <td class="tdstyle">
            <table style="width:100%;">
            <tr>
                <td>
                    <img src="../img/no.png" />
                </td>
                <td>
                     <img src="../img/yes.png" />
                </td>
                <td>
                     <img src="../img/no.png" />
                </td>
            </tr>
            </table>
        </td>
        <td class="tdstyle">
           1. Hanya diisi oleh karyawan yang masih mempunyai kewajiban dan akan melakukan pelunasan melalui pemotongan dana DPA.
           <br />
           2.Surat kuasa dan kwitansi ditanda-tangan di atas materai 6000.
           <br />
           3. Surat kuasa tidak di attach namun wajib dikirim aslinya ke bag.Personnel HRD.
        </td>
        <td class="tdstyle">
           <asp:HyperLink ID="hy_SuratKuasa" runat="server" Target="_blank" Font-Underline="true">Surat Kuasa</asp:HyperLink>
        </td>
        <td class="tdstyle">
            <table style="width:100%">
            <tr>
                <td>
                   &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                   &nbsp;
                </td>
            </tr>
            </table>
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
     <tr>
        <td style="text-align:right" colspan="6">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="text-align:right" colspan="6">
            <asp:Button ID="cmdDeleteDokDPA" runat="server" Text="Delete Dokumen DPA" OnClick="cmdDeleteDokDPA_Click" 
                OnClientClick ="if(!confDeleteDokDPA()) return false;"/>
        </td>
    </tr>
</table>
<br />
                   <%-- <asp:GridView ID="gvhistoryresign1" runat="server" AllowPaging="false" AutoGenerateColumns="false"  Width="100%"
                     EmptyDataText="No Data">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775"  Width="100%" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" CssClass="GridPager" Width="10px" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    <Columns>
                        <asp:TemplateField HeaderText="Tanggal">
                            <ItemTemplate>
                                <asp:Label ID="lbldate1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.creda1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:Label ID="lblact1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.begda1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Keterangan">
                            <ItemTemplate>
                                <asp:Label ID="lblinfo1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.endda1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action By">
                            <ItemTemplate>
                                <asp:Label ID="lblactby1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.attname1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                </asp:GridView>--%>
<br />
<br />
<table style="width:100%">
<tr>
    <td colspan="2">
        - Dengan menekan tombol "Submit Resign" di bawah ini , maka anda akan submit data Resign ke tim SERA HR.
        <br />
        - Proses Resign akan diproses oleh tim SERA HR dan anda akan dihubungi sesegera mungkin untuk proses lebih lanjut.
        <br />
        - Anda tidak bisa mengubah tanggal Resign anda setelah anda klik tombol "Submit Resign" di bawah ini.
        <br />
        - Anda masih bisa mengubah form yang anda submit apabila ada update data dengan 
        menghapus dulu file yang dimaksud kemudian upload ulang file yang sudah terupdate.
        <br />
    </td>
</tr>
<tr>
    <td colspan="2">
        &nbsp;
    </td>
</tr>
<tr>
    <%--<td>
        <asp:Button ID="cmdCancelResign1" runat="server" Text="Cancel Resign" Width="100%" />
    </td>--%>
    <td>
        <asp:Button ID="cmdSubmitResign1" runat="server" Text="Submit Resign" Width="100%" 
            OnClick="cmdSubmitResign1_Click" OnClientClick ="if(!confResign()) return false;" />
    </td>
</tr>
</table>