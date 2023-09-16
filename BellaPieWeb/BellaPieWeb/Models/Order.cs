namespace BellaPieWeb.Models
{
    public class Order
    {

        public int Id { get; set; }

        public DateOnly Date { get; set; }

        public int UserId{ get; set; }

        public Decimal Total { get; set; }
    }
}
