using Minesweeper.MatrixDescription;
namespace Minesweeper.Service
{
    public class AdjacentCellCalculatorService
    {
        public static List<Position> CalculateAdjacentCells(Position position)
        {
            List<Position> positions = new List<Position>(8);

            positions.Add(
                AdjacentCellsCalculator.CalculateUpperCell(position));
            positions.Add(
                AdjacentCellsCalculator.CalculateLowerCell(position));
            positions.Add(
                AdjacentCellsCalculator.CalculateLeftCell(position));
            positions.Add(
                AdjacentCellsCalculator.CalculateRightCell(position));
            //----------------------------------------------------------------------------------
            positions.Add(
                AdjacentCellsCalculator.CalculateUpperLeftCell(position));
            positions.Add(
                AdjacentCellsCalculator.CalculateLowerLeftCell(position));
            positions.Add(
                AdjacentCellsCalculator.CalculateUpperRightCell(position));
            positions.Add(
                AdjacentCellsCalculator.CalculateLowerRightCell(position));

            return positions;
        }

        public static void AppendAdjacentCells(Position position, Matrix matrix)
        {
            
            matrix.IncrementCellValue(
                AdjacentCellsCalculator.CalculateUpperCell(position));
            matrix.IncrementCellValue(
                AdjacentCellsCalculator.CalculateLowerCell(position));
            matrix.IncrementCellValue(
                AdjacentCellsCalculator.CalculateLeftCell(position));
            matrix.IncrementCellValue(
                AdjacentCellsCalculator.CalculateRightCell(position));
            //----------------------------------------------------------------------------------
            matrix.IncrementCellValue(
                AdjacentCellsCalculator.CalculateUpperLeftCell(position));
            matrix.IncrementCellValue(
                AdjacentCellsCalculator.CalculateLowerLeftCell(position));
            matrix.IncrementCellValue(
                AdjacentCellsCalculator.CalculateUpperRightCell(position));
            matrix.IncrementCellValue(
                AdjacentCellsCalculator.CalculateLowerRightCell(position));
        }
    }
}