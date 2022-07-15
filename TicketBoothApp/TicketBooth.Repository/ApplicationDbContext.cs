using System;
using TicketBooth.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TicketBooth.Domain.DomainModels;

namespace TicketBooth.Repository
{
    public class ApplicationDbContext : IdentityDbContext<TicketBoothUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Order> OrderItems { get; set; }
        public virtual DbSet<Theater> Theaters { get; set; }
        public virtual DbSet<Cart> ShoppingCarts { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Movie>()
                 .Property(z => z.Id)
                 .ValueGeneratedOnAdd();

            builder.Entity<Cart>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Ticket>()
               .Property(z => z.Id)
               .ValueGeneratedOnAdd();

            builder.Entity<Cart>()
                .HasOne<TicketBoothUser>(z => z.Owner)
                .WithOne(z => z.Cart)
                .HasForeignKey<Cart>(z => z.OwnerId);

            builder.Entity<Order>()
                .HasOne(z => z.Cart)
                .WithMany(z => z.OrdersInCart)
                .HasForeignKey(z => z.CartId);

            builder.Entity<Order>()
                .HasOne(z => z.Theater)
                .WithMany(z => z.Orders)
                .HasForeignKey(z => z.TheaterId);

            builder.Entity<Ticket>()
                .HasOne(z => z.Order)
                .WithMany(z => z.Tickets)
                .HasForeignKey(z => z.OrderId);

            builder.Entity<Theater>()
                .HasOne(z => z.Movie)
                .WithMany(z => z.Theaters)
                .HasForeignKey(z => z.MovieId);

            builder.Entity<Ticket>()
                .HasOne(z => z.Theater)
                .WithMany(z => z.Tickets)
                .HasForeignKey(z => z.TheaterId);
        }
    }
}
