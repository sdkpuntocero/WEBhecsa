﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DatosHECSAEntities : DbContext
    {
        public DatosHECSAEntities()
            : base("name=DatosHECSAEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CorreoNotificacion> CorreoNotificacion { get; set; }
        public virtual DbSet<DatosFiscales> DatosFiscales { get; set; }
        public virtual DbSet<Empresas> Empresas { get; set; }
        public virtual DbSet<Generos> Generos { get; set; }
        public virtual DbSet<InventariosProductos> InventariosProductos { get; set; }
        public virtual DbSet<MexCP> MexCP { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
        public virtual DbSet<ProveedoresContactos> ProveedoresContactos { get; set; }
        public virtual DbSet<RolesUsuarios> RolesUsuarios { get; set; }
        public virtual DbSet<TiposProveedores> TiposProveedores { get; set; }
        public virtual DbSet<TiposUbicaciones> TiposUbicaciones { get; set; }
        public virtual DbSet<TiposUsuarios> TiposUsuarios { get; set; }
        public virtual DbSet<Ubicaciones> Ubicaciones { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
    }
}
