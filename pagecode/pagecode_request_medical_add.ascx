<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_request_medical_add.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_request_medical_add" %>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<style type="text/css">
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
            width: 500px;
        }
    </style>

<script type="text/javascript">
   
</script>

<table style="width:100%">
    <tr style="background-color:lightgray;font-weight:500">
        <td>
            Limit Medical</td>
    </tr>
    <tr>
        <td>
        <asp:Label ID="lbllimitmedical1" runat="server"></asp:Label>    
        </td>
    </tr>
    <tr>
        <td>
        <asp:Label ID="lblsisamedical1" runat="server"></asp:Label>   
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            Nama Pasien :
        </td>
    </tr>
    <tr>
        <td>
            <asp:DropDownList ID="ddlPasien1" runat="server" CssClass="form-control">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            Tanggal Kuitansi :
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="txtKuiDa1" runat="server" CssClass="form-control"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="txtKuiDa1_CalendarExtender" runat="server" 
                BehaviorID="txtKuiDa1_CalendarExtender" TargetControlID="txtKuiDa1" Format="dd-MMM-yyyy" /> 
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Font-Size="Small">Pastikan tanggal kuitansi tidak > 30 hari dari tanggal hari ini</asp:Label>    

        </td>
    </tr>

    <tr>
        <td>
            &nbsp;</td>
    </tr>

    <tr>
        <td>
            Diagnosa :</td>
    </tr>

    <tr>
        <td>
           <asp:TextBox ID="txtDiagnosa1" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
        </td>
    </tr>



    <tr>
        <td>
         <asp:Label ID="lblInfo" runat="server" Font-Size="Small">Diisi dengan jenis penyakit yang diderita (bahasa medis/non medis)</asp:Label>    
        </td>
    </tr>



    <tr>
        <td>
            &nbsp;</td>
    </tr>



    <tr>
        <td>
            Jumlah (Rp.) :</td>
    </tr>



    <tr>
        <td>
         <asp:TextBox ID="txtJumlah1" runat="server" CssClass="form-control"></asp:TextBox>   
        </td>
    </tr>



    <tr>
        <td>
            <asp:Label ID="lblInfo1" runat="server" Font-Size="Small">Diisi dengan angka saja , cth : 100000</asp:Label>
        </td>
    </tr>



    <tr>
        <td>
            &nbsp;</td>
    </tr>

     <tr>
        <td>
            <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="cmdSubmitTrxMed" runat="server" Text="Next >>" OnClick="cmdSubmitTrxMed_Click" />
           
        </td>
    </tr>


</table>
<asp:HiddenField ID="hidLimit1" runat="server" />
<asp:HiddenField ID="hidSisa1" runat="server" />
