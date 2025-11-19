using Locadora.Models;

Cliente cliente = new Cliente("Felipe", "a@a.com");

Documento documento = new Documento(1, "RG", "123456789", new DateOnly(2015, 5, 1), new DateOnly(2025, 5, 1));

Console.WriteLine(cliente);
Console.WriteLine(documento);
