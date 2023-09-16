namespace BellaPieWeb.Models
{
	public class OrderProduct
	{
		public int Id { get; set; }
		public int OrderId { get; set; }
        public int ProductId { get; set; }

		public int Qty { get; set; }
        public int Price { get; set; }

    }
}
