<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_family_list.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_family_list" %>

<table style="width:100%">
    <tr>
        <td>
            <asp:GridView ID="gvfamily1" runat="server" AllowPaging="true" AutoGenerateColumns="false" PageSize="35" Width="100%"
                     EmptyDataText="No Data" OnRowCommand="gvfamily1_RowCommand">
                    <PagerStyle BackColor="#284775" CssClass="GridPager" ForeColor="White" HorizontalAlign="Center" Width="12px" />
                    <Columns>
                        <asp:TemplateField HeaderText="Nama">
                            <ItemTemplate>
                                <asp:Label ID="lblnama1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.nama1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="lblstatus1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.status1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tempat Lahir">
                            <ItemTemplate>
                                <asp:Label ID="lblplacebirth1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.tempatlahir1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tgl.Lahir">
                            <ItemTemplate>
                                <asp:Label ID="lbldatebirth1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.tgllahir1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Jenis Kelamin">
                            <ItemTemplate>
                                <asp:Label ID="lbljeniskelamin1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.jeniskelamin1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>                        
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:Button ID="cmdSelect1" runat="server" 
                                    CommandArgument='<%# DataBinder.Eval(Container, "DataItem.idfamily1").ToString() %>'
                                     CommandName="cmdFamilySelect" Text="Select" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

        </td>
    </tr>
    <tr>
        <td style="text-align:right">
            <asp:ImageButton ID="cmdAdd1" runat="server" ImageUrl="~/img/add.png" OnClick="cmdAdd1_Click" />
        </td>
    </tr>
</table>

