<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_request_claim_internet_wfh.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_request_claim_internet_wfh" %>
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

<script type="text/javascript">
   
</script>

<table style="width:100%">
    <tr>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            Select CI/CO WFH Record : &nbsp;&nbsp; 
            <asp:ImageButton ID="cmdSearchCICOWFH" runat="server" ImageUrl="~/img/search.png" Width="20px" Height="20px" OnClick="cmdSearchCICOWFH_Click" />
             <ajaxToolkit:ModalPopupExtender ID="mdlPopUpCICO" runat="server" CancelControlID="CMDClose"
                 BackgroundCssClass="modalBackground" TargetControlID="cmdSearchCICOWFH" PopupControlID="panel1">
            </ajaxToolkit:ModalPopupExtender>
        </td>
    </tr>
    <tr>
        <td>
            <table style="width:100%">
                <tr>
                    <td>
                        <asp:UpdatePanel ID="updPanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                        <asp:Label ID="lblCICOWFHin" runat="server"></asp:Label>
                        &nbsp;&nbsp;-
                        &nbsp;&nbsp;
                        <asp:Label ID="lblCICOWFHout" runat="server"></asp:Label>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        
                        <asp:UpdatePanel ID="updPanel3" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                Lama Jam Kerja :  <asp:Label ID="lblWorkHour" runat="server"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                       
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="background-color:darkgray">
            <span>Penggunaan Akses (Dalam Jam)</span></td>
    </tr>
    <tr>
        <td>
            <table style="width:100%">
                <tr>
                    <td>
                        <asp:Label ID="lblEmail" runat="server" Text="E-Mail"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmailHour" runat="server" TextMode="Number" Text="0"></asp:TextBox>
                    &nbsp; </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <span class="notefontsize">Tidak dapat input dalam bentuk pecahan</span></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSAP" runat="server" Text="SAP"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSAPHour" runat="server" TextMode="Number" Text="0"></asp:TextBox>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <span class="notefontsize">Tidak dapat input dalam bentuk pecahan</span>
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
                        <asp:Label ID="lblMSTeams" runat="server" Text="Microsoft Teams"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTeamsHour" runat="server" TextMode="Number" Text="0"></asp:TextBox>
                        &nbsp; 
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <span class="notefontsize">Tidak dapat input dalam bentuk pecahan</span>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            Note : <br />
            - Hanya isi dengan angka.
            <br />
            - Apabila tidak ada penggunaan , isi dengan angka 0</td>
    </tr>



    <tr>
        <td>
            &nbsp;</td>
    </tr>



    <tr>
          <td style="text-align:left">
              1. Claim Usage Internet hanya bisa dilakukan pada tanggal yang mempunyai CI/CO WFH yang lengkap (satu tanggal mempunyai Clock In dan Clock Out).<br />
            <br />
              2. Apabila tanggal WFH belum lengkap , maka tidak akan muncul pada waktu memilih CI/CO WFH Record. Silahkan melakukan Request CI/CO WFH terlebih dahulu sebelum melakukan Claim Usage Internet.<br />
            <br />
              3. Untuk melihat laporan CI/CO WFH anda , silahkan dilihat di menu &quot;Request Report Absence WFH&quot;.<br />
&nbsp;</td>
    </tr>



    <tr>
        <td>
            &nbsp;</td>
    </tr>



     <tr>
        <td>
            <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="cmdSubmitCICO" runat="server" Text="Next >>" OnClick="cmdSubmitCICO_Click"/>
           
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
                <asp:GridView ID="gvcicowfh" runat="server" AllowPaging="true" AutoGenerateColumns="false" PageSize="35" Width="100%"
                     EmptyDataText="No Data" OnRowCommand="gvcicowfh_RowCommand" >
                    <PagerStyle BackColor="#284775" CssClass="GridPager" ForeColor="White" HorizontalAlign="Center" Width="12px" />
                    <Columns>
                        <asp:TemplateField HeaderText="Tgl CI/CO WFH">
                            <ItemTemplate>
                                <asp:Label ID="lblDateCICO" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.dateCICO1")%>' />
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
                                    CommandArgument='<%# DataBinder.Eval(Container, "DataItem.dateCICO1").ToString() + " " +
                                        DataBinder.Eval(Container, "DataItem.clockinCICO1").ToString() + "#" +
                                        DataBinder.Eval(Container, "DataItem.dateCICO1").ToString() + " " +
                                        DataBinder.Eval(Container, "DataItem.clockoutCICO1").ToString()
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
   <asp:SqlDataSource ID="sqlcicowfh" runat="server">
   </asp:SqlDataSource>
    </ContentTemplate>
  </asp:UpdatePanel>
    <br />
    <asp:Button ID="CMDClose" runat="server" Text="Close" />  
    &nbsp;&nbsp;
    
</asp:Panel>
<asp:Label ID="lblDebug" runat="server"></asp:Label>