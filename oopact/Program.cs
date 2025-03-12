using System;
using System.Collections.Generic;
using System.Threading;
using ProgramDB;


/* MEMBERS:
CHAVOSO
CALDERON
CAGUIOA
FERMIN
MORALES
SOLIGUEN
VICENTE */

class Program
{

    public static void Main()
    {

        int barLength = 20;
        Console.Write("Loading: |                    |");

        for (int prg = 0; prg <= 100; prg += 5)
        {
            Console.SetCursorPosition(10, Console.CursorTop);
            Console.Write(new string('▌', prg / 5).PadRight(barLength));
            Console.SetCursorPosition(33, Console.CursorTop);
            Console.Write($"{prg}%");
            Thread.Sleep(50);
        }
        Console.Clear();

        


        Console.WriteLine(@"  
 _____            ____ ___  __  __ __  __ _____ ____   ____ _____      _    ____  ____  
| ____|          / ___/ _ \|  \/  |  \/  | ____|  _ \ / ___| ____|    / \  |  _ \|  _ \ 
|  _|    _____  | |  | | | | |\/| | |\/| |  _| | |_) | |   |  _|     / _ \ | |_) | |_) |
| |___  |_____| | |__| |_| | |  | | |  | | |___|  _ <| |___| |___   / ___ \|  __/|  __/ 
|_____|          \____\___/|_|  |_|_|  |_|_____|_| \_\\____|_____| /_/   \_\_|   |_| 
        ");


        int bar = 15;
        string ecommerceText = "ECOMMERCE BY CHAVOSO";
        Console.Write("Loading: |                     |");

        for (int prg = 0; prg <= 100; prg += 5)
        {
            Console.SetCursorPosition(10, Console.CursorTop);

            string progress = new string(' ', barLength);
            for (int i = 0; i < prg / 5; i++)
            {
                progress = progress.Remove(i, 1).Insert(i, ecommerceText[i % ecommerceText.Length].ToString());
            }

            Console.Write(progress);
            Console.SetCursorPosition(33, Console.CursorTop);
            Console.Write($"{prg}%");
            Thread.Sleep(50);
        }
        Console.Clear();


        while (true)
        {
            Console.WriteLine(@"


                               __  __     _     ___  _   _        __  __  _____  _   _  _   _ 
                              |  \/  |   / \   |_ _|| \ | |      |  \/  || ____|| \ | || | | |
                              | |\/| |  / _ \   | | |  \| |      | |\/| ||  _|  |  \| || | | |
                              | |  | | / ___ \  | | | |\  |      | |  | || |___ | |\  || |_| |
                              |_|  |_|/_/   \_\|___||_| \_|      |_|  |_||_____||_| \_| \___/ 
                                         ______________________________________
                                         | [1] Register                       |
                                         | [2] Login                          |
                                         | [3] Exit                           |
                                         |____________________________________|

                                       __________________________________________
                                       | [4]  21232f297a57a5a743894a0e4a801fc3  |
                                       |________________________________________| 
            ");
            Console.WriteLine(new string('-', 118));
            Console.Write(@"                                        
 _____  _   _  _____  _____  ____        ___   ____  _____  ___  ___   _   _     
| ____|| \ | ||_   _|| ____||  _ \      / _ \ |  _ \|_   _||_ _|/ _ \ | \ | |  _ 
|  _|  |  \| |  | |  |  _|  | |_) |    | | | || |_) | | |   | || | | ||  \| | (_)
| |___ | |\  |  | |  | |___ |  _ <     | |_| ||  __/  | |   | || |_| || |\  |  _ 
|_____||_| \_|  |_|  |_____||_| \_\     \___/ |_|     |_|  |___|\___/ |_| \_| (_)
");
            string option = Console.ReadLine();
            Console.WriteLine(new string('-', 118));

            Console.Clear();

            switch (option)
            {
                case "1":
                    Register();
                    break;
                case "2":
                    Login();
                    break;
                case "3":
                    return;
                case "4":
                    AdminLogin();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    private static List<User> users = new List<User>();

    static void Register()
    {
        Console.WriteLine(@"
 _   _  ____   _____  ____   _   _     _     __  __  _____ 
| | | |/ ___| | ____||  _ \ | \ | |   / \   |  \/  || ____|
| | | |\___ \ |  _|  | |_) ||  \| |  / _ \  | |\/| ||  _|  
| |_| | ___) || |___ |  _ < | |\  | / ___ \ | |  | || |___ 
 \___/ |____/ |_____||_| \_\|_| \_|/_/   \_\|_|  |_||_____|
");
        Console.Write("|Enter your username: ");
        string username = Console.ReadLine();


        Console.WriteLine(@"
 ____    _     ____  ____ __        __ ___   ____   ____  
|  _ \  / \   / ___|/ ___|\ \      / // _ \ |  _ \ |  _ \ 
| |_) |/ _ \  \___ \\___ \ \ \ /\ / /| | | || |_) || | | |
|  __// ___ \  ___) |___) | \ V  V / | |_| ||  _ < | |_| |
|_|  /_/   \_\|____/|____/   \_/\_/   \___/ |_| \_\|____/ 
                        ");
        Console.Write("|Enter your password: ");
        string password = Console.ReadLine();

        Console.Clear();

        Console.WriteLine(new string('-', 118));

        bool isAuthenticated = ProgramDB.LogUseracc.UserLogin(username, password);
        if (isAuthenticated)
        {
            Console.WriteLine("|Username already exists. Please try again.|");
            return;
        }


        ProgramDB.ManageUseracc.insertnewuser insertNewUser = new ProgramDB.ManageUseracc.insertnewuser();
        insertNewUser.Insertuser(username, password);

        Console.WriteLine("|Registration successful.|");
    }



    static void Login()
    {

        Console.WriteLine(@"
 _   _  ____   _____  ____   _   _     _     __  __  _____ 
| | | |/ ___| | ____||  _ \ | \ | |   / \   |  \/  || ____|
| | | |\___ \ |  _|  | |_) ||  \| |  / _ \  | |\/| ||  _|  
| |_| | ___) || |___ |  _ < | |\  | / ___ \ | |  | || |___ 
 \___/ |____/ |_____||_| \_\|_| \_|/_/   \_\|_|  |_||_____|
