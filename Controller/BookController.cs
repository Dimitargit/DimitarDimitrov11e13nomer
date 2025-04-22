using DimitarDimitrov11e.Data.Models;
using DimitarDimitrov11e.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DimitarDimitrov11e.Controller
{
	public class BookController
	{
		MyContext context;

		public BookController()
		{
			context = new MyContext();
		}

		public void Create(Book book)
		{
			context.Books.Add(book);
			context.SaveChanges();
		}

		public Book Read(int id)
		{
			return context.Books
				.Include(b => b.Readers)
				.Include(b => b.Genres)
				.FirstOrDefault(b => b.Id == id);
		}

		public List<Book> ReadAll()
		{
			return context.Books
				.Include(b => b.Readers)
				.Include(b => b.Genres)
				.ToList();
		}

		public void Update(int id, int newID, string newTitle, string newAuthor, List<Reader> newReaders, List<Genre> newGenres)
		{
			var item = context.Books
				.Include(b => b.Readers)
				.Include(b => b.Genres)
				.FirstOrDefault(b => b.Id == id);
			if (item == null)
				return;

			item.Id = newID;
			item.Title = newTitle;
			item.Author = newAuthor;
			item.Readers = newReaders;
			item.Genres = newGenres;

			context.SaveChanges();
		}

		public void Delete(int id)
		{
			var item = context.Books.FirstOrDefault(b => b.Id == id);
			if (item == null)
				return;

			context.Books.Remove(item);
			context.SaveChanges();
		}
	}
}
