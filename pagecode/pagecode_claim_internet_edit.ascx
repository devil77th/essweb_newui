<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_claim_internet_edit.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_claim_internet_edit" %>
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
    <tr>
        <td colspan="2" style="background-color:lightgray">
            Request Data
            <table style="width:100%">
                <tr>
                    <td style="width:50%">
                        Tanggal WFH Claim : 
                    </td>
                     <td>
                        <asp:Label ID="lblDateClaim1" runat="server"></asp:Label>
                         &nbsp;&nbsp;-&nbsp;&nbsp;
                        <asp:Label ID="lblDateClaim2" runat="server"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td style="width:50%">
                        E-Mail : 
                    </td>
                     <td>
                        <asp:TextBox id="txtMailHour" runat="server" TextMode="Number"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width:50%">
                        SAP : 
                    </td>
                     <td>
                        <asp:TextBox id="txtSAPHour" runat="server" TextMode="Number"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width:50%">
                        Microsoft Teams : 
                    </td>
                     <td>
                        <asp:TextBox id="txtMSTeams" runat="server" TextMode="Number"></asp:TextBox>
                    </td>
                </tr>
                </table>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            &nbsp;</td>
    </tr>



    <tr>
        <td colspan="2">
         <asp:Label ID="lblInfo" runat="server" Font-Size="Small">
             Penggunaan dalam satuan jam. Apabila tidak ada penggunaan , isi dengan angka 0</asp:Label>    
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
        <td style="width:50%;text-align:center">
            <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="cmdSubmitClaim" runat="server" Text="Submit & Approve Claim" 
                Width="90%" OnClick="cmdSubmitClaim_Click" />          
        </td>
        <td style="width:50%;text-align:center">
            <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="cmdCancel" runat="server" Text="Cancel" 
                Width="90%" OnClick="cmdCancel_Click" />          
        </td>
    </tr>


</table>
<asp:HiddenField ID="hidvalNRP" runat="server" />