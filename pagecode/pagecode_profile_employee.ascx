<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_profile_employee.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_profile_employee" %>
<table style="width:100%">
    <tr>
        <td style="width:50%">
            Nama :
        </td>
        <td>
            <asp:Label ID="lblNama" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            E-Mail :
        </td>
        <td>
            <asp:Label ID="lblEmail" runat="server"></asp:Label>
        </td>
    </tr>
     <tr>
        <td>
            &nbsp;</td>
        <td>
        <asp:Button ID="cmdEditAlamat" runat="server" Text="Data Karyawan" OnClick="cmdEditAlamat_Click" />
        &nbsp;&nbsp;
        <asp:Button ID="cmdEditKeluarga" runat="server" Text="Data Keluarga" OnClick="cmdEditKeluarga_Click" />
        </td>
    </tr>
</table>