<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_request_report_absence_wfh_all.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_request_report_absence_wfh_all" %>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<table style="width:100%">
    <tr>
        <td>
            Pilih Bulan :
        </td>
    </tr>
    <tr>
        <td>
            <asp:DropDownList ID="ddlMonthAbsence" runat="server" CssClass="form-control">
                <asp:ListItem Text="Januari" Value="01"></asp:ListItem>
                <asp:ListItem Text="Februari" Value="02"></asp:ListItem>
                <asp:ListItem Text="Maret" Value="03"></asp:ListItem>
                <asp:ListItem Text="April" Value="04"></asp:ListItem>
                <asp:ListItem Text="Mei" Value="05"></asp:ListItem>
                <asp:ListItem Text="Juni" Value="06"></asp:ListItem>
                <asp:ListItem Text="Juli" Value="07"></asp:ListItem>
                <asp:ListItem Text="Agustus" Value="08"></asp:ListItem>
                <asp:ListItem Text="September" Value="09"></asp:ListItem>
                <asp:ListItem Text="Oktober" Value="10"></asp:ListItem>
                <asp:ListItem Text="November" Value="11"></asp:ListItem>
                <asp:ListItem Text="Desember" Value="12"></asp:ListItem>          
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
            Pilih Tahun :
        </td>
    </tr>
    <tr>
        <td>
            <asp:DropDownList ID="ddlYearAbsence" runat="server" CssClass="form-control">
            </asp:DropDownList>

        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>


    <tr>
        <td>
         <asp:Label ID="lblInfo" runat="server" Font-Size="Large"></asp:Label>    
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
            <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="cmdReqReportAbsence" 
                runat="server" Text="Request Report Absence WFH" OnClick="cmdReqReportAbsence_Click" />
           
        </td>
    </tr>


</table>