using Bussiness.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AppDbContextSeed
    {
        public static Task SeedAsync(AppDbContext context)
        {
            if (!context.Departments.Any())
            {
                var seedDepartment = new List<Department>
                {
                    new Department
                    {
                        Name="Electronicos",
                        Subdepartments = new List<Subdepartment>
                        {
                            new Subdepartment
                            {
                                Name="TVs",
                                Products=new List<Product>
                                {
                                    //new Product("TV Oled", 9000, "Una tv Plana", "Dico", "S1S2", 1)
                                }
                            },
                            new Subdepartment
                            {
                                Name="Celulares",
                                Products=new List<Product>
                                {
                                    //new Product("Iphone 13", 8000, "Celular Gama Alta", "Apple", "ip123", 10)
                                }
                            },
                            new Subdepartment
                            {
                                Name="Audio",
                                Products=new List<Product>
                                {
                                    //new Product("Auriculares Bose", 15000, "Auriculares Gama Alta", "Bose", "bs123", 3)
                                }
                            }
                        }
                    },
                    new Department
                    {
                        Name="Muebles",
                        Subdepartments = new List<Subdepartment>
                        {
                            new Subdepartment
                            {
                                Name="Cocina",
                                Products=new List<Product>
                                {
                                    //new Product("Silla", 1000, "Silla color negro", "Dico", "S123", 1)
                                }
                            },
                            new Subdepartment
                            {
                                Name="Recamara",
                                Products=new List<Product>
                                {
                                    //new Product("Cama Matrimonial", 9000, "Base de cama", "Dico", "M123", 10)
                                }
                            },
                             new Subdepartment
                            {
                                Name="Sala",
                                Products=new List<Product>
                                {
                                    //new Product("Sofa Carmesi", 6500, "Conjunto de Sofa color Carmesi", "Arper", "AR123", 2)
                                }
                            }
                        }
                    },
                    new Department
                    {
                        Name="Alimentos",
                        Subdepartments = new List<Subdepartment>
                        {
                            new Subdepartment
                            {
                                Name="Lacteos",
                                Products=new List<Product>
                                {
                                    //new Product("Leche Alpura", 35, "Leche Deslactozada", "Alpura", "LA123", 5)
                                }
                            },
                            new Subdepartment
                            {
                                Name="Carnes frias",
                                Products=new List<Product>
                                {
                                    //new Product("Salchicha Chimex", 40, "Salchicha estilo vienna", "Chimex", "Ch123", 15)
                                }
                            },
                             new Subdepartment
                            {
                                Name="Pastas",
                                Products=new List<Product>
                                {
                                    //new Product("Spaghetti", 20, "Pasta estilo Spaghetti", "Barilla", "Br123", 18)
                                }
                            }
                        }
                    }
                };
                foreach (var department in seedDepartment)
                {
                    context.Departments.Add(department);
                }
                context.SaveChanges();
            }
            if (!context.Providers.Any())
            {
                var seedProvider = new List<Provider> {
                    new Provider{ Name="Bose", Address="islas 123", PhoneNumber="6861234567",EmailAddress="proveedor@apple.com", City="Mexicali"},
                    new Provider{ Name="Arper", Address="islas arper 123", PhoneNumber="4433127892",EmailAddress="proveedor@arper.com", City="Morelia"},
                    new Provider{ Name="Mercado Chuchita", Address="islas chu 123", PhoneNumber="6641231644",EmailAddress="proveedor@chuchita.com", City="Mexicali"}
                };
                
                foreach (var provider in seedProvider)
                {
                    context.Providers.Add(provider);
                }
                context.SaveChanges();
            }
            return Task.CompletedTask;
        }
    }
}
