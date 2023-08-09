<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_request_claim_internet_wfh_confirm.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_request_claim_internet_wfh_confirm" %>
<table style="width:100%">
        <tr>
            <td colspan="2" style="background-color:lightgray;font-size:larger;font-weight:500">
                Confirm Request Claim Internet WFH</td>
            
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
                <asp:Label ID="lblDateCICOWFHin" runat="server"></asp:Label> 
                &nbsp;&nbsp;-&nbsp;&nbsp;
                 <asp:Label ID="lblDateCICOWFHout" runat="server"></asp:Label> 
            </td>
        </tr>

        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>

        <tr>
            <td colspan="2" style="background-color:lightgray">
                Penggunaan</td>
        </tr>

        <tr>
            <td colspan="2">
                <asp:Label ID="lblEmail1" runat="server" Text="E-Mail :"></asp:Label>  
                &nbsp;&nbsp; <asp:Label ID="lblEmailHour" runat="server"></asp:Label>
            </td>
        </tr>

        <tr>
            <td colspan="2">
                <asp:Label ID="Label1" runat="server" Text="SAP :"></asp:Label>  
                &nbsp;&nbsp; <asp:Label ID="lblSAPHour" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label2" runat="server" Text="Microsoft Teams :"></asp:Label>  
                &nbsp;&nbsp; <asp:Label ID="lblTeamsHour" runat="server"></asp:Label>
            </td>
        </tr>
 
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
 
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
 
        <tr>
            <td>
                <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="cmdSubmitClaimInternet" runat="server" Text="Submit Request" OnClick="cmdSubmitClaimInternet_Click" />    
            </td>
            <td>
                <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="cmdCancel" runat="server" Text="Cancel Request" OnClick="cmdCancel_Click" />    
            </td>
        </tr>
 
 
 
    </table>