");
        Console.WriteLine(new string('-', 118));
        Console.Write("| Enter your username: ");
        string username = Console.ReadLine();

        Console.WriteLine(@"
 ____    _     ____  ____ __        __ ___   ____   ____  
|  _ \  / \   / ___|/ ___|\ \      / // _ \ |  _ \ |  _ \ 
| |_) |/ _ \  \___ \\___ \ \ \ /\ / /| | | || |_) || | | |
|  __// ___ \  ___) |___) | \ V  V / | |_| ||  _ < | |_| |
|_|  /_/   \_\|____/|____/   \_/\_/   \___/ |_| \_\|____/ 
");
        Console.Write("|Enter your password: ");
        string password = Console.ReadLine();
        Console.Clear();
        Console.WriteLine(new string('-', 118));

        bool isAuthenticated = ProgramDB.LogUseracc.UserLogin(username, password);

        if (isAuthenticated)
        {
            Console.WriteLine("|Login successful.");
            Ecommerce.Productsview(); // log in bug
            Console.WriteLine(new string('-', 118));
        }
        else
        {
            Console.WriteLine("|Invalid username or password. Please try again.|");
            Console.WriteLine(new string('-', 118));
        }
    }


    static void AdminLogin()
    {
        Console.WriteLine(new string('-', 118));
        Console.WriteLine(@"
 ____    _     ____  ____ __        __ ___   ____   ____  
|  _ \  / \   / ___|/ ___|\ \      / // _ \ |  _ \ |  _ \ 
| |_) |/ _ \  \___ \\___ \ \ \ /\ / /| | | || |_) || | | |
|  __// ___ \  ___) |___) | \ V  V / | |_| ||  _ < | |_| |
|_|  /_/   \_\|____/|____/   \_/\_/   \___/ |_| \_\|____/ ");
        Console.Write("|Enter your password: ");
        string password = Console.ReadLine();
        Console.WriteLine(new string('-', 118));
        if (password == "admin123")
        {
            Console.WriteLine("|Login successful.");
            Console.Clear();
            Adminright.Adminmenu();
            Console.WriteLine(new string('-', 118));
            return;


        }
        Console.WriteLine("|Invalid password. Please try again.");
        Console.WriteLine(new string('-', 118));
    }



    class Adminright
    {
        public static void Adminmenu()
        {
            Console.WriteLine(@"

                                                ______________________________________
                                                |             Admin Menu             |
                                                | [1] Add Product                    |
                                                | [2] Update Product                 |      
                                                | [3] Delete Product                 |
                                                | [4] View Product                   |
                                                | [5] Exit                           |
                                                |____________________________________|

                              ");
            Console.WriteLine(new string('-', 118));
            Console.WriteLine(@"
 _____  _   _  _____  _____  ____        ___   ____  _____  ___  ___   _   _     
| ____|| \ | ||_   _|| ____||  _ \      / _ \ |  _ \|_   _||_ _|/ _ \ | \ | |  _ 
|  _|  |  \| |  | |  |  _|  | |_) |    | | | || |_) | | |   | || | | ||  \| | (_)
| |___ | |\  |  | |  | |___ |  _ <     | |_| ||  __/  | |   | || |_| || |\  |  _ 
|_____||_| \_|  |_|  |_____||_| \_\     \___/ |_|     |_|  |___|\___/ |_| \_| (_)
                              ");
            Console.Write("| Enter your option: ");
            string option = Console.ReadLine();
            Console.WriteLine(new string('-', 118));
            Console.WriteLine(option);

            Console.Clear();

            switch (option)
            {
                case "1":
                    AddProduct();
                    break;
                case "2":
                    UpdateProduct();
                    break;
                case "3":
                    DeleteProduct();
                    break;
                case "4":
                    ViewProduct();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("|Invalid option. Please try again.");
                    Console.WriteLine(new string('-', 118));
                    Adminright.Adminmenu();
                    break;
            }
        }
    }

    static void AddProduct()
    {
        Console.WriteLine(new string('-', 118));
        Console.WriteLine("Add Product");
        Console.WriteLine(new string('-', 118));
        Console.Write(@"Product Name: ");
        string product_name = Console.ReadLine();
        Console.Write(@"Product Price: ");
        if (!int.TryParse(Console.ReadLine(), out int product_price))
        {
            Console.WriteLine(new string('-', 118));
            Console.WriteLine("Invalid price format. Please enter a valid number.");
            Console.WriteLine(new string('-', 118));
            return;
        }
        Console.Write(@"Product Quantity: ");
        if (!int.TryParse(Console.ReadLine(), out int product_quantity))
        {
            Console.WriteLine(new string('-', 118));
            Console.WriteLine("Invalid price format. Please enter a valid number.");
            return;
            Console.WriteLine(new string('-', 118));
        }
        Console.Write(@"Product Description: ");
        string product_description = Console.ReadLine();

        ProgramDB.Addproduct addProduct = new ProgramDB.Addproduct();
        addProduct.Insertproduct(product_name, product_price, product_quantity, product_description);
        {
            Console.WriteLine("Product added successfully.");
            Adminright.Adminmenu();
            Console.WriteLine(new string('-', 118));
        }
    }

    static void UpdateProduct()
    {
        Console.WriteLine("Update Product");
        {

            Ecommerce.ShowProductsUpdate();
            Console.Write("Enter Product ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int productId))
            {
                Console.WriteLine("Invalid Product ID!");
                return;
            }

            Console.Write("Enter new Product Name: ");
            string newName = Console.ReadLine();

            Console.Write("Enter new Product Price: ");
            if (!int.TryParse(Console.ReadLine(), out int newPrice))
            {
                Console.WriteLine("Invalid Price!");
                UpdateProduct();
            }

            Console.Write("Enter new Product Quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int newQuantity))
            {
                Console.WriteLine("Invalid Quantity!");
                return;
            }

            Console.Write("Enter new Product Description: ");
            string newDescription = Console.ReadLine();

            ProductUpdate productManager = new ProductUpdate();
            productManager.UpdateProduct(productId, newName, newPrice, newQuantity, newDescription);
        }

    }

    static void DeleteProduct()
    {
        Console.WriteLine("Delete Product");
        {
            Ecommerce.ShowProductsUpdate();
            Console.Write("Enter Product ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int productId))
            {
                Console.WriteLine("Invalid Product ID!");
                return;
            }

            Console.Write("Are you sure you want to delete this product? (yes/no): ");
            string confirm = Console.ReadLine();

            if (confirm == "yes")
            {
                ProductDelete productManager = new ProductDelete();
                productManager.DeleteProduct(productId);
            }
            else
            {
                Console.WriteLine("Deletion Canceled.");
            }
        }


    }

    static void ViewProduct()
    {
        Console.WriteLine("View Product");
        Ecommerce.ShowProducts();
    }





    class Ecommerce
    {
        public static void Products()
        {
            Console.WriteLine(@"
                            ______________________________________
                            |              Products              |
                            | [1] All Products                   |
                            | [2] Exit                           |
                            |____________________________________|
                        ");

            Console.WriteLine(@"
 _____  _   _  _____  _____  ____        ___   ____  _____  ___  ___   _   _     
| ____|| \ | ||_   _|| ____||  _ \      / _ \ |  _ \|_   _||_ _|/ _ \ | \ | |  _ 
|  _|  |  \| |  | |  |  _|  | |_) |    | | | || |_) | | |   | || | | ||  \| | (_)
| |___ | |\  |  | |  | |___ |  _ <     | |_| ||  __/  | |   | || |_| || |\  |  _ 
|_____||_| \_|  |_|  |_____||_| \_\     \___/ |_|     |_|  |___|\___/ |_| \_| (_)

");
            Console.Write("                             |Enter your option: ");
            string option = Console.ReadLine();

            Console.Clear();

            switch (option)
            {
                case "1":
                    ShowProducts();
                    break;
                case "2":
                    return; // bug?
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

            public static void Productsview() // bug
            {
                Console.WriteLine(@"
                            ______________________________________
                            |              Products              |
                            | [1] All Products                   |
                            | [2] Exit                           |
                            |____________________________________|
                        ");


            Console.WriteLine(@"
 _____  _   _  _____  _____  ____        ___   ____  _____  ___  ___   _   _     
| ____|| \ | ||_   _|| ____||  _ \      / _ \ |  _ \|_   _||_ _|/ _ \ | \ | |  _ 
|  _|  |  \| |  | |  |  _|  | |_) |    | | | || |_) | | |   | || | | ||  \| | (_)
| |___ | |\  |  | |  | |___ |  _ <     | |_| ||  __/  | |   | || |_| || |\  |  _ 
|_____||_| \_|  |_|  |_____||_| \_\     \___/ |_|     |_|  |___|\___/ |_| \_| (_)

");
                Console.Write("                             |Enter your option: ");
                string option = Console.ReadLine();

            Console.Clear();

            switch (option)
                {
                    case "1":
                        ShowProducts();
                        break;
                    case "2":
                    return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        

            public static void ShowProducts()
        {
            List<string[]> products = EcommerceProduct.GetProducts();

            Console.WriteLine(@"
                                           Available Products
                    -------------------------------------------------------------------
                    |ID          | Name           | Price   | Quantity | Description   |
                    -------------------------------------------------------------------");

            foreach (var product in products)
            {
                Console.WriteLine(@$"                    | {product[0],-15} | {product[1],-7} | {product[2],-8} | {product[3],-12} | {product[4],-225}");
            }
            Console.WriteLine("                    ------------------------------------------------------------------------------------------------");

            Console.WriteLine("\nPress any key to go back...");
            Console.ReadKey();
            Console.Clear();
            Products();
            Adminright.Adminmenu();

        }




        public static void ShowProductsUpdate()
        {
            List<string[]> products = EcommerceProduct.GetProducts();

            Console.WriteLine(@"
                                           Available Products
                    -------------------------------------------------------------------
                    |ID          | Name           | Price   | Quantity | Description   |
                    -------------------------------------------------------------------");

            foreach (var product in products)
            {
                Console.WriteLine(@$"                    | {product[0],-15} | {product[1],-7} | {product[2],-8} | {product[3],-12} | {product[4], -50}");
            }
            Console.WriteLine("                    ----------------------------------------------------------------------------------------------");
            Console.Clear();
        }
    }
}
