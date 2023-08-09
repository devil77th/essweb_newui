<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_request_absence.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_request_absence" %>
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
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<script type="text/javascript">
    function nodata1() {
        var a = document.getElementById('<%=txtDateAbs1.ClientID%>');
        a.value = "";
    }

    function nodata2() {
        var a = document.getElementById('<%=txtDateAbs2.ClientID%>');
        a.value = "";
    }

</script>



<table style="width:100%">
     <tr style="background-color:lightgray;font-weight:500">
        <td>
            Sisa Cuti :</td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gvcuti1" runat="server" AllowPaging="true" AutoGenerateColumns="false" PageSize="10" Width="100%"
                     EmptyDataText="No Data">
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
                        <asp:TemplateField HeaderText="Jenis Cuti">
                            <ItemTemplate>
                                <asp:Label ID="lbljeniscuti1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.abscode1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Berlaku Dari">
                            <ItemTemplate>
                                <asp:Label ID="lblbegda1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.begda1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Berlaku Sampai">
                            <ItemTemplate>
                                <asp:Label ID="lblendda1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.endda1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sisa Cuti">
                            <ItemTemplate>
                                <asp:Label ID="lblsisa1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.remain1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
        </td>
    </tr>
    <tr>
       <td>
           <span style="font-size:10px">* Jumlah Saldo Cuti sebelum request. Apabila jumlah cuti belum terupdate , silahkan menghubungi HRD untuk mengetahui jumlah cuti aktual</span>
       </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            Transaksi :
        </td>
    </tr>
    <tr>
        <td>
            <asp:DropDownList ID="ddlTypeAbsence" runat="server" CssClass="form-control">
            </asp:DropDownList>
<%--            <asp:SqlDataSource ID="sqlDDLTypeAbsence" runat="server" SelectCommand="EXEC abs.sp_yaw_absencetype_list"
                ConnectionString="<%$ ConnectionStrings:ESSConnStrDev %>">
            </asp:SqlDataSource>--%>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            Tanggal Mulai :
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="txtDateAbs1" runat="server" CssClass="form-control" onkeypress="nodata1();return false"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="txtDateAbs_CalendarExtender" runat="server" 
                BehaviorID="txtDateAbs1_CalendarExtender" TargetControlID="txtDateAbs1" Format="dd-MMM-yyyy" />
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>

     <tr>
        <td>
            s.d Tanggal :
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="txtDateAbs2" runat="server" CssClass="form-control" onkeypress="nodata2();return false"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" 
                BehaviorID="txtDateAbs2_CalendarExtender" TargetControlID="txtDateAbs2" Format="dd-MMM-yyyy" />
        </td>
    </tr>


    <tr>
        <td>
            &nbsp;</td>
    </tr>

     <tr>
        <td>
            <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="cmdSubmitAbs" runat="server" Text="Next >>" OnClick="cmdSubmitAbs_Click" />
           
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
    

</table>