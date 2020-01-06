using System;
using System.IO;

namespace KortSpel
{
    class Program : Deck
    {
        static Player player;
        static Card playerCard;
        static Card computerCard;

        static bool guess;
        static bool result;

        static void Main(string[] args)
        {
            AskForUserName();
            Menu();
        }

        static void AskForUserName()
        {
            Console.WriteLine("Welcome to Aardvark Card Park!");
            Console.Write("Please enter your name: ");
            string input = Console.ReadLine();

            if (input.Length >= 2)
            {
                player = new Player(input);
            }
            else
            {
                Console.WriteLine("Name must consist of 2 or more characters");
                AskForUserName();
            }

            Console.Clear();
        }

        public static void Menu()
        {
            Console.WriteLine($"Welcome {player.Name}, to the Aardvark Card Park!");
            Console.WriteLine();
            Console.WriteLine("[P]lay Game: High - Low");
            Console.WriteLine("[R]ules");
            Console.WriteLine("[H]ighscore");
            Console.WriteLine("[E]nd Game");
            UserInput();
        }

        public static void UserInput()
        {
            ConsoleKeyInfo input = Console.ReadKey(true);

            switch (input.Key)
            {
                case ConsoleKey.P:
                    Console.Clear();
                    SetGame();
                    break;
                case ConsoleKey.R:
                    Console.Clear();
                    Rules();
                    break;
                case ConsoleKey.H:
                    Console.Clear();
                    HighScore();
                    break;
                case ConsoleKey.E:
                    Console.Clear();
                    EndGame();
                    break;
                case ConsoleKey.A:
                    Console.Clear();
                    Aardvark();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid input!");
                    Console.WriteLine();
                    Menu();
                    break;
            }
        }

        private static void SetGame()
        {
            createDeck();
            Shuffle();
            HighLowGame();
        }

        public static void HighLowGame()
        {
            SetCards();
            PlayerGuess();

            if (guess == result)
            {
                player.Score++;

                Console.WriteLine("Correct!");
                Console.WriteLine();

                Console.WriteLine("Your card:");
                Console.WriteLine($"{playerCard.Value} of {playerCard.Suit}");

                Console.WriteLine();

                Console.WriteLine("Computers card:");
                Console.WriteLine($"{computerCard.Value} of {computerCard.Suit}");

                Console.WriteLine();
                Console.WriteLine($"Score: {player.Score}");

                PutCardLast();
                PutCardLast();

                Console.WriteLine();

                PlayAgainW();
            }
            else if (guess != result)
            {
                player.Score--;

                Console.WriteLine("Too bad!");
                Console.WriteLine();

                Console.WriteLine("Your card:");
                Console.WriteLine($"{playerCard.Value} of {playerCard.Suit}");

                Console.WriteLine();

                Console.WriteLine("Computers card:");
                Console.WriteLine($"{computerCard.Value} of {computerCard.Suit}");

                Console.WriteLine();
                Console.WriteLine($"Score: {player.Score}");

                PutCardLast();
                PutCardLast();

                Console.WriteLine();

                PlayAgainL();
            }
        }

        public static void Shuffle()
        {
            Random random = new Random();
            Card temp;

            for (int i = 0; i < 100; i++)
            {
                for (int n = 0; n < playDeck.Length - 1; n++)
                {
                    int newIndex = random.Next(13);
                    temp = playDeck[n];
                    playDeck[n] = playDeck[newIndex];
                    playDeck[newIndex] = temp;
                }
            }
        }

        private static void SetCards()
        {
            playerCard = playDeck[0];
            computerCard = playDeck[1];

            if (playerCard.Value < computerCard.Value)
            {
                result = true;
            }
            else if (playerCard.Value > computerCard.Value)
            {
                result = false;
            }
            else if (playerCard.Value == computerCard.Value)
            {
                if (playerCard.Suit > computerCard.Suit)
                {
                    result = true;
                }
                else if (playerCard.Suit < computerCard.Suit)
                {
                    result = false;
                }
            }
        }

        public static void PlayerGuess()
        {
            Console.WriteLine("Your card:");
            Console.WriteLine($"{playerCard.Value} of {playerCard.Suit}");

            Console.WriteLine();

            Console.WriteLine("Do you think the computers card is higher or lower?");

            Console.WriteLine();

            Console.WriteLine("[H]igher");
            Console.WriteLine("[L]ower");
            Console.WriteLine("[Q]uit");

            ConsoleKeyInfo input = Console.ReadKey(true);

            switch (input.Key)
            {
                case ConsoleKey.H:
                    Console.Clear();
                    guess = true;
                    break;
                case ConsoleKey.L:
                    Console.Clear();
                    guess = false;
                    break;
                case ConsoleKey.Q:
                    Console.Clear();
                    EndGame();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid input! Game: Start over...");
                    Console.WriteLine();
                    HighLowGame();
                    break;
            }
        }

        public static void Rules()
        {
            Console.WriteLine("You will be presented a random card from the deck");
            Console.WriteLine("Once you have seen your card, you get to guess");
            Console.WriteLine("is your card higher or lower than the computers card?");
            Console.WriteLine("Pick between the options 'High', 'Low' or 'Quit'");
            Console.WriteLine("Guess correctly and win one point");
            Console.WriteLine("Guess incorrectly and die (or lose one point)");
            Console.WriteLine();

            Console.WriteLine("Remember: Be careful! The Aardvark is watching...");

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Press any key to continue...");

            ConsoleKeyInfo input = Console.ReadKey(true);

            switch (input.Key)
            {
                default:
                    Console.Clear();
                    Menu();
                    break;
            }
        }

        public static void HighScore()
        {
            Console.WriteLine($"Score: {player.Score}");
        }

