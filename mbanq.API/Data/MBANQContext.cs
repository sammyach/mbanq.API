using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace mbanq.API.Data
{
    public partial class MBANQContext : DbContext
    {
        public MBANQContext()
        {
        }

        public MBANQContext(DbContextOptions<MBANQContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MbqAppRole> MbqAppRoles { get; set; } = null!;
        public virtual DbSet<MbqAppUser> MbqAppUsers { get; set; } = null!;
        public virtual DbSet<MbqAppUserRole> MbqAppUserRoles { get; set; } = null!;
        public virtual DbSet<MbqBranch> MbqBranches { get; set; } = null!;
        public virtual DbSet<MbqCountry> MbqCountries { get; set; } = null!;
        public virtual DbSet<MbqCustomer> MbqCustomers { get; set; } = null!;
        public virtual DbSet<MbqCustomerContact> MbqCustomerContacts { get; set; } = null!;
        public virtual DbSet<MbqCustomerDocument> MbqCustomerDocuments { get; set; } = null!;
        public virtual DbSet<MbqCustomerGuarantor> MbqCustomerGuarantors { get; set; } = null!;
        public virtual DbSet<MbqCustomerNextOfKin> MbqCustomerNextOfKins { get; set; } = null!;
        public virtual DbSet<MbqDocumentType> MbqDocumentTypes { get; set; } = null!;
        public virtual DbSet<MbqLoan> MbqLoans { get; set; } = null!;
        public virtual DbSet<MbqLoanRepayment> MbqLoanRepayments { get; set; } = null!;
        public virtual DbSet<MbqLoanStatus> MbqLoanStatuses { get; set; } = null!;
        public virtual DbSet<MbqOrganization> MbqOrganizations { get; set; } = null!;
        public virtual DbSet<MbqPaymentMethodType> MbqPaymentMethodTypes { get; set; } = null!;
        public virtual DbSet<MbqRegion> MbqRegions { get; set; } = null!;
        public virtual DbSet<MbqState> MbqStates { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MbqAppRole>(entity =>
            {
                entity.ToTable("mbq_app_role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Role)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("role");
            });

            modelBuilder.Entity<MbqAppUser>(entity =>
            {
                entity.ToTable("mbq_app_user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BranchId).HasColumnName("branch_id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("date_created");

                entity.Property(e => e.DateDeleted)
                    .HasColumnType("datetime")
                    .HasColumnName("date_deleted");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Enabled).HasColumnName("enabled");

                entity.Property(e => e.Forename)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("forename");

                entity.Property(e => e.LastModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_modified_date");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("modified_by");

                entity.Property(e => e.Nacl)
                    .HasMaxLength(255)
                    .HasColumnName("nacl");

                entity.Property(e => e.OtherPhone)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("other_phone");

                entity.Property(e => e.Othernames)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("othernames");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(255)
                    .HasColumnName("password_hash");

                entity.Property(e => e.PrimaryPhone)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("primary_phone");

                entity.Property(e => e.Surname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("surname");

                entity.Property(e => e.Uid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("uid");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.MbqAppUsers)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK__mbq_app_u__branc__3D5E1FD2");
            });

            modelBuilder.Entity<MbqAppUserRole>(entity =>
            {
                entity.ToTable("mbq_app_user_roles");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AssignedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("assigned_by");

                entity.Property(e => e.DateAssigned)
                    .HasColumnType("datetime")
                    .HasColumnName("date_assigned");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.MbqAppUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mbq_app_u__role___52593CB8");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MbqAppUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mbq_app_u__user___5165187F");
            });

            modelBuilder.Entity<MbqBranch>(entity =>
            {
                entity.ToTable("mbq_branch");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Alias)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("alias");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("date_created");

                entity.Property(e => e.DigitalAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("digital_address");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IsHead).HasColumnName("is_head");

                entity.Property(e => e.LastModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_modified_date");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("modified_by");

                entity.Property(e => e.OrganizationId).HasColumnName("organization_id");

                entity.Property(e => e.Phone)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.RegionId).HasColumnName("region_id");

                entity.Property(e => e.ResidentialAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("residential_address");

                entity.Property(e => e.StateId).HasColumnName("state_id");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.MbqBranches)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mbq_branc__organ__398D8EEE");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.MbqBranches)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("FK__mbq_branc__regio__3A81B327");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.MbqBranches)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK__mbq_branc__state__3B75D760");
            });

            modelBuilder.Entity<MbqCountry>(entity =>
            {
                entity.ToTable("mbq_country");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.ShortName)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("short_name");
            });

            modelBuilder.Entity<MbqCustomer>(entity =>
            {
                entity.ToTable("mbq_customer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BranchId).HasColumnName("branch_id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("date_created");

                entity.Property(e => e.DateDeleted)
                    .HasColumnType("datetime")
                    .HasColumnName("date_deleted");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("date_of_birth");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.Employer)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("employer");

                entity.Property(e => e.EmployerContact)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("employer_contact");

                entity.Property(e => e.Forename)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("forename");

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.LastModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("last_modified_date");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("modified_by");

                entity.Property(e => e.Occupation)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("occupation");

                entity.Property(e => e.OtherNames)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("other_names");

                entity.Property(e => e.Surname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("surname");

                entity.Property(e => e.Uid)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("uid");

                entity.Property(e => e.Verified).HasColumnName("verified");
            });

            modelBuilder.Entity<MbqCustomerContact>(entity =>
            {
                entity.ToTable("mbq_customer_contacts");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.DigitalAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("digital_address");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.OtherPhone)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("other_phone");

                entity.Property(e => e.PostalAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("postal_address");

                entity.Property(e => e.PrimaryPhone)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("primary_phone");

                entity.Property(e => e.ResidentialAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("residential_address");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.MbqCustomerContacts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__mbq_custo__custo__534D60F1");
            });

            modelBuilder.Entity<MbqCustomerDocument>(entity =>
            {
                entity.ToTable("mbq_customer_documents");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("date_created");

                entity.Property(e => e.DocumentTypeId).HasColumnName("document_type_id");

                entity.Property(e => e.DocumentUrl)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("document_url");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.MbqCustomerDocuments)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mbq_custo__custo__5441852A");

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.MbqCustomerDocuments)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mbq_custo__docum__38996AB5");
            });

            modelBuilder.Entity<MbqCustomerGuarantor>(entity =>
            {
                entity.ToTable("mbq_customer_guarantors");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.DigitalAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("digital_address");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Forename)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("forename");

                entity.Property(e => e.OtherNames)
                    .HasMaxLength(255)
                    .HasColumnName("other_names");

                entity.Property(e => e.OtherPhone)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("other_phone");

                entity.Property(e => e.PhotoUrl)
                    .HasMaxLength(300)
                    .HasColumnName("photo_url");

                entity.Property(e => e.PrimaryPhone)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("primary_phone");

                entity.Property(e => e.ResidentialAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("residential_address");

                entity.Property(e => e.Surname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("surname");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.MbqCustomerGuarantors)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__mbq_custo__custo__5535A963");
            });

            modelBuilder.Entity<MbqCustomerNextOfKin>(entity =>
            {
                entity.ToTable("mbq_customer_next_of_kins");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.DigitalAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("digital_address");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Forename)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("forename");

                entity.Property(e => e.OtherNames)
                    .HasMaxLength(255)
                    .HasColumnName("other_names");

                entity.Property(e => e.OtherPhone)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("other_phone");

                entity.Property(e => e.PhotoUrl)
                    .HasMaxLength(300)
                    .HasColumnName("photo_url");

                entity.Property(e => e.PrimaryPhone)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("primary_phone");

                entity.Property(e => e.ResidentialAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("residential_address");

                entity.Property(e => e.Surname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("surname");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.MbqCustomerNextOfKins)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__mbq_custo__custo__5629CD9C");
            });

            modelBuilder.Entity<MbqDocumentType>(entity =>
            {
                entity.ToTable("mbq_document_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<MbqLoan>(entity =>
            {
                entity.ToTable("mbq_loan");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AmountDue)
                    .HasColumnType("decimal(13, 4)")
                    .HasColumnName("amount_due");

                entity.Property(e => e.AmountPaid)
                    .HasColumnType("decimal(13, 4)")
                    .HasColumnName("amount_paid");

                entity.Property(e => e.Balance)
                    .HasColumnType("decimal(13, 4)")
                    .HasColumnName("balance");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.DateApplied)
                    .HasColumnType("datetime")
                    .HasColumnName("date_applied");

                entity.Property(e => e.DateReleased)
                    .HasColumnType("datetime")
                    .HasColumnName("date_released");

                entity.Property(e => e.Fee)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("fee");

                entity.Property(e => e.MaturityDate)
                    .HasColumnType("datetime")
                    .HasColumnName("maturity_date");

                entity.Property(e => e.Penalty)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("penalty");

                entity.Property(e => e.Principal)
                    .HasColumnType("decimal(13, 4)")
                    .HasColumnName("principal");

                entity.Property(e => e.RepaymentFrequency)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("repayment_frequency");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.MbqLoans)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mbq_loan__custom__49C3F6B7");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.MbqLoans)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK__mbq_loan__status__4AB81AF0");
            });

            modelBuilder.Entity<MbqLoanRepayment>(entity =>
            {
                entity.ToTable("mbq_loan_repayments");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AmountPaid)
                    .HasColumnType("decimal(13, 4)")
                    .HasColumnName("amount_paid");

                entity.Property(e => e.CollectedBy)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("collected_by");

                entity.Property(e => e.DateCollected)
                    .HasColumnType("datetime")
                    .HasColumnName("date_collected");

                entity.Property(e => e.LoanId).HasColumnName("loan_id");

                entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");

                entity.HasOne(d => d.Loan)
                    .WithMany(p => p.MbqLoanRepayments)
                    .HasForeignKey(d => d.LoanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mbq_loan___loan___571DF1D5");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.MbqLoanRepayments)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .HasConstraintName("FK__mbq_loan___payme__59FA5E80");
            });

            modelBuilder.Entity<MbqLoanStatus>(entity =>
            {
                entity.ToTable("mbq_loan_status");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<MbqOrganization>(entity =>
            {
                entity.ToTable("mbq_organization");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Uid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("uid");
            });

            modelBuilder.Entity<MbqPaymentMethodType>(entity =>
            {
                entity.ToTable("mbq_payment_method_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<MbqRegion>(entity =>
            {
                entity.ToTable("mbq_region");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.MbqRegions)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__mbq_regio__count__35BCFE0A");
            });

            modelBuilder.Entity<MbqState>(entity =>
            {
                entity.ToTable("mbq_state");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.MbqStates)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__mbq_state__count__36B12243");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
