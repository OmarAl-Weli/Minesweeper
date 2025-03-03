using Minesweeper.MatrixDescription;
namespace Minesweeper.Service;

public class AdjacentCellsCalculator
{
    public static Position CalculateUpperCell(Position position)
    {
        int row = UpperCellLocation(position.Row);
        int column = position.Column;

        if (!ValidCell(row, column, 4, 0))
            return position;

        var newPosition = new Position
        {
            Row = row,
            Column = column
        };
        return newPosition;
    }
    public static Position CalculateLowerCell(Position position)
    {
        int row = LowerCellLocation(position.Row);
        int column = position.Column;

        if (!ValidCell(row, column, 4, 0))
            return position;

        var newPosition = new Position
        {
            Row = row,
            Column = column
        };

        return newPosition;

    }
    public static Position CalculateLeftCell(Position position)
    {
        int row = position.Row;
        int column = LeftCellLocation(position.Column);

        if (!ValidCell(row, column, 4, 0))
            return position;

        var newPosition = new Position
        {
            Row = row,
            Column = column
        };

        return newPosition;
    }
    public static Position CalculateRightCell(Position position)
    {
        int row = position.Row;
        int column = RightCellLocation(position.Column);

        if (!ValidCell(row, column, 4, 0))
            return position;

        var newPosition = new Position
        {
            Row = row,
            Column = column
        };

        return newPosition;
    }
    public static Position CalculateUpperLeftCell(Position position)
    {
        int row = UpperCellLocation(position.Row);
        int column = LeftCellLocation(position.Column);

        if (!ValidCell(row, column, 4, 0))
            return position;

        var newPosition = new Position
        {
            Row = row,
            Column = column
        };

        return newPosition;
    }
    public static Position CalculateUpperRightCell(Position position)
    {
        int row = UpperCellLocation(position.Row);
        int column = RightCellLocation(position.Column);

        if (!ValidCell(row, column, 4, 0))
            return position;

        var newPosition = new Position
        {
            Row = row,
            Column = column
        };

        return newPosition;
    }
    public static Position CalculateLowerLeftCell(Position position)
    {
        int row = LowerCellLocation(position.Row);
        int column = LeftCellLocation(position.Column);

        if (!ValidCell(row, column, 4, 0))
            return position;

        var newPosition = new Position
        {
            Row = row,
            Column = column
        };

        return newPosition;
    }
    public static Position CalculateLowerRightCell(Position position)
    {
        int row = LowerCellLocation(position.Row);
        int column = RightCellLocation(position.Column);

        if (!ValidCell(row, column, 4, 0))
            return position;

        var newPosition = new Position
        {
            Row = row,
            Column = column
        };

        return newPosition;
    }

    private static int UpperCellLocation(int row)
    {
        return (--row);
    }

    private static int LowerCellLocation(int row)
    {
        return ++row;
    }

    private static int LeftCellLocation(int column)
    {
        return --column;
    }

    private static int RightCellLocation(int column)
    {
        return ++column;
    }

    public static bool ValidCell(int row, int column, int max, int min)
    {
        //this function should be moved!!!!!
        if (row > max || row < min)
            return false;
        if (column > max || column < min)
            return false;
        return true;
    }
}