using System;
using System.Globalization;
using System.Linq;
using WEBhecsa.Models;

namespace WEBhecsa.Clases
{
    public class ControlEmpresa
    {
        public static bool AltaEmpresaRegistro(string NombreEmpresa)
        {
            string strNombreEmpresa = string.Empty;

            TextInfo CINombreEmpresa = new CultureInfo("es-MX", false).TextInfo;

            strNombreEmpresa = CINombreEmpresa.ToTitleCase(NombreEmpresa.ToLower());

            try
            {
                var iRegistro = new DatosHECSAEntities();

                var iCorporativos = new Empresas
                {
                    EmpresaID = Guid.NewGuid(),
                    NombreEmpresa = strNombreEmpresa,
                    EstatusRegistroID = 1,
                    FechaRegistro = DateTime.Now
                };

                iRegistro.Empresas.Add(iCorporativos);
                iRegistro.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

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

        public static bool ActualizaEmpresa(string iNombreComercial, string iCorreoElectronicoEmpresa, string iTelefonoEmpresa, string iCalleNumEmpresa, string iCPEmpresa, string sColonia)
        {
            string striNombreComercial = string.Empty, striCalleNumEmpresa = string.Empty;

            TextInfo CINombreEmpresa = new CultureInfo("es-MX", false).TextInfo;
            TextInfo CICalleNum = new CultureInfo("es-MX", false).TextInfo;

            striNombreComercial = CINombreEmpresa.ToTitleCase(iNombreComercial.ToLower());
            striCalleNumEmpresa = CICalleNum.ToTitleCase(iCalleNumEmpresa.ToLower());

            Guid iEmpresaID, iUbicacionID;
            using (var Modelo = new DatosHECSAEntities())
            {
                var iModeloU = (from a in Modelo.Empresas
                                select a).ToList();

                iEmpresaID = Guid.Parse(iModeloU[0].EmpresaID.ToString());
            }

            var iRegistro = new DatosHECSAEntities();

            using (var Modelo = new DatosHECSAEntities())
            {
                var iModelo = (from a in Modelo.Empresas
                               join b in Modelo.Ubicaciones on a.UbicacionID equals b.UbicacionID
                               select a).ToList();

                iUbicacionID = Guid.NewGuid();

                if (iModelo.Count == 0)
                {
                    var iUbicaciones = new Ubicaciones
                    {
                        UbicacionID = iUbicacionID,
                        TipoUbicacionID = 1,
                        CalleNumero = iCalleNumEmpresa,
                        CodigoPostal = iCPEmpresa,
                        ColoniaID = sColonia,
                        EstatusRegistroID = 1,
                        FechaRegistro = DateTime.Now
                    };

                    iRegistro.Ubicaciones.Add(iUbicaciones);
                    iRegistro.SaveChanges();
                    Modelo.SaveChanges();
                }
                else
                {
                    iUbicacionID = Guid.Parse(iModelo[0].UbicacionID.ToString());
                    var iModeloU = (from c in Modelo.Ubicaciones
                                    where c.UbicacionID == iUbicacionID
                                    select c).FirstOrDefault();

                    iModeloU.CalleNumero = iCalleNumEmpresa;
                    iModeloU.CodigoPostal = iCPEmpresa;
                    iModeloU.ColoniaID = sColonia;

                    Modelo.SaveChanges();
                }
            }

            using (var Modelo = new DatosHECSAEntities())
            {
                var iModelo = (from c in Modelo.Empresas
                               select c).FirstOrDefault();

                iModelo.NombreEmpresa = striNombreComercial;
                iModelo.CorreoElectronico = iCorreoElectronicoEmpresa;
                iModelo.Telefono = iTelefonoEmpresa;
                iModelo.UbicacionID = iUbicacionID;

                Modelo.SaveChanges();
            }

            return true;
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

        internal static bool AgregaEmpresaDatosFiscales(string iRFCDatosFiscales, string iRazonSocialDatosFiscales, string iCorreoElectronicoDatosFiscales, string iTelefonoDatosFiscales, string iCalleNumeroDatosFiscales, string iCPDatosFiscales, string iColoniaDatosFiscales)
        {
            string striRazonSocialDatosFiscales = string.Empty, striCalleNumeroDatosFiscales = string.Empty;

            TextInfo CINombreEmpresa = new CultureInfo("es-MX", false).TextInfo;
            TextInfo CICalleNum = new CultureInfo("es-MX", false).TextInfo;

            striRazonSocialDatosFiscales = CINombreEmpresa.ToTitleCase(iRazonSocialDatosFiscales.ToLower());
            striCalleNumeroDatosFiscales = CICalleNum.ToTitleCase(iCalleNumeroDatosFiscales.ToLower());

            Guid iEmpresaID, iUbicacionID;
            using (var Modelo = new DatosHECSAEntities())
            {
                var iModeloU = (from a in Modelo.Empresas
                                select a).ToList();

                iEmpresaID = Guid.Parse(iModeloU[0].EmpresaID.ToString());
            }

            iUbicacionID = Guid.NewGuid();

            var iRegistro = new DatosHECSAEntities();

            var iUbicaciones = new Ubicaciones
            {
                UbicacionID = iUbicacionID,
                TipoUbicacionID = 2,
                CalleNumero = striCalleNumeroDatosFiscales,
                CodigoPostal = iCPDatosFiscales,
                ColoniaID = iColoniaDatosFiscales,
                EstatusRegistroID = 1,
                FechaRegistro = DateTime.Now
            };

            iRegistro.Ubicaciones.Add(iUbicaciones);

            var iDatosFiscales = new DatosFiscales
            {
                DatoFiscalID = Guid.NewGuid(),
                RFC = iRFCDatosFiscales,
                RazonSocial = striRazonSocialDatosFiscales,
                CorreoElectronico = iCorreoElectronicoDatosFiscales,
                Telefono = iTelefonoDatosFiscales,
                UbicacionID = iUbicacionID,
                EstatusRegistroID = 1,
                FechaRegistro = DateTime.Now,
                EmpresaID = iEmpresaID
            };

            iRegistro.DatosFiscales.Add(iDatosFiscales);
            iRegistro.SaveChanges();

            using (var Modelo = new DatosHECSAEntities())
            {
                var iModelo = (from c in Modelo.DatosFiscales
                               select c).FirstOrDefault();

                iModelo.RFC = iRFCDatosFiscales;
                iModelo.RazonSocial = striRazonSocialDatosFiscales;
                iModelo.CorreoElectronico = iColoniaDatosFiscales;
                iModelo.Telefono = iTelefonoDatosFiscales;

                Modelo.SaveChanges();
            }

            return true;
        }

        internal static bool ActualizaEmpresaDatosFiscales(string iRFCDatosFiscales, string iRazonSocialDatosFiscales, string iCorreoElectronicoDatosFiscales, string iTelefonoDatosFiscales, string iCalleNumeroDatosFiscales, string iCPDatosFiscales, string iColoniaDatosFiscales)
        {
            string striRazonSocialDatosFiscales = string.Empty, striCalleNumeroDatosFiscales = string.Empty;

            TextInfo CINombreEmpresa = new CultureInfo("es-MX", false).TextInfo;
            TextInfo CICalleNum = new CultureInfo("es-MX", false).TextInfo;

            striRazonSocialDatosFiscales = CINombreEmpresa.ToTitleCase(iRazonSocialDatosFiscales.ToLower());
            striCalleNumeroDatosFiscales = CICalleNum.ToTitleCase(iCalleNumeroDatosFiscales.ToLower());

            Guid iEmpresaID, iUbicacionID;
            using (var Modelo = new DatosHECSAEntities())
            {
                var iModelo = (from c in Modelo.Empresas
                               select c).FirstOrDefault();
                iEmpresaID = iModelo.EmpresaID;
               

                var iModeloDF = (from c in Modelo.DatosFiscales
                                 where c.EmpresaID == iEmpresaID
                                 select c).FirstOrDefault();
                iUbicacionID = Guid.Parse(iModeloDF.UbicacionID.ToString());

                iModeloDF.RFC = iRFCDatosFiscales;
                iModeloDF.RazonSocial = striRazonSocialDatosFiscales;
                iModeloDF.CorreoElectronico = iCorreoElectronicoDatosFiscales;
                iModeloDF.Telefono = iTelefonoDatosFiscales;

                var iModeloU = (from c in Modelo.Ubicaciones
                                where c.UbicacionID == iUbicacionID
                                select c).FirstOrDefault();

                iModeloU.CalleNumero = iCalleNumeroDatosFiscales;
                iModeloU.CodigoPostal = iCPDatosFiscales;
                iModeloU.ColoniaID = iColoniaDatosFiscales;

                Modelo.SaveChanges();
            }
            return true;
        }
    }
}