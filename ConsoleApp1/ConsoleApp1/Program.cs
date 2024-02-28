using ConsoleApp1.DAL;
using ConsoleApp1.Models;
using ConsoleApp1.DAL;
using ConsoleApp1.Models;

string opt;
do
{
    Console.WriteLine(" ***Menu*** ");
    Console.WriteLine("1.Create brand");
    Console.WriteLine("2.Get brand by Id");
    Console.WriteLine("3.Get all brands");
    Console.WriteLine("4.Update brand");
    Console.WriteLine("5.Delete brand");
    Console.WriteLine("6.Create product");
    Console.WriteLine("7.Get product by id");
    Console.WriteLine("8.Get all products");
    Console.WriteLine("9.Update product");
    Console.WriteLine("10.Delete product");
    Console.WriteLine("0.Exiting");
    Console.Write("Choose option:");

    opt = Console.ReadLine();
    AppDbContext dbContext = new AppDbContext();
    string brName, brIdStr, prName, prIdStr;
    int brId, prId;
    double price;

    switch (opt)
    {
        case "1":
            do
            {
                Console.Write("Enter the brand name:");
                prName = Console.ReadLine();

            } while (string.IsNullOrWhiteSpace(prName));
            var newBrand = new Brand
            {
                Name = prName,
            };
            dbContext.Brands.Add(newBrand);
            dbContext.SaveChanges();
            Console.WriteLine("Brand successfully created");
            break;
        case "2":
            do
            {
                Console.Write("Enter the brand Id:");
                brIdStr = Console.ReadLine();
            } while (!int.TryParse(brIdStr, out brId) || brId < 0);
            var brand = dbContext.Brands.Find(brId);
            if (brand != null)
                Console.WriteLine(brand);
            else
                Console.WriteLine("Brand not found!");
            break;
        case "3":
            var brands = dbContext.Brands.ToList();
            foreach (var item in brands)
            {
                Console.WriteLine(item);
            }
            break;
        case "4":
            do
            {
                Console.Write("Enter the brand Id:");
                brIdStr = Console.ReadLine();
            } while (!int.TryParse(brIdStr, out brId) || brId < 0);
            brand = dbContext.Brands.Find(brId);
            if (brand != null)
            {
                do
                {
                    Console.Write("Enter the new brand name:");
                    brName = Console.ReadLine();

                } while (string.IsNullOrWhiteSpace(brName));
                brand.Name = brName;
                dbContext.SaveChanges();
                Console.WriteLine("Brand succesfully updated");
                break;
            }
            else
                Console.WriteLine("Brand not found!");
            break;
        case "5":
            do
            {
                Console.Write("Enter the brand Id:");
                brIdStr = Console.ReadLine();
            } while (!int.TryParse(brIdStr, out brId) || brId < 0);
            brand = dbContext.Brands.Find(brId);
            if (brand != null)
            {
                dbContext.Brands.Remove(brand);
                dbContext.SaveChanges();
                Console.WriteLine("Brand succesfully deleted");
            }
            else
                Console.WriteLine("Brand not found!");
            break;
        case "6":
            do
            {
                Console.Write("Enter the product name:");
                prName = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(prName));
            do
            {
                Console.Write("Enter the price:");
                prIdStr = Console.ReadLine();
            } while (!double.TryParse(prIdStr, out price) || price < 0);

            foreach (var item in dbContext.Brands.ToList())
            {
                Console.WriteLine(item.Id + item.Name);
            }
               
            do
            {
                Console.Write("Enter the brand id: ");
                brIdStr = Console.ReadLine();
            } while (!int.TryParse(brIdStr, out brId) || brId < 0);
            Product product = new Product
            {
                Name = prName,
                Price = price,
                BrandId = brId
            };
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
            break;
        case "7":
            do
            {
                Console.Write("Enter the product id:");
                prIdStr = Console.ReadLine();
            } while (!int.TryParse(prIdStr, out prId) || prId < 0);

            var prod = dbContext.Products.Find(prId);
            if (prod != null)
                Console.WriteLine(prod);
            else
                Console.WriteLine("Product not found!");
            break;
        case "8":
            var productss = dbContext.Products.ToList();
            foreach (var item in productss)
            {
                Console.WriteLine(item);
            }
            break;
        case "9":
            do
            {
                Console.Write("Enter the product id:");
                prIdStr = Console.ReadLine();
            } while (!int.TryParse(prIdStr, out prId) || prId < 0);
            var prodct=dbContext.Products.Find(prId);
            if (prodct != null)
            {
                do
                {
                    Console.Write("Enter the new product name:");
                    prName = Console.ReadLine();

                } while (string.IsNullOrWhiteSpace(prName));
                prodct.Name = prName;
                do
                {
                    Console.Write("Enter the new price:");
                    prIdStr = Console.ReadLine();
                } while (!double.TryParse(prIdStr, out price) || price < 0);
                prodct.Price = price;
                dbContext.SaveChanges();

                Console.WriteLine("Price succesfully updated");
                break;
            }
            else
                Console.WriteLine("Product not found!");
            break;
        case "10":
            do
            {
                Console.Write("Enter the product id:");
                prIdStr = Console.ReadLine();
            } while (!int.TryParse(prIdStr, out prId) || prId < 0);
            prodct = dbContext.Products.Find(prId);
            if (prodct != null)
            {
                dbContext.Products.Remove(prodct);
                dbContext.SaveChanges();
                Console.WriteLine("Product succesfully deleted");
            }
            else 
                Console.WriteLine("Product not found!");
            break;
        default:
            Console.WriteLine("Wrong option");
            break;
    }

} while (opt!="0");
