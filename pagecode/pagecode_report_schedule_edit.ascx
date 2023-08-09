<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_report_schedule_edit.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_report_schedule_edit" %>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<table style="width:100%">
     <tr>
        <td colspan="2">
            Tanggal :
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Label ID="lbldate1" runat="server"></asp:Label>
        </td>
    </tr>

    <tr>
        <td colspan="2">
            Absensi :
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:DropDownList ID="ddlTypeCICO" runat="server" CssClass="form-control">
                <asp:ListItem Text="WFO (Work From Office)" Value="WFO"></asp:ListItem>
                <asp:ListItem Text="WFH (Work From Home)" Value="WFH"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            &nbsp;
        </td>
    </tr>
   
    <tr>
        <td colspan="2">
        <asp:LinkButton ID="lbChange" runat="server" OnClick="lbChange_Click">Request Change Schedule</asp:LinkButton>
        </td>
    </tr>



    <tr>
        <td colspan="2">
            &nbsp;</td>
    </tr>

     <tr>
        <td>
            <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="cmdSubmit" runat="server" Text="Save" 
                OnClick="cmdSubmit_Click"  />
        </td>
         <td>
            <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="cmdCancel" runat="server" Text="Cancel" 
                OnClick="cmdCancel_Click" />    
         </td>
    </tr>


     <tr>
        <td colspan="2">
            &nbsp;</td>
    </tr>


     <tr>
        <td colspan="2">
        <asp:Label ID="lblStatus" runat="server"></asp:Label>
        <asp:HiddenField ID="lblnrp" runat="server" />
        </td>
    </tr>


</table>