using System.ComponentModel.DataAnnotations;

namespace BellaPieWeb.Models
{
    public class Report
    {

        public int Id { get; set; }
        public int UserId { get; set; }

		[DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
		public string Reports { get; set; }

    }
}
