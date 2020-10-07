using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using WEBhecsa.Models;

namespace WEBhecsa.Clases
{
    public class ControlUsuarios
    {
        public static bool AltaUsuario(int i_TipoUsuarioID, int i_PerfilUsuarioID, string Nombre, string Apaterno, string Amaterno, string striEmailPersonal, string striCodigoinvitacion, Guid CorporativoID)
        {
            Guid i_UsuarioID;
            string i_CodigoUsuario = string.Empty, i_nombres = string.Empty, i_apaterno = string.Empty, i_amaterno = string.Empty, i_usuario = string.Empty, i_clave = string.Empty;

            TextInfo CINombre = new CultureInfo("es-MX", false).TextInfo;
            TextInfo CIApaterno = new CultureInfo("es-MX", false).TextInfo;
            TextInfo CIAmaterno = new CultureInfo("es-MX", false).TextInfo;
            TextInfo CICompania = new CultureInfo("es-MX", false).TextInfo;
            TextInfo CICompaniaNombre = new CultureInfo("es-MX", false).TextInfo;

            TextInfo CICalleNum = new CultureInfo("es-MX", false).TextInfo;

            string strNombreUsuario = CINombre.ToTitleCase(Nombre.ToLower());
            string strApaternoUsuario = CIApaterno.ToTitleCase(Apaterno.ToLower());
            string strAmaternoUsuario = CIAmaterno.ToTitleCase(Amaterno.ToLower());

            try
            {
                i_nombres = RemueveCaracteresEspeciales.Acentos(RemueveCaracteresEspeciales.CaracteresEspeciales(Nombre.Trim().ToLower()));
                string[] separados;

                separados = Nombre.Split(" ".ToCharArray());

                i_apaterno = RemueveCaracteresEspeciales.Acentos(RemueveCaracteresEspeciales.CaracteresEspeciales(Apaterno.Trim().ToLower()));
                i_amaterno = RemueveCaracteresEspeciales.Acentos(RemueveCaracteresEspeciales.CaracteresEspeciales(Amaterno.Trim().ToLower()));

                i_usuario = IzquierdaMedioDerecha.Izquierda(i_nombres, 1) + Apaterno.ToLower() + IzquierdaMedioDerecha.Izquierda(i_amaterno, 1);
            }
            catch
            {
                //"Se requiere minimo 2 letras por cada campo(nombre,apellido paterno, apellido materno) para generar el usuario.";
            }

            try
            {
                i_clave = Encrypta.Encrypt("poc123");
                i_UsuarioID = Guid.NewGuid();
                i_CodigoUsuario = GeneraCodigoUsuario();

                var iRegistro = new DatosHECSAEntities();

                var iUsuarios = new Usuarios
                {
                    UsuarioID = i_UsuarioID,
                    TipoUsuarioID = i_TipoUsuarioID,
                    RolUsuarioID = i_PerfilUsuarioID,
                    CodigoUsuario = i_CodigoUsuario,
                    Usuario = i_usuario,
                    Clave = i_clave,
                    Nombres = Nombre,
                    ApellidoPaterno = Apaterno,
                    ApellidoMaterno = Amaterno,
                    CorreoPersonal = striEmailPersonal,
                    EstatusRegistroID = 1,
                    FechaRegistro = DateTime.Now,
                    EmpresaID = CorporativoID
                };
                //var iUsuariosCorporativo = new UsuariosCorporativo
                //{
                //    CorporativoID = CorporativoID,
                //    UsuarioID = i_UsuarioID
                //};

                //Models.Usuarios usuarios = iRegistro.Usuarios.Add(iUsuarios);
                //iRegistro.UsuariosCorporativo.Add(iUsuariosCorporativo);
                //iRegistro.SaveChanges();

                string strBody = EnviarCorreo.Cuerpo("Notificaciones Automaticas", "Alta de Usuario", Nombre + " " + Apaterno + " " + Amaterno, i_usuario, "poc123", "~/html/HtmlTemplate.html", DateTime.Now, "informacion@iides.info");

                using (DatosHECSAEntities Modelo = new DatosHECSAEntities())
                {
                    var iModelo = (from a in Modelo.CorreoNotificacion
                                   select a).FirstOrDefault();

                    string strTitulo = iModelo.Asunto;
                    string strFROM = iModelo.CorreoElectronico;
                    string strUsuario = iModelo.Usuario;
                    string strClave = iModelo.Clave;
                    string strHost = iModelo.SMTP;
                    int strPort = int.Parse(iModelo.Puerto.ToString());

                    if (EnviarCorreo.Enviar(striEmailPersonal, strFROM, strTitulo, strBody, strUsuario, strClave, strHost, strPort, false, true))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private static string GeneraCodigoUsuario()
        {
            string CodigoUsuarios = string.Empty;

            using (DatosHECSAEntities mCodigoUsuarios = new DatosHECSAEntities())
            {
                var iCodigoUsuarios = (from c in mCodigoUsuarios.Usuarios
                                       select c).ToList();

                if (iCodigoUsuarios.Count == 0)
                {
                    CodigoUsuarios = "USR0001";
                }
                else
                {
                    CodigoUsuarios = "USR" + string.Format("{0:0000}", iCodigoUsuarios.Count + 1);
                }
            }

            return CodigoUsuarios;
        }

        public static string GeneraUsuario(string Nombre, string Apaterno, string Amaterno)
        {
            Guid i_UsuarioID, EmpresaID = Guid.NewGuid();
            string i_CodigoUsuario = string.Empty, i_nombres = string.Empty, i_apaterno = string.Empty, i_amaterno = string.Empty, i_usuario = string.Empty, i_clave = string.Empty;
            try
            {
                i_nombres = RemueveCaracteresEspeciales.Acentos(RemueveCaracteresEspeciales.CaracteresEspeciales(Nombre.Trim().ToLower()));
                string[] separados;

                separados = Nombre.Split(" ".ToCharArray());

                i_apaterno = RemueveCaracteresEspeciales.Acentos(RemueveCaracteresEspeciales.CaracteresEspeciales(Apaterno.Trim().ToLower()));
                i_amaterno = RemueveCaracteresEspeciales.Acentos(RemueveCaracteresEspeciales.CaracteresEspeciales(Amaterno.Trim().ToLower()));

                i_usuario = IzquierdaMedioDerecha.Izquierda(i_nombres, 1) + Apaterno.ToLower() + IzquierdaMedioDerecha.Izquierda(i_amaterno, 1);
            }
            catch
            {
                //"Se requiere minimo 2 letras por cada campo(nombre,apellido paterno, apellido materno) para generar el usuario.";
            }

            return i_usuario;
        }

        public static bool ActualizaUsuarioPerfil(Guid iUsuarioID, int intGeneroID, DateTime dtFechaNacimiento, string strCorreoPersonal, string strCelular, string strTelefonoContacto, string strCodigoPostal, string intColoniaID, string strClaveNueva)
        {
            Guid UbicacionID = Guid.NewGuid();

            string ClaveNueva = Encrypta.Encrypt(strClaveNueva);

            using (var Modelo = new DatosHECSAEntities())
            {
                var iModeloU = (from a in Modelo.Usuarios
                                join b in Modelo.Ubicaciones on a.UbicacionID equals b.UbicacionID
                                where a.UsuarioID == iUsuarioID
                                select a).ToList();
                Guid ubicacionIDn = Guid.Parse(iModeloU[0].UbicacionID.ToString());
                if (iModeloU.Count == 0)
                {
                    var ModeloCP = new DatosHECSAEntities();

                    var iModeloCP = new Ubicaciones
                    {
                        UbicacionID = UbicacionID,
                        TipoUbicacionID = 1,
                        CalleNumero = string.Empty,
                        CodigoPostal = strCodigoPostal,
                        ColoniaID = intColoniaID,
                        EstatusRegistroID = 1,
                        FechaRegistro = DateTime.Now,
                    };

                    ModeloCP.Ubicaciones.Add(iModeloCP);
                    ModeloCP.SaveChanges();
                }
                else
                {

                    var iModeloUU = (from c in Modelo.Ubicaciones
                                     where c.UbicacionID == ubicacionIDn
                                     select c).FirstOrDefault();

                    iModeloUU.CalleNumero = string.Empty;
                    iModeloUU.CodigoPostal = strCodigoPostal;
                    iModeloUU.ColoniaID = intColoniaID;
                }


                var iModelo = (from c in Modelo.Usuarios
                               where c.UsuarioID == iUsuarioID
                               select c).FirstOrDefault();

                iModelo.GeneroID = intGeneroID;
                iModelo.FechaNacimiento = dtFechaNacimiento;
                iModelo.CorreoPersonal = strCorreoPersonal;
                iModelo.Celular = strCelular;
                iModelo.TelefonoContacto = strTelefonoContacto;
                iModelo.UbicacionID = ubicacionIDn;
                iModelo.Clave = ClaveNueva;

                Modelo.SaveChanges();
            }
            return true;
        }
    }
}