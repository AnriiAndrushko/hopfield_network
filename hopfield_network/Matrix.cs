using System.Text;

namespace hopfield_network.Matrix
{
    internal class Matrix
    {
        public double[,] matrixData;
        public int Height => matrixData.GetLength(0);
        public int Width => matrixData.GetLength(1);
        public Matrix(double[,] matrix)
        {
            matrixData = matrix;
        }
        public static Matrix operator *(Matrix a, Matrix b) {

            int rA = a.matrixData.GetLength(0);
            int cA = a.matrixData.GetLength(1);
            int rB = b.matrixData.GetLength(0);
            int cB = b.matrixData.GetLength(1);

            if (cA != rB){throw new Exception("Matrixes can't be multiplied!!");}

            double temp = 0;
            double[,] ret = new double[rA, cB];

            for (int i = 0; i < rA; i++)
            {
                for (int j = 0; j < cB; j++)
                {
                    temp = 0;
                    for (int k = 0; k < cA; k++)
                    {
                        temp += a.matrixData[i, k] * b.matrixData[k, j];
                    }
                    ret[i, j] = temp;
                }
            }

            return new Matrix(ret);
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {

            int rA = a.matrixData.GetLength(0);
            int cA = a.matrixData.GetLength(1);
            int rB = b.matrixData.GetLength(0);
            int cB = b.matrixData.GetLength(1);
            double[,] ret = new double[rB, cB];

            for (int i = 0; i < rB; i++)
            {
                for (int j = 0; j < cB; j++)
                {
                    ret[i, j] = a.matrixData[i, j];
                    ret[i, j] += b.matrixData[i, j];
                }
            }

            return new Matrix(ret);
        }
        public static Matrix operator *(double a, Matrix b)
        {
            int rB = b.matrixData.GetLength(0);
            int cB = b.matrixData.GetLength(1);
            double[,] ret = new double[rB, cB];

            for (int i = 0; i < rB; i++)
            {
                for (int j = 0; j < cB; j++)
                {
                    ret[i, j] = b.matrixData[i,j] * a;
                }
            }

            return new Matrix(ret);
        }
        public Matrix Transpose()
        {
            double[,] transposedMatrix = new double[Width, Height];

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    transposedMatrix[j, i] = matrixData[i, j];
                }
            }
            return new Matrix(transposedMatrix);
        }
        public override string ToString()
        {
            return ToString(Height);
        }

        public string ToString(int rowLength)
        {
            StringBuilder sb = new();
            int count = 0;
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    count++;
                    sb.Append(matrixData[i, j].ToString("N2").PadLeft(5) + " ");
                    if (count == rowLength)
                    {
                        sb.AppendLine();
                        count = 0;
                    }
                }
            }
            return sb.ToString();
        }
        public Matrix NullDiagonal()
        {
            if (Height != Width) { throw new Exception("Column count must be equal Row count"); }
            double[,] ret = (double[,])matrixData.Clone();

            for (int i = 0; i < Height; i++)
            {
                ret[i, i] = 0;
            }

            return new Matrix(ret);
        }
        public Matrix InverseMatrix()
        {
            int n = matrixData.GetLength(0);
            double[,] augmentedMatrix = new double[n, 2 * n];

            // Створюємо початкову розширену матрицю [A | I], де I - одинична матриця
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    augmentedMatrix[i, j] = matrixData[i, j];
                    augmentedMatrix[i, j + n] = (i == j) ? 1 : 0;
                }
            }

            // Виконуємо операції Гаусса-Джордана для знаходження оберненої матриці
            for (int i = 0; i < n; i++)
            {
                double pivot = augmentedMatrix[i, i];
                if (pivot==0)
                {
                    continue;
                }


                for (int j = 0; j < 2 * n; j++)
                {
                    augmentedMatrix[i, j] /= pivot;
                }

                for (int k = 0; k < n; k++)
                {
                    if (k != i)
                    {
                        double factor = augmentedMatrix[k, i];

                        for (int j = 0; j < 2 * n; j++)
                        {
                            augmentedMatrix[k, j] -= factor * augmentedMatrix[i, j];
                        }
                    }
                }
            }

            // Виокремлюємо обернену матрицю з розширеної матриці
            double[,] inverseMatrix = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    inverseMatrix[i, j] = augmentedMatrix[i, j + n];
                }
            }

            return new Matrix(inverseMatrix);
        }

        public Matrix Apply(Func<double, double> funk) { 
            double[,] ret = new double[Height, Width];

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    ret[i, j] = funk(matrixData[i,j]);
                }
            }

            return new Matrix(ret);
        }

    }
}
