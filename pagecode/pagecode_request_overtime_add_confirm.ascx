<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_request_overtime_add_confirm.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_request_overtime_add_confirm" %>
<table style="width:100%">
        <tr>
            <td colspan="2" style="background-color:lightgray;font-size:larger;font-weight:500">
                Confirm Request Overtime</td>
            
        </tr>
        <tr>
            <td colspan="2" >
                <br /></td>
        </tr>
        
        <tr>
            <td colspan="2" style="background-color:lightgray">
                Tgl Request Overtime :              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblDateOT" runat="server"></asp:Label>  
            </td>
        </tr>

        <tr>
            <td colspan="2" style="background-color:lightgray">
                Jam Request Overtime In - Out :              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblTimeOTIn" runat="server"></asp:Label>  
                &nbsp;&nbsp;-&nbsp;&nbsp;
                <asp:Label ID="lblTimeOTOut" runat="server"></asp:Label>  
            </td>
        </tr>
     <tr>
            <td colspan="2" style="background-color:lightgray">
                Reason Overtime :              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblReasonOT" runat="server"></asp:Label>  
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="cmdSubmitOT" runat="server" Text="Submit Request" OnClick="cmdSubmitOT_Click" />    
            </td>
            <td>
                <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="cmdCancelOT" runat="server" Text="Cancel Request" OnClick="cmdCancelOT_Click" />    
            </td>
        </tr>
 
 
 
    </table>