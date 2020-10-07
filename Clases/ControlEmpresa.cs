using System;
using System.Globalization;
using System.Linq;
using WEBhecsa.Models;

namespace WEBhecsa.Clases
{
    public class ControlEmpresa
    {
        public static bool AltaEmpresa(string NombreEmpresa, string CorreoElectronico, string Telefono, string CalleNumero, string d_codigo, string id_asenta_cpcons, Guid CorporativoID)
        {

            string strNombreEmpresa = string.Empty, strCalleNumero = string.Empty;

            TextInfo CINombreEmpresa = new CultureInfo("es-MX", false).TextInfo;
            TextInfo CICalleNum = new CultureInfo("es-MX", false).TextInfo;

            strNombreEmpresa = CINombreEmpresa.ToTitleCase(NombreEmpresa.ToLower());
            strCalleNumero = CICalleNum.ToTitleCase(CalleNumero.ToLower());

            try
            {
                var iRegistro = new DatosHECSAEntities();

                var iCorporativos = new Empresas
                {
                    EmpresaID = CorporativoID,
                    NombreEmpresa = strNombreEmpresa,
                    CorreoElectronico = CorreoElectronico,
                    Telefono = Telefono,
                    EstatusRegistroID = 1,
                    FechaRegistro = DateTime.Now
                };

                var iUbicaciones = new Ubicaciones
                {
                    UbicacionID = CorporativoID,
                    TipoUbicacionID = 3,
                    CalleNumero = CalleNumero,
                    CodigoPostal = d_codigo,
                    ColoniaID = id_asenta_cpcons,
                    EstatusRegistroID = 1,
                    FechaRegistro = DateTime.Now
                };

                iRegistro.Empresas.Add(iCorporativos);
                iRegistro.Ubicaciones.Add(iUbicaciones);
                iRegistro.SaveChanges();


                return true;
            }
            catch (Exception e)
            {
                return false;
            }
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