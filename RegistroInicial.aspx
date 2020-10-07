<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroInicial.aspx.cs" Inherits="WEBhecsa.RegistroInicial" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Sign up - Voler Admin Dashboard</title>
    <link rel="stylesheet" href="assets/css/bootstrap.css">

    <link rel="shortcut icon" href="assets/images/favicon.svg" type="image/x-icon">
    <link rel="stylesheet" href="assets/css/app.css">
</head>

<body>
    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="auth">

            <div class="container">
                <div class="row">
                    <div class="col-md-10 col-sm-12 mx-auto">
                        <div class="card pt-4">
                            <div class="card-body">
                                <div class="text-center mb-5">
                                    <img src="assets/images/favicon.svg" height="48" class='mb-4'>
                                    <h3>Empresa</h3>
                                    <p>Por favor complete el formulario para registrarla    .</p>
                                </div>

                                <div class="row">
                                    <div class="col-md-6 col-12">
                                        <div class="form-group">
                                            <label for="first-name-column">First Name</label>
                                            <input type="text" id="first-name-column" class="form-control" name="fname-column">
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-12">
                                        <div class="form-group">
                                            <label for="last-name-column">Last Name</label>
                                            <input type="text" id="last-name-column" class="form-control" name="lname-column">
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-12">
                                        <div class="form-group">
                                            <label for="username-column">Username</label>
                                            <input type="text" id="username-column" class="form-control" name="username-column">
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-12">
                                        <div class="form-group">
                                            <label for="country-floating">Country</label>
                                            <input type="text" id="country-floating" class="form-control" name="country-floating">
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-12">
                                        <div class="form-group">
                                            <label for="company-column">Company</label>
                                            <input type="text" id="company-column" class="form-control" name="company-column">
                                        </div>
                                    </div>
                                    <div class="col-md-6 col-12">
                                        <div class="form-group">
                                            <label for="email-id-column">Email</label>
                                            <input type="email" id="email-id-column" class="form-control" name="email-id-column">
                                        </div>
                                    </div>
                                </div>

                                <a href="auth-login.html">Have an account? Login</a>
                                <div class="clearfix">
                                    <button class="btn btn-primary float-right">Submit</button>
                                </div>
                                <div class="card-body">
                                    <div class="text-center mb-3">
                                        <i class="icon-office icon-3x text-success"></i>
                                        <h5 class="mb-0">Crear Corporativo</h5>
                                        <span class="d-block text-muted">Todos los campos son requeridos</span>
                                    </div>

                                    <div class="form-group form-group-feedback form-group-feedback-right">
                                        <input type="text" class="form-control " runat="server" id="iNombreEmpresa" placeholder="Nombre" required="required" tabindex="1" onkeyup="this.value = this.value.toUpperCase();">

                                        <div class="form-control-feedback">
                                            <i class="icon-office text-muted"></i>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group form-group-feedback form-group-feedback-right">
                                                <input type="text" class="form-control " runat="server" id="iTelefonoEmpresa" placeholder="Telefono" required="required" tabindex="2" onkeyup="this.value = this.value.toUpperCase();">
                                                <div class="form-control-feedback">
                                                    <i class="icon-phone text-muted"></i>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-8">
                                            <div class="form-group form-group-feedback form-group-feedback-right">
                                                <input type="text" class="form-control form-control-lg" runat="server" id="iCalleNumero" placeholder="Calle y Numero" required="required" tabindex="3">
                                                <div class="form-control-feedback">
                                                    <i class="icon-road text-muted"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <asp:UpdatePanel ID="upPage" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div class="row">

                                                <div class="col-md-6">

                                                    <div class="input-group">

                                                        <input type="text" class="form-control border" placeholder="*Código Postal" runat="server" id="iCP" required="required" tabindex="4">
                                                        <span class="input-group-prepend">
                                                            <asp:UpdatePanel ID="upCP" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <asp:LinkButton ID="lkbCP" runat="server" CssClass="btn bg-primary " TabIndex="5">
                                                            <i class="icon-pin-alt"></i>
                                                                    </asp:LinkButton>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </span>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <select class="form-control" runat="server" id="sColonia" required="required" tabindex="6"></select>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <input type="text" class="form-control" runat="server" id="iMunicipio" placeholder="Municipio" disabled="disabled" />
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="form-group">

                                                        <input type="text" class="form-control" runat="server" id="iEstado" placeholder="Estado" disabled="disabled" />
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <div class="text-center mb-3">
                                        <i class="icon-user-tie icon-3x text-success border-success"></i>
                                        <h5 class="mb-0">Director</h5>
                                        <span class="d-block text-muted">Todos los campos son requeridos</span>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group form-group-feedback form-group-feedback-right">
                                                <input type="text" class="form-control " runat="server" id="iNombreAdministrador" placeholder="Nombres(s)" required="required" tabindex="7" onkeyup="this.value = this.value.toUpperCase();">

                                                <div class="form-control-feedback">
                                                    <i class="icon-user-plus text-muted"></i>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group form-group-feedback form-group-feedback-right">
                                                <input type="text" class="form-control " runat="server" id="iApellidoPaternoAdministrador" placeholder="Apellido Paterno" required="required" tabindex="8" onkeyup="this.value = this.value.toUpperCase();">

                                                <div class="form-control-feedback">
                                                    <i class="icon-user-plus text-muted"></i>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group form-group-feedback form-group-feedback-right">
                                                <input type="text" class="form-control " runat="server" id="iApellidoMaternoAdministrador" placeholder="Apellido Materno" required="required" tabindex="9" onkeyup="this.value = this.value.toUpperCase();">

                                                <div class="form-control-feedback">
                                                    <i class="icon-user-plus text-muted"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group form-group-feedback form-group-feedback-right">
                                                <input type="email" class="form-control form-control-lg" runat="server" id="iCorreoElectronicoAdministrador" placeholder="Correo Electronico" required="required" tabindex="10">
                                                <div class="form-control-feedback">
                                                    <i class="icon-mention text-muted"></i>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group form-group-feedback form-group-feedback-right">
                                                <input type="text" class="form-control " runat="server" id="iCelularAdministrador" placeholder="Celular" required="required" tabindex="11" onkeyup="this.value = this.value.toUpperCase();">
                                                <div class="form-control-feedback">
                                                    <i class="icon-mobile text-muted"></i>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="form-check">
                                            <label class="form-check-label">
                                                <input type="checkbox" class="form-input-styled" checked data-fouc tabindex="12">
                                                Suscríbete al boletín mensual
                                            </label>
                                        </div>

                                        <div class="form-check">
                                            <label class="form-check-label">
                                                <input type="checkbox" class="form-input-styled" required data-fouc tabindex="13">
                                                Aceptar <a href="#">términos de servicio</a>
                                            </label>
                                        </div>
                                    </div>
                                    <div class="form-group">

                                        <label class="form-check-label">
                                            <a href="Acceso.aspx">Iniciar Sesion</a>
                                        </label>
                                    </div>
                                    <asp:Button CssClass="btn bg-teal-400 btn-labeled btn-labeled" type="submit" ID="btnRegistro" runat="server" Text="Crear Cuenta" TabIndex="14" />
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

                                <div class="divider">
                                    <div class="divider-text">OR</div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <script src="assets/js/feather-icons/feather.min.js"></script>
        <script src="assets/js/app.js"></script>

        <script src="assets/js/main.js"></script>
    </form>
</body>

</html>

