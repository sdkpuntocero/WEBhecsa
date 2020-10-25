using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using WEBhecsa.Clases;
using WEBhecsa.Models;

namespace WEBhecsa
{
    public partial class Acceso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    try
                    {
             
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

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string strUsuario, strClave, strValClave;

            Guid GuidUsario;
            strUsuario = Request.Form["iUsuario"];
            strClave = Request.Form["iClave"];

            strClave = Encrypta.Encrypt(strClave);

            try

            {
                using (var Modelo = new DatosHECSAEntities())
                {
                    var iModelo = (from a in Modelo.Usuarios
                                   where a.Usuario == strUsuario
                                   select new
                                   {
                                       a.UsuarioID,
                                       a.Clave,
                                   }).ToList();

                    GuidUsario = iModelo[0].UsuarioID;
                    strValClave = iModelo[0].Clave;
                    //string dos = "fGVifCvpWWGgKTZ46axSOQ==";

                    //string pass_de = Encrypta.Decrypt(dos);
                    if (iModelo.Count == 0)
                    {
                        lblSuccess.Text = "Usuario no existe, favor de re-intentar";
                        upModal.Update();
                        modSuccess.Show();
                    }
                    else
                    {
                        if (strClave == strValClave)
                        {
                            HttpCookie usr_cookie = new HttpCookie("UsuarioCookie", GuidUsario.ToString());
                            usr_cookie.Expires = DateTime.Now.AddDays(1);
                            Response.Cookies.Add(usr_cookie);
                            //Session["UsuarioFirmadoID"] = GuidUsario;
                            Response.Redirect("Panel.aspx");
                        }
                        else
                        {
                            lblSuccess.Text = "Contraseña incorrecta, favor de re-intentar";
                            upModal.Update();
                            modSuccess.Show();
                        }
                    }
                }
            }
            catch
            {
                lblSuccess.Text = "Datos incorrectos, favor de re-intentar";
                upModal.Update();
                modSuccess.Show();
            }
        }
    }
}