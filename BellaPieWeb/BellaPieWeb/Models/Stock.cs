using System.ComponentModel.DataAnnotations;

namespace BellaPieWeb.Models
{
    public class Stock
    {

        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }

		[DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }
	}
}
