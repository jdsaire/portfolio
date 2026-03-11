using System;
using System.Collections.Generic; // Required to use Lists

class Product // Define a class to represent a product in the inventory
{
    public string Name { get; set; }
    public string Code { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}
class Program
{
    static List<Product> products = new List<Product>(); // Create a list to store products, allowing for dynamic resizing

    static void Main()
    {
        Console.WriteLine("Welcome to JD Warehouse!");

        string command = ""; // Command input
        bool isEntered = false; // Flag to control the while loop, initially set to false to allow entry into the loop

        while (isEntered == false) // Prompt the user to enter a command inside the while loop
        {
            Console.WriteLine("Input command ('1' for Add, '2' for Update, '3' for Delete, '4' for View, or '0' to Quit: ");
            command = Console.ReadLine();

            switch (command) // Use switch statement to route the command
            {
                case "1":
                    isEntered = false; // User has entered a valid command
                    AddNewProduct(); // Call the function to add new product
                    break;
                case "2":
                    isEntered = false; // User has entered a valid command
                    UpdateStock(); // Call the function to update a product
                    break;
                case "3": 
                    isEntered = false; // User has entered a valid command
                    RemoveProduct(); // Call the function to delete a product
                    break;
                case "4": 
                    isEntered = false; // User has entered a valid command
                    ViewStock(); // Call the function to display the status report
                    break;
                case "0":
                    isEntered = true; // User wants to quit
                    Console.WriteLine("Thank you for using JD Warehouse. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid command. Try again.");
                    break;
            }
        }
    }
    static void AddNewProduct() // Define a method to add a product to the inventory
    {
        Console.WriteLine("Enter Product Name:"); // Prompt for product name
        string inputProductName = Console.ReadLine().ToUpper().Trim(); // Convert to uppercase and trim spaces for consistency
        
        // 1. Trap the user if the input is null, empty "", or only contains spaces "   "
        while (string.IsNullOrWhiteSpace(inputProductName))
        {
            Console.WriteLine("Error: Name cannot be empty. Please enter a valid name:");
            inputProductName = Console.ReadLine().ToUpper().Trim(); // Convert to uppercase and trim spaces for consistency
        }
        
        // 2. Soft Constraint: Warn the user if a similar name already exists
        bool nameWarningTriggered = false;

        for (int i = 0; i < products.Count; i++)
        {
            string existingName = products[i].Name.ToUpper().Trim(); // Normalize existing product name for comparison
            string newName = inputProductName.ToUpper().Trim();

            // Check for exact matches OR if one string is a substring of the other
            if (existingName == newName || existingName.Contains(newName) || newName.Contains(existingName))
            {
                Console.WriteLine($"WARNING: Similar product found: '{products[i].Name}' (Code: {products[i].Code}).");
                nameWarningTriggered = true;
            }
        }

        // 3. The UX Friction: Force confirmation before proceeding
        if (nameWarningTriggered)
        {
            Console.WriteLine("Do you want to continue adding this product? (Y/N)");
            string confirmation = Console.ReadLine().ToUpper().Trim();
            if (confirmation != "Y")
            {
                Console.WriteLine("Product addition cancelled. Consider 'Update' instead.");
                return; // Aborts the AddNewProduct method and returns to the Main menu
            }
        }

        Console.WriteLine("Enter Product Code:"); // Prompt for product code (KEY)
        string inputCode = ""; // Declare a variable to hold the user input for product code
        bool isUnique = false; // Flag to control the while loop, initially set to false to allow entry into the loop

        // Trap the user until they provide a code that doesn't exist in the list
        while (!isUnique)
        {
            inputCode = Console.ReadLine().ToUpper().Trim(); 

            // Check 1: Is it empty or just spaces?
            if (string.IsNullOrWhiteSpace(inputCode))
            {
                Console.WriteLine("Error: Product Code cannot be empty. Please enter a valid code:");
                continue; // This restarts the while-loop immediately, skipping the duplicate check
            }

            // Check 2: Does it already exist?
            isUnique = true; // Assume innocence until proven guilty
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Code == inputCode)
                {
                    isUnique = false; // Guilty! We found a match.
                    Console.WriteLine($"Error: Code '{inputCode}' already exists in inventory. Enter a UNIQUE Product Code:");
                    break; // Stop searching the rest of the list; we already know it's a duplicate
                }
            }
        }
        // Once the loop breaks, 'inputCode' is guaranteed to be unique.

        double price; // Declare the output variable for TryParse
        Console.WriteLine("Enter Product Price ($):"); // Prompt for product price
        string inputPrice = Console.ReadLine(); // Declare a variable to hold the user input for price

        while (!double.TryParse(inputPrice, out price) || price <= 0) // As long as the conversion FAILs, keep asking.
        {
            Console.WriteLine("Invalid input. Please enter a positive numeric value for the price:");
            inputPrice = Console.ReadLine();
        }
        // Once the loop breaks, 'price' holds the valid number.

        int quantity; // Declare the output variable for TryParse
        Console.WriteLine("Enter Product Quantity (units):"); // Prompt for product quantity
        string inputQuantity = Console.ReadLine(); // Declare a variable to hold the user input for
        
        while (!int.TryParse(inputQuantity, out quantity) || quantity <= 0) // As long as the conversion FAILs, keep asking.
        {
            Console.WriteLine("Invalid input. Please enter a positive integer numeric value for the quantity:");
            inputQuantity = Console.ReadLine();
        }
        // Once the loop breaks, 'quantity' holds the valid number.

