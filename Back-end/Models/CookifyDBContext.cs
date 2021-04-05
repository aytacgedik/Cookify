using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Back_end.Models
{
    public partial class CookifyDBContext : DbContext
    {
        public CookifyDBContext()
        {
        }

        public CookifyDBContext(DbContextOptions<CookifyDBContext> options)
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
                optionsBuilder.UseMySQL("server=cookifydb.c6pepxozpcek.eu-central-1.rds.amazonaws.com;uid=admin;pwd=iamadmin;database=CookifyDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.ToTable("Ingredient");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CaloriesPer100Gr).HasColumnName("caloriesPer100Gr");

                entity.Property(e => e.IngredientName)
                    .HasMaxLength(100)
                    .HasColumnName("ingredientName");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.ToTable("Recipe");

                entity.HasIndex(e => e.CreatorId, "fk_creatorId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatorId).HasColumnName("creatorId");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.RecipeDescription).HasColumnName("recipeDescription");

                entity.Property(e => e.RecipeName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("recipeName");

                entity.Property(e => e.Tag)
                    .HasMaxLength(50)
                    .HasColumnName("tag");

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_creatorId");
            });

            modelBuilder.Entity<RecipeIngredient>(entity =>
            {
                entity.ToTable("RecipeIngredient");

                entity.HasIndex(e => e.IngredientId, "fk_recipeIngredient_ingredientId");

                entity.HasIndex(e => e.RecipeId, "fk_recipeIngredient_recipeId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IngredientId).HasColumnName("ingredientId");

                entity.Property(e => e.RecipeId).HasColumnName("recipeId");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.RecipeIngredients)
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_recipeIngredient_ingredientId");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipeIngredients)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_recipeIngredient_recipeId");
            });

            modelBuilder.Entity<SavedRecipe>(entity =>
            {
                entity.ToTable("SavedRecipe");

                entity.HasIndex(e => e.RecipeId, "fk_recipeId");

                entity.HasIndex(e => e.UserId, "fk_userId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RecipeId).HasColumnName("recipeId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.SavedRecipes)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_recipeId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SavedRecipes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_userId");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User_");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("firstname");

                entity.Property(e => e.Isadmin).HasColumnName("isadmin");

                entity.Property(e => e.Isverified).HasColumnName("isverified");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("surname");
            });

            modelBuilder.Entity<UserFriend>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("UserFriend");

                entity.HasIndex(e => e.UserFollowedId, "fk_userfollowedId");

                entity.HasIndex(e => e.UserFollowerId, "fk_userfollowerId");

                entity.Property(e => e.UserFollowedId).HasColumnName("userFollowedId");

                entity.Property(e => e.UserFollowerId).HasColumnName("userFollowerId");

                entity.HasOne(d => d.UserFollowed)
                    .WithMany()
                    .HasForeignKey(d => d.UserFollowedId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_userfollowedId");

                entity.HasOne(d => d.UserFollower)
                    .WithMany()
                    .HasForeignKey(d => d.UserFollowerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_userfollowerId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
