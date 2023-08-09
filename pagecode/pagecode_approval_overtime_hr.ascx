<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_approval_overtime_hr.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_approval_overtime_hr" %>
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
            <table style="width:100%">
                <tr>
                    <td>
                        NRP Requester :
                    </td>
                    <td>
                        <asp:TextBox ID="txtfilterNRPreq" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        NRP Approver :
                    </td>
                    <td>
                        <asp:TextBox ID="txtfilterNRPapp" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Tgl.Request :
                    </td>
                    <td>
                        <asp:TextBox ID="txtfilterDate1" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="txtfilterDate1_CalendarExtender" runat="server" 
                            BehaviorID="txtfilterDate1_CalendarExtender" TargetControlID="txtfilterDate1" 
                             Format="dd-MMM-yyyy"/>
                        &nbsp;&nbsp;-&nbsp;&nbsp;
                        <asp:TextBox ID="txtfilterDate2" runat="server"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="txtfilterDate2_CalendarExtender" runat="server" 
                            BehaviorID="txtfilterDate2_CalendarExtender" TargetControlID="txtfilterDate2" 
                             Format="dd-MMM-yyyy"/>
                    </td>
                </tr>
                 <tr>
                    <td>
                        Status :
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStatus1" runat="server">
                            <asp:ListItem Text="All" Value=""></asp:ListItem>
                            <asp:ListItem Text="Waiting for Approval" Value="WFSTS_01"></asp:ListItem>
                            <asp:ListItem Text="Approved" Value="WFSTS_02"></asp:ListItem>
                            <asp:ListItem Text="Rejected" Value="WFSTS_03"></asp:ListItem>
                            <asp:ListItem Text="Cancelled by User" Value="WFSTS_04"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="cmdFilter" runat="server" Text="Filter" Width="200px" OnClick="cmdFilter_Click" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
           <%-- <div class="dropdown">
              <button type="button" class="btn btn-primary dropdown-toggle" data-toggle="dropdown">
                Menu</button>
              <div class="dropdown-menu">
                <a class="dropdown-item" href="#"><asp:Button ID="cmdApproveAll" runat="server" Text="Approve All"  
                    OnClientClick="if(!confApproval()) return false;" OnClick="cmdApproveAll_Click" /></a>
                <a class="dropdown-item" href="#"><asp:Button ID="cmdRejectAll" runat="server" Text="Reject All" 
                    OnClientClick="if(!confDelete()) return false;" OnClick="cmdRejectAll_Click" /></a>
              </div>
            </div> --%>
        </td>
    </tr>
    <tr>
        <td>
            <asp:UpdatePanel ID="updDataListOvertime1" runat="server" RenderMode="Inline" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:GridView ID="gvovt1" runat="server" AllowPaging="true" AutoGenerateColumns="false" PageSize="10" 
                    Width="100%" EmptyDataText="No Data" OnPageIndexChanging="gvovt1_PageIndexChanging" 
                     OnRowCommand="gvovt1_RowCommand">
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
                        <asp:TemplateField HeaderText="NRP">
                            <ItemTemplate>
                                <asp:Label ID="lblnrp1" runat="server" 
                                 Text='<%# DataBinder.Eval(Container, "DataItem.nrp1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nama">
                            <ItemTemplate>
                                <asp:Label ID="lblnama1" runat="server" 
                                 Text='<%# DataBinder.Eval(Container, "DataItem.fullname1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tgl.Request OVT">
                            <ItemTemplate>
                                <asp:Label ID="lbltglovt1" runat="server" 
                                 Text='<%# DataBinder.Eval(Container, "DataItem.timefrom1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tgl.Approved OVT">
                            <ItemTemplate>
                                <asp:Label ID="lbltglovt2" runat="server" 
                                 Text='<%# DataBinder.Eval(Container, "DataItem.timeapp1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Approved/Rejected By">
                            <ItemTemplate>
                                <asp:Label ID="lblapprover1" runat="server" 
                                 Text='<%# DataBinder.Eval(Container, "DataItem.nameapprover1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="lblstatus1" runat="server" 
                                 Text='<%# DataBinder.Eval(Container, "DataItem.status1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:Button ID="cmdEdit1" runat="server" 
                                    CommandArgument='<%# DataBinder.Eval(Container, "DataItem.idtrx1").ToString() %>'
                                     CommandName="cmdOvtSelect" Text="Select" />
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                </Columns>
                </asp:GridView>
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
</table>

<br />
