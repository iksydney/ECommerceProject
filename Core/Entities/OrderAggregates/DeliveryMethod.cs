namespace Core.Entities.OrderAggregates
{
    public class DeliveryMethod : BaseEntity<int>
    {
        public string ShortName { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public string DeliveryTime { get; set; }
    }
}
