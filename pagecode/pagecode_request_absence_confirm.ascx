<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_request_absence_confirm.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_request_absence_confirm" %>
<table style="width:100%">
        <tr>
            <td colspan="2" style="background-color:lightgray;font-size:larger;font-weight:500">
                Confirm Request Absence</td>
            
        </tr>
        <tr>
            <td colspan="2" >
                <br /></td>
        </tr>
        
        <tr>
            <td colspan="2" style="background-color:lightgray">
                Tipe Request Absence :              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblTypeAbsence1" runat="server"></asp:Label>  
            </td>
        </tr>

        <tr>
            <td colspan="2" style="background-color:lightgray">
                Tanggal Request Absence :              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblDateAbsence1" runat="server"></asp:Label>  
            </td>
        </tr>

        <tr>
            <td colspan="2" style="background-color:lightgray">
                Jumlah Hari :              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblNumDaysAbsence1" runat="server"></asp:Label>  
            </td>
        </tr>
 
        <tr>
            <td>
                <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="cmdSubmitCICO" runat="server" Text="Submit Request" OnClick="cmdSubmitCICO_Click" />    
            </td>
            <td>
                <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="cmdCancel" runat="server" Text="Cancel Request" OnClick="cmdCancel_Click" />    
            </td>
        </tr>
    <tr>
        <td>
        &nbsp;    
        </td>
    </tr>
    <tr>
        <td>
        <asp:Label ID="lblNote" runat="server"></asp:Label>    
        </td>
    </tr>
 
 
 
    </table>
<asp:HiddenField ID="hidValTypeAbs1" runat="server" />