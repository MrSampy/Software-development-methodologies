// See https://aka.ms/new-console-template for more information
using FirstLab.Regimes;

Regime regime;
if (args.Any())
{
    regime = new NonInteractiveRegime(args);
}
else
{
    regime = new InteractiveRegime();
}

regime.PrintSolution();