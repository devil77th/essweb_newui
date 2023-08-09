<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_approval_overtime.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_approval_overtime" %>
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
        OnClientClick="if(!confDelete()) return false;" OnClick="cmdRejectAll_Click" /></a>
  </div>
</div> 
<br />
<asp:UpdatePanel ID="updDataListOvertime1" runat="server" RenderMode="Inline" UpdateMode="Conditional">
<ContentTemplate>
<asp:DataList ID="dlOvertime1" runat="server" BackColor="Gray" BorderColor="#666666"

            BorderStyle="None" BorderWidth="2px" CellPadding="3" CellSpacing="2"

            Font-Names="Verdana" Font-Size="Small" GridLines="Both" RepeatColumns="1"

            Width="100%" OnItemCommand="dlOvertime1_ItemCommand">

            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" Font-Size="Large" ForeColor="White"
                HorizontalAlign="Center" VerticalAlign="Middle" />

            <HeaderTemplate>List Request Overtime</HeaderTemplate>

            <ItemStyle BackColor="White" ForeColor="Black" BorderWidth="2px" />
            <ItemTemplate>

                <b>Nama :</b>

                <asp:Label ID="lblfullNameOVT" runat="server" Text='<%# Eval("fullnameOVT1") %>'></asp:Label>

                <br />

                <b>Tanggal Overtime (DD/MM/YYYY HH:MM) :</b>

                <asp:Label ID="lbldateOVT" runat="server" Text='<%# Eval("timeFromOVT1") + " - " + Eval("timeToOVT1") %>'></asp:Label>

                <br />

                <b>Alasan Overtime :</b>

                <asp:Label ID="lblreasonOVT" runat="server" Text='<%# Eval("reasonOVT1") %>'></asp:Label>
                <br />
                <asp:HiddenField ID="lbltrxOVT" runat="server" Value='<%# Eval("idtrxOVT1") %>' />
                <asp:HiddenField ID="lblnrp1" runat="server" Value='<%# Eval("nrp1") %>' />
                
                   
                
                <div style="text-align:right">
                    <asp:Button ID="cmdEdit" runat="server" Text="Edit" Width="100px" CommandName="cmdEdit" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="cmdApprove" runat="server" Text="Approve" Width="100px" CommandName="cmdApprove" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="cmdReject" runat="server" Text="Reject" Width="100px" CommandName="cmdReject" />
                </div>
            </ItemTemplate>

        </asp:DataList>
    </ContentTemplate>
    </asp:UpdatePanel>