        private static void PlayAgainW()
        {
            Console.WriteLine("Would you like to play again?");
            Console.WriteLine("[Y]es");
            Console.WriteLine("[N]o");

            ConsoleKeyInfo input = Console.ReadKey(true);

            switch (input.Key)
            {
                case ConsoleKey.Y:
                    Console.Clear();
                    HighLowGame();
                    break;
                case ConsoleKey.N:
                    Console.Clear();
                    EndGame();
                    break;
                case ConsoleKey.V:
                    Console.Clear();
                    Aardvark2();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid input!");
                    Console.WriteLine();
                    PlayAgainW();
                    break;
            }
        }

        private static void PlayAgainL()
        {
            Console.WriteLine("Would you like to play again?");
            Console.WriteLine("[Y]es");
            Console.WriteLine("[N]o");

            ConsoleKeyInfo input = Console.ReadKey(true);

            switch (input.Key)
            {
                case ConsoleKey.Y:
                    Console.Clear();
                    HighLowGame();
                    break;
                case ConsoleKey.N:
                    Console.Clear();
                    EndGame();
                    break;
                case ConsoleKey.F:
                    Console.Clear();
                    Aardvark1();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid input!");
                    Console.WriteLine();
                    PlayAgainL();
                    break;
            }
        }

        public static void EndGame()
        {
            SaveScore();
            Console.WriteLine($"Thanks for playing, {player.Name}!");
            Console.WriteLine();
            Console.WriteLine($"Final score: {player.Score}");
            Console.WriteLine();
        }

        private static void SaveScore()
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Marie\source\repos\KortSpel\score.txt", true))
            {
                sw.WriteLine(string.Format($"{player.Name}: {player.Score}"));
                sw.Close();
            }
        }

        private static void Aardvark()
        {
            Console.WriteLine(@"                    _,,......_");
            Console.WriteLine(@"                 ,-'          `'--.");
            Console.WriteLine(@"              ,-'  _              '-.");
            Console.WriteLine(@"     (`.    ,'   ,  `-.              `.");
            Console.WriteLine(@"      \ \  -    / )    \               \");
            Console.WriteLine(@"       `\`-^^^, )/      |     /         :");
            Console.WriteLine(@"         )^ ^ ^V/            /          '.");
            Console.WriteLine(@"         |      )            |           `.");
            Console.WriteLine(@"         9   9 /,--,\    |._:`         .._`.");
            Console.WriteLine(@"         |    /   /  `.  \    `.      (   `.`.");
            Console.WriteLine(@"         |   / \  \    \  \     `--\   )    `.`.___");
            Console.WriteLine(@"        .;;./  '   )   '   )       ///'       `-'''");
            Console.WriteLine(@"        `--'   7//\    ///\");
            Console.WriteLine(@"  - Memento Mori");

            Console.WriteLine();

            Console.WriteLine("Press any key to continue...");

            ConsoleKeyInfo input = Console.ReadKey(true);

            switch (input.Key)
            {
                default:
                    Console.Clear();
                    Menu();
                    break;
            }
        }

        private static void Aardvark1()
        {
            Console.WriteLine(@"                    _,,......_");
            Console.WriteLine(@"                 ,-'          `'--.");
            Console.WriteLine(@"              ,-'  _              '-.");
            Console.WriteLine(@"     (`.    ,'   ,  `-.              `.");
            Console.WriteLine(@"      \ \  -    / )    \               \");
            Console.WriteLine(@"       `\`-^^^, )/      |     /         :");
            Console.WriteLine(@"         )^ ^ ^V/            /          '.");
            Console.WriteLine(@"         |      )            |           `.");
            Console.WriteLine(@"         9   9 /,--,\    |._:`         .._`.");
            Console.WriteLine(@"         |    /   /  `.  \    `.      (   `.`.");
            Console.WriteLine(@"         |   / \  \    \  \     `--\   )    `.`.___");
            Console.WriteLine(@"        .;;./  '   )   '   )       ///'       `-'''");
            Console.WriteLine(@"        `--'   7//\    ///\");
            Console.WriteLine(@"  - Delectamenti");

            Console.WriteLine();

            Console.WriteLine("Press any key to continue...");

            ConsoleKeyInfo input = Console.ReadKey(true);

            switch (input.Key)
            {
                default:
                    Console.Clear();
                    HighLowGame();
                    break;
            }
        }

        private static void Aardvark2()
        {
            Console.WriteLine(@"                    _,,......_");
            Console.WriteLine(@"                 ,-'          `'--.");
            Console.WriteLine(@"              ,-'  _              '-.");
            Console.WriteLine(@"     (`.    ,'   ,  `-.              `.");
            Console.WriteLine(@"      \ \  -    / )    \               \");
            Console.WriteLine(@"       `\`-^^^, )/      |     /         :");
            Console.WriteLine(@"         )^ ^ ^V/            /          '.");
            Console.WriteLine(@"         |      )            |           `.");
            Console.WriteLine(@"         9   9 /,--,\    |._:`         .._`.");
            Console.WriteLine(@"         |    /   /  `.  \    `.      (   `.`.");
            Console.WriteLine(@"         |   / \  \    \  \     `--\   )    `.`.___");
            Console.WriteLine(@"        .;;./  '   )   '   )       ///'       `-'''");
            Console.WriteLine(@"        `--'   7//\    ///\");
            Console.WriteLine(@"  - Fututus et in igni mori");

            Console.WriteLine();

            Console.WriteLine("Press any key to continue...");

            ConsoleKeyInfo input = Console.ReadKey(true);

            switch (input.Key)
            {
                default:
                    Console.Clear();
                    HighLowGame();
                    break;
            }
        }
    }
}
