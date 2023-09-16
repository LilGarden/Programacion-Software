using System.ComponentModel.DataAnnotations;

namespace BellaPieWeb.Models
{
	public class Trend
	{
        public int Id { get; set; }

		[DataType(DataType.Date)]
		public DateTime Date { get; set; }

        public string Title { get; set; }
		public string Trends { get; set; }


	}
}
