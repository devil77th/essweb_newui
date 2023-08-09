<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_user_profile1.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_user_profile1" %>
<asp:ScriptManager runat="server" ID="sc1"></asp:ScriptManager>
<style type="text/css">
            body
            {
                font-family: Verdana;
                font-size: 14px;
            }
            /* Accordion */
            .accordionHeader
            {
                border: 1px solid #2F4F4F;
                color: white;
                background-color: #2E4d7B;
                font-family: Arial, Sans-Serif;
                font-size: 12px;
                font-weight: bold;
                padding: 5px;
                margin-top: 5px;
                cursor: pointer;
            }
 
            #master_content .accordionHeader a
            {
                color: #FFFFFF;
                background: none;
                text-decoration: none;
            }
 
                #master_content .accordionHeader a:hover
                {
                    background: none;
                    text-decoration: underline;
                }
 
            .accordionHeaderSelected
            {
                border: 1px solid #2F4F4F;
                color: white;
                background-color: #5078B3;
                font-family: Arial, Sans-Serif;
                font-size: 12px;
                font-weight: bold;
                padding: 5px;
                margin-top: 5px;
                cursor: pointer;
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
        </style>
<table style="width:100%">
    <tr>
        <td style="text-align:center;background-color:#0e1a40;">
            <asp:ImageButton ID="imgProfile1" runat="server" Width="125px" Height="125px" />
        </td>
    </tr>
    <tr>    
        <td style="text-align:center;background-color:#0e1a40;">
            <asp:Label ID="lblFullname" runat="server" ForeColor="White" Font-Size="20px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align:center;background-color:#0e1a40;">
            <asp:Label ID="lblEmail" runat="server" ForeColor="White" Font-Size="20px" />
        </td>
    </tr>
        <tr>
        <td style="text-align:center;background-color:#0e1a40;">
<%--            <asp:hyperlink ID="lblLinkUpdateData" runat="server" ForeColor="White" Font-Underline="true" 
                Font-Size="20px" Text="Update Data Karyawan & Keluarga untuk Vaksin" 
                 NavigateUrl="~/page/profile_employee.aspx"/>--%>
        </td>
    </tr>
    <tr>
         <td>
            Jika ada perubahan data , silahkan mengajukan perubahannya melalui ESS Skyline / Sharepoint.
        </td>
    </tr>

    <tr>
        
        <td>
           <ajaxtoolkit:accordion id="acc1" runat="server" selectedindex="0" 
               headercssclass="accordionHeader" headerselectedcssclass="accordionHeaderSelected" contentcssclass="accordionContent" 
               fadetransitions="false" framespersecond="40" 
               transitionduration="250" AutoSize="none" requireopenedpane="false" suppressheaderpostbacks="true" width="100%">
                 <panes>
                   
                     <ajaxtoolkit:accordionpane id="AccordionPanePersonalData" runat="server">
                         <header>
                             <%--//--- Heading -----%>
                             <span class="accordionLink">Personal Data</span>
                         </header>
                         <%--//--- Content -----%>
                         <content>
                             <asp:DataList ID="dlPersonalData" runat="server" Width="100%">
                                  <ItemStyle BackColor="White" ForeColor="Black" BorderWidth="2px" />
                                        <ItemTemplate>

                                            <b>NRP :</b>
                                            <asp:Label ID="lblNRP1" runat="server" Text='<%# Eval("nrp1") %>'></asp:Label>
                                            <br />
                                            
                                            <b>Nama Karyawan :</b>
                                            <asp:Label ID="lblfullname1" runat="server" Text='<%# Eval("fullname1") %>'></asp:Label>
                                            <br />

                                           <b>Tgl.Lahir :</b>

                                            <asp:Label ID="lblbirthdate1" runat="server" Text=' <%# Eval("birthdate1") %>'></asp:Label>

                                            <br />

                                            <b>Negara Kelahiran :</b>

                                            <asp:Label ID="lblnegaralahir1" runat="server" Text='<%# Eval("birthplace1") %>'></asp:Label>

                                            <br />

                                            <b>Jenis Kelamin :</b>

                                            <asp:Label ID="lbljeniskelamin1" runat="server" Text='<%# Eval("gender1") %>'></asp:Label>
                                            <br />

                                            <b>Kebangsaan :</b>

                                            <asp:Label ID="lblkebangsaan1" runat="server" Text='<%# Eval("nationality1") %>'></asp:Label>
                                            <br />

                                            <b>Status Marital :</b>

                                            <asp:Label ID="lblmarital1" runat="server" Text='<%# Eval("maritalstatus1") %>'></asp:Label>
                                            <br />

                                            <b>Agama :</b>

                                            <asp:Label ID="lblagama1" runat="server" Text='<%# Eval("religion1") %>'></asp:Label>
                                            <br />

                                            <b>User Login DPA :</b>

                                            <asp:Label ID="lbldpa1" runat="server" Text='<%# Eval("useriddpa1") %>'></asp:Label>
                                            <br />

                                            <b>No.BPJS Ketenagakerjaan :</b>

                                            <asp:Label ID="lblnobpjstk1" runat="server" Text='<%# Eval("jamsostek1") %>'></asp:Label>
                                            <br />

                                            <b>Rekening :</b>

                                            <asp:Label ID="lblrekening1" runat="server" Text='<%# Eval("bankkey1") + " - " + Eval("bankacct1") %>'></asp:Label>
                                            <br />
                                            <b>No.BPJS Kesehatan :</b>

                                            <asp:Label ID="lblnobpjskesehatan1" runat="server" Text='<%# Eval("nobpjs1") %>'></asp:Label>
                                            <br />

                                        </ItemTemplate>
                             </asp:DataList>
                         </content>
                     </ajaxtoolkit:accordionpane>
                     <ajaxtoolkit:accordionpane id="AccordionPane2" runat="server">
                         <header>
                             <span class="accordionLink">Organizational Assignment</span>
                         </header>
                         <content>
                              <asp:DataList ID="dlOrg" runat="server" Width="100%">
                                  <ItemStyle BackColor="White" ForeColor="Black" BorderWidth="2px" />
                                        <ItemTemplate>
                                            <b>Nama Atasan :</b>
                                            <asp:Label ID="lblNamaSPV" runat="server" Text='<%# Eval("fullnamespv1") %>'></asp:Label>
                                            <br />

                                            <b>Personal Sub Area :</b>
                                            <asp:Label ID="lblSubArea" runat="server" Text='<%# Eval("personalareaname1") %>'></asp:Label>
                                            <br />

                                            <b>Lokasi :</b>
                                            <asp:Label ID="lblLocation" runat="server" Text='<%# Eval("location1") %>'></asp:Label>
                                            <br />

                                            <b>Jabatan :</b>
                                            <asp:Label ID="lblJabatan" runat="server" Text='<%# Eval("position1") %>'></asp:Label>
                                            <br />

                                            <b>Cost Center :</b>
                                            <asp:Label ID="lblCostCenter" runat="server" Text='<%# Eval("costcenter1") %>'></asp:Label>
                                            <br />

                                            <b>Contract :</b>
                                            <asp:Label ID="lblContract" runat="server" Text='<%# Eval("contracttype1") %>'></asp:Label>
                                            <br />

                                        </ItemTemplate>
                              </asp:DataList>
                         </content>
                     </ajaxtoolkit:accordionpane>
                     <ajaxtoolkit:accordionpane id="AccordionPane3" runat="server">
                         <header>
                             <span class="accordionLink">Addresses</span>
                         </header>
                         <content>
                             <asp:DataList ID="dlEmpAddress" runat="server" Width="100%">
                                  <ItemStyle BackColor="White" ForeColor="Black" BorderWidth="2px" />
                                        <ItemTemplate>
                                            <b><asp:Label ID="lblAddressType" runat="server" Text='<%# Eval("addresstype1") %>'></asp:Label></b>
                                            <br />

                                            <b>Alamat :</b>
                                            <asp:Label ID="lblAlamat1" runat="server" Text='<%# Eval("streetandhouseno1") %>'></asp:Label>
                                            &nbsp;
                                            <asp:Label ID="lblAlamat2" runat="server" Text='<%# Eval("secondaddressline1") %>'></asp:Label>
                                            <br />

                                            <b>Kota :</b>
                                            <asp:Label ID="lblKota1" runat="server" Text='<%# Eval("city1") %>'></asp:Label>
                                            <br />

                                            <b>Kode Pos :</b>
                                            <asp:Label ID="lblKodePos1" runat="server" Text='<%# Eval("postalcode1") %>'></asp:Label>
                                            <br />

                                            <b>Provinsi :</b>
                                            <asp:Label ID="lblProvinsi1" runat="server" Text='<%# Eval("region1") %>'></asp:Label>
                                            <br />

                                            <b>Negara :</b>
                                            <asp:Label ID="lblNegara1" runat="server" Text='<%# Eval("country1") %>'></asp:Label>
                                            <br />

                                            <b>Telepon :</b>
                                            <asp:Label ID="lblTelepon1" runat="server" Text='<%# Eval("tlpno1") %>'></asp:Label>
                                            <br />

                                            <b>Handphone :</b>
                                            <asp:Label ID="lblHandphone" runat="server" Text='<%# Eval("hpno1") %>'></asp:Label>
                                            <br />
                                            <br />
                                            <br />
                                        </ItemTemplate>
                              </asp:DataList>
                         </content>
                     </ajaxtoolkit:accordionpane>
                     <ajaxtoolkit:accordionpane id="AccordionPane4" runat="server">
                         <header>
                             <span class="accordionLink">Family Member</span>
                         </header>
                         <content>
                            <asp:GridView ID="gvfamily1" runat="server" AutoGenerateColumns="false" PageSize="10" Width="100%"
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
                                <asp:TemplateField HeaderText="Family Member">
                                    <ItemTemplate>
                                        <asp:Label ID="lblmemberfamily1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.familytype1")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ke - ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblkefamily1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.number1")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="NIK">
                                    <ItemTemplate>
                                        <asp:Label ID="lblnikfamily1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.nik1")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nama">
                                    <ItemTemplate>
                                        <asp:Label ID="lblnamafamily1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.name1")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tgl.Lahir">
                                    <ItemTemplate>
                                        <asp:Label ID="lbltgllahirfamily1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.dateofbirth1")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tempat Lahir">
                                    <ItemTemplate>
                                        <asp:Label ID="lbltempatlahirfamily1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.birthplace1")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Negara Kelahiran">
                                    <ItemTemplate>
                                        <asp:Label ID="lblnegarakelahiranfamily1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.cityofbirth1")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Jenis Kelamin">
                                    <ItemTemplate>
                                        <asp:Label ID="lbljeniskelaminfamily1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.gender1")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                     </content>
                  </ajaxtoolkit:accordionpane>
                  <ajaxtoolkit:accordionpane id="AccordionPane5" runat="server">
                         <header>
                             <span class="accordionLink">Education</span>
                         </header>
                         <content>
                   
                              <asp:GridView ID="gveducation1" runat="server" AutoGenerateColumns="false" PageSize="10" Width="100%"
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
                                    <asp:TemplateField HeaderText="Tgl.Masuk">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltgledu1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.tglmasuk1")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tgl.Lulus">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltgledu2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.tgllulus1")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Jenjang Pendidikan">
                                        <ItemTemplate>
                                            <asp:Label ID="lbljenjangpendidikan1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.jenjangpendidikan1")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nama Institusi/Penyelenggara">
                                        <ItemTemplate>
                                            <asp:Label ID="lblnamainstitusiedu1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.namainstitusi1")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Bidang/Jurusan/Nama Training">
                                        <ItemTemplate>
                                            <asp:Label ID="lbljurusanedu1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.jurusan1")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                         </content>
                        </ajaxtoolkit:accordionpane>
                      <ajaxtoolkit:accordionpane id="AccordionPane6" runat="server">
                         <header>
                             <span class="accordionLink">Training</span>
                         </header>
                         <content>
                              <asp:GridView ID="gvtraining1" runat="server" AutoGenerateColumns="false" PageSize="10" Width="100%"
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
                                    <asp:TemplateField HeaderText="Tgl.Masuk">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltgltraining1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.tglmulai1")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tgl.Selesai">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltgltraining2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.tglselesai1")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Metode Training">
                                        <ItemTemplate>
                                            <asp:Label ID="lblmetodetraining1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.metodetraining1")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nama Institusi/Penyelenggara">
                                        <ItemTemplate>
                                            <asp:Label ID="lblnamainstitusitraining1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.namainstitusi1")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nama Training">
                                        <ItemTemplate>
                                            <asp:Label ID="lblnamatraining1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.namatraining1")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                         </content>
                        </ajaxtoolkit:accordionpane>
                      <ajaxtoolkit:accordionpane id="AccordionPane7" runat="server">
                         <header>
                             <span class="accordionLink">Personal ID</span>
                         </header>
                         <content>
                              <asp:GridView ID="gvpersonalid" runat="server" AutoGenerateColumns="false" PageSize="10" Width="100%"
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
                                    <asp:TemplateField HeaderText="Tipe">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltipepersonalid1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.tipe1")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nomor">
                                        <ItemTemplate>
                                            <asp:Label ID="lblnopersonalid1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.nomor1")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                         </content>
                        </ajaxtoolkit:accordionpane>
                      <ajaxtoolkit:accordionpane id="AccordionPane8" runat="server">
                         <header>
                             <span class="accordionLink">Tax Data</span>
                         </header>
                         <content>
                              <asp:GridView ID="gvtaxid" runat="server" AutoGenerateColumns="false" PageSize="10" Width="100%"
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
                                    <asp:TemplateField HeaderText="No.NPWP">
                                        <ItemTemplate>
                                            <asp:Label ID="lblnonpwp1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.nonpwp1")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstatusnpwp" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.status1")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Jumlah Tanggungan/Anak">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltggunpwp" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.jmlh1")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                         </content>
                        </ajaxtoolkit:accordionpane>
                      <ajaxtoolkit:accordionpane id="AccordionPane9" runat="server">
                         <header>
                             <span class="accordionLink">Klaim Kacamata Terakhir</span>
                         </header>
                         <content>
                              <asp:GridView ID="gvkm1" runat="server" AutoGenerateColumns="false" PageSize="10" Width="100%"
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
                                    <asp:TemplateField HeaderText="Tanggal">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltglclaimkm1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.tgl1")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Claimer">
                                        <ItemTemplate>
                                            <asp:Label ID="lblclaimerkm1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.claimer1")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Keterangan">
                                        <ItemTemplate>
                                            <asp:Label ID="lblketkm1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ket1")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Jumlah">
                                        <ItemTemplate>
                                            <asp:Label ID="lbljumlahkm1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.jmlh1")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                         </content>
                        </ajaxtoolkit:accordionpane>
                     <ajaxtoolkit:accordionpane id="AccordionPane10" runat="server">
                         <header>
                             <span class="accordionLink">Warning Letter</span>
                         </header>
                         <content>
                              <asp:GridView ID="gvwarning" runat="server" AutoGenerateColumns="false" PageSize="10" Width="100%"
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
                                    <asp:TemplateField HeaderText="Alasan">
                                        <ItemTemplate>
                                            <asp:Label ID="lblalasanwarning1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.reason1")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tgl.Awal">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltglwarning1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.begda1")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tgl.Akhir">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltglwarning2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.endda1")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                         </content>
                        </ajaxtoolkit:accordionpane>
                        </panes>
            </ajaxtoolkit:accordion>
        </td>
    </tr>
</table>