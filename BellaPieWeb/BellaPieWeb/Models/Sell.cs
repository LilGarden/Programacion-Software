namespace BellaPieWeb.Models
{
	public class Sell
	{

        public int Id { get; set; }

		public int ClientId { get; set; }
        public int UserId { get; set; }

        public Decimal Total { get; set; }


	}
}
