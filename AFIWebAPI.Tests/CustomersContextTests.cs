using AFIWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AFIWebAPI.Tests
{
    public class CustomersContextTests : TestWithSqlite
    {
        readonly Customer newItem = new Customer()
        {
            ID = Guid.NewGuid(),
            FirstName = "TestName",
            Surname = "TestSurname",
            RefNo = "TT-123456",
            DateOfBirth = DateTime.Parse("1994/09/19"),
            Email = "test@example.com"
        };

        [Fact]
        public async Task DatabaseIsAvailableAndCanBeConnectedTo()
        {
            Assert.True(await DbContext.Database.CanConnectAsync());
        }

        [Fact]
        public void TableShouldGetCreated()
        {
            Assert.False(DbContext.Customers.Any());
        }

        [Fact]
        public void FirstNameCannotBeNull()
        {
            newItem.FirstName = null;
            DbContext.Customers.Add(newItem);

            Assert.Throws<DbUpdateException>(() => DbContext.SaveChanges());
        }

        [Fact]
        public void AddedItemShouldGetGenerated()
        {
            DbContext.Customers.Add(newItem);
            DbContext.SaveChanges();

            Assert.NotEqual(Guid.Empty, newItem.ID);
        }

        [Fact]
        public void AddedItemShouldGetPersisted()
        {
            DbContext.Customers.Add(newItem);
            DbContext.SaveChanges();

            Assert.Equal(newItem, DbContext.Customers.Find(newItem.ID));
            Assert.Equal(1, DbContext.Customers.Count());
        }

        [Fact]
        public void GetAddedItemByIdAndMatchEmail()
        {
            DbContext.Customers.Add(newItem);
            DbContext.SaveChanges();

            Assert.Equal("test@example.com", DbContext.Customers.Find(newItem.ID).Email);
        }

        [Fact]
        public void GetAddedItemShouldGetUpdated()
        {
            newItem.FirstName = "Updated";
            DbContext.Customers.Add(newItem);
            DbContext.SaveChanges();

            Assert.Equal("Updated", DbContext.Customers.Find(newItem.ID).FirstName);
        }
    }
}
