using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FluentApi4.Models
{
    
  

    public class MCustomerContext : DbContext
    {
        public MCustomerContext() : base("dbFluentApi4Entries")
        {

        }
        public DbSet<MCustomer> MCustomers { get; set; }
        public DbSet<MOrder> MOrders { get; set; }
        public DbSet<MProduct> MProducts { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            #region<--MCustomer-->

            #region<--Table MCustomer -->
            modelBuilder.Entity<MCustomer>()
                .ToTable("MCustomer")
                .HasKey(t => t.CustomerId)
                .HasMany(t => t.MOrder)
                .WithRequired(t => t.MCustomer);
            #endregion

            #region<--Column CustomerId -->
            modelBuilder.Entity<MCustomer>()
                .Property(t => t.CustomerId)
                .HasColumnName("CustomerId");
            #endregion

            #region<--Column CustomerName -->
            modelBuilder.Entity<MCustomer>()
                .Property(t => t.CustomerName)
                .HasColumnName("CustomerName");
            #endregion

            #endregion

            #region<==MOrder==>

            #region<==Table MOrder==>

            modelBuilder.Entity<MOrder>()
                .ToTable("MOrder")
                .HasKey(t=>t.OrderId)
                .HasMany(t=>t.MProduct)
                .WithRequired(t=>t.MOrder);

            #endregion


            #region<--Column MOrderId -->
            modelBuilder.Entity<MOrder>()
                .Property(t => t.OrderId)
                .HasColumnName("OrderId");
            #endregion

            #region<--Column MCustomerId -->
            modelBuilder.Entity<MOrder>()
                .Property(t => t.CustomerId)
                .HasColumnName("CustomerId");
            #endregion


            #region<==MProduct==>


            #region<--MProduct -->
            modelBuilder.Entity<MProduct>()
                .ToTable("MProduct")
                .HasKey(t=>t.ProductId);
            #endregion


            #region<--Column MProductId -->
            modelBuilder.Entity<MProduct>()
                .Property(t => t.ProductId)
                .HasColumnName("ProductId");
            #endregion


            #region<--Column MOrderId -->
            modelBuilder.Entity<MProduct>()
                .Property(t => t.OrderId)
                .HasColumnName("OrderId");
            #endregion


            #region<--Column MProductName -->
            modelBuilder.Entity<MProduct>()
                .Property(t => t.ProductName)
                .HasColumnName("ProductName");
            #endregion


            #endregion

            #endregion





        }


    }
    
}