// See https://aka.ms/new-console-template for more information


using System.Text.Json;
using ClientApp;

var tools = new Tools();

var users = new List<string>();
// create two users
for (var i = 0; i < 2; i++)
{
    Console.WriteLine($"Enter the userName of User {i+1}:");
    var userName = Console.ReadLine();

    Console.WriteLine($"Enter the fullName of User {i+1}:");
    var fullName = Console.ReadLine();

    var userId = tools.CreateUser(new {
        userName = userName,
        password = "adm",
        fullName = fullName,
    });
    users.Add(userId);
}

foreach (var userId in users)
{
    for (int i = 0; i < 3; i++)
    {
        tools.CreateOrder(new
        {
            orderNumber = 0,
            orderDate = "2022-07-03T13:22:14.401Z",
            reference = "reference " + i ,
            customerName = "Random Customer" + i ,
            userId = JsonSerializer.Deserialize<string>(userId),
            lines = new[]
            {
                new {itemCode = "Item 1" + i, price = 10, quantity = 20},
                new {itemCode = "Item 2" + i, price = 20, quantity = 20},
                new {itemCode = "Item 3" + i, price = 130, quantity = 20},
                new {itemCode = "Item 4" + i, price = 140, quantity = 20},
                new {itemCode = "Item 5" + i, price = 50, quantity = 20},
                new {itemCode = "Item 6" + i, price = 101, quantity = 20},
                new {itemCode = "Item 7" + i, price = 10, quantity = 20},
                new {itemCode = "Item 8" + i, price = 10, quantity = 20},
                new {itemCode = "Item 9" + i, price = 10, quantity = 20},
            }
        });
    }
    
}

Console.WriteLine("Orders created.");
while (true)
{
    Console.WriteLine("Type in userName to see the orders. Type exit to exit.");
    var userName = Console.ReadLine();
    if(userName == "exit")
    {
        break;
    }
    var orders = tools.GetOrders(userName);
    var orderDtos = orders.OrderBy(c => c.User.FullName).ThenBy(c => c.OrderDate);

    foreach (var order in orderDtos)
    {
        order.Lines = order.Lines.OrderBy(o => o.LineNumber).ToList();
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine($"{order.User.FullName} - {order.OrderDate} - {order.OrderNumber} - {order.Reference}");
        foreach (var line in order.Lines)
        {
            Console.WriteLine($"\t{line.LineNumber} - {line.ItemCode} - {line.Price} - {line.Quantity}");
        }
    }
}

