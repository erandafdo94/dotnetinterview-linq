using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqPractice
{
    // Product class with various properties for LINQ practice
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public int Stock { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Rating { get; set; }
        public bool IsDiscontinued { get; set; }
        public List<string> Tags { get; set; }

        // Helper method to display product info
        public override string ToString()
        {
            return $"{Name} (${Price}) - {Category}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a sample list of products
            List<Product> products = GetSampleProducts();

            // EXERCISE 1: Basic aggregation
            // Calculate the total, average, minimum, and maximum product prices
            // Format output: "Total: $[Total], Average: $[Average], Min: $[Min], Max: $[Max]"
            var total = products.Sum(p => p.Price);
            var avg = products.Average(p => p.Price);
            var max = products.Max(p => p.Price);
            var min = products.Min(p => p.Price);
            
            // EXERCISE 2: Conditional aggregation
            // Calculate the average price of in-stock products vs. out-of-stock products
            // Format output: "In-stock average: $[InStockAvg], Out-of-stock average: $[OutOfStockAvg]"
            
            // EXERCISE 3: Dictionary creation
            // Create a dictionary with Category as key and count of products as value
            // Then iterate through it to display results
            // Format output: "[Category]: [Count] products"
            var categoryProductCount = products.GroupBy(x => x.Category).ToDictionary(g => g.Key, g => g.Count());
            
            Console.ReadKey();
            
            // EXERCISE 4: Dictionary with complex values
            // Create a dictionary with Category as key and a custom object with min, max, and avg price as value
            // Format output: "[Category]: Min=$[Min], Max=$[Max], Avg=$[Avg]"

            var categoryProductCount2 = products.GroupBy(p => p.Category)
                .ToDictionary(k => k.Key, k => new
                {
                    mix = k.Min(),
                    max = k.Max(),
                    avg = k.Average(p => p.Price)
                });
            
            // EXERCISE 5: Nested grouping
            // Group products by Category, then by whether they're discontinued
            // Format output: "[Category] - Active: [ActiveCount], Discontinued: [DiscontinuedCount]"

            var groupedproducts = products.GroupBy(k => k.Category)
                .Select(cat => new
                {
                    category = cat.Key,
                    discontinuedGroups = cat.GroupBy(p => p.IsDiscontinued)
                });
        }

        // Method to generate sample product data
        public static List<Product> GetSampleProducts()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Smartphone X",
                    Price = 899.99m,
                    Category = "Electronics",
                    Stock = 45,
                    ReleaseDate = DateTime.Now.AddMonths(-6),
                    Rating = 4.5,
                    IsDiscontinued = false,
                    Tags = new List<string> { "smartphone", "tech", "5G", "camera" }
                },
                new Product
                {
                    Id = 2,
                    Name = "Laptop Pro",
                    Price = 1299.99m,
                    Category = "Electronics",
                    Stock = 20,
                    ReleaseDate = DateTime.Now.AddMonths(-10),
                    Rating = 4.8,
                    IsDiscontinued = false,
                    Tags = new List<string> { "laptop", "tech", "gaming", "work" }
                },
                new Product
                {
                    Id = 3,
                    Name = "Wireless Earbuds",
                    Price = 149.99m,
                    Category = "Audio",
                    Stock = 100,
                    ReleaseDate = DateTime.Now.AddMonths(-4),
                    Rating = 4.2,
                    IsDiscontinued = false,
                    Tags = new List<string> { "audio", "wireless", "earbuds" }
                },
                new Product
                {
                    Id = 4,
                    Name = "Smart Watch",
                    Price = 249.99m,
                    Category = "Wearables",
                    Stock = 30,
                    ReleaseDate = DateTime.Now.AddMonths(-2),
                    Rating = 4.0,
                    IsDiscontinued = false,
                    Tags = new List<string> { "wearable", "tech", "fitness", "watch" }
                },
                new Product
                {
                    Id = 5,
                    Name = "Digital Camera",
                    Price = 799.99m,
                    Category = "Photography",
                    Stock = 15,
                    ReleaseDate = DateTime.Now.AddMonths(-8),
                    Rating = 4.7,
                    IsDiscontinued = false,
                    Tags = new List<string> { "camera", "photography", "video" }
                },
                new Product
                {
                    Id = 6,
                    Name = "Gaming Console",
                    Price = 499.99m,
                    Category = "Gaming",
                    Stock = 25,
                    ReleaseDate = DateTime.Now.AddMonths(-12),
                    Rating = 4.9,
                    IsDiscontinued = false,
                    Tags = new List<string> { "gaming", "console", "entertainment" }
                },
                new Product
                {
                    Id = 7,
                    Name = "Tablet Mini",
                    Price = 349.99m,
                    Category = "Electronics",
                    Stock = 0,
                    ReleaseDate = DateTime.Now.AddMonths(-5),
                    Rating = 4.3,
                    IsDiscontinued = false,
                    Tags = new List<string> { "tablet", "tech", "portable" }
                },
                new Product
                {
                    Id = 8,
                    Name = "Bluetooth Speaker",
                    Price = 79.99m,
                    Category = "Audio",
                    Stock = 80,
                    ReleaseDate = DateTime.Now.AddMonths(-3),
                    Rating = 4.1,
                    IsDiscontinued = false,
                    Tags = new List<string> { "audio", "bluetooth", "speaker", "wireless" }
                },
                new Product
                {
                    Id = 9,
                    Name = "Smart Home Hub",
                    Price = 129.99m,
                    Category = "Smart Home",
                    Stock = 40,
                    ReleaseDate = DateTime.Now.AddMonths(-7),
                    Rating = 3.9,
                    IsDiscontinued = false,
                    Tags = new List<string> { "smart home", "tech", "automation" }
                },
                new Product
                {
                    Id = 10,
                    Name = "External Hard Drive",
                    Price = 119.99m,
                    Category = "Storage",
                    Stock = 60,
                    ReleaseDate = DateTime.Now.AddMonths(-9),
                    Rating = 4.4,
                    IsDiscontinued = false,
                    Tags = new List<string> { "storage", "data", "backup" }
                },
                new Product
                {
                    Id = 11,
                    Name = "Gaming Mouse",
                    Price = 59.99m,
                    Category = "Gaming",
                    Stock = 55,
                    ReleaseDate = DateTime.Now.AddMonths(-11),
                    Rating = 4.6,
                    IsDiscontinued = false,
                    Tags = new List<string> { "gaming", "mouse", "peripheral" }
                },
                new Product
                {
                    Id = 12,
                    Name = "Mechanical Keyboard",
                    Price = 129.99m,
                    Category = "Computing",
                    Stock = 35,
                    ReleaseDate = DateTime.Now.AddMonths(-13),
                    Rating = 4.7,
                    IsDiscontinued = false,
                    Tags = new List<string> { "keyboard", "mechanical", "gaming", "typing" }
                },
                new Product
                {
                    Id = 13,
                    Name = "Vintage Record Player",
                    Price = 199.99m,
                    Category = "Audio",
                    Stock = 0,
                    ReleaseDate = DateTime.Now.AddMonths(-24),
                    Rating = 4.2,
                    IsDiscontinued = true,
                    Tags = new List<string> { "audio", "vinyl", "retro", "record" }
                },
                new Product
                {
                    Id = 14,
                    Name = "Budget Smartphone",
                    Price = 199.99m,
                    Category = "Electronics",
                    Stock = 75,
                    ReleaseDate = DateTime.Now.AddMonths(-14),
                    Rating = 3.8,
                    IsDiscontinued = false,
                    Tags = new List<string> { "smartphone", "budget", "affordable" }
                },
                new Product
                {
                    Id = 15,
                    Name = "Wireless Charging Pad",
                    Price = 39.99m,
                    Category = "Electronics",
                    Stock = 90,
                    ReleaseDate = DateTime.Now.AddDays(-15),
                    Rating = 4.0,
                    IsDiscontinued = false,
                    Tags = new List<string> { "charging", "wireless", "accessory" }
                },
                new Product
                {
                    Id = 16,
                    Name = "Ultra HD Monitor",
                    Price = 599.99m,
                    Category = "Computing",
                    Stock = 0,
                    ReleaseDate = DateTime.Now.AddMonths(-16),
                    Rating = 4.8,
                    IsDiscontinued = true,
                    Tags = new List<string> { "monitor", "display", "ultra hd", "computing" }
                },
                new Product
                {
                    Id = 17,
                    Name = "Fitness Tracker",
                    Price = 89.99m,
                    Category = "Wearables",
                    Stock = 70,
                    ReleaseDate = DateTime.Now.AddMonths(-17),
                    Rating = 3.9,
                    IsDiscontinued = false,
                    Tags = new List<string> { "fitness", "wearable", "health", "tracker" }
                },
                new Product
                {
                    Id = 18,
                    Name = "Portable Power Bank",
                    Price = 49.99m,
                    Category = "Accessories",
                    Stock = 110,
                    ReleaseDate = DateTime.Now.AddMonths(-18),
                    Rating = 4.3,
                    IsDiscontinued = false,
                    Tags = new List<string> { "power", "portable", "charger", "battery" }
                },
                new Product
                {
                    Id = 19,
                    Name = "Smart Light Bulbs (4-pack)",
                    Price = 79.99m,
                    Category = "Smart Home",
                    Stock = 65,
                    ReleaseDate = DateTime.Now.AddMonths(-19),
                    Rating = 4.1,
                    IsDiscontinued = false,
                    Tags = new List<string> { "smart home", "lighting", "automation" }
                },
                new Product
                {
                    Id = 20,
                    Name = "Home Security Camera",
                    Price = 149.99m,
                    Category = "Smart Home",
                    Stock = 50,
                    ReleaseDate = DateTime.Now.AddMonths(-20),
                    Rating = 4.5,
                    IsDiscontinued = false,
                    Tags = new List<string> { "security", "camera", "smart home" }
                },
                new Product
                {
                    Id = 21,
                    Name = "Virtual Reality Headset",
                    Price = 299.99m,
                    Category = "Gaming",
                    Stock = 0,
                    ReleaseDate = DateTime.Now.AddMonths(-21),
                    Rating = 4.6,
                    IsDiscontinued = true,
                    Tags = new List<string> { "VR", "gaming", "virtual reality" }
                },
                new Product
                {
                    Id = 22,
                    Name = "Noise-Cancelling Headphones",
                    Price = 249.99m,
                    Category = "Audio",
                    Stock = 40,
                    ReleaseDate = DateTime.Now.AddMonths(-22),
                    Rating = 4.7,
                    IsDiscontinued = false,
                    Tags = new List<string> { "audio", "headphones", "noise-cancelling" }
                },
                new Product
                {
                    Id = 23,
                    Name = "Desktop Computer",
                    Price = 1199.99m,
                    Category = "Computing",
                    Stock = 25,
                    ReleaseDate = DateTime.Now.AddMonths(-23),
                    Rating = 4.8,
                    IsDiscontinued = false,
                    Tags = new List<string> { "computer", "desktop", "workstation" }
                },
                new Product
                {
                    Id = 24,
                    Name = "Digital Drawing Tablet",
                    Price = 199.99m,
                    Category = "Computing",
                    Stock = 30,
                    ReleaseDate = DateTime.Now.AddMonths(-14),
                    Rating = 4.2,
                    IsDiscontinued = false,
                    Tags = new List<string> { "drawing", "tablet", "digital", "art" }
                },
                new Product
                {
                    Id = 25,
                    Name = "Digital Voice Assistant",
                    Price = 99.99m,
                    Category = "Smart Home",
                    Stock = 85,
                    ReleaseDate = DateTime.Now.AddMonths(-1),
                    Rating = 4.4,
                    IsDiscontinued = false,
                    Tags = new List<string> { "smart home", "voice", "assistant", "AI" }
                }
            };

            return products;
        }
    }
}