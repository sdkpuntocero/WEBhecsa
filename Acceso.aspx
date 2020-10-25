<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Acceso.aspx.cs" Inherits="WEBhecsa.Acceso" %>

<!DOCTYPE html>
<html lang="es-mx">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Admin</title>
    <link rel="stylesheet" href="assets/css/bootstrap.css">

    <link rel="shortcut icon" href="assets/images/favicon.svg" type="image/x-icon">
    <link rel="stylesheet" href="assets/css/app.css">
    <style>
        .modalBackground {
            background-color: white;
            filter: alpha(opacity=50);
            opacity: 0.7;
        }

        .pnlBackGround {
            position: fixed;
            top: 10%;
            left: 10px;
            width: 600px;
            height: 200px;
            text-align: center;
            background-color: White;
        }

        .footer {
            position: fixed;
            left: 0;
            bottom: 0;
            width: 100%;
            text-align: center;
        }
    </style>
</head>

<body>
    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="auth">

            <div class="container">
                <div class="row">
                    <div class="col-md-5 col-sm-12 mx-auto">
                        <div class="card pt-4">
                            <div class="card-body">
                                <div class="text-center mb-5">
                                    <img src="assets/images/favicon.svg" height="48" class='mb-4'>
                                    <h3>Registrarse</h3>
                                    <p>Inicie sesión para continuar.</p>
                                </div>

                                <div class="form-group position-relative has-icon-left">
                                    <label for="username">Usuario</label>
                                    <div class="position-relative">
                                        <input type="text" class="form-control" runat="server" id="iUsuario" required onkeyup="this.value = this.value.toLowerCase();">
                                        <div class="form-control-icon">
                                            <i data-feather="user"></i>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group position-relative has-icon-left">
                                    <div class="clearfix">
                                        <label for="password">Clave</label>
                                        <a href="auth-forgot-password.html" class='float-right'>
                                            <small>¿Se te olvidó tu contraseña?</small>
                                        </a>
                                    </div>
                                    <div class="position-relative">
                                        <input type="password" class="form-control" id="iClave" required runat="server">
                                        <div class="form-control-icon">
                                            <i data-feather="lock"></i>
                                        </div>
                                    </div>
                                </div>

                                <div class='form-check clearfix my-4'>

                                    <div class="float-right">
                                        <a href="auth-register.html">¿No tienes una cuenta?</a>
                                    </div>
                                </div>
                                <div class="clearfix">
                                    <asp:Button ID="btnShowPopup" runat="server" Style="display: none" Text="Shouldn't see this button" />
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:Button ID="btnRegistrar" CssClass="btn btn-primary float-right" runat="server" Text="Registrarse" OnClick="btnRegistrar_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:Panel ID="panPopup" Style="display: none" CssClass="pnlBackGround" runat="server">
            <asp:UpdatePanel ID="upModal" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <fieldset style="color: black; background: white">

                        <legend>Notificaciones</legend>

                        <h5>

                            <asp:Label ID="lblSuccess" runat="server" Text=""></asp:Label>
                        </h5>

                        <br />
                    </fieldset>
                </ContentTemplate>
            </asp:UpdatePanel>
            <a href="#" id="btnCancel" class="btn btn-primary">Aceptar</a>
        </asp:Panel>

        <ajaxToolkit:ModalPopupExtender ID="modSuccess" runat="server" BackgroundCssClass="modalBackground" TargetControlID="btnShowPopup" PopupControlID="panPopup" CancelControlID="btnCancel">
        </ajaxToolkit:ModalPopupExtender>
    </form>
    <script src="assets/js/feather-icons/feather.min.js"></script>
    <script src="assets/js/app.js"></script>

    <script src="assets/js/main.js"></script>
</body>
</html>