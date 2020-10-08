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
</head>

<body>
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
                            <form action="index.html">
                                <div class="form-group position-relative has-icon-left">
                                    <label for="username">Usuario</label>
                                    <div class="position-relative">
                                        <input type="text" class="form-control" id="username">
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
                                        <input type="text" class="form-control" id="password">
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
                                    <button class="btn btn-primary float-right">Registrarse</button>
                                </div>
                            </form>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="assets/js/feather-icons/feather.min.js"></script>
    <script src="assets/js/app.js"></script>

    <script src="assets/js/main.js"></script>
</body>

</html>
