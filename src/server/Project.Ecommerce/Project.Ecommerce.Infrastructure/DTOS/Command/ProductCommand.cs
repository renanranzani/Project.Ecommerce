namespace Project.Ecommerce.Infrastructure.DTOS.Command
{
    public class ProductCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Inventory { get; set; }
        public decimal Value { get; set; }
        public bool Status { get; set; }
        public byte[] Image { get; set; }
    }
}
