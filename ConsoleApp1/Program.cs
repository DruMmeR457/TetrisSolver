int[][] field = [[0, 0, 0, 0],
                 [0, 0, 0, 0],
                 [0, 1, 0, 0],
                 [0, 1, 0, 0],
                 [1, 1, 1, 0]];

int[][] figure = [[0, 0, 1],
                  [0, 1, 1],
                  [0, 0, 1]];

for (int startingColIndex = 0; startingColIndex < field[0].Length - 2; startingColIndex++)
{
    if (field[0][startingColIndex] == 1 && figure[0][0] == 1 ||
            field[0][startingColIndex + 1] == 1 && figure[0][1] == 1 ||
            field[0][startingColIndex + 2] == 1 && figure[0][2] == 1 ||
            field[1][startingColIndex] == 1 && figure[1][0] == 1 ||
            field[1][startingColIndex + 1] == 1 && figure[1][1] == 1 ||
            field[1][startingColIndex + 2] == 1 && figure[1][2] == 1 ||
            field[2][startingColIndex] == 1 && figure[2][0] == 1 ||
            field[2][startingColIndex + 1] == 1 && figure[2][1] == 1 ||
            field[2][startingColIndex + 2] == 1 && figure[2][2] == 1)
    {
        //invalid start
        continue;
    }
    else
    {
        //good start
        for (int currentRowIndex = 0; currentRowIndex < field.Length - 2; currentRowIndex++)
        {
            if (field.Length <= currentRowIndex + 3 ||
            field[currentRowIndex + 1][startingColIndex] == 1 && figure[0][0] == 1 ||
            field[currentRowIndex + 1][startingColIndex + 1] == 1 && figure[0][1] == 1 ||
            field[currentRowIndex + 1][startingColIndex + 2] == 1 && figure[0][2] == 1 ||
            field[currentRowIndex + 2][startingColIndex] == 1 && figure[1][0] == 1 ||
            field[currentRowIndex + 2][startingColIndex + 1] == 1 && figure[1][1] == 1 ||
            field[currentRowIndex + 2][startingColIndex + 2] == 1 && figure[1][2] == 1 ||
            field[currentRowIndex + 3][startingColIndex] == 1 && figure[2][0] == 1 ||
            field[currentRowIndex + 3][startingColIndex + 1] == 1 && figure[2][1] == 1 ||
            field[currentRowIndex + 3][startingColIndex + 2] == 1 && figure[2][2] == 1)
            {
                //collision detected
                bool isFullRow = true;
                for (int rowCheckIndex = 0; rowCheckIndex < 3; rowCheckIndex++)
                {
                    isFullRow = true;
                    for (int colCheckIndex = 0; colCheckIndex < field[0].Length; colCheckIndex++)    
                    {
                        if (colCheckIndex < startingColIndex)
                        {
                            //only check field
                            if (field[currentRowIndex + rowCheckIndex][colCheckIndex] == 0)
                            {
                                //not filled, check next row
                                isFullRow = false;
                                break;
                            }
                            else
                            {
                                //possibly filled, check next col (do nothing)
                            }
                        }
                        else if (colCheckIndex >= startingColIndex && colCheckIndex <= startingColIndex + 2)
                        {
                            //only check figure
                            if(figure[rowCheckIndex][colCheckIndex - startingColIndex] == 0 && field[currentRowIndex + rowCheckIndex][colCheckIndex] == 0)
                            {
                                //not filled, check next row
                                isFullRow = false;
                                break;
                            }
                            else
                            {
                                //possibly filled, check next col (do nothing)
                            }
                        }
                        else
                        {
                            //only check field
                            if (field[currentRowIndex + rowCheckIndex][colCheckIndex] == 0)
                            {
                                //not filled, check next row
                                isFullRow = false;
                                break;
                            }
                            else
                            {
                                //possibly filled, check next col (do nothing)
                            }
                        }
                    }
                    if(isFullRow)
                    {
                        //if full, return col index
                        Console.WriteLine(startingColIndex);
                        break;
                    }
                }
            }
            else
            {
                //drop one row (do nothing)
            }
        }
    }
}