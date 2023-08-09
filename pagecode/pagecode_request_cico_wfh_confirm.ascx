<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_request_cico_wfh_confirm.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_request_cico_wfh_confirm" %>
<table style="width:100%">
        <tr>
            <td colspan="2" style="background-color:lightgray;font-size:larger;font-weight:500">
                Confirm Request CI/CO - WFH</td>
            
        </tr>
        <tr>
            <td colspan="2" >
                <br /></td>
        </tr>
        
        <tr>
            <td colspan="2" style="background-color:lightgray">
                Tgl Request CI/CO WFH :              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblDateCICOWFH" runat="server"></asp:Label>  
            </td>
        </tr>

        <tr>
            <td colspan="2" style="background-color:lightgray">
                Jam Request CI/CO WFH :              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblTimeCICOWFH" runat="server"></asp:Label>  
            </td>
        </tr>

        <tr>
            <td colspan="2" style="background-color:lightgray">
                Tipe Request :              
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblTypeCICOWFH" runat="server"></asp:Label>  
            </td>
        </tr>
 
        <tr>
            <td>
                <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="cmdSubmitCICOWFH" runat="server" Text="Submit Request" OnClick="cmdSubmitCICOWFH_Click" />    
            </td>
            <td>
                <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="cmdCancelWFH" runat="server" Text="Cancel Request" OnClick="cmdCancelWFH_Click" />    
            </td>
        </tr>
 
 
 
    </table>