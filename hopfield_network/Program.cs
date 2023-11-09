using hopfield_network;

//Matrix t = new Matrix(new double[,] {
//{ 4, 2, 3 },
//{ 3, 5, 6 },
//{ 4, 8, 9 },
//});
//Console.WriteLine(t.InverseMatrix().ToString());


Matrix ValidData = new Matrix(new double[,] {
{ 1,  1, 1,
  1, -1, 1, 
  1,  1, 1 },

{ -1, -1, 1,
  -1, -1, 1,
   1,  1, 1 },

{ 1,  1,  1,
 -1,  1, -1,
 -1,  1, -1 },
});

Matrix Weights = ValidData * (ValidData.Transpose() * ValidData).InverseMatrix() * ValidData.Transpose();