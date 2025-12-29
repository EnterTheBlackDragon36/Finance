using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Finance.Models;

public partial class FinanceContext : DbContext
{
    public FinanceContext()
    {
    }

    public FinanceContext(DbContextOptions<FinanceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountBalance> AccountBalances { get; set; }

    public virtual DbSet<AccountHolder> AccountHolders { get; set; }

    public virtual DbSet<AccountType> AccountTypes { get; set; }

    public virtual DbSet<Bank> Banks { get; set; }

    public virtual DbSet<BankCard> BankCards { get; set; }

    public virtual DbSet<CardNumber> CardNumbers { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerType> CustomerTypes { get; set; }

    public virtual DbSet<Party> Parties { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentRequest> PaymentRequests { get; set; }

    public virtual DbSet<RefCurrencyCode> RefCurrencyCodes { get; set; }

    public virtual DbSet<RefDataSource> RefDataSources { get; set; }

    public virtual DbSet<RefDataSourceType> RefDataSourceTypes { get; set; }

    public virtual DbSet<RefPartyType> RefPartyTypes { get; set; }

    public virtual DbSet<RefPaymentMethod> RefPaymentMethods { get; set; }

    public virtual DbSet<RefPaymentStatus> RefPaymentStatuses { get; set; }

    public virtual DbSet<RefTransactionType> RefTransactionTypes { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<TransactionMessage> TransactionMessages { get; set; }

    public virtual DbSet<TransactionType> TransactionTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=EASTON-DESKTOP;Initial Catalog=Finance;User=entertheblackdragon;Password=Mononoke24(;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Accounts__46A222CD2ABD38E4");

            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.AccountHolderId).HasColumnName("account_holder_id");
            entity.Property(e => e.AccountName).HasColumnName("account_name");
            entity.Property(e => e.AccountNumber).HasColumnName("account_number");
            entity.Property(e => e.CurrentBalance)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("current_balance");
            entity.Property(e => e.DateClosed)
                .HasColumnType("datetime")
                .HasColumnName("date_closed");
            entity.Property(e => e.DateOpened)
                .HasColumnType("datetime")
                .HasColumnName("date_opened");
            entity.Property(e => e.LastActivity)
                .HasColumnType("datetime")
                .HasColumnName("last_Activity");
            entity.Property(e => e.OtherDetails).HasColumnName("other_details");

            entity.HasOne(d => d.AccountHolder).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.AccountHolderId)
                .HasConstraintName("FK__Accounts__accoun__5165187F");
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
        });

        modelBuilder.Entity<AccountHolder>(entity =>
        {
            entity.HasKey(e => e.AccountHolderId).HasName("PK__Account___5F7B87274CCBC53B");

            entity.ToTable("Account_Holders");

            entity.Property(e => e.AccountHolderId).HasColumnName("account_holder_id");
            entity.Property(e => e.AccountHolderName)
                .HasMaxLength(1000)
                .HasColumnName("account_holder_name");
            entity.Property(e => e.OtherDetails)
                .HasMaxLength(2000)
                .HasColumnName("other_details");
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
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
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
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
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
            entity
                .HasNoKey()
                .ToTable("BankCard");

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
            entity.Property(e => e.Expirationmonth)
                .HasMaxLength(20)
                .HasColumnName("expirationmonth");
            entity.Property(e => e.Expirationyear)
                .HasMaxLength(4)
                .HasColumnName("expirationyear");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Issuedate)
                .HasColumnType("datetime")
                .HasColumnName("issuedate");
            entity.Property(e => e.Nameoncard)
                .HasMaxLength(200)
                .HasColumnName("nameoncard");
            entity.Property(e => e.SecurityChip).HasColumnName("security_chip");
            entity.Property(e => e.TapEnabled).HasColumnName("tap_enabled");

            entity.HasOne(d => d.Account).WithMany()
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__BankCard__accoun__6FE99F9F");
        });

