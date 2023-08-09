<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_request_attendance.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_request_attendance" %>
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
            <asp:DropDownList ID="ddlTypeAttendance" runat="server" CssClass="form-control">
               <asp:ListItem Value="8000" Text="Perjalanan Dinas"></asp:ListItem>
               <asp:ListItem Value="8001" Text ="Ijin (< 1 hari kerja)"></asp:ListItem>
               <asp:ListItem Value="8002" Text ="Tugas Luar Kantor"></asp:ListItem>
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
            <asp:TextBox ID="txtDateAttendance1" runat="server" CssClass="form-control"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="txtDateAttendance1_CalendarExtender" runat="server" 
                BehaviorID="txtDateAttendance1_CalendarExtender" TargetControlID="txtDateAttendance1" Format="dd-MMM-yyyy" />
             
        </td>
        <td>
          
        </td>
    </tr>

    <tr>
        <td>
        </td>
    </tr>


    <tr>
        <td>
            &nbsp;</td>
    </tr>


    <tr>
        <td>
            Jam :</td>
    </tr>

    <tr>
        <td>
         <asp:TextBox ID="txtTimeAttendance1" runat="server" CssClass="form-control"></asp:TextBox>
            &nbsp;&nbsp;
            - 
            &nbsp;&nbsp;
             <asp:TextBox ID="txtTimeAttendance2" runat="server" CssClass="form-control"></asp:TextBox>
        &nbsp;<asp:Label ID="Label1" runat="server" Font-Size="Small">Isi dengan format HH:MM. Cth: 17:30 , 08:30</asp:Label>   
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
            <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="cmdSubmitAttendance" runat="server" Text="Next >>" 
                OnClick="cmdSubmitAttendance_Click" />
           
        </td>
    </tr>


</table>