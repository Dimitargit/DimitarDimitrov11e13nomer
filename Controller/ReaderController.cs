using DimitarDimitrov11e.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DimitarDimitrov11e.Data.Models;
using DimitarDimitrov11e.Data;
using Microsoft.EntityFrameworkCore;

namespace DimitarDimitrov11e.Controller
{
	public class ReaderController
	{
		MyContext context;
		public ReaderController()
		{
			context = new MyContext();
		}
		public void Create(Reader reader)
		{
			context.Readers.Add(reader);
			context.SaveChanges();
		}
		public Reader Read(int id)
		{
			return context.Readers.FirstOrDefault(r => r.Id == id);
		}
		public List<Reader> ReadAll()
		{
			return context.Readers.ToList();
		}
		public void Update(int id, int newID, string newName, int newAge, string newEmail, string newPhoneNumber, List<Book> newBooks)
		{
			var item = context.Readers.Include(r => r.Books).FirstOrDefault(r => r.Id == id);
			if (item == null)
				return;

			item.Id = newID;
			item.Name = newName;
			item.Age = newAge;
			item.Email = newEmail;
			item.PhoneNumber = newPhoneNumber;
			item.Books = newBooks;

			context.SaveChanges();
		}
		public void Delete(int id)
		{
			var item = context.Readers.FirstOrDefault(r => r.Id == id);
			if (item == null)
				return;

			context.Readers.Remove(item);
			context.SaveChanges();
		}
	}
}
