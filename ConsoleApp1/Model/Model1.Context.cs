//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApp1.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RestaurantEntities : DbContext
    {
        public RestaurantEntities()
            : base("name=RestaurantEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Authorization> Authorization { get; set; }
        public virtual DbSet<Check> Check { get; set; }
        public virtual DbSet<ConsituentDishes> ConsituentDishes { get; set; }
        public virtual DbSet<Dishes> Dishes { get; set; }
        public virtual DbSet<EmployeeInformation> EmployeeInformation { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<OrderDishes> OrderDishes { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Purchases> Purchases { get; set; }
        public virtual DbSet<PurchasesProducts> PurchasesProducts { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tables> Tables { get; set; }
        public virtual DbSet<TypesOfDishes> TypesOfDishes { get; set; }
    }
}
