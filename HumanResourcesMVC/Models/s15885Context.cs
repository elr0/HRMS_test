using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HumanResourcesMVC.Models
{
    public partial class s15885Context : DbContext
    {
        public s15885Context()
        {
        }

        public s15885Context(DbContextOptions<s15885Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AbsenceType> AbsenceType { get; set; }
        public virtual DbSet<AvailableAbsence> AvailableAbsence { get; set; }
        public virtual DbSet<Benefit> Benefit { get; set; }
        public virtual DbSet<Contract> Contract { get; set; }
        public virtual DbSet<ContractBenefit> ContractBenefit { get; set; }
        public virtual DbSet<ContractType> ContractType { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<Overtime> Overtime { get; set; }
        public virtual DbSet<Request> Request { get; set; }
        public virtual DbSet<RequestType> RequestType { get; set; }
        public virtual DbSet<Status> Status { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s15885;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<AbsenceType>(entity =>
            {
                entity.HasKey(e => e.IdAbsenceType)
                    .HasName("AbsenceType_pk");

                entity.Property(e => e.IdAbsenceType).ValueGeneratedNever();

                entity.Property(e => e.AbsenceType1)
                    .IsRequired()
                    .HasColumnName("AbsenceType")
                    .HasMaxLength(1);
            });


            modelBuilder.Entity<AvailableAbsence>(entity =>
            {
                entity.HasKey(e => e.IdAvailableAbsence)
                    .HasName("AvailableAbsence_pk");

                entity.Property(e => e.IdAvailableAbsence).ValueGeneratedNever();

                entity.Property(e => e.AvailableDays).HasColumnType("decimal(3, 2)");

                entity.Property(e => e.UsedAbsence).HasColumnType("decimal(3, 2)");

                entity.HasOne(d => d.IdAbsenceTypeNavigation)
                    .WithMany(p => p.AvailableAbsence)
                    .HasForeignKey(d => d.IdAbsenceType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("AvailableAbsence_AbsenceType");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.AvailableAbsence)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("AvailableAbsence_Employee");
            });

            modelBuilder.Entity<Benefit>(entity =>
            {
                entity.HasKey(e => e.IdBenefit)
                    .HasName("Benefit_pk");

                entity.Property(e => e.IdBenefit).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Price).HasColumnType("decimal(4, 2)");
            });


            modelBuilder.Entity<Contract>(entity =>
            {
                entity.HasKey(e => e.IdContract)
                    .HasName("Contract_pk");

                entity.Property(e => e.IdContract).ValueGeneratedNever();

                entity.Property(e => e.ContractEnd).HasColumnType("date");

                entity.Property(e => e.ContractStart).HasColumnType("date");

                entity.Property(e => e.Salary).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.HasOne(d => d.IdContractTypeNavigation)
                    .WithMany(p => p.Contract)
                    .HasForeignKey(d => d.IdContractType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Contract_ContractType");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Contract)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Contract_Employee");
            });

            modelBuilder.Entity<ContractBenefit>(entity =>
            {
                entity.HasKey(e => new { e.IdBenefitContract, e.BenefitIdBenefit, e.ContractIdContract })
                    .HasName("ContractBenefit_pk");

                entity.Property(e => e.BenefitIdBenefit).HasColumnName("Benefit_IdBenefit");

                entity.Property(e => e.ContractIdContract).HasColumnName("Contract_IdContract");

                entity.Property(e => e.ExpiryDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.BenefitIdBenefitNavigation)
                    .WithMany(p => p.ContractBenefit)
                    .HasForeignKey(d => d.BenefitIdBenefit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ContractBenefit_Benefit");

                entity.HasOne(d => d.ContractIdContractNavigation)
                    .WithMany(p => p.ContractBenefit)
                    .HasForeignKey(d => d.ContractIdContract)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ContractBenefit_Contract");
            });

            modelBuilder.Entity<ContractType>(entity =>
            {
                entity.HasKey(e => e.IdContractType)
                    .HasName("ContractType_pk");

                entity.Property(e => e.IdContractType).ValueGeneratedNever();

                entity.Property(e => e.ContractType1)
                    .IsRequired()
                    .HasColumnName("ContractType");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee)
                    .HasName("Employee_pk");

                entity.Property(e => e.IdEmployee).ValueGeneratedNever();

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.IdManager).HasColumnName("idManager");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.Pesel).HasColumnName("PESEL");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.SecondName).HasMaxLength(1);

                entity.HasOne(d => d.IdJobNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.IdJob)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employee_Job");

                entity.HasOne(d => d.IdManagerNavigation)
                    .WithMany(p => p.InverseIdManagerNavigation)
                    .HasForeignKey(d => d.IdManager)
                    .HasConstraintName("Employee_Manager");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasKey(e => e.IdJob)
                    .HasName("Job_pk");

                entity.Property(e => e.IdJob).ValueGeneratedNever();

                entity.Property(e => e.JobName)
                    .IsRequired()
                    .HasMaxLength(50);
            });


            modelBuilder.Entity<Overtime>(entity =>
            {
                entity.HasKey(e => e.IdOvertime)
                    .HasName("Overtime_pk");

                entity.Property(e => e.IdOvertime).ValueGeneratedNever();

                entity.Property(e => e.ToBeSettledBefore).HasColumnType("date");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Overtime)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Overtime_Employee");
            });


            modelBuilder.Entity<Request>(entity =>
            {
                entity.HasKey(e => e.IdRequest)
                    .HasName("Request_pk");

                entity.Property(e => e.IdRequest).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.QuantityRequested).HasColumnType("decimal(3, 2)");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdEmployeeReceiverNavigation)
                    .WithMany(p => p.RequestIdEmployeeReceiverNavigation)
                    .HasForeignKey(d => d.IdEmployeeReceiver)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Request_Manager");

                entity.HasOne(d => d.IdEmployeeSenderNavigation)
                    .WithMany(p => p.RequestIdEmployeeSenderNavigation)
                    .HasForeignKey(d => d.IdEmployeeSender)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Request_Employee");

                entity.HasOne(d => d.IdRequestTypeNavigation)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.IdRequestType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Request_RequestType");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Request_Status");
            });

            modelBuilder.Entity<RequestType>(entity =>
            {
                entity.HasKey(e => e.IdRequestType)
                    .HasName("RequestType_pk");

                entity.Property(e => e.IdRequestType).ValueGeneratedNever();

                entity.Property(e => e.Object)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(1);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.IdStatus)
                    .HasName("Status_pk");

                entity.Property(e => e.IdStatus).ValueGeneratedNever();

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasMaxLength(1);
            });
        }
    }
}
