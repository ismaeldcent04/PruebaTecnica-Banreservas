Beer presidenteBeer = new Beer("Presidente", 8);
Console.WriteLine(presidenteBeer.Name);
Console.WriteLine(presidenteBeer.GetInfo());

public class Beer
{
    public string Name { get; set; }

    public decimal Price { get; set; }

    public Beer(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public string GetInfo()
    {
        return "Nombre: " + Name + ", Precio: $" + Price;
    }
}

