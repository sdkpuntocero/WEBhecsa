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
    
    public partial class Empresa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empresa()
        {
            this.CorreoNotificacions = new HashSet<CorreoNotificacion>();
            this.DatosFiscales = new HashSet<DatosFiscale>();
            this.Productos = new HashSet<Producto>();
            this.Proveedores = new HashSet<Proveedore>();
            this.Usuarios = new HashSet<Usuario>();
        }
    
        public int EmpresaID { get; set; }
        public string NombreEmpresa { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public Nullable<System.Guid> UbicacionID { get; set; }
        public int EstatusRegistroID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CorreoNotificacion> CorreoNotificacions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatosFiscale> DatosFiscales { get; set; }
        public virtual Ubicacione Ubicacione { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Producto> Productos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proveedore> Proveedores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}