namespace CandyCrushLogic
{
    public class CandyCrusher
    {
        public static bool ScoreRowPresent(RegularCandies[,] playingField)
        {
            for (int row = 0; row < playingField.GetLength(0); row++)
            {
                RegularCandies rowItem = playingField[0, 0];
                int counter = 1;

                for (int col = 0; col < playingField.GetLength(1); col++)
                {
                    if (playingField[row, col] == rowItem)
                    {
                        counter++;

                        if (counter >= 3)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        rowItem = playingField[row, col];
                        counter = 1;
                    }
                }
            }
            return false;
        }

        public static bool ScoreColPresent(RegularCandies[,] playingField)
        {
            for (int col = 0; col < playingField.GetLength(0); col++)
            {
                RegularCandies rowItem = playingField[0, 0];
                int counter = 1;

                for (int row = 0; row < playingField.GetLength(1); row++)
                {
                    if (playingField[row, col] == rowItem)
                    {
                        counter++;

                        if (counter >= 3)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        rowItem = playingField[row, col];
                        counter = 1;
                    }
                }
            }
            return false;
        }
    }
}