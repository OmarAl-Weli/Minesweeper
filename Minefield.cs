using Minesweeper.MatrixDescription;
using Minesweeper.Service;

namespace Minesweeper;

public class Minefield
{
    public static void RevealTheMatrix(Position position, Matrix matrix, HiddenMatrix hiddenMatrix)
    {
        hiddenMatrix[position] = Convert.ToString(matrix[position]);

        List<Position> positions = AdjacentCellCalculatorService.CalculateAdjacentCells(position);

        foreach (var cell in positions)
        {
            if (!matrix.GetBomb(cell))
                hiddenMatrix[cell] = Convert.ToString(matrix[cell]);
        }
    }

    public static void Crawl(Matrix matrix, HiddenMatrix hiddenMatrix)
    {
        for (var row = MatrixConstants.Minimum;
                     row <= hiddenMatrix.MaxRows - 1; row++)
        {
            for (var column = MatrixConstants.Minimum;
                column <= hiddenMatrix.MaxColumns - 1; column++)
            {
                Position position = new Position() { Row = row, Column = column };
                if (hiddenMatrix[position] == Convert.ToString(MatrixConstants.EmptyCell))
                    RevealTheMatrix(position, matrix, hiddenMatrix);
            }
        }
    }
}




