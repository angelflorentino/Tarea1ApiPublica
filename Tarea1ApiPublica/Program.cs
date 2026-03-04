using Tarea1ApiPublica.AppServices;
using Tarea1ApiPublica.Entities;

CartasService cartasService = new CartasService();

List<Carta> cartas = await cartasService.GetCartaAsync(2);

Console.WriteLine("Cartas obtenidas:");

foreach (var carta in cartas)
{
    Console.WriteLine($"Valor: {carta.value}, Palo: {carta.suit}");
}