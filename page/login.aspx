<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication1.page.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/popper.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <title>Login SERA ESS</title>
    <style type="text/css">
        .messagealert {
            width: 100%;
            position: fixed;
            top:0px;
            z-index: 100000;
            padding: 0;
            font-size: 15px;
        }
    </style>
    <script type="text/javascript">
        function ShowMessage(message, messagetype) {
            var cssclass;
            switch (messagetype) {
                case 'Success':
                    cssclass = 'alert-success'
                    break;
                case 'Error':
                    cssclass = 'alert-danger'
                    break;
                case 'Warning':
                    cssclass = 'alert-warning'
                    break;
                default:
                    cssclass = 'alert-info'
            }
            $('#alert_container').append('<div id="alert_div" style="margin: 0 0.5%; -webkit-box-shadow: 3px 4px 6px #999;" class="alert ' + cssclass + '"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong>' + messagetype + '!</strong> <span>' + message + '</span></div>');
        }
    </script>
</head>
<body style="background-color:lightgray">
    <div class="messagealert" id="alert_container"></div>
    <div class="container">
      <br />
      <br />
      <form class="form-signin" id="form1" runat="server">
        <h2 class="form-signin-heading" style="text-align:center">SERA ESS Login</h2>
        <asp:label ID="lblUsername" runat="server" Text="Username (User ID Windows)"></asp:label>
        <asp:TextBox CssClass="form-control" ID="txtUsername" runat="server"></asp:TextBox>
        <asp:label id="lblPassword" runat="server" Text="Password"></asp:label>
        <asp:TextBox CssClass="form-control" ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <input type="checkbox" onchange="document.getElementById('txtPassword').type = this.checked ? 'text' : 'password'" /> Show Password
        <br />
        <br />
        <asp:Button CssClass="btn btn-lg btn-primary btn-block" ID="cmdLogin" runat="server" Text="Login" OnClick="cmdLogin_Click"/>
        <br />
        <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
      </form>

    </div>
</body>
</html>
