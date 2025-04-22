using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace DimitarDimitrov11e.Data.Models
{
	public class Book
	{
		[Key]
		[Required]
		public int Id { get; set; }
		[Required]
		[MaxLength(50)]
		public string Title {  get; set; }
		[MaxLength(50)]
		public string Author { get; set; }
		public List<Reader> Readers { get; set; }
		public List<Genre> Genres { get; set; }
		public Book(int id, string title, string author, List<Reader> readers, List<Genre> genres)
		{
			Id = id;
			Title = title;
			Author = author;
			Readers = readers;
			Genres = genres;
		}	
	}
}
