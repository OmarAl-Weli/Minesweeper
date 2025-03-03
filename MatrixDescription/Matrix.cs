using Minesweeper.Service;
namespace Minesweeper.MatrixDescription
{
    public class Matrix
    {
        private int[,] _matrix;
        private int _maxRows;
        private int _maxColumns;
        private int _numOfBombs = 0;

        public int MaxRows
        {
            get { return _maxRows - 1; }
        }

        public int MaxColumns
        {
            get { return _maxColumns - 1; }
        }

        public int numberOfBombs
        {
            get { return _numOfBombs; }
        }

        public Matrix(int maxRows, int maxColumns)
        {
            _maxRows = maxRows;
            _maxColumns = maxColumns;
            _matrix = new int[_maxRows, _maxColumns];
            Array.Clear(_matrix, MatrixConstants.EmptyCell, _matrix.Length);
        }

        public int this[Position cellPosition]
        {
            get { return _matrix[cellPosition.Row, cellPosition.Column]; }
            set { _matrix[cellPosition.Row, cellPosition.Column] = value; }
        }

        public void IncrementCellValue(Position position)
        {
            var currentValue = this[position];
            if (currentValue == MatrixConstants.Bomb)
                return;
            this[position] = currentValue + 1;
        }

        public bool GetBomb(Position position)
        {
            return this[position] == MatrixConstants.Bomb;
        }

        public void SetBomb(Position position, Matrix matrix)
        {
            matrix[position] = MatrixConstants.Bomb;
            _numOfBombs++;
            AdjacentCellCalculatorService.AppendAdjacentCells(position, matrix);
        }
    }
}