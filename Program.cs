string greeting = @"Welcome to Thrown For a Loop
Your one-stop shop for used sporting equipment";

Console.WriteLine(greeting);

string choice = null;
while (choice != "0")
{
  Console.WriteLine(@"Choose an option: 
                      0. Exit
                      1. View Product List
                      2. View Product Details");
  choice = Console.ReadLine();
  if (choice == "0")
  {
    Console.WriteLine("Goodbye");
  } else if (choice == "1")
  {
    viewProductList();
  } else if (choice == "2")
  {
    ViewProductDetails();
  }
}

void ViewProductDetails()
{

  List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Football",
        Price = 15.00M,
        Sold = false,
        StockDate = new DateTime(2022, 10, 20),
        ManufactureYear = 2010
    },
    new Product()
    {
        Name = "Hockey Stick",
        Price = 12.00M,
        Sold = false,
        StockDate = new DateTime(2022, 10, 20),
        ManufactureYear = 2010
    },
    new Product()
    {
        Name = "Salem Bowl",
        Price = 10000.00M,
        Sold = true,
        StockDate = new DateTime(2020, 04, 05),
        ManufactureYear = 2020
    }
};

  Product chosenProduct = null;

  while (chosenProduct == null)
  {
    Console.WriteLine("Please enter a product number: ");
    try
    {
      int response = int.Parse(Console.ReadLine().Trim());
      chosenProduct = products[response - 1];
    }
    catch
    {
      Console.WriteLine("Do better!");
    }
  }

  // Manufacturing Date Math
  DateTime now = DateTime.Now;
  TimeSpan timeInStock = now - chosenProduct.StockDate;

  // Response after an inpupt is received from user
  Console.WriteLine(@$"You chose: 
{chosenProduct.Name}, which costs {chosenProduct.Price} dollars.
It is {now.Year - chosenProduct.ManufactureYear} years old. 
It {(chosenProduct.Sold ? "is not available." : $"has been in stock for {timeInStock.Days} days.")}");
}

void viewProductList()
{
    List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Football",
        Price = 15.00M,
        Sold = false,
        StockDate = new DateTime(2022, 10, 20),
        ManufactureYear = 2010
    },
    new Product()
    {
        Name = "Hockey Stick",
        Price = 12.00M,
        Sold = false,
        StockDate = new DateTime(2022, 10, 20),
        ManufactureYear = 2010
    },
    new Product()
    {
        Name = "Salem Bowl",
        Price = 10000.00M,
        Sold = true,
        StockDate = new DateTime(2020, 04, 05),
        ManufactureYear = 2020
    }
};

   for (int i = 0; i < products.Count; i++)
  {
    Console.WriteLine($"{i + 1}. {products[i].Name}");
  }

  decimal totalValue = 0.0M;
  foreach (Product product in products)
  {
    if (!product.Sold)
    {
      totalValue += product.Price;
    }
  }
  Console.WriteLine($"Total inventory value: {totalValue}");

}
