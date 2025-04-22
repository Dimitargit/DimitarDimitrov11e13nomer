using DimitarDimitrov11e.Controller;
using DimitarDimitrov11e.Data;
using DimitarDimitrov11e.Data.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework.Api;
using System.Reflection.PortableExecutable;


namespace TestProject1
{
	public class Tests
	{

		private ReaderController controller;
		private MyContext context;

		[SetUp]
		public void Setup()
		{
			var options = new DbContextOptionsBuilder<MyContext>()
				.UseInMemoryDatabase(databaseName: "TestDB_" + System.Guid.NewGuid().ToString())
				.Options;

			context = new MyContext(options);
			controller = new ReaderController();
			controller.GetType()
					  .GetField("context", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
					  ?.SetValue(controller, context);
		}

		[Test]
		public void Create_ShouldAddNewReader()
		{
			var reader = new Reader(1, "Alice", 25, "alice@example.com", "1234567890");

			controller.Create(reader);

			var result = context.Readers.FirstOrDefault(r => r.Id == 1);
			Assert.That(result, Is.Not.Null);
			Assert.That(Equals("Alice", result.Name));
		}

		[Test]
		public void Read_ShouldReturnReader()
		{
			var reader = new Reader(2, "Bob", 30, "bob@example.com", "0987654321");
			context.Readers.Add(reader);
			context.SaveChanges();

			var result = controller.Read(2);

			Assert.That(result, Is.Not.Null);
			Assert.That(Equals("Bob", result.Name));
		}

		[Test]
		public void ReadAll_ShouldReturnAllReaders()
		{
			context.Readers.Add(new Reader(3, "Tom", 40, "tom@example.com", "1111111111"));
			context.Readers.Add(new Reader(4, "Jerry", 35, "jerry@example.com", "2222222222"));
			context.SaveChanges();

			var result = controller.ReadAll();

			Assert.That(Equals(2, result.Count));
		}

		[Test]
		public void Update_ShouldUpdateReaderInfo()
		{
			var reader = new Reader(5, "Old Name", 20, "old@example.com", "3333333333");
			context.Readers.Add(reader);
			context.SaveChanges();

			controller.Update(5, 5, "New Name", 21, "new@example.com", "4444444444", new List<Book>());

			var updated = context.Readers.FirstOrDefault(r => r.Id == 5);
			Assert.That(updated, Is.Not.Null);
			Assert.That(Equals("New Name", updated.Name));
			Assert.That(Equals(21, updated.Age));
			Assert.That(Equals("new@example.com", updated.Email));
			Assert.That(Equals("4444444444", updated.PhoneNumber));
		}

		[Test]
		public void Delete_ShouldDeleteReader()
		{
			var reader = new Reader(6, "ToDelete", 50, "delete@example.com", "5555555555");
			context.Readers.Add(reader);
			context.SaveChanges();

			controller.Delete(6);

			var deleted = context.Readers.FirstOrDefault(r => r.Id == 6);
			Assert.That(deleted, Is.Null);
		}

		[TearDown]
		public void TearDown()
		{
			context.Dispose();
		}
	}
}
