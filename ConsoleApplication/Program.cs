using Domain.Classes;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddTransient<IGame, Game>()
    .AddSingleton<IDice, Dice>()
    .BuildServiceProvider();

var game = serviceProvider.GetService<IGame>();
var dice = serviceProvider.GetService<IDice>();

if (game != null && dice != null)
{
    Console.WriteLine("Welcome to Snakes And Ladders game");
    Console.WriteLine("How many players?");

    int players;
    do
    {
        Console.WriteLine("");
        Console.WriteLine("Insert a number between 2 and 6");
        int.TryParse(Console.ReadLine(), out players);
    } while (!game.StartGame(players, dice));

    do
    {
        Console.WriteLine("");
        Console.WriteLine($"Press a key to roll the dice for the player {game.GetPlayerTurn()}");
        Console.ReadKey(true);
        Console.WriteLine($"Dice result = {game.PlayTurn()}");
        Console.WriteLine($"Player {game.GetPlayerTurn()} is in {game.GetCurrentPlayerPosition()}");
        game.ChangeTurn();

    } while (!game.IsGameCompleted());

    Console.WriteLine($"The winner is {game.GetWinner()}");
}
else
{
    Console.WriteLine("Error retrieving game library content");
}