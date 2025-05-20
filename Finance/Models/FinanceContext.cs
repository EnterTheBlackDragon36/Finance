using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Finance.Models;

public partial class FinanceContext : DbContext
{
    public FinanceContext()
    {
    }

    public FinanceContext(DbContextOptions<FinanceContext> options, IConfiguration configuration)
        : base(options)
    {
        Configuration = configuration;
    }
    public IConfiguration Configuration { get; }
    public virtual DbSet<Account> Accounts { get; set; }
    public virtual DbSet<AccountBalance> AccountBalances { get; set; }
    public virtual DbSet<AccountType> AccountTypes { get; set; }
    public virtual DbSet<Bank> Banks { get; set; }
    public virtual DbSet<BankCard> BankCards { get; set; }
    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<CustomerType> CustomerTypes { get; set; }
    public virtual DbSet<Party> Parties { get; set; }
    public virtual DbSet<Transaction> Transactions { get; set; }
    public virtual DbSet<TransactionMessage> TransactionMessages { get; set; }
    public virtual DbSet<TransactionType> TransactionTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
        {
            var connString = Configuration.GetConnectionString("FinanceConnection");
            optionsBuilder.UseSqlServer(connString);
        }
    }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Accounts__F267253E183ACD1F");

            entity.Property(e => e.AccountId)
                .ValueGeneratedNever()
                .HasColumnName("accountID");
            entity.Property(e => e.AccountNum).HasColumnName("account_num");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(100)
                .HasColumnName("customer_name");
            entity.Property(e => e.DateClosed)
                .HasColumnType("datetime")
                .HasColumnName("date_closed");
            entity.Property(e => e.DateOpened)
                .HasColumnType("datetime")
                .HasColumnName("date_opened");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.LastActivity)
                .HasColumnType("datetime")
                .HasColumnName("last_Activity");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");

            entity.HasOne(d => d.Customer).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Accounts__custom__52593CB8");
        });

        modelBuilder.Entity<AccountBalance>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("AccountBalance");

            entity.Property(e => e.AccountId).HasColumnName("accountID");
            entity.Property(e => e.CurrentBalance).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.NewBalance).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.PreviousBalance).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.TransactionDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany()
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__AccountBa__accou__5441852A");
        });

        modelBuilder.Entity<AccountType>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Account)
                .HasMaxLength(50)
                .HasColumnName("account");
            entity.Property(e => e.AccountTypeCode)
                .HasMaxLength(50)
                .HasColumnName("account_type_code");
            entity.Property(e => e.AccountTypeDescription)
                .HasMaxLength(2000)
                .HasColumnName("account_type_description");
        });

        modelBuilder.Entity<Bank>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Bank");

            entity.Property(e => e.Accountbal)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("accountbal");
            entity.Property(e => e.Accountcurrency)
                .HasMaxLength(200)
                .HasColumnName("accountcurrency");
            entity.Property(e => e.Accountnum).HasColumnName("accountnum");
            entity.Property(e => e.Deposit)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("deposit");
            entity.Property(e => e.Location)
                .HasMaxLength(2000)
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasMaxLength(2000)
                .HasColumnName("name");
            entity.Property(e => e.Withdrawal)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("withdrawal");
        });

        modelBuilder.Entity<BankCard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BankCard__3214EC07392ED121");

            entity.ToTable("BankCard");

            entity.Property(e => e.AccountId).HasColumnName("accountID");
            entity.Property(e => e.Cardnumber)
                .HasMaxLength(50)
                .HasColumnName("cardnumber");
            entity.Property(e => e.Cardtype)
                .HasMaxLength(50)
                .HasColumnName("cardtype");
            entity.Property(e => e.Csv).HasColumnName("csv");
            entity.Property(e => e.Expirationdate)
                .HasColumnType("datetime")
                .HasColumnName("expirationdate");
            entity.Property(e => e.Expirationmonth).HasColumnName("expirationmonth");
            entity.Property(e => e.Expirationyear).HasColumnName("expirationyear");
            entity.Property(e => e.Issuedate)
                .HasColumnType("datetime")
                .HasColumnName("issuedate");
            entity.Property(e => e.Nameoncard)
                .HasMaxLength(200)
                .HasColumnName("nameoncard");
            entity.Property(e => e.Securitychip).HasColumnName("securitychip");

            entity.HasOne(d => d.Account).WithMany(p => p.BankCards)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__BankCard__accoun__5812160E");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC071012F6E7");

            entity.Property(e => e.CustomerId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("customer_id");
            entity.Property(e => e.CustomertypeId).HasColumnName("customertypeId");
            entity.Property(e => e.DateBecameCustomer)
                .HasColumnType("datetime")
                .HasColumnName("date_became_customer");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(100)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(100)
                .HasColumnName("lastname");
            entity.Property(e => e.Middlename)
                .HasMaxLength(100)
                .HasColumnName("middlename");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Suffix)
                .HasMaxLength(10)
                .HasColumnName("suffix");

            entity.HasOne(d => d.Customertype).WithMany(p => p.Customers)
                .HasForeignKey(d => d.CustomertypeId)
                .HasConstraintName("FK__Customers__custo__4F7CD00D");
        });

        modelBuilder.Entity<CustomerType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC073818F7AA");

            entity.Property(e => e.CustomerTypeCode)
                .HasMaxLength(20)
                .HasColumnName("customer_type_code");
            entity.Property(e => e.Customertype1)
                .HasMaxLength(100)
                .HasColumnName("customertype");
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Party>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Parties__3214EC07C940E145");

            entity.Property(e => e.Details)
                .HasMaxLength(2000)
                .HasColumnName("details");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.AccountId).HasColumnName("accountID");
            entity.Property(e => e.TransactionDate).HasColumnType("datetime");
            entity.Property(e => e.Type).HasMaxLength(100);

            entity.HasOne(d => d.Account).WithMany()
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Transacti__accou__5BE2A6F2");
        });

        modelBuilder.Entity<TransactionMessage>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.AccountId).HasColumnName("account_ID");
            entity.Property(e => e.CounterpartyId).HasColumnName("counterparty_id");
            entity.Property(e => e.Message)
                .HasMaxLength(2000)
                .HasColumnName("message");
            entity.Property(e => e.TransactionTypeCode)
                .HasMaxLength(50)
                .HasColumnName("transaction_type_code");

            entity.HasOne(d => d.Account).WithMany()
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Transacti__accou__5EBF139D");

            entity.HasOne(d => d.Counterparty).WithMany()
                .HasForeignKey(d => d.CounterpartyId)
                .HasConstraintName("FK__Transacti__count__5EBF139D");
        });

        modelBuilder.Entity<TransactionType>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .HasColumnName("description");
            entity.Property(e => e.TransactionTypeCode)
                .HasMaxLength(10)
                .HasColumnName("transaction_type_code");
            entity.Property(e => e.Transactiontype1)
                .HasMaxLength(50)
                .HasColumnName("transactiontype");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
