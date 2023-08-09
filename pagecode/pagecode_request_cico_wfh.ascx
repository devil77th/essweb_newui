<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_request_cico_wfh.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_request_cico_wfh" %>
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
        <td>
            Transaksi :
        </td>
    </tr>
    <tr>
        <td>
            <asp:DropDownList ID="ddlTypeCICOWFH" runat="server" CssClass="form-control">
                <asp:ListItem Text="WFH - Clock In" Value="TRXCC_01"></asp:ListItem>
                <asp:ListItem Text="WFH - Clock Out" Value="TRXCC_02"></asp:ListItem>
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
            Tanggal :
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="txtDateCICOWFH" runat="server" CssClass="form-control"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="txtDateCICO_CalendarExtender" runat="server" 
                BehaviorID="txtDateCICO_CalendarExtender" TargetControlID="txtDateCICOWFH" Format="dd-MMM-yyyy" />
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>

    <tr>
        <td>
            Waktu :</td>
    </tr>

    <tr>
        <td>
           <asp:TextBox ID="txtTimeCICO" runat="server" CssClass="form-control"></asp:TextBox>
        </td>
    </tr>



    <tr>
        <td>
         <asp:Label ID="lblInfo" runat="server" Font-Size="Small">Isi dengan format HH:MM. Cth: 17:30 , 08:30</asp:Label>    
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
            <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="cmdSubmitCICOWFH" runat="server" Text="Next >>"
                 OnClick="cmdSubmitCICOWFH_Click"/>
           
        </td>
    </tr>


</table>