// See https://aka.ms/new-console-template for more information
using FirstLab;

ISolver<List<double>> quadraticEquationSolver = new QuadraticEquationSolver(2,1,-3);
var result = quadraticEquationSolver.Solve();

foreach (var x in result) 
{

    Console.WriteLine(x);

}
Console.WriteLine("**********************");
quadraticEquationSolver = new QuadraticEquationSolver(2, 4, 2);
result = quadraticEquationSolver.Solve();
foreach (var x in result)
{

    Console.WriteLine(x);

}
Console.WriteLine("**********************");
quadraticEquationSolver = new QuadraticEquationSolver(1, 0, 9);
result = quadraticEquationSolver.Solve();
foreach (var x in result)
{

    Console.WriteLine(x);

}
Console.WriteLine("**********************");
