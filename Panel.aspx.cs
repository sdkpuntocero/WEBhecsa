using System;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using WEBhecsa.Clases;
using WEBhecsa.Models;

namespace WEBhecsa
{
    public partial class Panel : System.Web.UI.Page
    {
        private Guid fUsuarioID;

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
            CargaNotificaciones();

            pnlResumen.Visible = false;
            upResumen.Update();
            pnlEmpresaF.Visible = false;
            upEmpresaF.Update();
            pnlNotificacionesF.Visible = true;
            upNotificacionesF.Update();
        }

        private void CargaNotificaciones()
        {
            using (DatosHECSAEntities Modelo = new DatosHECSAEntities())
            {
                var iModelo = (from a in Modelo.CorreoNotificacion
                               select a).FirstOrDefault();

                iCorreoElectronicoNotificacion.Value = iModelo.CorreoElectronico;
                iUsuarioNotificacion.Value = iModelo.Usuario;
                iClaveNotificacion.Value = iModelo.Clave;
                iAsuntoNotificacion.Value = iModelo.Asunto;
                iSMTPNotificacion.Value = iModelo.SMTP;
                iPuertoNotificacion.Value = iModelo.Puerto.ToString();
            }
        }

        protected void btnRegistroNotificacion_Click(object sender, EventArgs e)
        {
            string striCorreoElectronicoNotificacion = Request.Form["iCorreoElectronicoNotificacion"];
            string striUsuarioNotificacion = Request.Form["iUsuarioNotificacion"];
            string striClaveNotificacion = Request.Form["iClaveNotificacion"];
            string striAsuntoNotificacion = Request.Form["iAsuntoNotificacion"];
            string striSMTPNotificacion = Request.Form["iSMTPNotificacion"];
            int striPuertoNotificacion = int.Parse(Request.Form["iPuertoNotificacion"]);

            if (ControlNotificaciones.ActualizaNotificaciones(striCorreoElectronicoNotificacion, striUsuarioNotificacion, striClaveNotificacion, striAsuntoNotificacion, striSMTPNotificacion, striPuertoNotificacion))
            {
                iNombreComercial.Value = String.Empty;
                lblSuccess.Text = "Datos actualizados con éxito";
                upModal.Update();
                modSuccess.Show();
            }
        }

        private void CargaEmpresa()
        {
            sColonia.Items.Clear();
            sColonia.Items.Insert(0, new ListItem("Seleccionar", string.Empty));

            using (DatosHECSAEntities Modelo = new DatosHECSAEntities())
            {
                var iModelo = (from a in Modelo.Empresas
                               select a).FirstOrDefault();

                iNombreComercial.Value = iModelo.NombreEmpresa;
                iCorreoElectronicoEmpresa.Value = iModelo.CorreoElectronico;
                iTelefonoEmpresa.Value = iModelo.Telefono;


                try
                {
                    var iModeloU = (from a in Modelo.Empresas
                                    join b in Modelo.Ubicaciones on a.UbicacionID equals b.UbicacionID
                                    select new
                                    {
                                        b.CalleNumero,
                                        b.CodigoPostal,
                                        b.ColoniaID
                                    }).FirstOrDefault();

                    iCalleNumEmpresa.Value = iModeloU.CalleNumero;

                    using (DataSet ListCP = CodigoPostal.FiltroCP(iModeloU.CodigoPostal))
                    {
                        if (ListCP.Tables[0].Rows.Count == 0)
                        {
                            sColonia.Items.Clear();

                            sColonia.Items.Insert(0, new ListItem("Colonia", string.Empty));

                            iMunicipio.Value = string.Empty;
                            iEstado.Value = string.Empty;
                            sColonia.Attributes.Add("required", "required");
                        }
                        else
                        {
                            sColonia.DataSource = ListCP;
                            sColonia.DataTextField = "Colonia";
                            sColonia.DataValueField = "ColoniaID";
                            sColonia.DataBind();

                            iMunicipio.Value = ListCP.Tables[0].Rows[0]["Municipio"].ToString();
                            iEstado.Value = ListCP.Tables[0].Rows[0]["Estado"].ToString();
                            sColonia.Attributes.Add("required", string.Empty);
                            sColonia.Value = iModeloU.ColoniaID;
                            iCPEmpresa.Value = iModeloU.CodigoPostal;
                        }
                    }
                }
                catch (Exception e)
                {
                    sColonia.Items.Clear();

                    sColonia.Items.Insert(0, new ListItem("Colonia", string.Empty));

                    iMunicipio.Value = string.Empty;
                    iEstado.Value = string.Empty;
                    sColonia.Attributes.Add("required", "required");
                }
            }

        }

        protected void lkbEmpresa_Click(object sender, EventArgs e)
        {
            CargaEmpresa();

            pnlResumen.Visible = false;
            upResumen.Update();
            pnlNotificacionesF.Visible = false;
            upNotificacionesF.Update();
            pnlEmpresaF.Visible = true;
            upEmpresaF.Update();
        }

        protected void lkbCP_Click(object sender, EventArgs e)
        {
            using (DataSet ListCP = CodigoPostal.FiltroCP(iCPEmpresa.Value))
            {
                if (ListCP.Tables[0].Rows.Count == 0)
                {
                    sColonia.Items.Clear();

                    sColonia.Items.Insert(0, new ListItem("Colonia", string.Empty));

                    iMunicipio.Value = string.Empty;
                    iEstado.Value = string.Empty;
                    sColonia.Attributes.Add("required", "required");
                }
                else
                {
                    sColonia.DataSource = ListCP;
                    sColonia.DataTextField = "Colonia";
                    sColonia.DataValueField = "ColoniaID";
                    sColonia.DataBind();

                    iMunicipio.Value = ListCP.Tables[0].Rows[0]["Municipio"].ToString();
                    iEstado.Value = ListCP.Tables[0].Rows[0]["Estado"].ToString();
                    sColonia.Attributes.Add("required", string.Empty);
                    sColonia.Items.Insert(0, new ListItem("Colonia", string.Empty));
                }
            }

            sColonia.Focus();
            upPage.Update();
        }

        protected void btnRegistrarEmpresa_Click(object sender, EventArgs e)
        {
            string striNombreComercial = Request.Form["iNombreComercial"];
            string striCorreoElectronicoEmpresa = Request.Form["iCorreoElectronicoEmpresa"];
            string striTelefonoEmpresa = Request.Form["iTelefonoEmpresa"];
            string striCalleNumEmpresa = Request.Form["iCalleNumEmpresa"];
            string striCPEmpresa = Request.Form["iCPEmpresa"];
            string strsColonia = Request.Form["sColonia"];


            if (ControlEmpresa.ActualizaEmpresa(striNombreComercial, striCorreoElectronicoEmpresa, striTelefonoEmpresa, striCalleNumEmpresa, striCPEmpresa, strsColonia))
            {
                iNombreComercial.Value = String.Empty;
                lblSuccess.Text = "Datos actualizados con éxito";
                upModal.Update();
                modSuccess.Show();
            }
        }
    }
}