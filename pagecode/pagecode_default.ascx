<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_default.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_default" %>
<asp:ScriptManager runat="server" ID="sc1"></asp:ScriptManager>
<table style="width:100%">
    <tr>
        <td style="text-align:center;background-color:#0e1a40;">
            <asp:ImageButton ID="imgProfile1" runat="server" Width="125px" Height="125px" OnClick="imgProfile1_Click" 
                AlternateText="Klik untuk melihat user profile anda" ToolTip="Klik untuk melihat user profile anda" />
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
            <table style="width:100%;text-align:center">
                <tr style="height:200px;width:50%">
                    <td>
                    <asp:ImageButton ID="imgWFH" runat="server" Width="125px" Height="125px" ImageUrl="~/img/wfh.png" OnClick="imgWFH_Click" />    
                    </td>
                    <td>
                    <asp:ImageButton ID="imgWFO" runat="server" Width="125px" Height="125px" ImageUrl="~/img/wfo2.jpg" OnClick="imgWFO_Click" />
                    </td>
                    
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl2" runat="server" Font-Names="Arial" Font-Size="20px" Text="WFH"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lbl3" runat="server" Font-Names="Arial" Font-Size="20px" Text="WFO"></asp:Label>
                    </td>
                    
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    
                </tr>
                <tr style="height:200px;width:50%">
                    <td>
                        
                        <asp:ImageButton ID="imgApproval1" runat="server" ImageUrl="~/img/approval.png" Width="125px" Height="125px" OnClick="imgApproval1_Click" />
                        
                    </td>
                    <td>
                       <%-- <asp:ImageButton ID="imgRequest1" runat="server" ImageUrl="~/img/request.png" Width="125px" Height="125px" OnClick="imgRequest1_Click" />--%>
                        <asp:ImageButton ID="rptabsencesub" runat="server" Width="125px" Height="125px" 
                            ImageUrl="~/img/reportabsencesub.png" OnClick="rptabsencesub_Click" />
                    </td>
                    
                </tr>
                <tr>
                    <td style="text-align:center">
                        <asp:Label ID="lbl1" runat="server" Text="Approval Menu" Font-Size="20px" Font-Names="Arial"></asp:Label>
                        </td>
                    <td style="text-align:center">
                        <%--<asp:Label ID="lbl2" runat="server" Text="Request Menu" Font-Size="20px" Font-Names="Arial"></asp:Label>--%>
                        <asp:Label ID="Label5" runat="server" Text="Report Absensi" Font-Size="20px" Font-Names="Arial" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>

                        &nbsp;</td>
                    <td>

                        &nbsp;</td>
                </tr>
                <tr style="height:200px;width:50%">
                    <td>
                        <asp:ImageButton ID="imgClaim" runat="server" ImageUrl="~/img/claim.png" Width="125px" Height="125px" OnClick="imgClaim_Click" />
                    </td>
                    <td>
                        <asp:ImageButton ID="imgLink" runat="server" ImageUrl="~/img/internet.png" Width="125px" Height="125px" OnClick="imgLink_Click"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl4" runat="server" Text="Klaim Menu" Font-Size="20px" Font-Names="Arial"></asp:Label>
                        </td>
                    <td>

                        <asp:Label ID="lbl5" runat="server" Text="Link Menu" Font-Size="20px" Font-Names="Arial"></asp:Label>

                    </td>
                </tr>
                
                <tr> 
                    <td style="text-align:center">
                        &nbsp;</td>
                    <td>

                    </td>
                </tr>

                <tr style="height:200px;width:50%">
                    <td>
                        <asp:ImageButton ID="imgPersonnel" runat="server" ImageUrl="~/img/personnel.png" Width="125px" Height="125px" OnClick="imgPersonnel_Click" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Personnel Menu" Font-Size="20px" Font-Names="Arial"></asp:Label>
                        </td>
                    <td>

                        &nbsp;</td>
                </tr>

            </table>
        </td>
    </tr>
</table>