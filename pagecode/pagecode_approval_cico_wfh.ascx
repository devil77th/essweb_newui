<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_approval_cico_wfh.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_approval_cico_wfh" %>
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
    <a class="dropdown-item" href="#"><asp:Button ID="cmdApproveAll" runat="server" Text="Approve All" OnClick="cmdApproveAll_Click" 
        OnClientClick="if(!confApproval()) return false;" /></a>
    <a class="dropdown-item" href="#"><asp:Button ID="cmdRejectAll" runat="server" Text="Reject All" OnClick="cmdRejectAll_Click" 
        OnClientClick="if(!confDelete()) return false;" /></a>
  </div>
</div> 
<br />
<asp:UpdatePanel ID="updDataListCICO1" runat="server" RenderMode="Inline" UpdateMode="Conditional">
<ContentTemplate>
<asp:DataList ID="dlCICO1" runat="server" BackColor="Gray" BorderColor="#666666"

            BorderStyle="None" BorderWidth="2px" CellPadding="3" CellSpacing="2"

            Font-Names="Verdana" Font-Size="Small" GridLines="Both" RepeatColumns="1"

            Width="100%" OnItemCommand="dlCICO1_ItemCommand">

            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" Font-Size="Large" ForeColor="White"
                HorizontalAlign="Center" VerticalAlign="Middle" />

            <HeaderTemplate>List Request CI/CO WFH</HeaderTemplate>

            <ItemStyle BackColor="White" ForeColor="Black" BorderWidth="2px" />
            <ItemTemplate>

                <b>Nama :</b>

                <asp:Label ID="lblfullNameCICO" runat="server" Text='<%# Eval("fullnameCICOWFH1") %>'></asp:Label>

                <br />

                <b>Tanggal CI/CO WFH :</b>

                <asp:Label ID="lbldateCICO" runat="server" Text='<%# Eval("dateCICOWFH1") %>'></asp:Label>

                <br />

               <b>Waktu CI/CO WFH :</b>

                <asp:Label ID="lbltimeCICO" runat="server" Text=' <%# Eval("clockCICOWFH1") %>'></asp:Label>

                <br />

                <b>Tipe CI/CO WFH :</b>

                <asp:Label ID="lbltypeCICO" runat="server" Text='<%# Eval("typeCICOWFH1") %>'></asp:Label>
                <br />
                <asp:HiddenField ID="lbltrxCICO" runat="server" Value='<%# Eval("idtrxCICOWFH1") %>' />
                <div style="text-align:right">
                    <asp:Button ID="cmdApprove" runat="server" Text="Approve" Width="100px" CommandName="cmdApprove" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="cmdReject" runat="server" Text="Reject" Width="100px" CommandName="cmdReject" />
                </div>
            </ItemTemplate>

        </asp:DataList>
    </ContentTemplate>
    </asp:UpdatePanel>