using System.Text;

namespace CodeTests.GrantThornton.Application.Types
{
    public class DiagonalSquare
    {
        public int DiagonalOfSquare { get; }
        public int CenterOfDiagonal { get; }
        public bool[,] Representation { get; }

        public DiagonalSquare(int n)
        {
            if (n % 2 == 0)
                throw new ArgumentException("Even numbers are not allowed");

            DiagonalOfSquare = n;
            CenterOfDiagonal = ((n + 1) / 2);
            Representation = CreateDiagonalSquare();
        }

        private bool[,] CreateDiagonalSquare()
        {
            var diagonalSquare = new bool[DiagonalOfSquare, DiagonalOfSquare];
            var numberOfVisibleColumns = -1;
            for (var row = 0; row < DiagonalOfSquare; row++)
            {
                numberOfVisibleColumns = row < CenterOfDiagonal
                    ? numberOfVisibleColumns + 2
                    : numberOfVisibleColumns - 2;

                // Center the visible columns
                var startIndexOfVisibleColumns = (DiagonalOfSquare - numberOfVisibleColumns) / 2;
                for (var column = 0; column < DiagonalOfSquare; column++)
                    diagonalSquare[row, column] = column >= startIndexOfVisibleColumns && column < startIndexOfVisibleColumns + numberOfVisibleColumns;

            }

            return diagonalSquare;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            for (var row = 0; row < DiagonalOfSquare; row++)
            {
                for (var column = 0; column < DiagonalOfSquare; column++)
                    stringBuilder.Append(Representation[row, column] ? '*' : ' ');

                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }
    }
}
