<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_request_cico_confirm.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_request_cico_confirm" %>
<table style="width:100%">
        <tr>
            <td colspan="2" style="background-color:lightgray;font-size:larger;font-weight:500">
                Confirm Request CI/CO</td>
            
        </tr>
        <tr>
            <td colspan="2" >
                <br /></td>
        </tr>
        
        <tr>
            <td colspan="2" style="background-color:lightgray">
                Tgl Request CI/CO :              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblDateCICO" runat="server"></asp:Label>  
            </td>
        </tr>

        <tr>
            <td colspan="2" style="background-color:lightgray">
                Jam Request CI/CO :              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblTimeCICO" runat="server"></asp:Label>  
            </td>
        </tr>

        <tr>
            <td colspan="2" style="background-color:lightgray">
                Tipe Request :              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblTypeCICO" runat="server"></asp:Label>  
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
 
 
 
    </table>
