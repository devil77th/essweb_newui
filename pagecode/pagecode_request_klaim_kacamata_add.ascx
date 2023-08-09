<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_request_klaim_kacamata_add.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_request_klaim_kacamata_add" %>
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
            width: 500px;
        }
    </style>

<table style="width:100%">
    <tr>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            Peserta :
        </td>
    </tr>
    <tr>
        <td>
            <asp:UpdatePanel ID="updddlpeserta1" runat="server" RenderMode="Block">
            <ContentTemplate>
            <asp:DropDownList ID="ddlPeserta1" runat="server" CssClass="form-control" 
                OnSelectedIndexChanged ="ddlPeserta1_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel>

        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            Klaim Frame Terakhir :
        </td>
    </tr>
    <tr>
        <td>
            <asp:UpdatePanel ID="updlblframe" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Label ID="lbllastclaimframe" runat="server"></asp:Label>
                    
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
        <tr>
        <td>
            Klaim Lensa Terakhir :
        </td>
    </tr>
    <tr>
        <td>
            <asp:UpdatePanel ID="updlbllens" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Label ID="lbllastclaimlens" runat="server"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
    </tr>

    <tr style="background-color:lightgray;font-weight:500">
        <td>
            Add Claim</td>
    </tr>

    <tr>
        <td>
            &nbsp;</td>
    </tr>

    <tr>
        <td>
            &nbsp;</td>
    </tr>

    <tr>
        <td>
            Item Frame&nbsp; : </td>
    </tr>

    <tr>
        <td>
        <asp:UpdatePanel ID="updddlitemframe1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:DropDownList ID="ddlItemClaimFrame" runat="server" Width="100%" 
            OnSelectedIndexChanged="ddlItemClaimFrame_SelectedIndexChanged" AutoPostBack="true">
        </asp:DropDownList>
        </ContentTemplate>
        </asp:UpdatePanel>
        </td>
    </tr>



    <tr>
        <td>
        <asp:UpdatePanel ID="updlimitframe1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Label ID="lblLimitClaimFrame" runat="server"></asp:Label>    
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
            Amount Claim Frame :</td>
    </tr>



    <tr>
        <td>
        <asp:UpdatePanel ID="updamtframe1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:TextBox ID="txtItemAmtClaimFrame" runat="server" Width="100%" Enabled="false" BackColor="DarkGray"></asp:TextBox>    
        </ContentTemplate>
        </asp:UpdatePanel>
        </td>
    </tr>



    <tr>
        <td>
            <asp:Label ID="lblInfo1" runat="server" Font-Size="Small">Diisi dengan angka saja , cth : 100000</asp:Label>
        </td>
    </tr>



    <tr>
        <td>
            &nbsp;</td>
    </tr>

        <tr>
        <td>
            Item Lensa&nbsp; : </td>
    </tr>

    <tr>
        <td>
        <asp:UpdatePanel ID="updddlitemlensa1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:DropDownList ID="ddlItemClaimLensa" runat="server" Width="100%" 
            OnSelectedIndexChanged="ddlItemClaimLensa_SelectedIndexChanged" AutoPostBack="true">
        </asp:DropDownList>
        </ContentTemplate>
        </asp:UpdatePanel>
        </td>
    </tr>



    <tr>
        <td>
        <asp:UpdatePanel ID="updlimitlensa1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:Label ID="lblLimitClaimLensa" runat="server"></asp:Label>
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
            Amount Claim Lensa :</td>
    </tr>



    <tr>
        <td>
        <asp:UpdatePanel ID="updamtlensa1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:TextBox ID="txtItemAmtClaimLensa" runat="server" Width="100%" Enabled="false" BackColor="DarkGray"></asp:TextBox>    
        </ContentTemplate>
        </asp:UpdatePanel>
        </td>
    </tr>



    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Font-Size="Small">Diisi dengan angka saja , cth : 100000</asp:Label>
        </td>
    </tr>



    <tr>
        <td>
            &nbsp;</td>
    </tr>





    <tr>
        <td>
            Keterangan : </td>
    </tr>





    <tr>
        <td>
        <asp:TextBox ID="txtKeterangan1" runat="server" TextMode="MultiLine" Width="100%" Rows="5"></asp:TextBox>
        </td>
    </tr>



    <tr>
        <td>
       
        </td>
    </tr>

     <tr>
        <td>
            <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="cmdSubmitClaimKM" runat="server" Text="Next >>" OnClick="cmdSubmitClaimKM_Click" />
           
        </td>
    </tr>


</table>
<asp:UpdatePanel ID="updhid1" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<asp:HiddenField ID="hidlimitframe1" runat="server" />
<asp:HiddenField ID="hidlimitlensa1" runat="server" />
<asp:HiddenField ID="hidClaimant1" runat="server" />
<asp:HiddenField ID="hidframeelig1" runat="server" />
<asp:HiddenField ID="hidframeyear1" runat="server" />
<asp:HiddenField ID="hidlensaelig1" runat="server" />
<asp:HiddenField ID="hidlensayear1" runat="server" />
</ContentTemplate>
</asp:UpdatePanel>

