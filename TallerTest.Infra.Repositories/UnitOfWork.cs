using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

using TallerTest.Domain.Aggregations.CarAgg;
using TallerTest.Domain.Aggregations.MakeAgg;
using TallerTest.Domain.Seedwork;

namespace TallerTest.Infra.Repositories
{
    public class UnitOfWork : DbContext, IUnitOfWork
    {
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Make> Make { get; set; }

        public UnitOfWork(DbContextOptions<UnitOfWork> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Make>().HasData(
            //    new Make { Id = 1, Name = "Audi" },
            //    new Make { Id = 2, Name = "Tesla" },
            //    new Make { Id = 3, Name = "Porsche" },
            //    new Make { Id = 4, Name = "Mercedes-Benz" },
            //    new Make { Id = 5, Name = "BMW" }
            //    );

            //modelBuilder.Entity<Car>().HasData(
            //    new Car { Id = 1, MakeId = 1, Name = "R8", Year = 2018, Doors = 2, Color = "Red", Price = 79995 },
            //    new Car { Id = 2, MakeId = 2, Name = "3", Year = 2018, Doors = 4, Color = "Black", Price = 54995 },
            //    new Car { Id = 3, MakeId = 3, Name = "911 991", Year = 2020, Doors = 2, Color = "White", Price = 155000 },
            //    new Car { Id = 4, MakeId = 4, Name = "GLE 63S", Year = 2021, Doors = 5, Color = "Blue", Price = 83995 },
            //    new Car { Id = 5, MakeId = 5, Name = "X6 M", Year = 2020, Doors = 5, Color = "Silver", Price = 62995 }
            //    );


            

        }

        public void Commit()
        {
            SaveChanges();
        }
    }
}
