<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_family_list_add.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_family_list_add" %>

<script type="text/javascript" src="../js/jquery-3.6.0.js"></script>
<script type="text/javascript" src="../js/select2.js"></script>
<link href="../css/select2.css" rel="stylesheet" />
<script type="text/javascript">
     $(document).ready(function () {
         $("#<%=ddlKabKotaKerja.ClientID %>").select2();
     });
</script>

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<table style="width:100%">
    <tr>
        <td style="width:50%">
            Status : 
        </td>
        <td>
            <asp:DropDownList ID="ddlType1" runat="server">
                <asp:ListItem Text="" Value=""></asp:ListItem>
                <asp:ListItem Text="Suami/Istri" Value="1"></asp:ListItem>
                <asp:ListItem Text="Anak" Value="2"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            Nama Lengkap (Sesuai KTP / Akte Kelahiran) : 
        </td>
        <td>
            <asp:TextBox ID="txtNama1" runat="server" Width="200px"></asp:TextBox>
        </td>
    </tr>
   <%-- <tr>
        <td>
            Anak ke :
        </td>
        <td>
            <asp:UpdatePanel ID="updDdlNumber1" RenderMode="Inline" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
            <asp:DropDownList ID="ddlNumber1" runat="server">
                <asp:ListItem Text="01" Value="01"></asp:ListItem>
                <asp:ListItem Text="02" Value="02"></asp:ListItem>
                <asp:ListItem Text="03" Value="03"></asp:ListItem>
                <asp:ListItem Text="04" Value="04"></asp:ListItem>
                <asp:ListItem Text="05" Value="05"></asp:ListItem>
                <asp:ListItem Text="06" Value="06"></asp:ListItem>
                <asp:ListItem Text="07" Value="07"></asp:ListItem>
                <asp:ListItem Text="08" Value="08"></asp:ListItem>
                <asp:ListItem Text="09" Value="09"></asp:ListItem>
                <asp:ListItem Text="10" Value="10"></asp:ListItem>
            </asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>--%>
    <tr>
        <td>
            NIK (Nomor Induk Kependudukan) :
        </td>
        <td>
            <asp:TextBox ID="txtNIK1" runat="server" Width="200px" MaxLength="16"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
            <span style="font-size:10px">- Sesuai dgn NIK KTP (16 angka)</span>
             <br>
              <span style="font-size:10px">- Penulisan NIK tanpa tanda spasi, titik, strip, dll</span>

        </td>
    </tr>
    
    <tr>
        <td>
            Tanggal Lahir :
        </td>
        <td>
            <asp:TextBox ID="txtTglLahir1" runat="server" Width="200px"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="txtTglLahir1_CalendarExtender" runat="server" 
                BehaviorID="txtTglLahir1_CalendarExtender" TargetControlID="txtTglLahir1" Format="dd-MMM-yyyy" />
        </td>
    </tr>
    <tr>
        <td>
            Tempat Lahir :
        </td>
        <td>
            <asp:TextBox ID="txtTempatLahir1" runat="server" Width="200px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Gender :
        </td>
        <td>
            <asp:DropDownList ID="ddlGender1" runat="server">
                <asp:ListItem Value="1" Text="Lelaki"></asp:ListItem>
                <asp:ListItem Value="2" Text="Perempuan"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            Pekerjaan :
        </td>
        <td>
            <asp:TextBox ID="txtJob1" runat="server" Width="200px"> </asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
