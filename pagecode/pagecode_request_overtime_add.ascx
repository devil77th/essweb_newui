<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_request_overtime_add.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_request_overtime_add" %>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<style type="text/css">
    .modalBackground
        {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
        .modalPopup
        {
            background-color: #fff;
            border: 3px solid #ccc;
            padding: 10px;  
            width: 80%;
        }

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
    
    .notefontsize {
        font-size: 9pt;
    }
    
    </style>

<table style="width:100%">
    <tr>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            Select CI/CO WFO Record : &nbsp;&nbsp; 
            <asp:ImageButton ID="cmdSearchCICOWFO" runat="server" ImageUrl="~/img/search.png" Width="20px" Height="20px" OnClick="cmdSearchCICOWFO_Click" />
             <ajaxToolkit:ModalPopupExtender ID="mdlPopUpCICO" runat="server" CancelControlID="CMDClose"
                 BackgroundCssClass="modalBackground" TargetControlID="cmdSearchCICOWFO" PopupControlID="panel1">
            </ajaxToolkit:ModalPopupExtender>
        </td>
    </tr>
</table>

<table style="width:100%">
                <tr>
                    <td>
                        <asp:UpdatePanel ID="updPanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                        <asp:Label ID="lblCICOWFOin" runat="server"></asp:Label>
                        &nbsp;&nbsp;-
                        &nbsp;&nbsp;
                        <asp:Label ID="lblCICOWFOout" runat="server"></asp:Label>
                        <asp:HiddenField ID="hidtglcicowfo" runat="server" />
                        <asp:HiddenField ID="hidciwfo" runat="server" />
                        <asp:HiddenField ID="hidcowfo" runat="server" />
                        </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
</table>
<table style="width:100%">
  <tr>
        <td style="background-color:darkgray">
            Overtime Entry</td>
    </tr>
    <tr>
        <td>
            <table style="width:100%">
                <tr>
                    <td>
                        Work Schedule (In - Out) :</td>
                    <td>
                        <asp:UpdatePanel ID="updws1" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                                 <asp:Label ID="lblwsin1" runat="server"></asp:Label>
                                    &nbsp;&nbsp;-&nbsp;&nbsp;
                                 <asp:Label ID="lblwsout1" runat="server"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                       
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        Tgl.Overtime</td>
                    <td>
                    <asp:UpdatePanel ID="upd_ddl_dtOvt1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    <asp:DropDownList ID="ddl_dtOvt1" runat="server"></asp:DropDownList>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblOTin" runat="server" Text="Overtime Start"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtOTIn" runat="server" ></asp:TextBox>
                    &nbsp; </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <span class="notefontsize">Isi dengan format HH:MM. Cth: 17:30 , 08:30</span></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblOTOut" runat="server" Text="Overtime End"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtOTOut" runat="server"></asp:TextBox>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <span class="notefontsize">Isi dengan format HH:MM. Cth: 17:30 , 08:30</span>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        Reason</td>
                    <td>
                    <asp:TextBox ID="txtReason" TextMode="MultiLine" Rows="5" Width="250px" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                   <%-- <asp:UpdatePanel ID="upd_otinout1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    <asp:HiddenField ID="hidot1" runat="server" />
                    <asp:HiddenField ID="hidot2" runat="server" />
                    </ContentTemplate>
                    </asp:UpdatePanel>--%>
                    </td>
                </tr>
                </table>
        </td>
    </tr>


    <tr>
          <td style="text-align:left">
              1. Request Overtime hanya bisa dilakukan pada tanggal yang mempunyai CI/CO WFO yang lengkap (satu tanggal mempunyai Clock In dan Clock Out) dan sudah di-approve oleh atasan.<br />
            <br />
              2. Apabila tanggal WFO belum lengkap / belum di-approve atasan , maka tidak akan muncul pada waktu memilih CI/CO WFO Record.<br />
            <br />
              3. Untuk melihat laporan CI/CO WFO anda , silahkan dilihat di menu &quot;Request Report Absence&quot;.<br />
&nbsp;</td>
    </tr>



    <tr>
        <td>
            &nbsp;</td>
    </tr>



     <tr>
        <td>
            <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="cmdSubmitOT" runat="server" Text="Next >>" OnClick="cmdSubmitOT_Click"/>
           
        </td>
    </tr>
</table>



<asp:Panel ID="panel1" runat="server" CssClass="modalPopup">
    <asp:UpdatePanel ID="updPanel1" runat="server" RenderMode="Inline" UpdateMode="Conditional">
        <ContentTemplate>
    <table style="width:100%">
        <tr>
            <td>
                Bulan (MM-YYYY) :
                <asp:DropDownList ID="ddlMonth1" runat="server"></asp:DropDownList>
                &nbsp;&nbsp;
                <asp:ImageButton ID="cmdSearchData" runat="server" Height="20px" ImageUrl="~/img/search.png" OnClick="cmdSearchData_Click" />
                &nbsp;&nbsp;
                
                </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <div style="overflow-y: scroll;height: 500px;">
                <asp:GridView ID="gvcicowfo" runat="server" AllowPaging="true" AutoGenerateColumns="false" PageSize="35" Width="100%"
                     EmptyDataText="No Data" OnRowCommand="gvcicowfo_RowCommand" >
                    <PagerStyle BackColor="#284775" CssClass="GridPager" ForeColor="White" HorizontalAlign="Center" Width="12px" />
                    <Columns>
                        <asp:TemplateField HeaderText="Tgl CI/CO WFO">
                            <ItemTemplate>
                                <asp:Label ID="lblDateCICO" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.dateCICO1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="WS-In">
                            <ItemTemplate>
                                <asp:Label ID="lblwsin" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.wsin1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="WS-Out">
                            <ItemTemplate>
                                <asp:Label ID="lblwsout" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.wsout1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Clock In">
                            <ItemTemplate>
                                <asp:Label ID="lblCI" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.clockinCICO1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Clock Out">
                            <ItemTemplate>
                                <asp:Label ID="lblCO" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.clockoutCICO1")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:Button ID="cmdSelect1" runat="server" 
                                    CommandArgument='<%# DataBinder.Eval(Container, "DataItem.clockinCICO1").ToString() + "#" +
                                        DataBinder.Eval(Container, "DataItem.clockoutCICO1").ToString() + "#" +
                                        DataBinder.Eval(Container, "DataItem.wsin1").ToString() + "#" +
                                        DataBinder.Eval(Container, "DataItem.wsout1").ToString()
                                        %>'
                                     CommandName="cmdCICOSelect" Text="Select" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                </div>
            </td>
        </tr>
    </table>
   <asp:SqlDataSource ID="sqlcicowfo" runat="server" >
   </asp:SqlDataSource>
    </ContentTemplate>
  </asp:UpdatePanel>
    <br />
    <asp:Button ID="CMDClose" runat="server" Text="Close" />  
    &nbsp;&nbsp;
    
</asp:Panel>
<asp:Label ID="lblDebug" runat="server"></asp:Label>