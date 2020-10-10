using System;
using System.Linq;
using WEBhecsa.Models;

namespace WEBhecsa.Clases
{
    public class ControlNotificaciones
    {
        public static bool ActualizaNotificaciones(string iCorreoElectronicoNotificacion, string iUsuarioNotificacion, string iClaveNotificacion, string iAsuntoNotificacion, string iSMTPNotificacion, int iPuertoNotificacion)
        {
            Guid iEmpresaID;
            using (var Modelo = new DatosHECSAEntities())
            {
                var iModeloU = (from a in Modelo.Empresas
                                select a).ToList();

                iEmpresaID = Guid.Parse(iModeloU[0].EmpresaID.ToString());
            }

            using (var Modelo = new DatosHECSAEntities())
            {

                var iModelo = (from c in Modelo.CorreoNotificacion
                               select c).FirstOrDefault();

                iModelo.CorreoElectronico = iCorreoElectronicoNotificacion;
                iModelo.Usuario = iUsuarioNotificacion;
                iModelo.Clave = iClaveNotificacion;
                iModelo.Asunto = iAsuntoNotificacion;
                iModelo.SMTP = iSMTPNotificacion;
                iModelo.Puerto = iPuertoNotificacion;
                iModelo.EmpresaID = iEmpresaID;

                Modelo.SaveChanges();
            }

            return true;
        }
    }
}