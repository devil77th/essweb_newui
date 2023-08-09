<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagecode_change_winpass.ascx.cs" Inherits="WebApplication1.pagecode.pagecode_change_winpass" %>
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
            Username :
        </td>
    </tr>
    <tr>
        <td>
             <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
    </tr>
     <tr>
        <td>
            Date Expired :
        </td>
    </tr>
    <tr>
        <td>
             <asp:Label ID="lblExpDate" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            Old Password :
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="txtOldPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>

    <tr>
        <td>
            New Password :</td>
    </tr>

    <tr>
        <td>
           <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
        </td>
    </tr>



    <tr>
        <td>
         <asp:Label ID="lblInfo" runat="server" Font-Size="Small">Password minimal 8 karakter,huruf besar dan gabungan antara numerik dan karakter</asp:Label>    
        </td>
    </tr>



    <tr>
        <td>
            &nbsp;</td>
    </tr>



    <tr>
        <td>
         <asp:Label ID="lblStatus" runat="server" Font-Size="Small"></asp:Label>     
        </td>
    </tr>



    <tr>
        <td>
         
        </td>
    </tr>



    <tr>
        <td>
            &nbsp;</td>
    </tr>

     <tr>
        <td>
            <asp:Button CssClass="btn btn-lg btn-primary btn-block" 
                ID="cmdChangePass" runat="server" Text="Change Password" OnClick="cmdChangePass_Click" />
           
        </td>
    </tr>


</table>