No.HP :
        </td>
        <td>
            <asp:TextBox ID="txtHP1" runat="server" Width="200px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Alamat E-Mail Pribadi : </td>
        <td>
        <asp:TextBox ID="txtEmailPriv" runat="server" Width="250px"></asp:TextBox>    
        </td>
    </tr>
     <tr>
        <td>
            Status Pernikahan : 
        </td>
        <td>
        <asp:DropDownList ID="ddlStatusNikah" runat="server">
            <asp:ListItem Text="Kawin" Value="Kawin"></asp:ListItem>
            <asp:ListItem Text="Belum Kawin" Value="Belum Kawin"></asp:ListItem>
            <asp:ListItem Text="Cerai Mati" Value="Cerai Mati"></asp:ListItem>
            <asp:ListItem Text="Cerai Hidup" Value="Cerai Hidup"></asp:ListItem>
        </asp:DropDownList>    
        </td>
    </tr>

    <tr>
        <td>
            Customer Journey : 
        </td>
        <td>
        <asp:DropDownList ID="ddlCustJourney" runat="server">
            <asp:ListItem Text="YA" Value="YA"></asp:ListItem>
            <asp:ListItem Text="TIDAK" Value="TIDAK"></asp:ListItem>
        </asp:DropDownList>    
        &nbsp;&nbsp;<span style="font-size:10px">Diisi YA jika No.HP milik pribadi , diisi TIDAK jika No.HP milik orang lain</span>
        </td>
    </tr>
    <tr>
        <td>
            Nama Kabupaten/Kota Tempat Kerja : 
        </td>
        <td>
        <asp:DropDownList id="ddlKabKotaKerja" runat="server">
            
        </asp:DropDownList>    
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
            &nbsp;</td>
        <td>
        <asp:Button ID="cmdGetDataFromEmployee" runat="server" Text="Klik jika alamat keluarga sama dengan alamat karyawan" OnClick="cmdGetDataFromEmployee_Click" />    
        </td>
    </tr>
    <tr>
        <td colspan="2" style="background-color:lightgrey">
            Alamat Tinggal</td>
    </tr>
    <tr>
        <td>
            Alamat Tinggal :</td>
        <td>
            <asp:TextBox ID="txtAlamat1" runat="server" TextMode="MultiLine" Width="250px" Rows="5"></asp:TextBox>   
        </td>
    </tr>
    <tr>
        <td>
            Kelurahan : 
        </td>
        <td>
            <asp:TextBox ID="txtKelurahan1" runat="server" Width="250px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Kecamatan : 
        </td>
        <td>
            <asp:TextBox ID="txtKecamatan1" runat="server" Width="250px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Kabupaten / Kota : 
        </td>
        <td>
            <asp:TextBox ID="txtKabupatenKota1" runat="server" Width="250px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Propinsi : 
        </td>
        <td>
            <asp:TextBox ID="txtPropinsi1" runat="server" Width="250px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="2" style="background-color:lightgrey">
        Alamat KTP    
        </td>
    </tr>
    <tr>
        <td style="width:50%">
            Alamat KTP : 
        </td>
        <td>
            <asp:TextBox ID="txtAlamatKTP" runat="server" TextMode="MultiLine" Width="250px" Rows="5"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Kelurahan KTP : 
        </td>
        <td>
            <asp:TextBox ID="txtKelurahanKTP" runat="server" Width="250px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Kecamatan KTP : 
        </td>
        <td>
            <asp:TextBox ID="txtKecamatanKTP" runat="server" Width="250px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Kabupaten / Kota KTP : 
        </td>
        <td>
            <asp:TextBox ID="txtKabKTP" runat="server" Width="250px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Propinsi KTP : 
        </td>
        <td>
            <asp:TextBox ID="txtPropinsiKTP" runat="server" Width="250px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width:50%;background-color:yellow">
            Checklist jika mendaftar sebagai penerima vaksin gotong royong : 
        </td>
        <td style="width:50%;background-color:yellow">
        <asp:CheckBox ID="chkVac" runat="server" />    
        </td>
    </tr>
     <tr>
        <td style="width:50%;background-color:yellow">
            Apakah sudah pernah divaksin covid-19 sebelumnya : 
        </td>
        <td style="background-color:yellow">
            <asp:UpdatePanel ID="updVacBefore" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
            <asp:DropDownList ID="ddlVaccineBefore" runat="server" AutoPostBack="true" 
                OnSelectedIndexChanged="ddlVaccineBefore_SelectedIndexChanged">
                <asp:ListItem Text="Belum" Value="0"></asp:ListItem>
                <asp:ListItem Text="Sudah" Value="1"></asp:ListItem>
            </asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
  <tr>
        <td style="width:50%;background-color:yellow">
            </td>
        <td style="background-color:yellow">
        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updVaccineData">
        <ContentTemplate>
        <table>
            <tr>
                <td>
                    Penyelenggara vaksin :
                </td>
                <td>
                    <asp:DropDownList ID="ddlVaccineProvider" runat="server">
                         <asp:ListItem Text="Astra" Value="Astra"></asp:ListItem>
                         <asp:ListItem Text="Non-Astra" Value="Non-Astra"></asp:ListItem>
                    </asp:DropDownList>  
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    Vaksin ke-1 : 
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtVac1" runat="server"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="txtVac1_CalendarExtender" runat="server" BehaviorID="txtVac1_CalendarExtender" 
                        TargetControlID="txtVac1" Format="dd-MMM-yyyy" />
                </td>
            </tr>
                        <tr>
                <td>
                    Vaksin ke-2 : 
                </td>
                <td>
                    <asp:TextBox ID="txtVac2" runat="server"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="txtVac2_CalendarExtender" runat="server" BehaviorID="txtVac2_CalendarExtender" 
                        TargetControlID="txtVac2" Format="dd-MMM-yyyy" />
                </td>
            </tr>

        </table>
        </ContentTemplate>
        </asp:UpdatePanel>          
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td></td>
        <td>
            <asp:Button ID="cmdSave1" runat="server" Text="Save Data" Width="150px" OnClick="cmdSave1_Click" /> 
            </td>
    </tr>
</table>
<asp:HiddenField ID="hidID1" runat="server" />