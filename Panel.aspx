<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Panel.aspx.cs" Inherits="WEBhecsa.Panel" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html>
<html lang="es-mx">

<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Resumen</title>

    <link rel="stylesheet" href="assets/css/bootstrap.css">
    <link rel="stylesheet" href="assets/vendors/chartjs/Chart.min.css">
    <link rel="stylesheet" href="assets/vendors/perfect-scrollbar/perfect-scrollbar.css">
    <link rel="stylesheet" href="assets/css/app.css">
    <link rel="shortcut icon" href="assets/images/favicon.svg" type="image/x-icon">
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
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
            </ContentTemplate>
        </asp:UpdatePanel>

        <div id="app">
            <div id="sidebar" class="active">
                <div class="sidebar-wrapper active">
                    <div class="sidebar-header">
                        <h2>
                            <asp:Label ID="lblEmpresa" runat="server" Text="" Font-Size="Smaller"></asp:Label></span></h2>

                        <h6><strong>
                            <asp:Label ID="lblRazonSocial" runat="server" Text="" Font-Size="Smaller"></asp:Label></span></strong></h6>
                    </div>
                    <div class="sidebar-menu">
                        <ul class="menu">

                            <li class="sidebar-title">Main Menu</li>

                            <li class="sidebar-item active">
                                <a href="Panel.aspx" class="sidebar-link">
                                    <i data-feather="home" width="20"></i>
                                    <span>Resumen</span>
                                </a>
                            </li>
                            <li class="sidebar-item  has-sub">
                                <a href="#" class="sidebar-link">
                                    <i data-feather="briefcase" width="20"></i>
                                    <span>Configuracion</span>
                                </a>

                                <ul class="submenu ">

                                    <asp:UpdatePanel ID="upNotificaciones" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <li>
                                                <asp:LinkButton ID="lkbNotificaciones" runat="server" OnClick="lkbNotificaciones_Click">
                                                            <span>Notificaciones</span>
                                                </asp:LinkButton>
                                            </li>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                    <asp:UpdatePanel ID="upEmpresa" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <li>
                                                <asp:LinkButton ID="lkbEmpresa" runat="server" OnClick="lkbEmpresa_Click">
                                                            <span>Empresa</span>
                                                </asp:LinkButton>
                                            </li>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </ul>
                            </li>

                            <li class="sidebar-title">Administración</li>

                            <asp:UpdatePanel ID="upUsuarios" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <li class="sidebar-item">
                                        <asp:LinkButton ID="lkbUsuarios" runat="server" CssClass="sidebar-link" OnClick="lkbUsuarios_Click">
                                                    <i data-feather="layers" width="20"></i>
                                                            <span>Usuarios</span>
                                        </asp:LinkButton>
                                    </li>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdatePanel ID="upProveedores" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <li class="sidebar-item">
                                        <asp:LinkButton ID="lkbProveedores" runat="server" CssClass="sidebar-link" OnClick="lkbProveedores_Click">
                                                    <i data-feather="briefcase" width="20"></i>
                                                            <span>Proveedores</span>
                                        </asp:LinkButton>
                                    </li>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdatePanel ID="upProductos" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <li class="sidebar-item">
                                        <asp:LinkButton ID="lkbProductos" runat="server" CssClass="sidebar-link" OnClick="lkbProductos_Click">
                                                    <i data-feather="briefcase" width="20"></i>
                                                            <span>Productos</span>
                                        </asp:LinkButton>
                                    </li>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <li class="sidebar-item">
                                        <asp:LinkButton ID="LinkButton3" runat="server" CssClass="sidebar-link" OnClick="lkbUsuarios_Click">
                                                    <i data-feather="briefcase" width="20"></i>
                                                            <span>Clientes</span>
                                        </asp:LinkButton>
                                    </li>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <li class="sidebar-title">Registros</li>

                            <li class="sidebar-item  ">
                                <a href="#" class="sidebar-link">
                                    <i data-feather="file-plus" width="20"></i>
                                    <span>Orden de Compras</span>
                                </a>
                            </li>

                            <li class="sidebar-item  ">
                                <a href="#" class="sidebar-link">
                                    <i data-feather="file-plus" width="20"></i>
                                    <span>Cotizacion</span>
                                </a>
                            </li>
                        </ul>
                    </div>
                    <button class="sidebar-toggler btn x"><i data-feather="x"></i></button>
                </div>
            </div>
            <div id="main">
                <nav class="navbar navbar-header navbar-expand navbar-light">
                    <a class="sidebar-toggler" href="#"><span class="navbar-toggler-icon"></span></a>
                    <button class="btn navbar-toggler" type="button" data-toggle="collapse"
                        data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false"
                        aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul class="navbar-nav d-flex align-items-center navbar-light ml-auto">
                            <li class="dropdown nav-icon">
                                <a href="#" data-toggle="dropdown"
                                    class="nav-link  dropdown-toggle nav-link-lg nav-link-user">
                                    <div class="d-lg-inline-block">
                                        <i data-feather="bell"></i>
                                    </div>
                                </a>
                                <div class="dropdown-menu dropdown-menu-right dropdown-menu-large">
                                    <h6 class="py-2 px-4">Notifications</h6>
                                    <ul class="list-group rounded-none">
                                        <li class="list-group-item border-0 align-items-start">
                                            <div class="avatar bg-success mr-3">
                                                <span class="avatar-content"><i data-feather="shopping-cart"></i></span>
                                            </div>
                                            <div>
                                                <h6 class="text-bold">New Order</h6>
                                                <p class="text-xs">
                                                    An order made by Ahmad Saugi for product Samsung Galaxy S69
                                                </p>
                                            </div>
                                        </li>
                                    </ul>
                                </div>
                            </li>
                            <li class="dropdown">
                                <a href="#" data-toggle="dropdown"
                                    class="nav-link dropdown-toggle nav-link-lg nav-link-user">
                                    <div class="avatar mr-1">
                                        <img src="assets/images/avatar/avatar-s-1.png" alt="" srcset="">
                                    </div>
                                    <div class="d-none d-md-block d-lg-inline-block">
                                        <span class="user-name">
                                            <asp:Label ID="lblNombreUsuario" runat="server" Text=""></asp:Label>
                                            <strong>

                                                <asp:Label ID="lblNombreApellidos" runat="server" Text=""></asp:Label>
                                            </strong>
                                        </span>
                                    </div>
                                </a>
                                <div class="dropdown-menu dropdown-menu-right">
                                    <a class="dropdown-item" href="#"><i data-feather="user"></i>Perfil</a>
                                    <a class="dropdown-item" href="#"><i data-feather="mail"></i>Mesajes</a>
                                    <a class="dropdown-item" href="#"><i data-feather="settings"></i>Configuracion</a>
                                    <div class="dropdown-divider"></div>
                                    <a class="dropdown-item" href="#"><i data-feather="log-out"></i>Salir</a>
                                </div>
                            </li>
                        </ul>
                    </div>
                </nav>

                <div class="main-content container-fluid">
                    <asp:UpdatePanel ID="upResumen" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Panel ID="pnlResumen" runat="server">
                                <div class="page-title">
                                    <h3>Dashboard</h3>
                                    <p class="text-subtitle text-muted">A good dashboard to display your statistics</p>
                                </div>
                                <section class="section">
                                    <div class="row mb-2">
                                        <div class="col-12 col-md-3">
                                            <div class="card card-statistic">
                                                <div class="card-body p-0">
                                                    <div class="d-flex flex-column">
                                                        <div class="px-3 py-3 d-flex justify-content-between">
                                                            <h3 class="card-title">BALANCE</h3>
                                                            <div class="card-right d-flex align-items-center">
                                                                <p>$50 </p>
                                                            </div>
                                                        </div>
                                                        <div class="chart-wrapper">
                                                            <canvas id="canvas1" style="height: 100px !important"></canvas>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-12 col-md-3">
                                            <div class="card card-statistic">
                                                <div class="card-body p-0">
                                                    <div class="d-flex flex-column">
                                                        <div class="px-3 py-3 d-flex justify-content-between">
                                                            <h3 class="card-title">Revenue</h3>
                                                            <div class="card-right d-flex align-items-center">
                                                                <p>$532,2 </p>
                                                            </div>
                                                        </div>
                                                        <div class="chart-wrapper">
                                                            <canvas id="canvas2" style="height: 100px !important"></canvas>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-12 col-md-3">
                                            <div class="card card-statistic">
                                                <div class="card-body p-0">
                                                    <div class="d-flex flex-column">
                                                        <div class="px-3 py-3 d-flex justify-content-between">
                                                            <h3 class="card-title">ORDERS</h3>
                                                            <div class="card-right d-flex align-items-center">
                                                                <p>1,544 </p>
                                                            </div>
                                                        </div>
                                                        <div class="chart-wrapper">
                                                            <canvas id="canvas3" style="height: 100px !important"></canvas>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-12 col-md-3">
                                            <div class="card card-statistic">
                                                <div class="card-body p-0">
                                                    <div class="d-flex flex-column">
                                                        <div class="px-3 py-3 d-flex justify-content-between">
                                                            <h3 class="card-title">Sales Today</h3>
                                                            <div class="card-right d-flex align-items-center">
                                                                <p>423 </p>
                                                            </div>
                                                        </div>
                                                        <div class="chart-wrapper">
                                                            <canvas id="canvas4" style="height: 100px !important"></canvas>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row mb-4">
                                        <div class="col-md-8">
                                            <div class="card">
                                                <div class="card-header">
                                                    <h3 class="card-heading p-1 pl-3">Sales</h3>
                                                </div>
                                                <div class="card-body">
                                                    <div class="row">
                                                        <div class="col-md-4 col-12">
                                                            <div class="pl-3">
                                                                <h1 class="mt-5">$21,102</h1>
                                                                <p class="text-xs">
                                                                    <span class="text-green"><i data-feather="bar-chart"
                                                                        width="15"></i>+19%</span> than last month
                                                                </p>
                                                                <div class="legends">
                                                                    <div class="legend d-flex flex-row align-items-center">
                                                                        <div class="w-3 h-3 rounded-full bg-info mr-2"></div>
                                                                        <span
                                                                            class="text-xs">Last Month</span>
                                                                    </div>
                                                                    <div class="legend d-flex flex-row align-items-center">
                                                                        <div class="w-3 h-3 rounded-full bg-blue mr-2"></div>
                                                                        <span
                                                                            class="text-xs">Current Month</span>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-8 col-12">
                                                            <canvas id="bar"></canvas>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="card">
                                                <div class="card-header d-flex justify-content-between align-items-center">
                                                    <h4 class="card-title">Orders Today</h4>
                                                    <div class="d-flex ">
                                                        <i data-feather="download"></i>
                                                    </div>
                                                </div>
                                                <div class="card-body px-0 pb-0">
                                                    <div class="table-responsive">
                                                        <table class="table mb-0" id="table1">
                                                            <thead>
                                                                <tr>
                                                                    <th>Name</th>
                                                                    <th>Email</th>
                                                                    <th>Phone</th>
                                                                    <th>City</th>
                                                                    <th>Status</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <tr>
                                                                    <td>Graiden</td>
                                                                    <td>vehicula.aliquet@semconsequat.co.uk</td>
                                                                    <td>076 4820 8838</td>
                                                                    <td>Offenburg</td>
                                                                    <td>
                                                                        <span class="badge bg-success">Active</span>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Dale</td>
                                                                    <td>fringilla.euismod.enim@quam.ca</td>
                                                                    <td>0500 527693</td>
                                                                    <td>New Quay</td>
                                                                    <td>
                                                                        <span class="badge bg-success">Active</span>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Nathaniel</td>
                                                                    <td>mi.Duis@diam.edu</td>
                                                                    <td>(012165) 76278</td>
                                                                    <td>Grumo Appula</td>
                                                                    <td>
                                                                        <span class="badge bg-danger">Inactive</span>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Darius</td>
                                                                    <td>velit@nec.com</td>
                                                                    <td>0309 690 7871</td>
                                                                    <td>Ways</td>
                                                                    <td>
                                                                        <span class="badge bg-success">Active</span>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Ganteng</td>
                                                                    <td>velit@nec.com</td>
                                                                    <td>0309 690 7871</td>
                                                                    <td>Ways</td>
                                                                    <td>
                                                                        <span class="badge bg-success">Active</span>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Oleg</td>
                                                                    <td>rhoncus.id@Aliquamauctorvelit.net</td>
                                                                    <td>0500 441046</td>
                                                                    <td>Rossignol</td>
                                                                    <td>
                                                                        <span class="badge bg-success">Active</span>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>Kermit</td>
                                                                    <td>diam.Sed.diam@anteVivamusnon.org</td>
                                                                    <td>(01653) 27844</td>
                                                                    <td>Patna</td>
                                                                    <td>
                                                                        <span class="badge bg-success">Active</span>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="card ">
                                                <div class="card-header">
                                                    <h4>Your Earnings</h4>
                                                </div>
                                                <div class="card-body">
                                                    <div id="radialBars"></div>
                                                    <div class="text-center mb-5">
                                                        <h6>From last month</h6>
                                                        <h1 class="text-green">+$2,134</h1>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="card widget-todo">
                                                <div
                                                    class="card-header border-bottom d-flex justify-content-between align-items-center">
                                                    <h4 class="card-title d-flex">
                                                        <i class="bx bx-check font-medium-5 pl-25 pr-75"></i>Progress
                                                    </h4>
                                                </div>
                                                <div class="card-body px-0 py-1">
                                                    <table class="table table-borderless">
                                                        <tr>
                                                            <td class="col-3">UI Design</td>
                                                            <td class="col-6">
                                                                <div class="progress progress-info">
                                                                    <div class="progress-bar" role="progressbar" style="width: 60%"
                                                                        aria-valuenow="0" aria-valuemin="0" aria-valuemax="100">
                                                                    </div>
                                                                </div>
                                                            </td>
                                                            <td class="col-3 text-center">60%</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="col-3">VueJS</td>
                                                            <td class="col-6">
                                                                <div class="progress progress-success">
                                                                    <div class="progress-bar" role="progressbar" style="width: 35%"
                                                                        aria-valuenow="0" aria-valuemin="0" aria-valuemax="100">
                                                                    </div>
                                                                </div>
                                                            </td>
                                                            <td class="col-3 text-center">30%</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="col-3">Laravel</td>
                                                            <td class="col-6">
                                                                <div class="progress progress-danger">
                                                                    <div class="progress-bar" role="progressbar" style="width: 50%"
                                                                        aria-valuenow="0" aria-valuemin="0" aria-valuemax="100">
                                                                    </div>
                                                                </div>
                                                            </td>
                                                            <td class="col-3 text-center">50%</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="col-3">ReactJS</td>
                                                            <td class="col-6">
                                                                <div class="progress progress-primary">
                                                                    <div class="progress-bar" role="progressbar" style="width: 80%"
                                                                        aria-valuenow="0" aria-valuemin="0" aria-valuemax="100">
                                                                    </div>
                                                                </div>
                                                            </td>
                                                            <td class="col-3 text-center">80%</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="col-3">Go</td>
                                                            <td class="col-6">
                                                                <div class="progress progress-secondary">
                                                                    <div class="progress-bar" role="progressbar" style="width: 65%"
                                                                        aria-valuenow="0" aria-valuemin="0" aria-valuemax="100">
                                                                    </div>
                                                                </div>
                                                            </td>
                                                            <td class="col-3 text-center">65%</td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </section>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="upNotificacionesF" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Panel ID="pnlNotificacionesF" runat="server" Visible="false">
                                <div class="col-md-6">
                                    <h5 class="card-title">Datos Notificaciones</h5>
                                    <%-- <div class="row">
                                                <div class="col-3">
                                                    <div class="nav flex-column nav-pills" id="v-pills-tab" role="tablist" aria-orientation="vertical">
                                                        <a class="nav-link" id="v-pills-home-tab" data-toggle="pill" href="#v-pills-home" role="tab" aria-controls="v-pills-home" aria-selected="false">Editar</a>
                                                    </div>
                                                </div>

                                                <div class="col-9">
                                                    <div class="tab-content" id="v-pills-tabContent">
                                                        <div class="tab-pane fade" id="v-pills-home" role="tabpanel" aria-labelledby="v-pills-home-tab">
                                                            <div class="row">

                                                                <div class="col-md-4 col-12">
                                                                    <div class="form-group">
                                                                        <label for="username-column" tooltip="Para Notificaciones">*Correo electrónico</label>
                                                                        <input type="text" runat="server" id="iCorreoElectronicoNotificacion" class="form-control" required>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4 col-12">
                                                                    <div class="form-group">
                                                                        <label for="first-name-column">*Usuario Correo</label>
                                                                        <input type="text" runat="server" id="iUsuarioNotificacion" class="form-control" required>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4 col-12">
                                                                    <div class="form-group">
                                                                        <label for="last-name-column">*Clave</label>
                                                                        <input type="password" runat="server" id="iClaveNotificacion" class="form-control" required>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4 col-12">
                                                                    <div class="form-group">
                                                                        <label for="last-name-column">*Asunto</label>
                                                                        <input type="text" runat="server" id="iAsuntoNotificacion" class="form-control" required onkeyup="this.value = this.value.toUpperCase();">
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4 col-12">
                                                                    <div class="form-group">
                                                                        <label for="last-name-column">*SMTP</label>
                                                                        <input type="text" runat="server" id="iSMTPNotificacion" class="form-control" required>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-4 col-12">
                                                                    <div class="form-group">
                                                                        <label for="last-name-column">*Puerto</label>
                                                                        <input type="number" runat="server" id="iPuertoNotificacion" class="form-control">
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="clearfix">
                                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:Button CssClass="btn btn-primary float-right" type="submit" ID="btnRegistroNotificacion" runat="server" Text="Registrar" OnClick="btnRegistroNotificacion_Click" />
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
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
                                            </div>--%>
                                    <div class="row">
                                        <div class="col-12">
                                            <ul class="nav nav-pills mb-3" id="pills-tab" role="tablist">
                                                <li class="nav-item">
                                                    <asp:LinkButton ID="lkbEditaNotificaciones" runat="server" CssClass="nav-item nav-link" role="tab" aria-selected="true" OnClick="lkbEditaNotificaciones_Click">Editar
                                                    </asp:LinkButton>
                                                </li>
                                            </ul>
                                            <hr />
                                            <div class="tab-content" id="myTabContent">
                                                <asp:Panel ID="pnlEditaNotificaciones" runat="server" Visible="false">
                                                    <div class="row">

                                                        <div class="col-md-4 col-12">
                                                            <div class="form-group">
                                                                <label for="username-column" tooltip="Para Notificaciones">*Correo electrónico</label>
                                                                <input type="text" runat="server" id="iCorreoElectronicoNotificacion" class="form-control" required>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4 col-12">
                                                            <div class="form-group">
                                                                <label for="first-name-column">*Usuario Correo</label>
                                                                <input type="text" runat="server" id="iUsuarioNotificacion" class="form-control" required>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4 col-12">
                                                            <div class="form-group">
                                                                <label for="last-name-column">*Clave</label>
                                                                <input type="password" runat="server" id="iClaveNotificacion" class="form-control" required>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4 col-12">
                                                            <div class="form-group">
                                                                <label for="last-name-column">*Asunto</label>
                                                                <input type="text" runat="server" id="iAsuntoNotificacion" class="form-control" required onkeyup="this.value = this.value.toUpperCase();">
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4 col-12">
                                                            <div class="form-group">
                                                                <label for="last-name-column">*SMTP</label>
                                                                <input type="text" runat="server" id="iSMTPNotificacion" class="form-control" required>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4 col-12">
                                                            <div class="form-group">
                                                                <label for="last-name-column">*Puerto</label>
                                                                <input type="number" runat="server" id="iPuertoNotificacion" class="form-control">
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="clearfix">
                                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                            <ContentTemplate>
                                                                <asp:Button CssClass="btn btn-primary float-right" type="submit" ID="btnRegistroNotificacion" runat="server" Text="Registrar" OnClick="btnRegistroNotificacion_Click" />
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
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
                                                </asp:Panel>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="upEmpresaF" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Panel ID="pnlEmpresaF" runat="server" Visible="false">
                                <div class="col-md-6">
                                    <h5 class="card-title">Datos Empresa</h5>
                                    <div class="row">
                                        <div class="col-12">
                                            <ul class="nav nav-pills mb-3" id="pills-tab" role="tablist">
                                                <li class="nav-item">
                                                    <asp:LinkButton ID="lkbEditaEmpresa" runat="server" CssClass="nav-item nav-link" role="tab" aria-selected="true" OnClick="lkbEditaEmpresa_Click">Editar
                                                    </asp:LinkButton>
                                                    <%--<a class="nav-link active" id="home-tab" data-toggle="tab" href="#home" role="tab" aria-controls="home" aria-selected="true">Home</a>--%>
                                                </li>
                                                <li class="nav-item">
                                                    <asp:LinkButton ID="lkbEditaEmpresaDatosFiscales" runat="server" CssClass="nav-item nav-link" role="tab" aria-controls="home" aria-selected="true" OnClick="lkbEditaEmpresaDatosFiscales_Click">Datos Fiscales
                                                    </asp:LinkButton>
                                                </li>
                                            </ul>
                                            <hr />
                                            <div class="tab-content" id="myTabContent">
                                                <asp:Panel ID="pnlEditaEmpresa" runat="server" Visible="false">
                                                    <div class="row">

                                                        <div class="col-md-4 col-12">
                                                            <div class="form-group">
                                                                <label for="username-column" tooltip="Para Notificaciones">*Nombre Comercial</label>
                                                                <input type="text" runat="server" id="iNombreComercial" class="form-control" required onkeyup="this.value = this.value.toUpperCase();">
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4 col-12">
                                                            <div class="form-group">
                                                                <label for="first-name-column">*Correo Electrónico</label>
                                                                <input type="email" runat="server" id="iCorreoElectronicoEmpresa" class="form-control" required>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4 col-12">
                                                            <div class="form-group">
                                                                <label for="last-name-column">*Teléfono</label>
                                                                <input type="text" runat="server" id="iTelefonoEmpresa" class="form-control" required>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 col-12">
                                                            <div class="form-group">
                                                                <label for="last-name-column">*Calle y Numero</label>
                                                                <input type="text" runat="server" id="iCalleNumEmpresa" class="form-control" required onkeyup="this.value = this.value.toUpperCase();">
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <asp:UpdatePanel ID="upPage" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <div class="row">
                                                                <div class="col-md-6 mb-1">
                                                                    <div class="input-group mb-3">
                                                                        <span class="input-group-text" id="basic-addon1">
                                                                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-search">
                                                                                <circle cx="11" cy="11" r="8"></circle><line x1="21" y1="21" x2="16.65" y2="16.65"></line></svg></span>
                                                                        <input type="text" class="form-control" runat="server" id="iCPEmpresa" placeholder="*Código Postal" aria-label="Recipient's username" aria-describedby="button-addon2" required>
                                                                        <asp:LinkButton ID="lkbCP" runat="server" CssClass="btn btn-outline-secondary" TabIndex="5" OnClick="lkbCP_Click">Buscar
                                                                        </asp:LinkButton>
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
                                                    <div class="clearfix">
                                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                            <ContentTemplate>
                                                                <asp:Button CssClass="btn btn-primary float-right" type="submit" ID="btnRegistrarEmpresa" runat="server" Text="Registrar" OnClick="btnRegistrarEmpresa_Click" />
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </asp:Panel>

                                                <asp:Panel ID="pnlEditaEmpresaDatosFiscales" runat="server" Visible="false">
                                                    <div class="row">
                                                        <div class="col-md-4 col-12">
                                                            <div class="form-group">
                                                                <label for="username-column" tooltip="Para Notificaciones">*RFC</label>
                                                                <input type="text" runat="server" id="iRFCDatosFiscales" class="form-control" required onkeyup="this.value = this.value.toUpperCase();">
                                                            </div>
                                                        </div>
                                                        <div class="col-md-8 col-12">
                                                            <div class="form-group">
                                                                <label for="username-column" tooltip="Para Notificaciones">*Razon Social</label>
                                                                <input type="text" runat="server" id="iRazonSocialDatosFiscales" class="form-control" required onkeyup="this.value = this.value.toUpperCase();">
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6 col-12">
                                                            <div class="form-group">
                                                                <label for="first-name-column">*Correo Electrónico</label>
                                                                <input type="email" runat="server" id="iCorreoElectronicoDatosFiscales" class="form-control" required>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6 col-12">
                                                            <div class="form-group">
                                                                <label for="last-name-column">*Teléfono</label>
                                                                <input type="text" runat="server" id="iTelefonoDatosFiscales" class="form-control" required>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 col-12">
                                                            <div class="form-group">
                                                                <label for="last-name-column">*Calle y Numero</label>
                                                                <input type="text" runat="server" id="iCalleNumeroDatosFiscales" class="form-control" required onkeyup="this.value = this.value.toUpperCase();">
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <asp:UpdatePanel ID="upCPDatosFiscales" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <div class="row">
                                                                <div class="col-md-6 mb-1">
                                                                    <div class="input-group mb-3">
                                                                        <span class="input-group-text" id="basic-addon1">
                                                                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-search">
                                                                                <circle cx="11" cy="11" r="8"></circle><line x1="21" y1="21" x2="16.65" y2="16.65"></line></svg></span>
                                                                        <input type="text" class="form-control" runat="server" id="iCPDatosFiscales" placeholder="*Código Postal" aria-label="Recipient's username" aria-describedby="button-addon2" required>
                                                                        <asp:LinkButton ID="lkbCPDatosFiscales" runat="server" CssClass="btn btn-outline-secondary" TabIndex="5" OnClick="lkbCPDatosFiscales_Click">Buscar
                                                                        </asp:LinkButton>
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <div class="form-group">
                                                                        <select class="form-control" runat="server" id="iColoniaDatosFiscales" required="required" tabindex="6"></select>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-md-6">
                                                                    <div class="form-group">
                                                                        <input type="text" class="form-control" runat="server" id="iMunicipioDatosFiscales" placeholder="Municipio" disabled="disabled" />
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6">
                                                                    <div class="form-group">
                                                                        <input type="text" class="form-control" runat="server" id="iEstadoDatosFiscales" placeholder="Estado" disabled="disabled" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    <div class="clearfix">
                                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                            <ContentTemplate>
                                                                <asp:Button CssClass="btn btn-primary float-right" type="submit" ID="btnRegistrarDatosFiscales" runat="server" Text="Registrar" OnClick="btnRegistrarDatosFiscales_Click" />
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </asp:Panel>

                                                <div class="tab-pane fade" id="contact" role="tabpanel" aria-labelledby="contact-tab">...</div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="upUsuariosF" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Panel ID="pnlUsuarios" runat="server" Visible="false">
                                <div class="col-md-12">
                                    <h5 class="card-title">Control Usuarios</h5>
                                    <div class="row">
                                        <div class="col-12">
                                            <hr />
                                            <div class="tab-content" id="myTabContent">
                                                <asp:Panel ID="pnlAgregaUsuarios" runat="server" Visible="true">
                                                    <div class="row">
                                                        <asp:UpdatePanel ID="upGridUsuarios" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <asp:GridView ID="gvGridUsuarios" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvGridUsuarios_RowDataBound"
                                                                    DataKeyNames="UsuarioID" OnRowEditing="gvGridUsuarios_RowEditing" OnRowCancelingEdit="gvGridUsuarios_RowCancelingEdit" PageSize="3" AllowPaging="true" OnPageIndexChanging="gvGridUsuarios_PageIndexChanging"
                                                                    OnRowUpdating="gvGridUsuarios_RowUpdating" EmptyDataText="No records has been added." CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvGridUsuarios_SelectedIndexChanged">
                                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                                                                    <Columns>
                                                                        <asp:BoundField DataField="CodigoUsuario" HeaderText="Codigo Usuario"></asp:BoundField>
                                                                        <asp:BoundField DataField="Nombres" HeaderText="Nombres"></asp:BoundField>
                                                                        <asp:BoundField DataField="ApellidoPaterno" HeaderText="Apellido Paterno"></asp:BoundField>
                                                                        <asp:BoundField DataField="ApellidoMaterno" HeaderText="Apellid Materno"></asp:BoundField>
                                                                        <asp:BoundField DataField="CorreoPersonal" HeaderText="Correo Personal"></asp:BoundField>
                                                                        <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha Registro" DataFormatString="{0:d}"></asp:BoundField>
                                                                    </Columns>
                                                                    <EditRowStyle BackColor="#999999"></EditRowStyle>

                                                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

                                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

                                                                    <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

                                                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

                                                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

                                                                    <SortedAscendingCellStyle BackColor="#E9E7E2"></SortedAscendingCellStyle>

                                                                    <SortedAscendingHeaderStyle BackColor="#506C8C"></SortedAscendingHeaderStyle>

                                                                    <SortedDescendingCellStyle BackColor="#FFFDF8"></SortedDescendingCellStyle>

                                                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE"></SortedDescendingHeaderStyle>
                                                                </asp:GridView>
                                                                <hr />
                                                                <div class="row">

                                                                    <div class="col-md-4 col-12">
                                                                        <div class="form-group">
                                                                            <label for="username-column" tooltip="Para Notificaciones">*Nombre(s)</label>
                                                                            <input type="text" runat="server" id="txtNombresUsuario" class="form-control" required onkeyup="this.value = this.value.toUpperCase();">
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-4 col-12">
                                                                        <div class="form-group">
                                                                            <label for="username-column" tooltip="Para Notificaciones">*Apellido Paterno</label>
                                                                            <input type="text" runat="server" id="txtApellidoPaternoUsuario" class="form-control" required onkeyup="this.value = this.value.toUpperCase();">
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-4 col-12">
                                                                        <div class="form-group">
                                                                            <label for="username-column" tooltip="Para Notificaciones">*Apellido Paterno</label>
                                                                            <input type="text" runat="server" id="txtApellidoMaternoUsuario" class="form-control" required onkeyup="this.value = this.value.toUpperCase();">
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-4 col-12">
                                                                        <div class="form-group">
                                                                            <label for="first-name-column">*Correo Electrónico</label>
                                                                            <input type="email" runat="server" id="iCorreoElectronicoUsuarios" class="form-control" required>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-4 col-12">
                                                                        <div class="form-group">
                                                                            <label for="last-name-column">*Teléfono</label>
                                                                            <input type="text" runat="server" id="iTelefonoUsuarios" class="form-control" required>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-md-12 col-12">
                                                                        <div class="form-group">
                                                                            <label for="last-name-column">*Calle y Numero</label>
                                                                            <input type="text" runat="server" id="iCalleNumUsuarios" class="form-control" required onkeyup="this.value = this.value.toUpperCase();">
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <div class="row">
                                                                            <div class="col-md-6 mb-1">
                                                                                <div class="input-group mb-3">
                                                                                    <span class="input-group-text" id="basic-addon1">
                                                                                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-search">
                                                                                            <circle cx="11" cy="11" r="8"></circle><line x1="21" y1="21" x2="16.65" y2="16.65"></line></svg></span>
                                                                                    <input type="text" class="form-control" runat="server" id="iCPUsuarios" placeholder="*Código Postal" aria-label="Recipient's username" aria-describedby="button-addon2" required>
                                                                                    <asp:LinkButton ID="lkbCPUsuarios" runat="server" CssClass="btn btn-outline-secondary" TabIndex="5" OnClick="lkbCPUsuarios_Click">Buscar
                                                                                    </asp:LinkButton>
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-md-6">
                                                                                <div class="form-group">
                                                                                    <select class="form-control" runat="server" id="iColoniaUsuarios" required="required" tabindex="6"></select>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="row">
                                                                            <div class="col-md-6">
                                                                                <div class="form-group">
                                                                                    <input type="text" class="form-control" runat="server" id="iMunicipioUsuarios" placeholder="Municipio" disabled="disabled" />
                                                                                </div>
                                                                            </div>
                                                                            <div class="col-md-6">
                                                                                <div class="form-group">

                                                                                    <input type="text" class="form-control" runat="server" id="iEstadoUsuarios" placeholder="Estado" disabled="disabled" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                                <div class="clearfix">
                                                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:Button CssClass="btn btn-primary float-right" type="submit" ID="btnRegistrarUsuarios" runat="server" Text="Registrar" OnClick="btnRegistrarEmpresa_Click" />
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </asp:Panel>

                                                <div class="tab-pane fade" id="contact" role="tabpanel" aria-labelledby="contact-tab">...</div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <footer>
                    <div class="footer clearfix mb-0 text-muted">
                        <div class="float-left">
                            <p>2020 &copy; Intelimundo</p>
                        </div>
                        <div class="float-right">
                            <p>
                                Desarrollador <span class="text-danger"><i data-feather="heart"></i></span>por <a
                                    href="http://iides.info">iIDes</a>
                            </p>
                        </div>
                    </div>
                </footer>
            </div>
        </div>

        <asp:Button ID="btnShowPopup" runat="server" Style="display: none" />
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
    <script src="assets/vendors/perfect-scrollbar/perfect-scrollbar.min.js"></script>
    <script src="assets/js/app.js"></script>

    <script src="assets/vendors/chartjs/Chart.min.js"></script>
    <script src="assets/vendors/apexcharts/apexcharts.min.js"></script>
    <script src="assets/js/pages/dashboard.js"></script>

    <script src="assets/js/main.js"></script>
</body>
</html>