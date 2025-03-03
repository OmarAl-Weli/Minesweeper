namespace Minesweeper.MatrixDescription
{
    public class HiddenMatrix
    {
        private readonly string[,] _hiddenMatrix;
        private readonly int _maxRows;
        private readonly int _maxColumns;

        public int MaxRows
        {
            get { return _maxRows - 1; }
        }

        public int MaxColumns
        {
            get { return _maxColumns - 1; }
        }

        public HiddenMatrix(int MaxRows, int MaxColumns)
        {
            _maxRows = MaxRows;
            _maxColumns = MaxColumns;
            _hiddenMatrix = new string[_maxRows, _maxColumns];
            PopulateHiddenMatrix(_hiddenMatrix, _maxRows, _maxColumns);
        }

        public string this[Position cellPosition]
        {
            get { return _hiddenMatrix[cellPosition.Row, cellPosition.Column]; }
            set { _hiddenMatrix[cellPosition.Row, cellPosition.Column] = value; }
        }

        public bool CheckMapStatus(Matrix matrix, HiddenMatrix hiddenMatrix)
        {
            int _numOfUncoveredCells = 0;
            for (var row = 0;
             row < hiddenMatrix.MaxRows; row++)
            {
                for (var column = 0;
                 column < hiddenMatrix.MaxColumns; column++)
                {
                    if (hiddenMatrix[new Position() { Row = row, Column = column }] != "?")
                        _numOfUncoveredCells++;
                }
            }

            return _numOfUncoveredCells == hiddenMatrix.MaxRows * hiddenMatrix.MaxColumns + -matrix.numberOfBombs;
        }

        public void PopulateHiddenMatrix(string[,] matrix, int MaxRows, int MaxColumns)
        {
            for (var row = MatrixConstants.Minimum;
                     row <= MaxRows - 1; row++)
            {
                for (var column = MatrixConstants.Minimum;
                    column <= MaxColumns - 1; column++)
                {
                    matrix[row, column] = MatrixConstants.HiddenCell;
                }
            }
        }
    }
}