<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_overtime_edit.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_overtime_edit" %>
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
                        Waktu Overtime Mulai : 
                    </td>
                     <td>
                        <asp:Label ID="lblTimeOvt1" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width:50%">
                        Waktu Overtime Selesai : 
                    </td>
                     <td>
                        <asp:Label ID="lblTimeOvt2" runat="server"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td style="width:50%">
                        Actual Clock In - Clock Out : 
                    </td>
                     <td>
                        <asp:Label ID="lblCICO" runat="server"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td style="width:50%">
                        Alasan Overtime : 
                    </td>
                     <td>
                        <asp:Label ID="lblReasonOvertime" runat="server"></asp:Label>
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
            Waktu Overtime mulai :
        </td>
    </tr>
    <tr>
        <td colspan="2">
        <asp:TextBox ID="txtOvtDate1" runat="server" Width="200px"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="txtOvtDate1_CalendarExtender" runat="server" 
                BehaviorID="txtOvtDate1_CalendarExtender" TargetControlID="txtOvtDate1" Format="dd-MMM-yyyy" />
            &nbsp;&nbsp; - &nbsp;&nbsp;
        <asp:TextBox ID="txtOvtHour1" runat="server" Width="200px"></asp:TextBox>
        
        </td>
    </tr>
    <tr>
        <td colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="2">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td colspan="2">
            Waktu Overtime selesai :
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:TextBox ID="txtOvtDate2" runat="server" Width="200px"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="txtOvtDate2_CalendarExtender" runat="server" 
                BehaviorID="txtOvtDate2_CalendarExtender" TargetControlID="txtOvtDate2" Format="dd-MMM-yyyy" />
            &nbsp;&nbsp; - &nbsp;&nbsp;
        <asp:TextBox ID="txtOvtHour2" runat="server" Width="200px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            &nbsp;</td>
    </tr>



    <tr>
        <td colspan="2">
         <asp:Label ID="lblInfo" runat="server" Font-Size="Small">Isi Waktu Overtime dengan format HH:MM. Cth: 17:30 , 08:30</asp:Label>    
        </td>
    </tr>



    <tr>
        <td colspan="2">
            &nbsp;</td>
    </tr>



    <tr>
        <td colspan="2">
        <asp:HiddenField ID="nrpreq1" runat="server" />
        </td>
    </tr>

     <tr>
        <td style="width:50%;text-align:center">
            <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="cmdSubmitCICO" runat="server" Text="Submit & Approve Overtime" 
                Width="90%" OnClick="cmdSubmitCICO_Click" />          
        </td>
        <td style="width:50%;text-align:center">
            <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="cmdCancel" runat="server" Text="Cancel" 
                Width="90%" OnClick="cmdCancel_Click" />          
        </td>
    </tr>


</table>