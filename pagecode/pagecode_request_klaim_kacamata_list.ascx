<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_request_klaim_kacamata_list.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_request_klaim_kacamata_list" %>
<style type="text/css">   
          
    .GridPager a, .GridPager span
    {
        display: block;
        height: 25px;
        width: 25px;
        font-weight: bold;
        text-align: center;
        text-decoration: none;
        font-size : 16px;
    }
    .GridPager a
    {
        background-color: #5D7B9D;
        color: #969696;
        border: 1px solid #969696;
    }
    .GridPager span
    {
        background-color: #A1DCF2;
        color: #000;
        border: 1px solid #3AC0F2;
    }

</style>

<table style="width:100%">
    <tr>
        <td style="text-align:center;font-size:18px;font-weight:bold">
            List Request Klaim Kacamata
        </td>
    </tr>
    <tr>
        <td style="text-align:left;font-size:18px;font-weight:bold">
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gvkm1" runat="server" AllowPaging="true" AutoGenerateColumns="false" PageSize="10" Width="100%"
                     EmptyDataText="No Data" OnPageIndexChanging="gvkm1_PageIndexChanging" OnRowCommand="gvkm1_RowCommand">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775"  Width="100%" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" CssClass="GridPager" Width="10px" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    <Columns>
                        <asp:TemplateField HeaderText="Kode Klaim">
                            <ItemTemplate>
                                <asp:Label ID="lblkodeklaim1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.kodeklaim1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tgl.Pengajuan">
                            <ItemTemplate>
                                <asp:Label ID="lbltgl1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.createdate1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Claimant">
                            <ItemTemplate>
                                <asp:Label ID="lblclaimant1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.claimant1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Claimant Name">
                            <ItemTemplate>
                                <asp:Label ID="lblclaimantname1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.claimantname1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Frame">
                            <ItemTemplate>
                                <asp:Label ID="lblframe1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.framedesc1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Frame Amount">
                            <ItemTemplate>
                                <asp:Label ID="lblframeamount1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.frameamt1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Lensa">
                            <ItemTemplate>
                                <asp:Label ID="lbllens1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.lensdesc1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Lensa Amount">
                            <ItemTemplate>
                                <asp:Label ID="lbllensamount1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.lensaamt1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Status Pengajuan">
                            <ItemTemplate>
                                <asp:Label ID="lblstatus1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.statuspengajuan1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:Button ID="cmdSelect1" runat="server" 
                                    CommandArgument='<%# DataBinder.Eval(Container, "DataItem.id1").ToString() %>'
                                     CommandName="cmdKmSelect" Text="Select" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

        </td>
    </tr>
    <tr>
        <td style="text-align:right">
            &nbsp;</td>
    </tr>
    <tr>
        <td>
        <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="cmdAdd" runat="server" OnClick="cmdAdd_Click" 
            Width="100%" Text="Request / Add Klaim Kacamata" />    
        </td>
    </tr>
</table>
