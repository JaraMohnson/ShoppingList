using System.Collections;

bool gettingGroceries = true;
bool continueShopping = true;
double total = 0;

// Menu 
Dictionary<string, double> ShoppingList = new Dictionary<string, double>() // STRING = KEY, DOUBLE = VALUE 
{
    ["Tofu"] = 3.99,
    ["Eggs"] = 2.00,
    ["Bagels"] = 4.50,
    ["Tortillas"] = 2.89,
    ["Mango"] = 1.25,
    ["Waffles"] = 3.00,
    ["Oreos"] = 3.59,
    ["Raspberries"] = 2.99

};

List<string> ShoppingCart = new List<string>();
//aka list of KEYS ^^ 


// initial greeting 

Console.WriteLine("Welcome to the store");
Console.WriteLine("Press any key when you are ready to display our menu");
Console.ReadKey();



// display menu to user 
Console.WriteLine();
Console.WriteLine("CURRENT ITEMS AVAILABLE:");
Console.WriteLine("-----------------------");

foreach (KeyValuePair<string, double> kvp in ShoppingList)
{
    Console.WriteLine($"{kvp.Key} - ${kvp.Value} ");
}

// Gathering items 
while (gettingGroceries)
{
    Console.WriteLine("Please select the item you wish to add to your cart:");
    string addToCart = Console.ReadLine();

    if (ShoppingList.ContainsKey(addToCart))     // ContainsKey method searches through dictionary, returns T/F
    {
        ShoppingCart.Add(addToCart); 
    }
    else
    {
        Console.WriteLine("This option is not currently available");
        continue;
    }


    while (continueShopping=true)
    {
        Console.WriteLine("Continue shopping? Reply y/yes to continue or n/no to check out.");
        string continueShop = Console.ReadLine().ToLower().Trim();
        if (continueShop.Contains("y"))
        {
            break;
        }
        else if (continueShop.Contains("n"))
        {
            gettingGroceries = false;
            break;
        }
        else
        {
            continue;
        }
    }
}



double minPrice = 9999;
double maxPrice = 0;
string minName = "";
string maxName = "";


Console.WriteLine("You Ordered: ");
foreach (string item in ShoppingCart)
{
    Console.WriteLine($"{item}    ${ShoppingList[item]}");
    total += (ShoppingList[item]);
    if (ShoppingList[item] < minPrice)
    {
        minPrice = ShoppingList[item];
        minName = item;
    } 
    if (ShoppingList[item] > maxPrice)
    {
        maxPrice = ShoppingList[item];
        maxName = item;
    }
} 


Console.WriteLine($"Your total is ${total}");
Console.WriteLine($"The cheapest item - {minName}, {minPrice}");
Console.WriteLine($"The most expensive item - {maxName}, {maxPrice}");    