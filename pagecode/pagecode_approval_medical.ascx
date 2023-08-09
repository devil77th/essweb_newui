<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_approval_medical.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_approval_medical" %>
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
<table style="width:100%">
    <tr>
        <td>
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width:50%">
            NRP Requester :
        </td>
        <td>
            <asp:TextBox ID="txtFilterNRP" runat="server" Width="200px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width:50%">
            Nama Pasien :
        </td>
        <td>
            <asp:TextBox ID="txtFilterNama" runat="server" Width="200px"></asp:TextBox>
        </td>
    </tr>
        <tr>
        <td style="width:50%">
            Personnel Area :
        </td>
        <td>
           <asp:UpdatePanel ID="updddlPersonnelArea" runat="server" RenderMode="Inline" UpdateMode="Conditional">
           <ContentTemplate>
           <asp:DropDownList ID="ddlPersonnelArea" runat="server" AutoPostBack="true" 
               OnSelectedIndexChanged="ddlPersonnelArea_SelectedIndexChanged"></asp:DropDownList>
           </ContentTemplate>
           </asp:UpdatePanel>
        </td>
    </tr>
        <tr>
        <td style="width:50%">
            Sub Personnel-Area :
        </td>
        <td>
            <asp:UpdatePanel ID="updddlSubPersonnelArea" runat="server" RenderMode="Block" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:DropDownList ID="ddlSubPersonnelArea" runat="server"></asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
        <tr>
        <td style="width:50%">
        </td>
        <td>
            <asp:Button ID="cmdFilter" runat="server" Width="200px" Text="Filter" OnClick="cmdFilter_Click" />
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>



</table>
<%--<div class="dropdown">
  <button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown">
    Menu
  </button>
  <div class="dropdown-menu">
    <a class="dropdown-item" href="#"><asp:Button ID="cmdApproveAll" runat="server" Text="Approve All" OnClick="cmdApproveAll_Click" 
        OnClientClick="if(!confApproval()) return false;" /></a>
    <a class="dropdown-item" href="#"><asp:Button ID="cmdRejectAll" runat="server" Text="Reject All" OnClick="cmdRejectAll_Click" 
        OnClientClick="if(!confDelete()) return false;" /></a>
  </div>
</div> --%>
<br />
<asp:UpdatePanel ID="updDataListMed1" runat="server" RenderMode="Inline" UpdateMode="Conditional">
<ContentTemplate>
<asp:DataList ID="dlMed1" runat="server" BackColor="Gray" BorderColor="#666666"

            BorderStyle="None" BorderWidth="2px" CellPadding="3" CellSpacing="2"

            Font-Names="Verdana" Font-Size="Small" GridLines="Both" RepeatColumns="1"

            Width="100%" OnItemCommand="dlMed1_ItemCommand">

            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" Font-Size="Large" ForeColor="White"
                HorizontalAlign="Center" VerticalAlign="Middle" />

            <HeaderTemplate>List Request Klaim Rawat Jalan</HeaderTemplate>

            <ItemStyle BackColor="White" ForeColor="Black" BorderWidth="2px" />
            <ItemTemplate>

                <b>Nama Requester:</b>

                <asp:Label ID="lblfullNameReqMed" runat="server" Text='<%# Eval("fullnamereq1") %>'></asp:Label>

                <br />

                <b>Tanggal Request Klaim :</b>

                <asp:Label ID="lbldateReqMed" runat="server" Text='<%# Eval("createdate1") %>'></asp:Label>

                <br />

               <b>Pasien :</b>

                <asp:Label ID="lblpasienMed" runat="server" Text=' <%# Eval("namapasien1") %>'></asp:Label>

                <br />

                <b>Diagnosa :</b>

                <asp:Label ID="lbldiagnosaMed" runat="server" Text='<%# Eval("diagnosa1") %>'></asp:Label>

                <br />

                <b>Jumlah Klaim :</b>

                <asp:Label ID="lblklaimMed" runat="server" Text='<%# Eval("amount1") %>'></asp:Label>
                <br />
                <asp:HiddenField ID="lbltrxMed" runat="server" Value='<%# Eval("idtrx1") %>' />
                <div style="text-align:right">
                    <div style="text-align:right">
                    <asp:Button ID="cmdSelect" runat="server" Text="Select" Width="100px" CommandName="cmdSelect" />
                </div>
                </div>
            </ItemTemplate>

        </asp:DataList>
    </ContentTemplate>
    </asp:UpdatePanel>
