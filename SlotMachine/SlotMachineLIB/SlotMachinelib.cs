public class SlotMachine
{
    private const int CoinsPerGame = 1;
    private const int JackpotCoins = 100;
    private const int ThreeConsecutiveCoins = 50;

    private readonly Random random;
    private readonly char[] alphabet;
    private int coins;

    public SlotMachine()
    {
        random = new Random();
        alphabet = new char[26];
        for (int i = 0; i < 26; i++)
        {
            alphabet[i] = (char)('A' + i);
        }
        coins = 0;
    }

    public void InsertCoin()
    {
        coins += CoinsPerGame;
        Play();
    }

    private void Play()
    {
        for (int i = 0; i < 2; i++)
        {
            char[] symbols = new char[3];
            for (int j = 0; j < 3; j++)
            {
                symbols[j] = alphabet[random.Next(alphabet.Length)];
            }

            Console.WriteLine("Symbols: " + string.Join(" ", symbols));

            Console.WriteLine("Vuoi cambiare qualche simbolo? (y/n)");
            if (Console.ReadLine()?.Trim().ToLower() != "y")
            {
                EvaluateSymbols(symbols);
                return;
            }

            Console.WriteLine("Inserisci la posizione (0-2) dei simboli che vuoi cambiare, separatid a uno spazio:");
            var positionsToKeep = Console.ReadLine()?.Split();
            if (positionsToKeep != null)
            {
                foreach (var position in positionsToKeep)
                {
                    if (int.TryParse(position, out int pos) && pos >= 0 && pos < symbols.Length)
                    {
                        Console.WriteLine($"Cambiare simbolo '{symbols[pos]}'");
                    }
                }
            }
        }

        Console.WriteLine("Hai tenuto i simboli due volte. Valutare...");
        EvaluateSymbols(new char[0]);
    }

    private void EvaluateSymbols(char[] symbols)
    {
        if (symbols.Length == 0)
        {
            Console.WriteLine("La tua combinazione non è vincente.");
            return;
        }

        Array.Sort(symbols);
        if (symbols[0] == symbols[1] && symbols[1] == symbols[2])
        {
            Console.WriteLine($"Tre di un tipo! Hai vinto: {symbols[0] - 'A' + 1} monete.");
            coins += symbols[0] - 'A' + 1;
        }
        else if ((symbols[0] + 1 == symbols[1] && symbols[1] + 1 == symbols[2]) || (symbols[0] == 'A' && symbols[1] == 'Y' && symbols[2] == 'Z'))
        {
            Console.WriteLine($"Tre simboli consecutivi. Hai vinto! {ThreeConsecutiveCoins} monete.");
            coins += ThreeConsecutiveCoins;
        }
        else if (symbols[0] == 'Z' && symbols[1] == 'Z' && symbols[2] == 'Z')
        {
            Console.WriteLine($"JACKPOT! Hai vinto: {JackpotCoins} monete.");
            coins += JackpotCoins;
        }
        else if (symbols[0] == symbols[1] || symbols[1] == symbols[2])
        {
            Console.WriteLine($"due simboli! hai vinto: {CoinsPerGame} monete.");
            coins += CoinsPerGame;
        }
        else
        {
            Console.WriteLine("La tua combinazione non è vincente");
        }
    }

    public void CollectCoins()
    {
        Console.WriteLine($"Collected {coins} coins.");
        coins = 0;
    }
}
