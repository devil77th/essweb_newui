<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_employee_address_edit.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_employee_address_edit" %>
<style type="text/css">
    .auto-style1 {
        height: 26px;
    }
</style>
<script type="text/javascript" src="../js/jquery-3.6.0.js"></script>
<script type="text/javascript" src="../js/select2.js"></script>
<link href="../css/select2.css" rel="stylesheet" />
<script type="text/javascript">
     $(document).ready(function () {
         $("#<%=ddlKabKotaKerja.ClientID %>").select2();
     });
</script>

<asp:ScriptManager ID="sc1" runat="server"></asp:ScriptManager>
<table style="width:100%">
     <tr>
        <td >
           
       </td>
        <td>
           
        </td>
    </tr>
    <tr>
        <td colspan="2" style="background-color:lightgrey">
            Alamat Tinggal saat ini
        </td>
    </tr>
    <tr>
        <td style="width:50%">
            Alamat Tinggal : 
        </td>
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
            No.HP : 
        </td>
        <td>
            <asp:TextBox ID="txtNoHP" runat="server" Width="250px"></asp:TextBox>
        </td>
    </tr>
   
    <tr>
        <td>
            Alamat E-Mail Pribadi : 
        </td>
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
   
</table>
<table style="width:100%">
     <tr>
        <td>
            NIK (Nomor Induk Kependudukan) : 
        </td>
        <td>
            <asp:TextBox ID="txtNIK" runat="server" Width="250px" MaxLength="16" ></asp:TextBox>
            <br>
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
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="2" style="background-color:lightgrey">
            Nama &amp;
            Alamat KTP 
        </td>
    </tr>
      <tr>
        <td style="width:50%">
            Nama Lengkap Sesuai KTP : 
        </td>
        <td>
        <asp:TextBox ID="txtNamaKTP" runat="server" TextMode="MultiLine" Width="250px" Rows="5"></asp:TextBox> 
        &nbsp;<span style="font-size:10px">Sesuai dengan penulisan di KTP</span>
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
        <td style="width:50%;background-color:yellow">
            Checklist jika mendaftar sebagai penerima vaksin gotong royong : 
        </td>
        <td style="background-color:yellow">
        <asp:CheckBox ID="chkVac" runat="server" />    
        </td>
    </tr>

    <tr>
        <td style="width:50%;background-color:yellow">
            Apakah sudah pernah divaksin covid-19 sebelumnya : 
        </td>
        <td style="background-color:yellow">
        <asp:UpdatePanel ID="updVacBefore1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:DropDownList ID="ddlVaccineBefore" runat="server"  
                OnSelectedIndexChanged="ddlVaccineBefore_SelectedIndexChanged" AutoPostBack="true">
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
        <td>
            &nbsp;</td>
        <td>
            <asp:Button ID="cmdSave1" runat="server" Width="150px" Text="Save Data" OnClick="cmdSave1_Click" />    
        </td>
    </tr>
</table>
<asp:HiddenField ID="hidID1" runat="server" />