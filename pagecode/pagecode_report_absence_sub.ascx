<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_report_absence_sub.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_report_absence_sub" %>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<table style="width:100%">
    <tr>
        <td colspan="2">
            &nbsp;</td>
    </tr>

    <tr>
        <td style="width:30%">
           Pilih Karyawan : 
        </td>
        <td>
            <asp:DropDownList ID="ddlSubordinate" runat="server" Width="100%" CssClass="form-control"></asp:DropDownList>
        </td>
    </tr>
     

    <tr>
        <td style="width:30%">
            Bulan :</td>
        <td>
            <asp:DropDownList ID="ddlMonth" runat="server" Width="100%" CssClass="form-control">
                <asp:ListItem Text="Januari" Value="01"></asp:ListItem>
                <asp:ListItem Text="Februari" Value="02"></asp:ListItem>
                <asp:ListItem Text="Maret" Value="03"></asp:ListItem>
                <asp:ListItem Text="April" Value="04"></asp:ListItem>
                <asp:ListItem Text="Mei" Value="05"></asp:ListItem>
                <asp:ListItem Text="Juni" Value="06"></asp:ListItem>
                <asp:ListItem Text="Juli" Value="07"></asp:ListItem>
                <asp:ListItem Text="Agustus" Value="08"></asp:ListItem>
                <asp:ListItem Text="September" Value="09"></asp:ListItem>
                <asp:ListItem Text="Oktober" Value="10"></asp:ListItem>
                <asp:ListItem Text="November" Value="11"></asp:ListItem>
                <asp:ListItem Text="Desember" Value="12"></asp:ListItem>  
            </asp:DropDownList>
        </td>
    </tr>
     

    <tr>
        <td style="width:30%">
            Tahun : </td>
        <td>
            <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control" Width="100%">
            </asp:DropDownList>
            </td>
    </tr>
    <tr>
        <td></td>
        <td>
            &nbsp;</td>
    </tr>
     

    <tr>
        <td style="width:30%">
            &nbsp;</td>
        <td>
          <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="cmdSearch" runat="server" Text="Search" OnClick="cmdSearch_Click" />      
        &nbsp;</td>
    </tr>
</table>
<table style="width:100%">
<tr>
<td>   
<asp:UpdatePanel ID="updDataListCICO1" runat="server" RenderMode="Inline" UpdateMode="Conditional">
<ContentTemplate>
                    <asp:GridView ID="gvcico1" runat="server" AllowPaging="true" AutoGenerateColumns="false" PageSize="35" Width="100%"
                     EmptyDataText="No Data">
                    <PagerStyle BackColor="#284775" CssClass="GridPager" ForeColor="White" HorizontalAlign="Center" Width="12px" />
                    <Columns>
                        <asp:TemplateField HeaderText="Tgl">
                            <ItemTemplate>
                                <asp:Label ID="lbltgl1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.tgl1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Hari">
                            <ItemTemplate>
                                <asp:Label ID="lblhari1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.hari1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="WS-In">
                            <ItemTemplate>
                                <asp:Label ID="lblwsin1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.wsin1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="WS-Out">
                            <ItemTemplate>
                                <asp:Label ID="lblwsout1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.wsout1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Clock In WFO">
                            <ItemTemplate>
                                <asp:Label ID="lblciwfo" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ciwfo1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Clock Out WFO">
                            <ItemTemplate>
                                <asp:Label ID="lblcowfo" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cowfo1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Clock In WFH">
                            <ItemTemplate>
                                <asp:Label ID="lblciwfh" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ciwfh1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Clock Out WFH">
                            <ItemTemplate>
                                <asp:Label ID="lblcowfh" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cowfh1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Absence">
                            <ItemTemplate>
                                <asp:Label ID="lblabsence" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.abswfo1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Attendance">
                            <ItemTemplate>
                                <asp:Label ID="lblattendance" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.attwfo1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Request Mail Hour">
                            <ItemTemplate>
                                <asp:Label ID="lblreqmail" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.reqmailhour1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Request SAP Hour">
                            <ItemTemplate>
                                <asp:Label ID="lblreqsap" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.reqsaphour1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Request Teams Hour">
                            <ItemTemplate>
                                <asp:Label ID="lblreqteams" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.reqteamshour1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status Request Claim">
                            <ItemTemplate>
                                <asp:Label ID="lblstatusreqclaim" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.statusreqclaim1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Libur">
                            <ItemTemplate>
                                <asp:Label ID="lbllibur" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.liburwfo1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                         
                       <%-- <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:Button ID="cmdSelect1" runat="server" 
                                    CommandArgument='<%# DataBinder.Eval(Container, "DataItem.tgl1").ToString() %>'
                                     CommandName="cmdCICOSelect" Text="Select" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                    </Columns>
                </asp:GridView>
    </ContentTemplate>
    </asp:UpdatePanel>
</td>
</tr>
</table>