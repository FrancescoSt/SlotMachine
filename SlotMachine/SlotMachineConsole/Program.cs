class Program
{
    static void Main(string[] args)
    {
        SlotMachine slotMachine = new SlotMachine();
        bool playing = true;

        while (playing)
        {
            Console.WriteLine("Inserisci una moneta per giocare (premi 'Q' per uscire)");
            var input = Console.ReadKey();

            if (input.KeyChar == 'Q' || input.KeyChar == 'q')
            {
                playing = false;
                Console.WriteLine("\nStai uscendo dal gioco. Ecco le tue monete:");
                slotMachine.CollectCoins();
            }
            else
            {
                Console.WriteLine();
                slotMachine.InsertCoin();
            }
        }
    }
}
