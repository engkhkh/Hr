using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Hr.Models
{
    public partial class hrContext : DbContext
    {
        internal readonly object ACourcesName;

        public hrContext()
        {
        }

        public hrContext(DbContextOptions<hrContext> options)
            : base(options)
        {
        }
        public virtual DbSet<MasterRequestTypeId> MasterRequestTypeIds { get; set; }
        public virtual DbSet<MasterDetails> MasterDetailss { get; set; }
        public virtual DbSet<ViewModelMasterwithother> ViewModelMasterwithothers { get; set; }
        
        public virtual DbSet<ACourcesCertImage> ACourcesCertImages { get; set; }
        public virtual DbSet<ACourcesCertImagehr> ACourcesCertImagehrs { get; set; }
        public virtual DbSet<ACourcesDeptin> ACourcesDeptins { get; set; }
        public virtual DbSet<ACourcesDeptout> ACourcesDeptouts { get; set; }
        public virtual DbSet<ACourcesEstimate> ACourcesEstimates { get; set; }
        public virtual DbSet<ACourcesMaster> ACourcesMasters { get; set; }
        public virtual DbSet<ACourcesName> ACourcesNames { get; set; }
        public virtual DbSet<ACourcesTrainingMethod> ACourcesTrainingMethods { get; set; }
        public virtual DbSet<ACourcesType> ACourcesTypes { get; set; }
        public virtual DbSet<Cemp> Cemps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-4IRPVGQ\\SQLEXPRESS;Database=hr;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ACourcesCertImage>(entity =>
            {
                entity.HasKey(e => e.CourcesIdImagecert);

                entity.ToTable("A_COURCES_CERT_IMAGE");

                entity.Property(e => e.CourcesIdImagecert).HasColumnName("COURCES_ID_IMAGECERT");

                entity.Property(e => e.CourcesIdmaster).HasColumnName("COURCES_IDMASTER");

                entity.Property(e => e.FileName1)
                    .HasMaxLength(255)
                    .HasColumnName("FILE_NAME1");

                entity.Property(e => e.ImageCreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("IMAGE_CREATED_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ImageName)
                    .HasMaxLength(255)
                    .HasColumnName("IMAGE_NAME");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(255)
                    .HasColumnName("IMAGE_PATH");

                entity.Property(e => e.ImageType)
                    .HasMaxLength(255)
                    .HasColumnName("IMAGE_TYPE");

                entity.Property(e => e.Note)
                    .HasMaxLength(255)
                    .HasColumnName("NOTE");
            });

            modelBuilder.Entity<ACourcesCertImagehr>(entity =>
            {
                entity.HasKey(e => e.CourcesIdImagehr);

                entity.ToTable("A_COURCES_CERT_IMAGEHR");

                entity.Property(e => e.CourcesIdImagehr).HasColumnName("COURCES_ID_IMAGEHR");

                entity.Property(e => e.CourcesIdmaster).HasColumnName("COURCES_IDMASTER");

                entity.Property(e => e.FileName1)
                    .HasMaxLength(255)
                    .HasColumnName("FILE_NAME1");

                entity.Property(e => e.ImageCreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("IMAGE_CREATED_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ImageName)
                    .HasMaxLength(255)
                    .HasColumnName("IMAGE_NAME");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(255)
                    .HasColumnName("IMAGE_PATH");

                entity.Property(e => e.ImageType)
                    .HasMaxLength(255)
                    .HasColumnName("IMAGE_TYPE");

                entity.Property(e => e.Note)
                    .HasMaxLength(255)
                    .HasColumnName("NOTE");
            });

            modelBuilder.Entity<ACourcesDeptin>(entity =>
            {
                entity.HasKey(e => e.CourcesIdDeptin);

                entity.ToTable("A_COURCES_DEPTIN");

                entity.Property(e => e.CourcesIdDeptin).HasColumnName("COURCES_ID_DEPTIN");

                entity.Property(e => e.CourcesNameDeptin)
                    .HasMaxLength(250)
                    .HasColumnName("COURCES_NAME_DEPTIN");
            });

            modelBuilder.Entity<ACourcesDeptout>(entity =>
            {
                entity.HasKey(e => e.CourcesIdDeptout);

                entity.ToTable("A_COURCES_DEPTOUT");

                entity.Property(e => e.CourcesIdDeptout).HasColumnName("COURCES_ID_DEPTOUT");

                entity.Property(e => e.CourcesNameDeptout)
                    .HasMaxLength(250)
                    .HasColumnName("COURCES_NAME_DEPTOUT");
            });
            modelBuilder.Entity<MasterRequestTypeId>(entity =>
            {
                entity.HasKey(e => e.MasterRequestTypeIdsMasterRequestTypeIdserial);

                entity.ToTable("MasterRequestTypeId");

                entity.Property(e => e.COURCES_IDMASTER).HasColumnName("COURCES_IDMASTER");

                entity.Property(e => e.MasterRequestType)
                    
                    .HasColumnName("MasterRequestType");
            });

            modelBuilder.Entity<MasterDetails>(entity =>
            {
                entity.HasKey(e => e.MasterDetailsSerial);
                //entity.HasKey(e => e.COURCES_IDMASTER);

                entity.ToTable("MasterDetails");

                entity.Property(e => e.COURCES_IDMASTER).HasColumnName("COURCES_IDMASTER");

                entity.Property(e => e.MasterRequestFrom) .HasColumnName("MasterRequestFrom");
                entity.Property(e => e.MasterRequestTo).HasColumnName("MasterRequestTo");
                entity.Property(e => e.MasterRequestTypeSatus).HasColumnName("MasterRequestTypeSatus");
                entity.Property(e => e.MasterRequestNotes).HasColumnName("MasterRequestNotes");

            });



            //
            modelBuilder.Entity<ACourcesEstimate>(entity =>
            {
                entity.HasKey(e => e.CourcesIdEstimate);

                entity.ToTable("A_COURCES_ESTIMATE");

                entity.Property(e => e.CourcesIdEstimate).HasColumnName("COURCES_ID_ESTIMATE");

                entity.Property(e => e.CourcesNameEstimate)
                    .HasMaxLength(250)
                    .HasColumnName("COURCES_NAME_ESTIMATE");
            });

            modelBuilder.Entity<ACourcesMaster>(entity =>
            {
                entity.HasKey(e => e.CourcesIdmaster);

                entity.ToTable("A_COURCES_MASTER");

                entity.Property(e => e.CourcesIdmaster).HasColumnName("COURCES_IDMASTER");

                entity.Property(e => e.Cempid)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("CEMPID");

                entity.Property(e => e.CourcesEndDate)
                    .HasColumnType("date")
                    .HasColumnName("COURCES_END_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CourcesId).HasColumnName("COURCES_ID");

                entity.Property(e => e.CourcesIdDeptin).HasColumnName("COURCES_ID_DEPTIN");

                entity.Property(e => e.CourcesIdDeptout).HasColumnName("COURCES_ID_DEPTOUT");

                entity.Property(e => e.CourcesIdEstimate).HasColumnName("COURCES_ID_ESTIMATE");

                entity.Property(e => e.CourcesIdImagecert).HasColumnName("COURCES_ID_IMAGECERT");

                entity.Property(e => e.CourcesIdImagehr).HasColumnName("COURCES_ID_IMAGEHR");

                entity.Property(e => e.CourcesIdTraining).HasColumnName("COURCES_ID_TRAINING");

                entity.Property(e => e.CourcesIdType).HasColumnName("COURCES_ID_TYPE");

                entity.Property(e => e.CourcesNumberofdays).HasColumnName("COURCES_NUMBEROFDAYS");

                entity.Property(e => e.CourcesPassRate)
                    .HasMaxLength(255)
                    .HasColumnName("COURCES_PASS_RATE");

                entity.Property(e => e.CourcesStartDate)
                    .HasColumnType("date")
                    .HasColumnName("COURCES_START_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Cemp)
                    .WithMany(p => p.ACourcesMasters)
                    .HasForeignKey(d => d.Cempid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_A_COURCES_MASTER_CEMPS");

                entity.HasOne(d => d.Cources)
                    .WithMany(p => p.ACourcesMasters)
                    .HasForeignKey(d => d.CourcesId)
                    .HasConstraintName("FK_A_COURCES_MASTER_A_COURCES_NAME");
            });

            modelBuilder.Entity<ACourcesName>(entity =>
            {
                entity.HasKey(e => e.CourcesId);

                entity.ToTable("A_COURCES_NAME");

                entity.Property(e => e.CourcesId).HasColumnName("COURCES_ID");

                entity.Property(e => e.CourcesName)
                    .HasMaxLength(250)
                    .HasColumnName("COURCES_NAME");
            });

            modelBuilder.Entity<ACourcesTrainingMethod>(entity =>
            {
                entity.HasKey(e => e.CourcesIdTraining);

                entity.ToTable("A_COURCES_TRAINING_METHOD");

                entity.Property(e => e.CourcesIdTraining).HasColumnName("COURCES_ID_TRAINING");

                entity.Property(e => e.CourcesNameTraining)
                    .HasMaxLength(250)
                    .HasColumnName("COURCES_NAME_TRAINING");
            });

            modelBuilder.Entity<ACourcesType>(entity =>
            {
                entity.HasKey(e => e.CourcesIdType);

                entity.ToTable("A_COURCES_TYPE");

                entity.Property(e => e.CourcesIdType).HasColumnName("COURCES_ID_TYPE");

                entity.Property(e => e.CourcesTypeName)
                    .HasMaxLength(250)
                    .HasColumnName("COURCES_TYPE_NAME");
            });

            modelBuilder.Entity<Cemp>(entity =>
            {
                entity.ToTable("CEMPS");

                entity.Property(e => e.Cempid)
                    .HasMaxLength(250)
                    .HasColumnName("CEMPID");

                entity.Property(e => e.Cempdepartment)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("CEMPDEPARTMENT");

                entity.Property(e => e.Cempgrade)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("CEMPGRADE");

                entity.Property(e => e.Cemphiringdate)
                    .HasColumnType("date")
                    .HasColumnName("CEMPHIRINGDATE");

                entity.Property(e => e.Cempidentityid)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("CEMPIDENTITYID");

                entity.Property(e => e.Cemplastupgrade)
                    .HasColumnType("date")
                    .HasColumnName("CEMPLASTUPGRADE");

                entity.Property(e => e.Cempname)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("CEMPNAME");

                entity.Property(e => e.Cempother1)
                    .HasMaxLength(250)
                    .HasColumnName("CEMPOTHER1");

                entity.Property(e => e.Cempother2)
                    .HasMaxLength(250)
                    .HasColumnName("CEMPOTHER2");

                entity.Property(e => e.Cemptitle)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("CEMPTITLE");

                entity.Property(e => e.Cempuser)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnName("CEMPUSER");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
