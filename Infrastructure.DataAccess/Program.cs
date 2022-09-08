// See https://aka.ms/new-console-template for more information

using Infrastructure.DataAccess.Contexts;

Console.WriteLine("Infrastructure -> Data access -> Creando base de datos si no existe");
MCCContext DB = new MCCContext();
DB.Database.EnsureCreated();
Console.WriteLine("Infrastructure -> Data access -> Conexion establecida");
Console.ReadKey();
