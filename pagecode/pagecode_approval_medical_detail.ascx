<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_approval_medical_detail.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_approval_medical_detail" %>
<table style="width:100%">
        <tr>
            <td style="background-color:lightgray;font-size:larger;font-weight:500">
                Request Medical Detail</td>
            
        </tr>
        <tr>
            <td >
                <br /></td>
        </tr>
        
        <tr>
            <td style="background-color:lightgray" >
                Nama Requester :</td>
        </tr>
        
        <tr>
            <td >
            <asp:Label ID="lblRequester" runat="server"></asp:Label>    
            </td>
        </tr>
        
        <tr>
            <td style="background-color:lightgray">
                Nama Pasien :              
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPasien1" runat="server"></asp:Label>  
            </td>
        </tr>

        <tr>
            <td style="background-color:lightgray">
                Diagnosa :              
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDiagnosa1" runat="server"></asp:Label>  
            </td>
        </tr>

        <tr>
            <td style="background-color:lightgray">
                Jumlah (Rp.) :              
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblJumlah1" runat="server"></asp:Label>  
            </td>
        </tr>

        <tr>
            <td style="background-color:lightgray">
                Tgl Kuitansi :              
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblKuiDa1" runat="server"></asp:Label>  
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="background-color:lightgray">
                Status :              
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                    <asp:ListItem Text="" Value=""></asp:ListItem>
                    <asp:ListItem Text="Approve" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Reject" Value="0"></asp:ListItem>
                </asp:DropDownList>  
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="background-color:lightgray">
                Alasan (apabila di-reject) :              
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtReject" runat="server" TextMode="MultiLine" Rows="5" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
 
        <tr>
            <td>
                &nbsp;</td>
        </tr>
 
        <tr>
            <td>
                <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="cmdSubmit" runat="server" 
                    Text="Submit Data" OnClick="cmdSubmit_Click" />    
            </td>
        </tr>
 
 
 
    </table>
<asp:HiddenField ID="hidMedTrx1" runat="server" />
<asp:HiddenField ID="hidAppRejDa1" runat="server" />
<asp:HiddenField ID="hidAppRejDa2" runat="server" />
<asp:HiddenField id="hidStepID1" runat="server" />