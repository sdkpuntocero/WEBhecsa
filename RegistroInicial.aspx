<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroInicial.aspx.cs" Inherits="WEBhecsa.RegistroInicial" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

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
    </style>
</head>

<body>

    <form runat="server" id="frm">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="auth">
            <div class="container">
                <div class="row">
                    <div class="col-md-7 col-sm-12 mx-auto">
                        <div class="card pt-4">
                            <div class="card-body">
                                <div class="text-center mb-5">
                                    <%--<img src="assets/images/favicon.svg" height="48" class="mb-4">--%>
                                    <h3>Registro Incial</h3>
                                    <p>Por favor complete el formulario para registrarse..</p>
                                </div>

                                <div class="row">
                                    <div class="col-md-6 col-12">
                                        <div class="form-group">
                                            <label for="first-name-column">*Nombre Comercial de la Empresa</label>
                                            <input type="text" runat="server" id="iNombreComercial" class="form-control" name="fname-column" required onkeyup="this.value = this.value.toUpperCase();">
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-12">
                                        <div class="form-group">
                                            <label for="username-column" tooltip="Para Notificaciones">*Correo electrónico para contacto</label>
                                            <input type="text" runat="server" id="iCorreoElectronicoContacto" class="form-control" name="username-column" required>
                                        </div>
                                    </div>
                                    <div class="col-md-4 col-12">
                                        <div class="form-group">
                                            <label for="last-name-column">*Nombre(s)</label>
                                            <input type="text" runat="server" id="iNombreAdministrador" class="form-control" name="lname-column" required onkeyup="this.value = this.value.toUpperCase();">
                                        </div>
                                    </div>
                                    <div class="col-md-4 col-12">
                                        <div class="form-group">
                                            <label for="last-name-column">*Apellido Paterno</label>
                                            <input type="text" runat="server" id="iApellidoPaternoAdministrador" class="form-control" name="lname-column" required onkeyup="this.value = this.value.toUpperCase();">
                                        </div>
                                    </div>
                                    <div class="col-md-4 col-12">
                                        <div class="form-group">
                                            <label for="last-name-column">*Apellido Materno</label>
                                            <input type="text" runat="server" id="iApellidoMaternoAdministrador" class="form-control" name="lname-column" required onkeyup="this.value = this.value.toUpperCase();">
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">

                                    <label class="form-check-label">
                                        ¿Tener una cuenta? <a href="Acceso.aspx">Iniciar sesión</a>
                                    </label>
                                </div>
                                <div class="clearfix">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>

                                            <asp:Button CssClass="btn btn-primary float-right" type="submit" ID="btnRegistro" runat="server" Text="Registrar" OnClick="btnRegistro_Click" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                    <asp:Button ID="btnShowPopup" runat="server" Style="display: none" Text="Shouldn't see this button" />

                                    <asp:UpdateProgress ID="upCarga" runat="server" DynamicLayout="true">
                                        <ProgressTemplate>
                                            <div id="overlay">
                                                <div class="center">
                                                    <img alt="" src="assets/image/ajax-loader.gif" />
                                                </div>
                                            </div>
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
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

        <ajaxtoolkit:ModalPopupExtender ID="modSuccess" runat="server" BackgroundCssClass="modalBackground" TargetControlID="btnShowPopup" PopupControlID="panPopup" CancelControlID="btnCancel">
        </ajaxtoolkit:ModalPopupExtender>
    </form>

    <script src="assets/js/feather-icons/feather.min.js"></script>
    <script src="assets/js/app.js"></script>
    <script src="assets/js/main.js"></script>
</body>
</html>