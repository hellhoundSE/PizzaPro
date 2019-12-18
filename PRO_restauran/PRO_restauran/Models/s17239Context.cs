using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PRO_restauran.Models
{
    public partial class s17239Context : DbContext
    {
        public s17239Context()
        {
        }

        public s17239Context(DbContextOptions<s17239Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Additional> Additional { get; set; }
        public virtual DbSet<AdditionalToMeal> AdditionalToMeal { get; set; }
        public virtual DbSet<Bill> Bill { get; set; }
        public virtual DbSet<Delivery> Delivery { get; set; }
        public virtual DbSet<Deliveryman> Deliveryman { get; set; }
        public virtual DbSet<Ingredient> Ingredient { get; set; }
        public virtual DbSet<IngredientToRecipe> IngredientToRecipe { get; set; }
        public virtual DbSet<Meal> Meal { get; set; }
        public virtual DbSet<MealToOrder> MealToOrder { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Restaurant> Restaurant { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<User> User { get; set; }

        // Unable to generate entity type for table 'dbo.DEPT'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.SALGRADE'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s17239;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Additional>(entity =>
            {
                entity.HasKey(e => e.IdAdditional)
                    .HasName("Additional_pk");

                entity.Property(e => e.IdAdditional)
                    .HasColumnName("id_additional")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.TypeIdType).HasColumnName("Type_id_type");

                entity.HasOne(d => d.TypeIdTypeNavigation)
                    .WithMany(p => p.Additional)
                    .HasForeignKey(d => d.TypeIdType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Additionally_Type");
            });

            modelBuilder.Entity<AdditionalToMeal>(entity =>
            {
                entity.HasKey(e => new { e.MealIdMeal, e.AdditionalIdAdditional })
                    .HasName("Additional_to_meal_pk");

                entity.ToTable("Additional_to_meal");

                entity.Property(e => e.MealIdMeal).HasColumnName("Meal_id_meal");

                entity.Property(e => e.AdditionalIdAdditional).HasColumnName("Additional_id_additional");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.HasOne(d => d.AdditionalIdAdditionalNavigation)
                    .WithMany(p => p.AdditionalToMeal)
                    .HasForeignKey(d => d.AdditionalIdAdditional)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Additionally_to_meal_Additionally");

                entity.HasOne(d => d.MealIdMealNavigation)
                    .WithMany(p => p.AdditionalToMeal)
                    .HasForeignKey(d => d.MealIdMeal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Additionally_to_meal_Meal");
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.HasKey(e => e.IdBill)
                    .HasName("Bill_pk");

                entity.Property(e => e.IdBill)
                    .HasColumnName("id_bill")
                    .ValueGeneratedNever();

                entity.Property(e => e.OrderIdOrder).HasColumnName("Order_id_order");

                entity.Property(e => e.PaymentMethod)
                    .IsRequired()
                    .HasColumnName("payment_method")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Time).HasColumnName("time");

                entity.Property(e => e.TotalCost).HasColumnName("total_cost");

                entity.HasOne(d => d.OrderIdOrderNavigation)
                    .WithMany(p => p.Bill)
                    .HasForeignKey(d => d.OrderIdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Bill_Order");
            });

            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.HasKey(e => e.IdDelivery)
                    .HasName("Delivery_pk");

                entity.Property(e => e.IdDelivery)
                    .HasColumnName("id_delivery")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BillIdBill).HasColumnName("Bill_id_bill");

                entity.Property(e => e.DeliveryTime)
                    .HasColumnName("delivery_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeliverymanIdDeliveryman).HasColumnName("Deliveryman_id_deliveryman");

                entity.Property(e => e.RestaurantIdRestaurant).HasColumnName("Restaurant_id_restaurant");

                entity.Property(e => e.UserIdUser).HasColumnName("User_id_user");

                entity.HasOne(d => d.BillIdBillNavigation)
                    .WithMany(p => p.Delivery)
                    .HasForeignKey(d => d.BillIdBill)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Delivery_Bill");

                entity.HasOne(d => d.DeliverymanIdDeliverymanNavigation)
                    .WithMany(p => p.Delivery)
                    .HasForeignKey(d => d.DeliverymanIdDeliveryman)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Delivery_Deliveryman");

                entity.HasOne(d => d.RestaurantIdRestaurantNavigation)
                    .WithMany(p => p.Delivery)
                    .HasForeignKey(d => d.RestaurantIdRestaurant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Delivery_Restauran");

                entity.HasOne(d => d.UserIdUserNavigation)
                    .WithMany(p => p.Delivery)
                    .HasForeignKey(d => d.UserIdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Delivery_User");
            });

            modelBuilder.Entity<Deliveryman>(entity =>
            {
                entity.HasKey(e => e.IdDeliveryman)
                    .HasName("Deliveryman_pk");

                entity.Property(e => e.IdDeliveryman)
                    .HasColumnName("id_deliveryman")
                    .ValueGeneratedNever();

                entity.Property(e => e.EmploymentDate)
                    .HasColumnName("employment_date")
                    .HasColumnType("date");

                entity.Property(e => e.HomeAddress)
                    .IsRequired()
                    .HasColumnName("home_address")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Salary).HasColumnName("salary");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });


            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.HasKey(e => e.IdIngredient)
                    .HasName("Ingredient_pk");

                entity.Property(e => e.IdIngredient)
                    .HasColumnName("id_Ingredient")
                    .ValueGeneratedNever();

                entity.Property(e => e.Calories).HasColumnName("calories");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Spicy).HasColumnName("spicy");

                entity.Property(e => e.Vegetarian).HasColumnName("vegetarian");
            });

            modelBuilder.Entity<IngredientToRecipe>(entity =>
            {
                entity.HasKey(e => e.IngredientIdIngredient)
                    .HasName("Ingredient_to_recipe_pk");

                entity.ToTable("Ingredient_to_recipe");

                entity.Property(e => e.IngredientIdIngredient)
                    .HasColumnName("Ingredient_id_Ingredient")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.MealIdMeal).HasColumnName("Meal_id_meal");

                entity.HasOne(d => d.IngredientIdIngredientNavigation)
                    .WithOne(p => p.IngredientToRecipe)
                    .HasForeignKey<IngredientToRecipe>(d => d.IngredientIdIngredient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Ingredient_to_receipt_Ingredient");

                entity.HasOne(d => d.MealIdMealNavigation)
                    .WithMany(p => p.IngredientToRecipe)
                    .HasForeignKey(d => d.MealIdMeal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Ingredient_to_recipe_Meal");
            });

            modelBuilder.Entity<Meal>(entity =>
            {
                entity.HasKey(e => e.IdMeal)
                    .HasName("Meal_pk");

                entity.Property(e => e.IdMeal)
                    .HasColumnName("id_meal")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.TypeIdType).HasColumnName("Type_id_type");

                entity.HasOne(d => d.TypeIdTypeNavigation)
                    .WithMany(p => p.Meal)
                    .HasForeignKey(d => d.TypeIdType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Meal_Type");
            });

            modelBuilder.Entity<MealToOrder>(entity =>
            {
                entity.HasKey(e => new { e.OrderIdOrder, e.MealIdMeal })
                    .HasName("meal_to_order_pk");

                entity.ToTable("meal_to_order");

                entity.Property(e => e.OrderIdOrder).HasColumnName("Order_id_order");

                entity.Property(e => e.MealIdMeal).HasColumnName("Meal_id_meal");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.HasOne(d => d.MealIdMealNavigation)
                    .WithMany(p => p.MealToOrder)
                    .HasForeignKey(d => d.MealIdMeal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("meal_to_order_Meal");

                entity.HasOne(d => d.OrderIdOrderNavigation)
                    .WithMany(p => p.MealToOrder)
                    .HasForeignKey(d => d.OrderIdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("meal_to_order_Order");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("Order_pk");

                entity.Property(e => e.IdOrder)
                    .HasColumnName("id_order")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cost).HasColumnName("cost");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.HasKey(e => e.IdRestaurant)
                    .HasName("Restaurant_pk");

                entity.Property(e => e.IdRestaurant)
                    .HasColumnName("id_restaurant")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Size).HasColumnName("size");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.HasKey(e => e.IdType)
                    .HasName("Type_pk");

                entity.Property(e => e.IdType)
                    .HasColumnName("id_type")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("User_pk");

                entity.Property(e => e.IdUser)
                    .HasColumnName("id_user")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnName("phone_number")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });
        }
    }
}
