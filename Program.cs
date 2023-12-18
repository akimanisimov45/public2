using System;
using System.Collections.Generic;

public class Player
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Score { get; set; }
}

public class Game
{
    private List<Player> players;

    public Game()
    {
        players = new List<Player>();
    }

    public void AddPlayer(Player player)
    {
        player.Id = players.Count + 1;
        players.Add(player);
        Console.WriteLine($"Гравець {player.Name} доданий до гри.");
    }

    public void RemovePlayer(int playerId)
    {
        var playerToRemove = players.Find(p => p.Id == playerId);
        if (playerToRemove != null)
        {
            players.Remove(playerToRemove);
            Console.WriteLine($"Гравець {playerToRemove.Name} видалений з гри.");
        }
        else
        {
            Console.WriteLine($"Гравець з ID {playerId} не знайдений.");
        }
    }

    public void DisplayPlayers()
    {
        Console.WriteLine("Список гравців у грі:");
        foreach (var player in players)
        {
            Console.WriteLine($"ID: {player.Id}, Ім'я: {player.Name}, Рахунок: {player.Score}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Game game = new Game();

        while (true)
        {
            Console.WriteLine("Оберіть дію:");
            Console.WriteLine("1. Додати гравця");
            Console.WriteLine("2. Видалити гравця");
            Console.WriteLine("3. Вивести список гравців");
            Console.WriteLine("4. Вийти");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Введіть ім'я нового гравця:");
                    string playerName = Console.ReadLine();
                    Console.WriteLine("Введіть рахунок гравця:");
                    if (int.TryParse(Console.ReadLine(), out int playerScore))
                    {
                        game.AddPlayer(new Player { Name = playerName, Score = playerScore });
                    }
                    else
                    {
                        Console.WriteLine("Невірний формат рахунку. Гравець не доданий.");
                    }
                    break;

                case "2":
                    Console.WriteLine("Введіть ID гравця, якого ви хочете видалити:");
                    if (int.TryParse(Console.ReadLine(), out int playerIdToRemove))
                    {
                        game.RemovePlayer(playerIdToRemove);
                    }
                    else
                    {
                        Console.WriteLine("Невірний формат ID. Гравець не видалений.");
                    }
                    break;

                case "3":
                    game.DisplayPlayers();
                    break;

                case "4":
                    return;

                default:
                    Console.WriteLine("Невідома опція. Спробуйте ще раз.");
                    break;
            }
        }
    }
}