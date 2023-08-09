<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_approval_claim_internet_wfh.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_approval_claim_internet_wfh" %>
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
<asp:UpdatePanel ID="updPanelListClaimInternet1" runat="server" RenderMode="Inline" UpdateMode="Conditional">
<ContentTemplate>
<asp:DataList ID="dlClaimInternet1" runat="server" BackColor="Gray" BorderColor="#666666"

            BorderStyle="None" BorderWidth="2px" CellPadding="3" CellSpacing="2"

            Font-Names="Verdana" Font-Size="Small" GridLines="Both" RepeatColumns="1"

            Width="100%" OnItemCommand="dlClaimInternet1_ItemCommand">

            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" Font-Size="Large" ForeColor="White"
                HorizontalAlign="Center" VerticalAlign="Middle" />

            <HeaderTemplate>List Request Claim Internet WFH</HeaderTemplate>

            <ItemStyle BackColor="White" ForeColor="Black" BorderWidth="2px" />
            <ItemTemplate>

                <b>Nama :</b>

                <asp:Label ID="lblfullName" runat="server" Text='<%# Eval("fullname1") %>'></asp:Label>

                <br />

                <b>Tanggal Claim (DD/MM/YYYY) :</b>

                <asp:Label ID="lbldateClaim" runat="server" Text='<%# Eval("dateclaim1").ToString() + " - " + Eval("dateclaim2").ToString() %>'></asp:Label>

                <br />

                <b>Penggunaan (dalam satuan jam) :</b>

                <table style="width:100%">
                    <tr>
                        <td style="width:25%">
                            E-Mail :
                        </td>
                        <td>
                             <asp:Label ID="lblMailHour" runat="server" Text='<%# Eval("mailhour1") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:25%">
                            SAP :
                        </td>
                        <td>
                             <asp:Label ID="lblSAPHour" runat="server" Text='<%# Eval("saphour1") %>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:25%">
                            Microsoft Teams :
                        </td>
                        <td>
                             <asp:Label ID="lblTeamsHour" runat="server" Text='<%# Eval("teamshour1") %>'></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                <asp:HiddenField ID="lbltrxIDClaim" runat="server" Value='<%# Eval("idtrx1") %>' />
                
                   
                
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