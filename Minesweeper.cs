using Minesweeper.MatrixDescription;
namespace Minesweeper;

public class Minesweeper
{
    static int UserPickedMaxRows = 5;
    static int UserPickedMaxColumns = 5;


    static void Main()
    {
        var matrix = new Matrix(UserPickedMaxRows, UserPickedMaxColumns);
        var hiddenMatrix = new HiddenMatrix(UserPickedMaxRows, UserPickedMaxColumns);
        //----------------------------------------------
        matrix.SetBomb(new Position() { Row = 0, Column = 0 }, matrix);
        matrix.SetBomb(new Position() { Row = 1, Column = 0 }, matrix);
        matrix.SetBomb(new Position() { Row = 1, Column = 1 }, matrix);
        matrix.SetBomb(new Position() { Row = 2, Column = 4 }, matrix);
        matrix.SetBomb(new Position() { Row = 4, Column = 1 }, matrix);
        //SetRandomBombs(5, matrix);
        Console.WriteLine("Welcome to Minesweepers!");
        //----------------------------------------------
        GameMenu();
        Console.WriteLine("-----------------------------");
        //----------------------------------------------
        StartTheGame(matrix, hiddenMatrix);
        Console.WriteLine("-----------------------------");
    }
    static void GameMenu()
    {
        bool validInput = false;

        while (!validInput)
        {
            Console.WriteLine("Please choose one of the following\n1.Play\n2.Quit");
            string input = Console.ReadLine().Trim();
            switch (input)
            {
                case "1":
                    Console.WriteLine("Let the games begin");
                    validInput = true;
                    break;
                case "2":
                    Console.WriteLine("Bye!");
                    System.Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Invalid Choice!");
                    break;
            }
        }
    }
    static void StartTheGame(Matrix matrix, HiddenMatrix hiddenMatrix)
    {
        bool _bombHit = false;
        string input;

        Position position = new Position();
        bool inputValidated = false;

        while (!_bombHit)
        {
            if (hiddenMatrix.CheckMapStatus(matrix, hiddenMatrix))
                break;

            Minefield.Crawl(matrix, hiddenMatrix);
            MinefieldPrinter(hiddenMatrix, UserPickedMaxRows, UserPickedMaxColumns);

            Console.WriteLine("Please input row");
            input = Console.ReadLine().Trim();

            if (ValidateInput(input))
            {
                position.Row = Convert.ToInt32(input);
                if (ValidateRange(position.Row, hiddenMatrix))
                {
                    Console.WriteLine("Please input column");
                    input = Console.ReadLine().Trim();

                    if (ValidateInput(input))
                    {
                        position.Column = Convert.ToInt32(input);
                        if (ValidateRange(position.Column, hiddenMatrix))
                            inputValidated = true;
                    }
                }
            }
            else
                Console.WriteLine("invalid input " + input);

            if (inputValidated)
            {
                if (matrix.GetBomb(position))
                    _bombHit = true;
                if (hiddenMatrix[position] != MatrixConstants.HiddenCell)
                    Console.WriteLine("Cell is already open!");
                else
                    Minefield.RevealTheMatrix(position, matrix, hiddenMatrix);

                inputValidated = false;
            }
        }
        if (_bombHit)
            Console.WriteLine("You have lost!");
        else
            Console.WriteLine("You have won!");
    }

    static void MinefieldPrinter(HiddenMatrix hiddenMatrix, int maxRows, int maxColumns)
    {
        Console.Write("  ");
        for (int column = 0; column < maxColumns; column++)
        {
            Console.Write(column);
        }
        Console.WriteLine();

        for (int row = 0; row < maxRows; row++)
        {
            Console.Write($"{row}|");
            for (int column = 0; column < maxColumns; column++)
            {
                Console.Write($"{hiddenMatrix[new Position() { Row = row, Column = column }]}");

            }
            Console.WriteLine();
        }
    }

    public static bool ValidateInput(string input)
    {
        if (input != null && int.TryParse(input, out _))
            return true;
        return false;
    }
    public static bool ValidateRange(int number, HiddenMatrix hiddenMatrix)
    {
        if (number >= 0 && number <= hiddenMatrix.MaxRows
         && number <= hiddenMatrix.MaxColumns)
            return true;
        return false;
    }

    public static void SetRandomBombs(int numberOfBombs, Matrix matrix)
    {
        Random random = new Random();
        int _randomRow;
        int _randomColumn;

        for (int i = 0; i < numberOfBombs; i++)
        {
            _randomRow = random.Next(0, matrix.MaxRows);
            _randomColumn = random.Next(0, matrix.MaxColumns);
            matrix.SetBomb(new Position() { Row = _randomRow, Column = _randomColumn }, matrix);
        }

    }
}
