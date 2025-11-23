public class OrderDto
{
    public Guid Id { get; set; }
    public string Details { get; set; } = "";
    public string Status { get; set; } = "";
    public DateTime CreatedAt { get; set; }
}