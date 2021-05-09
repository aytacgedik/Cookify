using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Back_end.DatabaseModels
{
    public partial class CookifyContext : DbContext
    {
        public CookifyContext()
        {
        }

        public CookifyContext(DbContextOptions<CookifyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public virtual DbSet<SavedRecipe> SavedRecipes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserFriend> UserFriends { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:sedbserver.database.windows.net,1433;Initial Catalog=Cookify;Persist Security Info=False;User ID=admingroupf;Password=admin.12345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.ToTable("Ingredient");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.ToTable("Recipe");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatorId).HasColumnName("creatorId");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Rating)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("rating");

                entity.Property(e => e.Tag)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tag");

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.CreatorId)
                    .HasConstraintName("FK__Recipe__creatorI__656C112C");
            });

            modelBuilder.Entity<RecipeIngredient>(entity =>
            {
                entity.ToTable("RecipeIngredient");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IngredientId).HasColumnName("ingredientId");

                entity.Property(e => e.RecipeId).HasColumnName("recipeId");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.RecipeIngredients)
                    .HasForeignKey(d => d.IngredientId)
                    .HasConstraintName("FK__RecipeIng__ingre__70DDC3D8");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipeIngredients)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK__RecipeIng__recip__6FE99F9F");
            });

            modelBuilder.Entity<SavedRecipe>(entity =>
            {
                entity.ToTable("SavedRecipe");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RecipeId).HasColumnName("recipeId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.SavedRecipes)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK__SavedReci__recip__693CA210");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SavedRecipes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__SavedReci__userI__68487DD7");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Admin).HasColumnName("admin");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Surname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("surname");

                entity.Property(e => e.Verified).HasColumnName("verified");
            });

            modelBuilder.Entity<UserFriend>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("UserFriend");

                entity.Property(e => e.UserFollowedId).HasColumnName("userFollowedId");

                entity.Property(e => e.UserFollowerId).HasColumnName("userFollowerId");

                entity.HasOne(d => d.UserFollowed)
                    .WithMany()
                    .HasForeignKey(d => d.UserFollowedId)
                    .HasConstraintName("FK__UserFrien__userF__628FA481");

                entity.HasOne(d => d.UserFollower)
                    .WithMany()
                    .HasForeignKey(d => d.UserFollowerId)
                    .HasConstraintName("FK__UserFrien__userF__619B8048");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
