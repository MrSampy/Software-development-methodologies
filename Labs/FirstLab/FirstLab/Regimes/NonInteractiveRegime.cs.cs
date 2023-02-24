using FirstLab.Solvers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLab.Regimes
{
    public class NonInteractiveRegime : Regime
    {
        private string Path { set; get; }

        protected double GetCoeffFromInput(string coeffName,string input)
        {
            double result = 0;
            while (true)
            {
                try
                {
                    result = Convert.ToDouble(input);
                }
                catch
                {
                    ErrorPrinter.PrintWrongInputError(coeffName, input);
                    Environment.Exit(-1);
                }

                if (result == 0 && coeffName.Equals(stringCoeffs.First()))
                {
                    ErrorPrinter.PrintNotZeroError(coeffName);
                    Environment.Exit(-1);
                }

                return result;
            }


        }


        public NonInteractiveRegime(string[] args) 
        {
            if (!args.Any()) 
            {
                ErrorPrinter.PrintNotCorrectPathError("");
                Environment.Exit(-1);
            }
            Path = args[0];
        }
        protected override Coeffs GetCoefficients()
        {     
            var result = new double[stringCoeffs.Length];
            var file = new FileInfo(Path);
            if (file.Exists)
            {
                if (file.Extension == ".txt")
                {
                    using (FileStream fstream = File.OpenRead(Path))
                    {
                        byte[] buffer = new byte[fstream.Length];
                        fstream.Read(buffer, 0, buffer.Length);
                        var textFromFile = Encoding.Default.GetString(buffer);
                        var coeffsFromFile = textFromFile.Split(' ');
                        if (coeffsFromFile.Length != 3)
                        {
                            ErrorPrinter.PrintInvalidTextInFileError(textFromFile);
                            Environment.Exit(-1);
                        }
                        for (int id = 0; id < stringCoeffs.Length; ++id)
                        {
                            result[id] = GetCoeffFromInput(stringCoeffs[id], coeffsFromFile[id]);
                        }
                    }

                }
                else
                {
                    ErrorPrinter.PrintInvalidFormatFileError();
                    Environment.Exit(-1);
                }

            }
            else
            {
                ErrorPrinter.PrintNotCorrectPathError(Path);
                Environment.Exit(-1);
            }

            return new Coeffs(result[0], result[1], result[2]);

        }
    }
}
