namespace BasketApi.Models;

public class Basket
{
    public string UserName { get; set; } = default!;
    public List<BasketItem> Items { get; set; } = new();
    public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);

    public Basket(string userName)
    {
        UserName = userName;
    }

    //Required for Mapping
    public Basket() { }
}
