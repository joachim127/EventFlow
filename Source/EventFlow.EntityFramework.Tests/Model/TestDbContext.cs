// The MIT License (MIT)
// 
// Copyright (c) 2015-2024 Rasmus Mikkelsen
// https://github.com/eventflow/EventFlow
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using EventFlow.EntityFramework.Extensions;
using EventFlow.EntityFramework.Tests.MsSql.IncludeTests.ReadModels;
using Microsoft.EntityFrameworkCore;

namespace EventFlow.EntityFramework.Tests.Model
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {
        }

        public DbSet<ThingyReadModelEntity> Thingys { get; set; }
        public DbSet<ThingyMessageReadModelEntity> ThingyMessages { get; set; }

        // Include tests
        public DbSet<PersonReadModelEntity> Persons { get; set; }
        public DbSet<AddressReadModelEntity> Addresses { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .AddEventFlowEvents()
                .AddEventFlowSnapshots();

            modelBuilder.Entity<ThingyMessageReadModelEntity>()
                .Property(e => e.MessageId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ThingyReadModelEntity>()
                .Property(e => e.AggregateId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<PersonReadModelEntity>()
                .Property(e => e.AggregateId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<AddressReadModelEntity>()
                .Property(e => e.AddressId)
                .ValueGeneratedNever();
        }
    }
}