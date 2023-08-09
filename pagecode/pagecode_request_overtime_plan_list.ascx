<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_request_overtime_plan_list.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_request_overtime_plan_list" %>
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
        <td colspan="2" style="text-align:center;font-size:18px;font-weight:bold">
            List Plan Overtime
        </td>
    </tr>
    <tr>
        <td>
            <table style="width:100%">
                <tr>
                    <td>
                        Bulan :
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMonOvt1" runat="server" CssClass="form-control">
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
                    <td>
                        Tahun :
                    </td>
                     <td>
                        <asp:DropDownList ID="ddlYearOvt1" runat="server" CssClass="form-control">
                        </asp:DropDownList>

                    </td>
                </tr>
                
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="cmdOvtPlanFilter" 
                         runat="server" Text="Search" OnClick="cmdOvtPlanFilter_Click" />
                    </td>
                </tr>
          

            </table>
        </td>
        </tr>
        <tr>
        <td>
            <asp:GridView ID="gvovt1" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="false" Width="100%"
                     EmptyDataText="No Data" OnDataBound="gvovt1_DataBound" OnRowCommand="gvovt1_RowCommand"
                     OnPageIndexChanging="gvovt1_PageIndexChanging">
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
                        <asp:TemplateField HeaderText="Tgl.Overtime">
                            <ItemTemplate>
                                <asp:Label ID="lbltgl1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.createdateOVT1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Time Start">
                            <ItemTemplate>
                                <asp:Label ID="lbltime1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.timeOVT1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Time End">
                            <ItemTemplate>
                                <asp:Label ID="lbltime2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.timeOVT2")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="lblstatus1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.statusOVT1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:Button ID="cmdSelect1" runat="server" 
                                    CommandArgument='<%# DataBinder.Eval(Container, "DataItem.idtrxOVT1").ToString() %>'
                                     CommandName="cmdOvtSelect" Text="Delete" OnClientClick="return confirm('Delete data?');" />
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
