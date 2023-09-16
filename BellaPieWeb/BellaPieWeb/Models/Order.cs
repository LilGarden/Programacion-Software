using System.ComponentModel.DataAnnotations;

namespace BellaPieWeb.Models
{
	public class Order
	{

        public int Id { get; set; }
		[DataType(DataType.Date)]
		public DateTime Date { get; set; }

        public int UserId{ get; set; }
		public int SupplierId { get; set; }

        public Decimal Total { get; set; }
	}
}
