namespace assignment3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start();
        }

        void Start()
        {
            YahtzeeGame yahtzeeGame = new YahtzeeGame();
            yahtzeeGame.Init();
            PlayYahtzee(yahtzeeGame);
        }

        void PlayYahtzee(YahtzeeGame game)
        {
            int nrOfAttempts = 0;
            do
            {
                game.Throw(); // throw all dices
                game.DisplayValues(); // display the thrown
                nrOfAttempts++;
            } while (!game.Yahtzee());

            Console.WriteLine($"Number of attempts needed (for Yahtzee): {nrOfAttempts}");
        }
    }
}