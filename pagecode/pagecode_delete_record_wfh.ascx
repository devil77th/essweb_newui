<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_delete_record_wfh.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_delete_record_wfh" %>
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

<script type="text/javascript">

</script>

<table style="width:100%">
    <tr>
        <td>
            Tanggal :
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="txtDateCICOWFH" runat="server" CssClass="form-control"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="txtDateCICO_CalendarExtender" runat="server" 
                BehaviorID="txtDateCICO_CalendarExtender" TargetControlID="txtDateCICOWFH" Format="dd-MMM-yyyy" />
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>

    <tr>
        <td>
            NRP :</td>
    </tr>

    <tr>
        <td>
           <asp:TextBox ID="txtNRP" runat="server" CssClass="form-control"></asp:TextBox>
        </td>
    </tr>



    <tr>
        <td>
            &nbsp;</td>
    </tr>



    <tr>
        <td>
        <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="cmdCheckWFH" runat="server" Text="Check Record"
               OnClick="cmdCheckWFH_Click" />    
        </td>
    </tr>



    <tr>
        <td>
            &nbsp;</td>
    </tr>



    <tr>
        <td>
<asp:UpdatePanel ID="updDataListCICO1" runat="server" RenderMode="Inline" UpdateMode="Conditional">
<ContentTemplate>
<asp:DataList ID="dlCICO1" runat="server" BackColor="Gray" BorderColor="#666666"

            BorderStyle="None" BorderWidth="2px" CellPadding="3" CellSpacing="2"

            Font-Names="Verdana" Font-Size="Small" GridLines="Both" RepeatColumns="1"

            Width="100%" OnItemCommand="dlCICO1_ItemCommand">

            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" Font-Size="Large" ForeColor="White"
                HorizontalAlign="Center" VerticalAlign="Middle" />

            <HeaderTemplate>List Request CI/CO WFH</HeaderTemplate>

            <ItemStyle BackColor="White" ForeColor="Black" BorderWidth="2px" />
            <ItemTemplate>

                <b>Nama :</b>

                <asp:Label ID="lblfullNameCICO" runat="server" Text='<%# Eval("fullnameCICOWFH1") %>'></asp:Label>

                <br />

                <b>Tanggal CI/CO WFH :</b>

                <asp:Label ID="lbldateCICO" runat="server" Text='<%# Eval("dateCICOWFH1") %>'></asp:Label>

                <br />

               <b>Waktu CI/CO WFH :</b>

                <asp:Label ID="lbltimeCICO" runat="server" Text=' <%# Eval("clockCICOWFH1") %>'></asp:Label>

                <br />

                <b>Tipe CI/CO WFH :</b>

                <asp:Label ID="lbltypeCICO" runat="server" Text='<%# Eval("typeCICOWFH1") %>'></asp:Label>
                <br />
                <asp:HiddenField ID="lbltrxCICO" runat="server" Value='<%# Eval("idtrxCICOWFH1") %>' />
                <div style="text-align:right">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="cmdDelete" runat="server" Text="Delete" Width="100px" CommandName="cmdDelete" />
                </div>
            </ItemTemplate>

        </asp:DataList>
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
            
           
        </td>
    </tr>


</table>