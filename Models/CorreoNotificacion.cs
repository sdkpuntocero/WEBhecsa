//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WEBhecsa.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CorreoNotificacion
    {
        public System.Guid CorreoNotificacionID { get; set; }
        public string CorreoElectronico { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string Asunto { get; set; }
        public string SMTP { get; set; }
        public int Puerto { get; set; }
        public int EstatusRegistroID { get; set; }
        public System.DateTime FechaRegistro { get; set; }
        public Nullable<int> EmpresaID { get; set; }
    
        public virtual Empresa Empresa { get; set; }
    }
}
