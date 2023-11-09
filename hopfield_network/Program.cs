using hopfield_network;

//Matrix t = new Matrix(new double[,] {
//{ -1, 1, -7 },
//{ 6, 2, 6 },
//{ 3, 0, 1 },
//});
//Console.WriteLine(t.InverseMatrix());


Matrix ValidData = new Matrix(new double[,] {
{ 1,  1, 1,
  1, -1, 1, 
  1,  -1, 1 },

{ 1,  1,  1,
  1, -1, -1,
  1, -1, -1 },

{ 1, -1, -1,
  1, -1, -1,
  1,  1, 1 },

});

Matrix TestData = new Matrix(new double[,] {
{ 1,  -1, -1,
  1, -1, -1,
  -1,  1, 1 }
});

//Matrix Weights = ValidData * (ValidData.Transpose() * ValidData).InverseMatrix() * ValidData.Transpose();
Matrix Weights = 1/ (double)ValidData.ColumnCount * ValidData.Transpose() * ValidData;
Weights = Weights.NullDiagonal();
Matrix res = Weights * TestData.Transpose();

Console.WriteLine(Weights);
Console.WriteLine(res.Apply((x)=>x>=0?1:-1).ToString(3));