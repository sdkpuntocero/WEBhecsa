<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroInicial.aspx.cs" Inherits="WEBhecsa.RegistroInicial" %>

<!DOCTYPE html>
<html lang="es-mx">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Admin</title>
    <link rel="stylesheet" href="assets/css/bootstrap.css">
    <link rel="shortcut icon" href="assets/images/favicon.svg" type="image/x-icon">
    <link rel="stylesheet" href="assets/css/app.css">
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
                                            <input type="text" id="first-name-column" class="form-control" name="fname-column" required onkeyup="this.value = this.value.toUpperCase();">
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-12">
                                        <div class="form-group">
                                            <label for="username-column" tooltip="Para Notificaciones">*Correo electrónico para contacto</label>
                                            <input type="text" id="username-column" class="form-control" name="username-column" required>
                                        </div>
                                    </div>
                                    <div class="col-md-4 col-12">
                                        <div class="form-group">
                                            <label for="last-name-column">*Nombre(s)</label>
                                            <input type="text" id="last-name-column" class="form-control" name="lname-column" required onkeyup="this.value = this.value.toUpperCase();">
                                        </div>
                                    </div>
                                    <div class="col-md-4 col-12">
                                        <div class="form-group">
                                            <label for="last-name-column">*Apellido Paterno</label>
                                            <input type="text" id="last-name-column" class="form-control" name="lname-column" required onkeyup="this.value = this.value.toUpperCase();">
                                        </div>
                                    </div>
                                    <div class="col-md-4 col-12">
                                        <div class="form-group">
                                            <label for="last-name-column">*Apellido Materno</label>
                                            <input type="text" id="last-name-column" class="form-control" name="lname-column" required onkeyup="this.value = this.value.toUpperCase();">
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">

                                    <label class="form-check-label">
                                        ¿Tener una cuenta? <a href="Acceso.aspx">Iniciar sesión</a>
                                    </label>
                                </div>
                                <div class="clearfix">
                                    <button class="btn btn-primary float-right">Registrar</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="assets/js/feather-icons/feather.min.js"></script>
    <script src="assets/js/app.js"></script>
    <script src="assets/js/main.js"></script>
</body>
</html>
