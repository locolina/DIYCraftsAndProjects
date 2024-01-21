using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DIYCraftsAndProjectsMVC.Models;

public partial class CraftsAndProjectsDbContext : DbContext
{
    public CraftsAndProjectsDbContext()
    {
    }

    public CraftsAndProjectsDbContext(DbContextOptions<CraftsAndProjectsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<PostScore> PostScores { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<ReportedType> ReportedTypes { get; set; }

    public virtual DbSet<TypeOfUser> TypeOfUsers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserFollowUser> UserFollowUsers { get; set; }

    public virtual DbSet<UserScore> UserScores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DIY");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__comment__E79576870081E94A");

            entity.ToTable("comment");

            entity.Property(e => e.CommentId).HasColumnName("comment_id");
            entity.Property(e => e.Comment1)
                .HasMaxLength(255)
                .HasColumnName("comment");
            entity.Property(e => e.Highlighted).HasColumnName("highlighted");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.Posted)
                .HasColumnType("datetime")
                .HasColumnName("posted");
            entity.Property(e => e.Reported).HasColumnName("reported");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK__comment__parent___4CA06362");

            entity.HasOne(d => d.Post).WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__comment__post_id__05D8E0BE");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__comment__user_id__4D94879B");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__country__7E8CD055AE6AE2FE");

            entity.ToTable("country");

            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CountryName)
                .HasMaxLength(255)
                .HasColumnName("country_name");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__notifica__E059842F2771E382");

            entity.ToTable("notification");

            entity.Property(e => e.NotificationId).HasColumnName("notification_id");
            entity.Property(e => e.Content)
                .HasMaxLength(255)
                .HasColumnName("content");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.SenderId).HasColumnName("sender_id");
            entity.Property(e => e.Sent)
                .HasColumnType("datetime")
                .HasColumnName("sent");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK__notificat__paren__5165187F");

            entity.HasOne(d => d.Sender).WithMany(p => p.NotificationSenders)
                .HasForeignKey(d => d.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__notificat__sende__52593CB8");

            entity.HasOne(d => d.User).WithMany(p => p.NotificationUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__notificat__user___5070F446");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__post__3ED7876671156C79");

            entity.ToTable("post");

            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.DateDeleted)
                .HasColumnType("datetime")
                .HasColumnName("date_deleted");
            entity.Property(e => e.DatePosted)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date_posted");
            entity.Property(e => e.FileType)
                .HasMaxLength(255)
                .HasColumnName("file_type");
            entity.Property(e => e.Public).HasColumnName("public");
            entity.Property(e => e.Score)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("score");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Views).HasColumnName("views");

            entity.HasOne(d => d.User).WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__post__user_id__02FC7413");
        });

        modelBuilder.Entity<PostScore>(entity =>
        {
            entity.HasKey(e => e.PostScoreId).HasName("PK__post_sco__85410F4E1D6742BD");

            entity.ToTable("post_score");

            entity.Property(e => e.PostScoreId).HasColumnName("post_score_id");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.Score).HasColumnName("score");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Post).WithMany(p => p.PostScores)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__post_scor__post___03F0984C");

            entity.HasOne(d => d.User).WithMany(p => p.PostScores)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__post_scor__user___44FF419A");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__report__779B7C589DDD59C4");

            entity.ToTable("report");

            entity.Property(e => e.ReportId).HasColumnName("report_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.ReportedId).HasColumnName("reported_id");
            entity.Property(e => e.ReportedTypeId).HasColumnName("reported_type_id");
            entity.Property(e => e.ReportingId).HasColumnName("reporting_id");
            entity.Property(e => e.Resolved).HasColumnName("resolved");
            entity.Property(e => e.Sent)
                .HasColumnType("datetime")
                .HasColumnName("sent");

            entity.HasOne(d => d.Reported).WithMany(p => p.ReportReporteds)
                .HasForeignKey(d => d.ReportedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__report__reported__5535A963");

            entity.HasOne(d => d.ReportedType).WithMany(p => p.Reports)
                .HasForeignKey(d => d.ReportedTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__report__reported__571DF1D5");

            entity.HasOne(d => d.Reporting).WithMany(p => p.ReportReportings)
                .HasForeignKey(d => d.ReportingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__report__reportin__5629CD9C");
        });

        modelBuilder.Entity<ReportedType>(entity =>
        {
            entity.HasKey(e => e.ReportedTypeId).HasName("PK__reported__8412431FB7B52DA4");

            entity.ToTable("reported_type");

            entity.Property(e => e.ReportedTypeId).HasColumnName("reported_type_id");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
        });

        modelBuilder.Entity<TypeOfUser>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__type_of___2C000598D3D73EBF");

            entity.ToTable("type_of_user");

            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.TypeName)
                .HasMaxLength(255)
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__user__B9BE370F845F4379");

            entity.ToTable("user");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.DateCreated).HasColumnName("date_created");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Score)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("score");
            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .HasColumnName("user_name");

            entity.HasOne(d => d.Country).WithMany(p => p.Users)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__user__country_id__3D5E1FD2");

            entity.HasOne(d => d.Type).WithMany(p => p.Users)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__user__type_id__3E52440B");
        });

        modelBuilder.Entity<UserFollowUser>(entity =>
        {
            entity.HasKey(e => e.IdUserFollowUser).HasName("PK__user_fol__3ABB68B319B1B268");

            entity.ToTable("user_follow_user");

            entity.Property(e => e.IdUserFollowUser).HasColumnName("Id_user_follow_user");
            entity.Property(e => e.UserFollowedId).HasColumnName("user_followed_Id");
            entity.Property(e => e.UserFollowingId).HasColumnName("user_following_Id");

            entity.HasOne(d => d.UserFollowed).WithMany(p => p.UserFollowUserUserFolloweds)
                .HasForeignKey(d => d.UserFollowedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_follow_user_user_followed_Id");

            entity.HasOne(d => d.UserFollowing).WithMany(p => p.UserFollowUserUserFollowings)
                .HasForeignKey(d => d.UserFollowingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_follow_user_user_following_Id");
        });

        modelBuilder.Entity<UserScore>(entity =>
        {
            entity.HasKey(e => e.UserScoreId).HasName("PK__user_sco__73A280CF72034DA9");

            entity.ToTable("user_score");

            entity.Property(e => e.UserScoreId).HasColumnName("user_score_id");
            entity.Property(e => e.Score).HasColumnName("score");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserIdScorer).HasColumnName("user_id_scorer");

            entity.HasOne(d => d.User).WithMany(p => p.UserScoreUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__user_scor__user___47DBAE45");

            entity.HasOne(d => d.UserIdScorerNavigation).WithMany(p => p.UserScoreUserIdScorerNavigations)
                .HasForeignKey(d => d.UserIdScorer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__user_scor__user___48CFD27E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
