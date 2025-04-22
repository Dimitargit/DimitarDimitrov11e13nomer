using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace DimitarDimitrov11e.Data.Models
{
	public class Reader
	{
		[Required]
		[Key]
		public int Id { get; set; }
		[Required]
		[MaxLength(50)]	
		public string Name { get; set; }
		[Required]
		[Range(10, 80)]
		public int Age {  get; set; }
		[Required]
		[MaxLength(20)]
		public string Email {  get; set; }
		[Required]
		[MaxLength(10)]
		public string PhoneNumber { get; set; }
		[Required]
		public List<Book> Books { get; set; }
		public Reader(int id, string name, int age, string email, string phoneNumber)
		{
			Id = id;
			Name = name;
			Age = age;
			Email = email;
			PhoneNumber = phoneNumber;
			Books = new List<Book>();
		}
	}
}
