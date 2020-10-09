using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEBhecsa.Models;

namespace WEBhecsa
{
    public partial class Panel : System.Web.UI.Page
    {
        Guid fUsuarioID;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    try
                    {
                        UsuarioFiltrado();
                        //DatosMateriasTemas();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            catch (Exception)
            {
                Response.Redirect("Acceso.aspx");
            }
        }

        private void UsuarioFiltrado()
        {
            try
            {
                fUsuarioID = Guid.Parse(Request.Cookies["UsuarioCookie"].Value);

                using (DatosHECSAEntities Modelo = new DatosHECSAEntities())
                {
                    var iModelo = (from a in Modelo.Usuarios
                                   join b in Modelo.TiposUsuarios on a.TipoUsuarioID equals b.TipoUsuarioID
                                   join c in Modelo.Empresas on a.EmpresaID equals c.EmpresaID
                                   where a.UsuarioID == fUsuarioID
                                   select new
                                   {
                                       a.Nombres,
                                       a.ApellidoPaterno,
                                       a.ApellidoMaterno,
                                       b.TipoUsuario,
                                       c.NombreEmpresa

                                   }).FirstOrDefault();

                    lblNombreUsuario.Text = iModelo.Nombres;
                    lblNombreApellidos.Text = iModelo.ApellidoPaterno + " " + iModelo.ApellidoMaterno;
                    lblEmpresa.Text = iModelo.NombreEmpresa;
                    //lbl_EstatusUsuario.Text = "Conectad@";
                    //i_EstatusUsuario.Attributes["style"] = "color: green";
                }
            }
            catch
            {
                Response.Redirect("Acceso.aspx");
            }
        }

        protected void lkbNotificaciones_Click(object sender, EventArgs e)
        {
            pnlResumen.Visible = false;
            upResumen.Update();
        }
    }
}