        modelBuilder.Entity<CardNumber>(entity =>
        {
            entity.HasKey(e => e.CardNumber1).HasName("PK__Card_Num__1E6E0AF503ED3124");

            entity.ToTable("Card_Numbers");

            entity.Property(e => e.CardNumber1)
                .ValueGeneratedNever()
                .HasColumnName("card_number");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CardHolderName)
                .HasMaxLength(2000)
                .HasColumnName("card_holder_name");
            entity.Property(e => e.ExpirDate)
                .HasColumnType("datetime")
                .HasColumnName("expir_date");
            entity.Property(e => e.OtherDetails).HasColumnName("other_details");

            entity.HasOne(d => d.Account).WithMany(p => p.CardNumbers)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Card_Numb__accou__5441852A");
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
        });

        modelBuilder.Entity<CustomerType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC0784BF0CBF");

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
            entity.HasKey(e => e.PartyId).HasName("PK__Parties__8A2AF38ED4652FD5");

            entity.Property(e => e.PartyId).HasColumnName("party_id");
            entity.Property(e => e.OtherDetails).HasColumnName("other_details");
            entity.Property(e => e.PartyEmail)
                .HasMaxLength(2000)
                .HasColumnName("party_email");
            entity.Property(e => e.PartyName)
                .HasMaxLength(2000)
                .HasColumnName("party_name");
            entity.Property(e => e.PartyPhone)
                .HasMaxLength(20)
                .HasColumnName("party_phone");
            entity.Property(e => e.PartyTypeCode).HasColumnName("party_type_code");

            entity.HasOne(d => d.PartyTypeCodeNavigation).WithMany(p => p.Parties)
                .HasForeignKey(d => d.PartyTypeCode)
                .HasConstraintName("FK__Parties__party_t__5FB337D6");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__ED1FC9EAE48079D0");

            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.AmountOfPayment)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("amount_of_payment");
            entity.Property(e => e.CardNumber).HasColumnName("card_number");
            entity.Property(e => e.DateOfPayment)
                .HasColumnType("datetime")
                .HasColumnName("date_of_payment");
            entity.Property(e => e.OtherDetails).HasColumnName("other_details");
            entity.Property(e => e.PayeeBankAccountNumber).HasColumnName("payee_bank_account_number");
            entity.Property(e => e.PayeeBankSortCode).HasColumnName("payee_bank_sort_code");
            entity.Property(e => e.PayeeCounterpartyPartyId).HasColumnName("payee_counterparty_party_id");
            entity.Property(e => e.PayeePayMobileNumber)
                .HasMaxLength(20)
                .HasColumnName("payee_pay_mobile_number");
            entity.Property(e => e.PayerPartyId).HasColumnName("payer_party_id");
            entity.Property(e => e.PaymentFromCurrencyCode).HasColumnName("payment_from_currency_code");
            entity.Property(e => e.PaymentMethodCode).HasColumnName("payment_method_code");
            entity.Property(e => e.PaymentRequestId).HasColumnName("payment_request_id");
            entity.Property(e => e.PaymentStatusCode).HasColumnName("payment_status_code");
            entity.Property(e => e.PaymentToCurrencyCode).HasColumnName("payment_to_currency_code");

            entity.HasOne(d => d.CardNumberNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.CardNumber)
                .HasConstraintName("FK__Payments__card_n__6754599E");

            entity.HasOne(d => d.PayeeCounterpartyParty).WithMany(p => p.PaymentPayeeCounterpartyParties)
                .HasForeignKey(d => d.PayeeCounterpartyPartyId)
                .HasConstraintName("FK__Payments__payee___693CA210");

            entity.HasOne(d => d.PayerParty).WithMany(p => p.PaymentPayerParties)
                .HasForeignKey(d => d.PayerPartyId)
                .HasConstraintName("FK__Payments__payer___68487DD7");

            entity.HasOne(d => d.PaymentFromCurrencyCodeNavigation).WithMany(p => p.PaymentPaymentFromCurrencyCodeNavigations)
                .HasForeignKey(d => d.PaymentFromCurrencyCode)
                .HasConstraintName("FK__Payments__paymen__6B24EA82");

            entity.HasOne(d => d.PaymentMethodCodeNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.PaymentMethodCode)
                .HasConstraintName("FK__Payments__paymen__6A30C649");

            entity.HasOne(d => d.PaymentRequest).WithMany(p => p.Payments)
                .HasForeignKey(d => d.PaymentRequestId)
                .HasConstraintName("FK__Payments__paymen__6D0D32F4");

            entity.HasOne(d => d.PaymentStatusCodeNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.PaymentStatusCode)
                .HasConstraintName("FK__Payments__paymen__6E01572D");

            entity.HasOne(d => d.PaymentToCurrencyCodeNavigation).WithMany(p => p.PaymentPaymentToCurrencyCodeNavigations)
                .HasForeignKey(d => d.PaymentToCurrencyCode)
                .HasConstraintName("FK__Payments__paymen__6C190EBB");
        });

        modelBuilder.Entity<PaymentRequest>(entity =>
        {
            entity.HasKey(e => e.PaymentRequestId).HasName("PK__Payment___EA007E4B99C743DD");

            entity.ToTable("Payment_Requests");

            entity.Property(e => e.PaymentRequestId).HasColumnName("payment_request_id");
            entity.Property(e => e.DataSourceCode).HasColumnName("data_source_code");
            entity.Property(e => e.OtherDetails).HasColumnName("other_details");

            entity.HasOne(d => d.DataSourceCodeNavigation).WithMany(p => p.PaymentRequests)
                .HasForeignKey(d => d.DataSourceCode)
                .HasConstraintName("FK__Payment_R__data___628FA481");
        });

        modelBuilder.Entity<RefCurrencyCode>(entity =>
        {
            entity.HasKey(e => e.CurrencyCode).HasName("PK__Ref_Curr__6008D0BB1361BC8D");

            entity.ToTable("Ref_Currency_Codes");

            entity.Property(e => e.CurrencyCode).HasColumnName("currency_code");
            entity.Property(e => e.CurrencyCodeName)
                .HasMaxLength(1000)
                .HasColumnName("currency_code_name");
        });

        modelBuilder.Entity<RefDataSource>(entity =>
        {
            entity.HasKey(e => e.DataSourceCode).HasName("PK__Ref_Data__FF9212FBC8C743AE");

            entity.ToTable("Ref_Data_Sources");

            entity.Property(e => e.DataSourceCode).HasColumnName("data_source_code");
            entity.Property(e => e.DataSourceName)
                .HasMaxLength(2000)
                .HasColumnName("data_source_name");
            entity.Property(e => e.DataSourceTypeCode).HasColumnName("data_source_type_code");

            entity.HasOne(d => d.DataSourceTypeCodeNavigation).WithMany(p => p.RefDataSources)
                .HasForeignKey(d => d.DataSourceTypeCode)
                .HasConstraintName("FK__Ref_Data___data___5CD6CB2B");
        });

        modelBuilder.Entity<RefDataSourceType>(entity =>
        {
            entity.HasKey(e => e.DataSourceTypeCode).HasName("PK__Ref_Data__64300420B81319BB");

            entity.ToTable("Ref_Data_Source_Types");

            entity.Property(e => e.DataSourceTypeCode).HasColumnName("data_source_type_code");
            entity.Property(e => e.DataSourceTypeDescription).HasColumnName("data_source_type_description");
        });

        modelBuilder.Entity<RefPartyType>(entity =>
        {
            entity.HasKey(e => e.PartyTypeCode).HasName("PK__Ref_Part__729F1EDC4586190D");

            entity.ToTable("Ref_Party_Types");

            entity.Property(e => e.PartyTypeCode).HasColumnName("party_type_code");
            entity.Property(e => e.PartyTypeDescription).HasColumnName("party_type_description");
        });

        modelBuilder.Entity<RefPaymentMethod>(entity =>
        {
            entity.HasKey(e => e.PaymentMethodCode).HasName("PK__Ref_Paym__6403475A0888A8DF");

            entity.ToTable("Ref_Payment_Methods");

            entity.Property(e => e.PaymentMethodCode).HasColumnName("payment_method_code");
            entity.Property(e => e.PaymentMethodName)
                .HasMaxLength(1000)
                .HasColumnName("payment_method_name");
        });

        modelBuilder.Entity<RefPaymentStatus>(entity =>
        {
            entity.HasKey(e => e.PaymentStatusCode).HasName("PK__Ref_Paym__F687C4BECFB6FB82");

            entity.ToTable("Ref_Payment_Status");

            entity.Property(e => e.PaymentStatusCode).HasColumnName("payment_status_code");
            entity.Property(e => e.PaymentStatusDescription).HasColumnName("payment_status_description");
        });

        modelBuilder.Entity<RefTransactionType>(entity =>
        {
            entity.HasKey(e => e.TransactionTypeCode).HasName("PK__Ref_Tran__6443D79ACF406BC5");

            entity.ToTable("Ref_Transaction_Types");

            entity.Property(e => e.TransactionTypeCode).HasColumnName("transaction_type_code");
            entity.Property(e => e.TransactionTypeDescription).HasColumnName("transaction_type_description");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transact__85C600AFDC2163A4");

            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.TransactionTypeCode).HasColumnName("transaction_type_code");
        });

        modelBuilder.Entity<TransactionMessage>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.AccountId).HasColumnName("account_ID");
            entity.Property(e => e.CounterpartyId).HasColumnName("counterparty_id");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Message)
                .HasMaxLength(2000)
                .HasColumnName("message");
            entity.Property(e => e.TransactionTypeCode)
                .HasMaxLength(50)
                .HasColumnName("transaction_type_code");
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
