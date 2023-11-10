using hopfield_network.Matrix;

public class HopfieldNetwork
{
    private Matrix weights;
    private List<double[,]> validData;
    public readonly int Height, Width;
    public HopfieldNetwork(int Height, int Width)
    {
        this.Height = Height;
        this.Width = Width;
        validData = new();
    }

    public void AddData(double[,] data)
    {
        AddDataWithoutUpdate(data);
        UpdateWeights();
    }
    public void ClearMemory()
    {
        validData.Clear();
        weights = null;
    }

    public void AddDataWithoutUpdate(double[,] data)
    {
        if (data.GetLength(0) != Height || data.GetLength(1) != Width)
        {
            throw new ArgumentException("Not valid data");
        }
        validData.Add(data);
    }
    public void UpdateWeights()
    {
        double[,] valids = new double[validData.Count, Height * Width];
        int m = 0;
        int k = 0;
        for(int i = 0; i < validData.Count; i++)
        {
            for (int j = 0; j < Height * Width; j++)
            {
                valids[i, j] = validData[i][k,m];
                m++;
                if (m >= Width) { m = 0; k++; if (k >= Height) { k = 0; } };
            }
            
        }
        Matrix t = new Matrix(valids);
        //weights = t * (t.Transpose() * t).InverseMatrix() * t.Transpose();
        weights = (1 / (double)t.Width) * (t.Transpose() * t);
        weights = weights.NullDiagonal();
    }
    public double[,]? Predict(double[,] data)
    {
        if (validData.Count==0)
        {
            return null;
        }
        double[,] dat = MatrixDataToArr(data);

        Matrix res = new Matrix(dat).Transpose();
        Matrix tmp;
        int counter = 500;
        int index = -1;
        do
        {
            tmp = res;
            res = (weights * tmp);
            res = res.Apply((x) => x >= 0 ? 1 : -1);
            index = FindIndexInValids(ArrToMatrixData(tmp.Transpose().Apply((x) => x >= 0 ? 1 : -1).matrixData));
            counter--;
        }
        while (index == -1&&counter>0);

        return res.matrixData;
    }
    private bool CompareArrays(double[,] arr1, double[,] arr2)
    {
        for (int i = 0; i < arr1.GetLength(0); i++)
        {
            for (int j = 0; j < arr1.GetLength(1); j++)
            {
                if (Math.Abs(arr1[i, j] - arr2[i, j]) > 0.00001){
                    return false;
                }
            }
        }
        return true;
    }
    private double[,] MatrixDataToArr(double[,] data)
    {
        double[,] dat = new double[1, Height * Width];
        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                dat[0, i * Width + j] = data[i, j];
            }
        }
        return dat;
    }
    private double[,] ArrToMatrixData(double[,] data)
    {
        double[,] dat = new double[Height, Width];
        int m = 0;
        int k = 0;
        for (int j = 0; j < Height * Width; j++)
        {
            dat[k, m] = data[0, j];
            m++;
            if (m >= Width) { m = 0; k++; if (k >= Height) { k = 0; } };
        }
        return dat;
    }
    private int FindIndexInValids(double[,] m)
    {
        for(int i = 0; i< validData.Count; i++)
        {
            if (CompareArrays(validData[i], m))
            {
                return i;
            }
        }
        return -1;
    }
}