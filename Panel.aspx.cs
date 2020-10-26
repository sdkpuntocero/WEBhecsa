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
            pnlUsuarios.Visible = false;
            upUsuariosF.Update();
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
            pnlUsuarios.Visible = false;
            upUsuariosF.Update();
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

        protected void lkbCPDatosFiscales_Click(object sender, EventArgs e)
        {
            using (DataSet ListCP = CodigoPostal.FiltroCP(iCPDatosFiscales.Value))
            {
                if (ListCP.Tables[0].Rows.Count == 0)
                {
                    iColoniaDatosFiscales.Items.Clear();

                    iColoniaDatosFiscales.Items.Insert(0, new ListItem("Colonia", string.Empty));

                    iMunicipioDatosFiscales.Value = string.Empty;
                    iEstadoDatosFiscales.Value = string.Empty;
                    iColoniaDatosFiscales.Attributes.Add("required", "required");
                }
                else
                {
                    iColoniaDatosFiscales.DataSource = ListCP;
                    iColoniaDatosFiscales.DataTextField = "Colonia";
                    iColoniaDatosFiscales.DataValueField = "ColoniaID";
                    iColoniaDatosFiscales.DataBind();

                    iMunicipioDatosFiscales.Value = ListCP.Tables[0].Rows[0]["Municipio"].ToString();
                    iEstadoDatosFiscales.Value = ListCP.Tables[0].Rows[0]["Estado"].ToString();
                    iColoniaDatosFiscales.Attributes.Add("required", string.Empty);
                    iColoniaDatosFiscales.Items.Insert(0, new ListItem("Colonia", string.Empty));
                }
            }

            iColoniaDatosFiscales.Focus();
            upCPDatosFiscales.Update();
        }

        protected void btnRegistrarDatosFiscales_Click(object sender, EventArgs e)
        {
            string striRFCDatosFiscales = Request.Form["iRFCDatosFiscales"];
            string striRazonSocialDatosFiscales = Request.Form["iRazonSocialDatosFiscales"];
            string striCorreoElectronicoDatosFiscales = Request.Form["iCorreoElectronicoDatosFiscales"];
            string striTelefonoDatosFiscales = Request.Form["iTelefonoDatosFiscales"];
            string striCalleNumeroDatosFiscales = Request.Form["iCalleNumeroDatosFiscales"];
            string striCPDatosFiscales = Request.Form["iCPDatosFiscales"];
            string striColoniaDatosFiscales = Request.Form["iColoniaDatosFiscales"];
            Guid iEmpresaID, iUbicacionID;
            using (var Modelo = new DatosHECSAEntities())
            {
                var iModeloU = (from a in Modelo.DatosFiscales
                                select a).ToList();

                if (iModeloU.Count == 0)
                {
                    if (ControlEmpresa.AgregaEmpresaDatosFiscales(striRFCDatosFiscales, striRazonSocialDatosFiscales, striCorreoElectronicoDatosFiscales, striTelefonoDatosFiscales, striCalleNumeroDatosFiscales, striCPDatosFiscales, striColoniaDatosFiscales))
                    {
                        iRFCDatosFiscales.Value = String.Empty;
                        iRazonSocialDatosFiscales.Value = String.Empty;
                        iCorreoElectronicoDatosFiscales.Value = String.Empty;
                        iTelefonoDatosFiscales.Value = String.Empty;
                        iCalleNumeroDatosFiscales.Value = String.Empty;
                        iCPDatosFiscales.Value = String.Empty;
                        iColoniaDatosFiscales.Value = String.Empty;

                        lblSuccess.Text = "Datos actualizados con éxito";
                        upModal.Update();
                        modSuccess.Show();
                    }
                }
                else
                {
                    if (ControlEmpresa.ActualizaEmpresaDatosFiscales(striRFCDatosFiscales, striRazonSocialDatosFiscales, striCorreoElectronicoDatosFiscales, striTelefonoDatosFiscales, striCalleNumeroDatosFiscales, striCPDatosFiscales, striColoniaDatosFiscales))
                    {
                        iRFCDatosFiscales.Value = String.Empty;
                        iRazonSocialDatosFiscales.Value = String.Empty;
                        iCorreoElectronicoDatosFiscales.Value = String.Empty;
                        iTelefonoDatosFiscales.Value = String.Empty;
                        iCalleNumeroDatosFiscales.Value = String.Empty;
                        iCPDatosFiscales.Value = String.Empty;
                        iColoniaDatosFiscales.Value = String.Empty;

                        lblSuccess.Text = "Datos actualizados con éxito";
                        upModal.Update();
                        modSuccess.Show();
                    }
                }
            }
        }

        protected void lkbEditaEmpresa_Click(object sender, EventArgs e)
        {
            pnlEditaEmpresaDatosFiscales.Visible = false;
            pnlEditaEmpresa.Visible = true;
            upEmpresaF.Update();
        }

        protected void lkbEditaEmpresaDatosFiscales_Click(object sender, EventArgs e)
        {
            CargaCPDatosFiscales();
            pnlEditaEmpresa.Visible = false;
            pnlEditaEmpresaDatosFiscales.Visible = true;
            upEmpresaF.Update();
        }

        private void CargaCPDatosFiscales()
        {
            iColoniaDatosFiscales.Items.Clear();
            iColoniaDatosFiscales.Items.Insert(0, new ListItem("Seleccionar", string.Empty));

            try
            {
                using (DatosHECSAEntities Modelo = new DatosHECSAEntities())
                {
                    var iModelo = (from a in Modelo.DatosFiscales
                                   select a).FirstOrDefault();

                    if (iModelo != null)
                    {
                        iRFCDatosFiscales.Value = iModelo.RFC;
                        iRazonSocialDatosFiscales.Value = iModelo.RazonSocial;
                        iCorreoElectronicoDatosFiscales.Value = iModelo.CorreoElectronico;
                        iTelefonoDatosFiscales.Value = iModelo.Telefono;

                        var iModeloU = (from a in Modelo.DatosFiscales
                                        join b in Modelo.Ubicaciones on a.UbicacionID equals b.UbicacionID
                                        select new
                                        {
                                            b.CalleNumero,
                                            b.CodigoPostal,
                                            b.ColoniaID
                                        }).FirstOrDefault();

                        iCalleNumeroDatosFiscales.Value = iModeloU.CalleNumero;

                        using (DataSet ListCP = CodigoPostal.FiltroCP(iModeloU.CodigoPostal))
                        {
                            if (ListCP.Tables[0].Rows.Count == 0)
                            {
                                iColoniaDatosFiscales.Items.Clear();

                                iColoniaDatosFiscales.Items.Insert(0, new ListItem("Colonia", string.Empty));

                                iMunicipioDatosFiscales.Value = string.Empty;
                                iEstadoDatosFiscales.Value = string.Empty;
                                iColoniaDatosFiscales.Attributes.Add("required", "required");
                            }
                            else
                            {
                                iColoniaDatosFiscales.DataSource = ListCP;
                                iColoniaDatosFiscales.DataTextField = "Colonia";
                                iColoniaDatosFiscales.DataValueField = "ColoniaID";
                                iColoniaDatosFiscales.DataBind();

                                iMunicipioDatosFiscales.Value = ListCP.Tables[0].Rows[0]["Municipio"].ToString();
                                iEstadoDatosFiscales.Value = ListCP.Tables[0].Rows[0]["Estado"].ToString();
                                iColoniaDatosFiscales.Attributes.Add("required", string.Empty);
                                iColoniaDatosFiscales.Value = iModeloU.ColoniaID;
                                iCPDatosFiscales.Value = iModeloU.CodigoPostal;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                iColoniaDatosFiscales.Items.Clear();

                iColoniaDatosFiscales.Items.Insert(0, new ListItem("Colonia", string.Empty));

                iMunicipioDatosFiscales.Value = string.Empty;
                iEstadoDatosFiscales.Value = string.Empty;
                iColoniaDatosFiscales.Attributes.Add("required", "required");
            }
        }

        protected void lkbUsuarios_Click(object sender, EventArgs e)
        {
            this.BindGridUsuarios();
            CargaCPUsuarios();
            pnlResumen.Visible = false;
            upResumen.Update();
            pnlEmpresaF.Visible = false;
            upEmpresaF.Update();
            pnlNotificacionesF.Visible = false;
            upNotificacionesF.Update();
            pnlUsuarios.Visible = true;
            upUsuariosF.Update();
        }

        private void CargaCPUsuarios()
        {
            iColoniaUsuarios.Items.Clear();
            iColoniaUsuarios.Items.Insert(0, new ListItem("Seleccionar", string.Empty));

            try
            {
                using (DatosHECSAEntities Modelo = new DatosHECSAEntities())
                {
                    var iModeloU = (from a in Modelo.Usuarios
                                    join b in Modelo.Ubicaciones on a.UbicacionID equals b.UbicacionID
                                    where a.UsuarioID != fUsuarioID
                                    select new
                                    {
                                        b.CalleNumero,
                                        b.CodigoPostal,
                                        b.ColoniaID
                                    }).FirstOrDefault();
                    if (iModeloU != null)
                    {
                        using (DataSet ListCP = CodigoPostal.FiltroCP(iModeloU.CodigoPostal))
                        {
                            if (ListCP.Tables[0].Rows.Count == 0)
                            {
                                iColoniaUsuarios.Items.Clear();

                                iColoniaUsuarios.Items.Insert(0, new ListItem("Colonia", string.Empty));

                                iMunicipioUsuarios.Value = string.Empty;
                                iEstadoUsuarios.Value = string.Empty;
                                iColoniaUsuarios.Attributes.Add("required", "required");
                            }
                            else
                            {
                                iColoniaUsuarios.DataSource = ListCP;
                                iColoniaUsuarios.DataTextField = "Colonia";
                                iColoniaUsuarios.DataValueField = "ColoniaID";
                                iColoniaUsuarios.DataBind();

                                iMunicipioUsuarios.Value = ListCP.Tables[0].Rows[0]["Municipio"].ToString();
                                iEstadoUsuarios.Value = ListCP.Tables[0].Rows[0]["Estado"].ToString();
                                iColoniaUsuarios.Attributes.Add("required", string.Empty);
                                iColoniaUsuarios.Value = iModeloU.ColoniaID;
                                iCPUsuarios.Value = iModeloU.CodigoPostal;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                iColoniaUsuarios.Items.Clear();

                iColoniaUsuarios.Items.Insert(0, new ListItem("Colonia", string.Empty));

                iMunicipioUsuarios.Value = string.Empty;
                iEstadoUsuarios.Value = string.Empty;
                iColoniaUsuarios.Attributes.Add("required", "required");
            }
        }

        protected void lkbProveedores_Click(object sender, EventArgs e)
        {
        }

        protected void lkbProductos_Click(object sender, EventArgs e)
        {
        }

        protected void lkbCPUsuarios_Click(object sender, EventArgs e)
        {
            using (DataSet ListCP = CodigoPostal.FiltroCP(iCPUsuarios.Value))
            {
                if (ListCP.Tables[0].Rows.Count == 0)
                {
                    iColoniaUsuarios.Items.Clear();

                    iColoniaUsuarios.Items.Insert(0, new ListItem("Colonia", string.Empty));

                    iMunicipioUsuarios.Value = string.Empty;
                    iEstadoUsuarios.Value = string.Empty;
                    iColoniaUsuarios.Attributes.Add("required", "required");
                }
                else
                {
                    iColoniaUsuarios.DataSource = ListCP;
                    iColoniaUsuarios.DataTextField = "Colonia";
                    iColoniaUsuarios.DataValueField = "ColoniaID";
                    iColoniaUsuarios.DataBind();

                    iMunicipio.Value = ListCP.Tables[0].Rows[0]["Municipio"].ToString();
                    iEstado.Value = ListCP.Tables[0].Rows[0]["Estado"].ToString();
                    iColoniaUsuarios.Attributes.Add("required", string.Empty);
                    iColoniaUsuarios.Items.Insert(0, new ListItem("Colonia", string.Empty));
                }
            }

            iColoniaUsuarios.Focus();
            upPage.Update();
        }

        protected void lkbEditaNotificaciones_Click(object sender, EventArgs e)
        {
            pnlEditaNotificaciones.Visible = true;
            upNotificacionesF.Update();
        }

     

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int customerId = Convert.ToInt32(gvGridUsuarios.DataKeys[e.RowIndex].Values[0]);

            using (DatosHECSAEntities Modelo = new DatosHECSAEntities())
            {
                Usuarios deptDelete = Modelo.Usuarios.Find(customerId);
                Modelo.Usuarios.Remove(deptDelete);
                Modelo.SaveChanges();
            }
            this.BindGridUsuarios();
        }


   
  

        private void BindGridUsuarios()
        {
            using (DatosHECSAEntities Modelo = new DatosHECSAEntities())
            {
                var iModelo = (from a in Modelo.Usuarios
                               select new
                               {
                                   a.UsuarioID,
                                   a.CodigoUsuario,
                                   a.Nombres,
                                   a.ApellidoPaterno,
                                   a.ApellidoMaterno,
                                   a.CorreoPersonal,
                                   a.FechaRegistro
                               }).ToList();

                gvGridUsuarios.DataSource = iModelo;
                gvGridUsuarios.DataBind();
            }
        }

        protected void gvGridUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != gvGridUsuarios.EditIndex)
            //{
            //    (e.Row.Cells[6].Controls[0] as LinkButton).Attributes["onclick"] = "return confirm('¿Quieres actualizar esta fila?');";
            //}
        }

        protected void gvGridUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvGridUsuarios.EditIndex = e.NewEditIndex;
            this.BindGridUsuarios();
        }

        protected void gvGridUsuarios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvGridUsuarios.EditIndex = -1;
            this.BindGridUsuarios();
        }

        protected void gvGridUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGridUsuarios.PageIndex = e.NewPageIndex;
            this.BindGridUsuarios();
        }

        protected void gvGridUsuarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvGridUsuarios.Rows[e.RowIndex];
            Guid UsuarioId = Guid.Parse(gvGridUsuarios.DataKeys[e.RowIndex].Values[0].ToString());

            string strNombres = (row.FindControl("txtNombres") as TextBox).Text;
            string strApellidoPaterno = (row.FindControl("txtApellidoPaterno") as TextBox).Text;
            string strApellidoMaterno = (row.FindControl("txtApellidoMaterno") as TextBox).Text;
            string strCorreoPersonal = (row.FindControl("txtCorreoPersonal") as TextBox).Text;

            using (DatosHECSAEntities Modelo = new DatosHECSAEntities())
            {
                var iModelo = (from c in Modelo.Usuarios
                               where c.UsuarioID == UsuarioId
                               select c).FirstOrDefault();

                iModelo.Nombres = strNombres;
                iModelo.ApellidoPaterno = strApellidoPaterno;
                iModelo.ApellidoMaterno = strApellidoMaterno;
                iModelo.CorreoPersonal = strCorreoPersonal;

                Modelo.SaveChanges();
            }
            this.BindGridUsuarios();

            gvGridUsuarios.EditIndex = -1;
            this.BindGridUsuarios();
        }

        protected void gvGridUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNombresUsuario.Value = gvGridUsuarios.SelectedRow.Cells[1].Text;
            txtApellidoPaternoUsuario.Value = gvGridUsuarios.SelectedRow.Cells[2].Text;
            txtApellidoMaternoUsuario.Value = gvGridUsuarios.SelectedRow.Cells[3].Text;
        }
    }
}