        Product newProduct = new Product // Packaging the data into an object
        {
            Name = inputProductName,
            Code = inputCode,
            Price = price,
            Quantity = quantity
        };
        
        products.Add(newProduct); // Add the new product to the list
        Console.WriteLine($"Product: '{newProduct.Name}' - Code: {newProduct.Code} - Quantity added: {newProduct.Quantity} - Price per Unit: ${newProduct.Price} "); // Confirmation message
    }
    static void UpdateStock()
    {
        // 1. Guard Clause: Check if there's anything to update
        if (products.Count == 0)
        {
            Console.WriteLine("Inventory is currently empty. Please add products first.");
            return; // Exits the method immediately
        }

        // 2. Search Mechanism
        Console.WriteLine("Enter Code of the product you want to update:");
        string targetCode = Console.ReadLine().ToUpper(); // Convert input to uppercase to match the stored format
        
        Product foundProduct = null; // Variable to hold the product if we find it

        for (int i = 0; i < products.Count; i++)
        {
            if (products[i].Code == targetCode)
            {
                foundProduct = products[i]; // Store the reference to the found object
                break; // Stop searching once we find a match
            }
        }

        // If the loop finishes and foundProduct is still null, the code didn't match anything
        if (foundProduct == null)
        {
            Console.WriteLine("Product Code not found in inventory.");
            return;
        }

        // 3. Transaction Routing with Retry Logic
        Console.WriteLine($"Found '{foundProduct.Name}'. Current Stock: {foundProduct.Quantity}");
        
        string actionUpdate = ""; // Initialize empty to ensure we enter the loop

        // Loop until the user provides a valid 1, 2, or 3
        while (actionUpdate != "1" && actionUpdate != "2" && actionUpdate != "3")
        {
            Console.WriteLine("Select action: (1) Restock, (2) Sale, or (3) Cancel Update");
            actionUpdate = Console.ReadLine();

            if (actionUpdate == "3")
            {
                Console.WriteLine("Update cancelled. Returning to main menu.");
                return; // Escapes the entire UpdateStock method immediately
            }
            else if (actionUpdate != "1" && actionUpdate != "2")
            {
                Console.WriteLine("Invalid selection. Please try again.");
            }
        }

        if (actionUpdate == "1") // RESTOCK
        {
            int amountToAdd;
            Console.WriteLine("Enter the number of units received:");
            string input = Console.ReadLine();
            
            while (!int.TryParse(input, out amountToAdd) || amountToAdd <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid positive number:");
                input = Console.ReadLine();
            }

            foundProduct.Quantity += amountToAdd; // Math: Current + New
            Console.WriteLine($"Restock successful. New total for {foundProduct.Name}: {foundProduct.Quantity}");
        }
        else if (actionUpdate == "2") // SALE
        {
            int amountToSell;
            Console.WriteLine("Enter the number of units sold:");
            string input = Console.ReadLine();
            
            // This validation checks for a valid number AND ensures we don't drop below 0 inventory
            while (!int.TryParse(input, out amountToSell) || amountToSell <= 0 || amountToSell > foundProduct.Quantity)
            {
                Console.WriteLine($"Invalid input. Must be a positive number and cannot exceed current stock ({foundProduct.Quantity}):");
                input = Console.ReadLine();
            }

            foundProduct.Quantity -= amountToSell; // Math: Current - Sold
            Console.WriteLine($"Sale recorded. New total for {foundProduct.Name}: {foundProduct.Quantity}");
        }
    }
    static void RemoveProduct()
    {
        // Implementation for removing a product
        Console.WriteLine("Enter Code of the product you want to remove:");
        string targetCode = Console.ReadLine().ToUpper();

        Product foundProduct = null;
        for (int i = 0; i < products.Count; i++)
        {
            if (products[i].Code == targetCode)
            {
                foundProduct = products[i];
                break;
            }
        }

        if (foundProduct == null)
        {
            Console.WriteLine("Product Code not found in inventory.");
            return;
        }

        // Confirm deletion with the user
        // Loop until the user provides a valid Y/N response
        string actionDelete = "";
        while (actionDelete != "Y" && actionDelete != "N")
        {
            Console.WriteLine($"Remove irreversibly '{foundProduct.Name}' from inventory? (Y/N)");
            actionDelete = Console.ReadLine().ToUpper();
            if (actionDelete != "Y" && actionDelete != "N")
            {
                Console.WriteLine("Invalid selection. Please enter 'Y' for Yes or 'N' for No.");
            }
        }

        if (actionDelete == "Y")
        {
            products.Remove(foundProduct);
            Console.WriteLine($"Product '{foundProduct.Name}' removed from inventory.");
        }
        else
        {
            Console.WriteLine("Deletion cancelled. Returning to main menu.");
            return; // Escapes the entire RemoveProduct method immediately
        }
    }
    static void ViewStock()
    {
        if (products.Count == 0)
        {
            Console.WriteLine("Inventory is currently empty.");
            return;
        }

        Console.WriteLine("Current Inventory:");
        foreach (var product in products)
        {
            Console.WriteLine($"Code: {product.Code} - Product: '{product.Name}' - Quantity: {product.Quantity} - Price: ${product.Price}");
        }
    }

}