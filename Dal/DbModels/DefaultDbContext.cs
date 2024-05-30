using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dal.DbModels;

public partial class DefaultDbContext : DbContext
{
    public DefaultDbContext()
    {
    }

    public DefaultDbContext(DbContextOptions<DefaultDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookAuthor> BookAuthors { get; set; }

    public virtual DbSet<BookGenre> BookGenres { get; set; }

    public virtual DbSet<CopyOfBook> CopyOfBooks { get; set; }

    public virtual DbSet<Debtor> Debtors { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<IssuedBook> IssuedBooks { get; set; }

    public virtual DbSet<Librarian> Librarians { get; set; }

    public virtual DbSet<Penalty> Penalties { get; set; }

    public virtual DbSet<PenaltyDebtor> PenaltyDebtors { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<Queue> Queues { get; set; }

    public virtual DbSet<Reader> Readers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ALEXLAPTOP\\SQLEXPRESS;Initial Catalog=Library;Trusted_Connection=True;TrustServerCertificate=True;Integrated security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.ToTable("Author");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("Book");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Circulation).HasColumnName("circulation");
            entity.Property(e => e.IdPublisher).HasColumnName("ID_publisher");
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .HasColumnName("title");
            entity.Property(e => e.YearOfPublish)
                .HasMaxLength(30)
                .HasColumnName("year_of_publish");

            entity.HasOne(d => d.IdPublisherNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdPublisher)
                .HasConstraintName("FK_Book_Publisher");
        });

        modelBuilder.Entity<BookAuthor>(entity =>
        {
            entity.ToTable("Book_Author");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdAuthor).HasColumnName("ID_Author");
            entity.Property(e => e.IdBook).HasColumnName("ID_Book");

            entity.HasOne(d => d.IdAuthorNavigation).WithMany(p => p.BookAuthors)
                .HasForeignKey(d => d.IdAuthor)
                .HasConstraintName("FK_Book_Author_Author");

            entity.HasOne(d => d.IdBookNavigation).WithMany(p => p.BookAuthors)
                .HasForeignKey(d => d.IdBook)
                .HasConstraintName("FK_Book_Author_Book");
        });

        modelBuilder.Entity<BookGenre>(entity =>
        {
            entity.ToTable("Book_Genre");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdBook).HasColumnName("ID_Book");
            entity.Property(e => e.IdGenre).HasColumnName("ID_Genre");

            entity.HasOne(d => d.IdBookNavigation).WithMany(p => p.BookGenres)
                .HasForeignKey(d => d.IdBook)
                .HasConstraintName("FK_Book_Genre_Book");

            entity.HasOne(d => d.IdGenreNavigation).WithMany(p => p.BookGenres)
                .HasForeignKey(d => d.IdGenre)
                .HasConstraintName("FK_Book_Genre_Genre");
        });

        modelBuilder.Entity<CopyOfBook>(entity =>
        {
            entity.ToTable("Copy_of_book");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdBook).HasColumnName("ID_Book");

            entity.HasOne(d => d.IdBookNavigation).WithMany(p => p.CopyOfBooks)
                .HasForeignKey(d => d.IdBook)
                .HasConstraintName("FK_Copy_of_book_Book");
        });

        modelBuilder.Entity<Debtor>(entity =>
        {
            entity.ToTable("Debtor");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdIssuedBook).HasColumnName("ID_Issued_book");

            entity.HasOne(d => d.IdIssuedBookNavigation).WithMany(p => p.Debtors)
                .HasForeignKey(d => d.IdIssuedBook)
                .HasConstraintName("FK_Debtor_Issued_book");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.ToTable("Genre");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<IssuedBook>(entity =>
        {
            entity.ToTable("Issued_book");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateOfIssue)
                .HasColumnType("date")
                .HasColumnName("Date_of_issue");
            entity.Property(e => e.DateOfPlannedDelivery)
                .HasColumnType("date")
                .HasColumnName("Date_of_planned_delivery");
            entity.Property(e => e.IdCopyOfBook).HasColumnName("ID_Copy_of_book");
            entity.Property(e => e.IdLibrarian).HasColumnName("ID_Librarian");
            entity.Property(e => e.IdReader).HasColumnName("ID_Reader");

            entity.HasOne(d => d.IdCopyOfBookNavigation).WithMany(p => p.IssuedBooks)
                .HasForeignKey(d => d.IdCopyOfBook)
                .HasConstraintName("FK_Issued_book_Copy_of_book");

            entity.HasOne(d => d.IdLibrarianNavigation).WithMany(p => p.IssuedBooks)
                .HasForeignKey(d => d.IdLibrarian)
                .HasConstraintName("FK_Issued_book_Librarian");

            entity.HasOne(d => d.IdReaderNavigation).WithMany(p => p.IssuedBooks)
                .HasForeignKey(d => d.IdReader)
                .HasConstraintName("FK_Issued_book_Reader");
        });

        modelBuilder.Entity<Librarian>(entity =>
        {
            entity.ToTable("Librarian");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Penalty>(entity =>
        {
            entity.ToTable("Penalty");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.SizeOfPenalty).HasColumnName("size_of_penalty");
        });

        modelBuilder.Entity<PenaltyDebtor>(entity =>
        {
            entity.ToTable("Penalty_Debtor");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdDebtor).HasColumnName("ID_Debtor");
            entity.Property(e => e.IdPenalty).HasColumnName("ID_Penalty");

            entity.HasOne(d => d.IdDebtorNavigation).WithMany(p => p.PenaltyDebtors)
                .HasForeignKey(d => d.IdDebtor)
                .HasConstraintName("FK_Penalty_Debtor_Debtor");

            entity.HasOne(d => d.IdPenaltyNavigation).WithMany(p => p.PenaltyDebtors)
                .HasForeignKey(d => d.IdPenalty)
                .HasConstraintName("FK_Penalty_Debtor_Penalty");
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.ToTable("Publisher");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Queue>(entity =>
        {
            entity.ToTable("Queue");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdBook).HasColumnName("ID_Book");
            entity.Property(e => e.IdReader).HasColumnName("ID_Reader");
            entity.Property(e => e.NumberInQueue).HasColumnName("Number_in_queue");

            entity.HasOne(d => d.IdBookNavigation).WithMany(p => p.Queues)
                .HasForeignKey(d => d.IdBook)
                .HasConstraintName("FK_Queue_Book");

            entity.HasOne(d => d.IdReaderNavigation).WithMany(p => p.Queues)
                .HasForeignKey(d => d.IdReader)
                .HasConstraintName("FK_Queue_Reader");
        });

        modelBuilder.Entity<Reader>(entity =>
        {
            entity.ToTable("Reader");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.Login, "Unique_Users_Login").IsUnique();

            entity.Property(e => e.Login)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.Password).IsRequired();
            entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
