using System;
using System.Web.UI;
using WEBhecsa.Clases;

namespace WEBhecsa
{
    public partial class RegistroInicial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            string striNombreEmpresa = Request.Form["iNombreComercial"];
            string striCorreoElectronicoContacto = Request.Form["iCorreoElectronicoContacto"];
            string striNombreAdministrador = Request.Form["iNombreAdministrador"];
            string striApellidoPaternoAdministrador = Request.Form["iApellidoPaternoAdministrador"];
            string striApellidoMaternoAdministrador = Request.Form["iApellidoMaternoAdministrador"];

            if (ControlEmpresa.AltaEmpresaRegistro(striNombreEmpresa))
            {
                iNombreComercial.Value = String.Empty;
            }
            if (ControlUsuarios.AltaUsuarioRegistro(striNombreAdministrador, striApellidoPaternoAdministrador, striApellidoMaternoAdministrador, striCorreoElectronicoContacto))
            {
                iNombreAdministrador.Value = String.Empty;
                iApellidoPaternoAdministrador.Value = String.Empty;
                iApellidoMaternoAdministrador.Value = String.Empty;
                iCorreoElectronicoContacto.Value = String.Empty;

                lblSuccess.Text = "Datos guardados con éxito, revisa el buzón de tu correo, si no aparece el mensaje de Notificaciones POS Automaticas, busca en tu bandeja de SPAM y selecciónalo como correo seguro ya que seguirán llegando correos de esta cuenta";
                upModal.Update();
                modSuccess.Show();
            }
            else
            {
                lblSuccess.Text = "Err.";
                upModal.Update();
                modSuccess.Show();
            }
        }

       
    }
}