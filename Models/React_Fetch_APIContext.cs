using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace react_axois_API_Fetch.Models
{
    public partial class React_Fetch_APIContext : DbContext
    {
        public React_Fetch_APIContext()
        {
        }

        public React_Fetch_APIContext(DbContextOptions<React_Fetch_APIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CardFocus> CardFoci { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=ELW5242\\SQLEXPRESS01;Database=React_Fetch_API;Trusted_Connection=True;");
            }*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CardFocus>(entity =>
            {
                entity.ToTable("card_focus");

                /*entity.Property(e => e.Id).HasColumnName("ID");*/

                entity.Property(e => e.FocusDesc)
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasColumnName("focus_desc");

                entity.Property(e => e.FocusImage)
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasColumnName("focus_image");

                entity.Property(e => e.FocusTitle)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("focus_title");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
