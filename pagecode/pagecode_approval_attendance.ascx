<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_approval_attendance.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_approval_attendance" %>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<script type="text/javascript">
    function confDelete()
    {
        return confirm("Reject All Request?");
    }

    function confApproval()
    {
        return confirm("Approve All Request?");
    }
</script>
<div class="dropdown">
  <button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown">
    Menu
  </button>
  <div class="dropdown-menu">
    <a class="dropdown-item" href="#"><asp:Button ID="cmdApproveAll" runat="server" Text="Approve All"  
       OnClientClick="if(!confApproval()) return false;" OnClick="cmdApproveAll_Click" /></a>
    <a class="dropdown-item" href="#"><asp:Button ID="cmdRejectAll" runat="server" Text="Reject All" 
       OnClientClick="if(!confDelete()) return false;"  OnClick="cmdRejectAll_Click"/></a>
  </div>
</div> 
<br />
<asp:UpdatePanel ID="updDataListAttendance1" runat="server" RenderMode="Inline" UpdateMode="Conditional">
<ContentTemplate>
<asp:DataList ID="dlAttendance1" runat="server" BackColor="Gray" BorderColor="#666666"

            BorderStyle="None" BorderWidth="2px" CellPadding="3" CellSpacing="2"

            Font-Names="Verdana" Font-Size="Small" GridLines="Both" RepeatColumns="1"

            Width="100%" OnItemCommand="dlAttendance1_ItemCommand">

            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" Font-Size="Large" ForeColor="White"
                HorizontalAlign="Center" VerticalAlign="Middle" />

            <HeaderTemplate>List Request Attendance</HeaderTemplate>

            <ItemStyle BackColor="White" ForeColor="Black" BorderWidth="2px" />
            <ItemTemplate>

                <b>Nama :</b>

                <asp:Label ID="lblfullNameAttendance" runat="server" Text='<%# Eval("fullName1") %>'></asp:Label>

                <br />

                <b>Tanggal Attendance (DD/MM/YYYY) :</b>

                <asp:Label ID="lbldateAttendance1" runat="server" Text='<%# Eval("dateAttendance1") + " - " + Eval("timeFrom1") %>'></asp:Label>
                <asp:Label ID="lbldateAttendance2" runat="server" Text='<%# Eval("dateAttendance1") + " - " + Eval("timeTo1") %>'></asp:Label>
                <br />

                <b>Tipe Attendance :</b>

                <asp:Label ID="lbltypeAttendance2" runat="server" Text='<%# Eval("typeAttendance1") %>'></asp:Label>
                <br />

                <asp:HiddenField ID="lbltrxAttendance" runat="server" Value='<%# Eval("idtrxAttendance1") %>' />
                <div style="text-align:right">
                    <asp:Button ID="cmdApprove" runat="server" Text="Approve" Width="100px" CommandName="cmdApprove" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="cmdReject" runat="server" Text="Reject" Width="100px" CommandName="cmdReject" />
                </div>
            </ItemTemplate>

        </asp:DataList>
    </ContentTemplate>
    </asp:UpdatePanel>