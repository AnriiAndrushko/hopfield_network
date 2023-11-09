namespace hopfield_network
{
    internal class Matrix
    {
        public float[,] matrixData;
        public int RowCount => matrixData.GetLength(0);
        public int CoulumnCount => matrixData.GetLength(1);
        public Matrix(float[,] matrix)
        {
            matrixData = matrix;
        }
        public static Matrix operator *(Matrix a, Matrix b) {

            int rA = a.matrixData.GetLength(0);
            int cA = a.matrixData.GetLength(1);
            int rB = b.matrixData.GetLength(0);
            int cB = b.matrixData.GetLength(1);

            if (cA != rB)
            {
                throw new Exception("Matrixes can't be multiplied!!");
            }

            float temp = 0;
            float[,] ret = new float[rA, cB];

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
        Matrix Transpose()
        {
            float[,] transposedMatrix = new float[CoulumnCount, RowCount];

            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < CoulumnCount; j++)
                {
                    transposedMatrix[j, i] = matrixData[i, j];
                }
            }
            return new Matrix(transposedMatrix);
        }
    }
}
