using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimitarDimitrov11e.Data.Models
{
	public class Genre
	{
		[Key]
		public int Id { get; set; }
		[MaxLength(20)]
		public string Name { get; set; }
		public List<Reader> Readers { get; set; }
		public Genre(int id, string name, List<Reader> readers)
		{
			Id = id;
			Name = name;
			Readers = readers;
		}	
	}
}
