# Software-development-methodologies

[![.NET](https://github.com/MrSampy/Software-development-methodologies/actions/workflows/dotnet.yml/badge.svg)](https://github.com/MrSampy/Software-development-methodologies/actions/workflows/dotnet.yml)

## Lab №1 - "Quadratic Equation Solver"
This program allows you to solve Quadratic Equation using two ways:<br />
 <b>Interactive</b>(by entering data to the console) <br />
 and <b>Non-Interactive</b>(by starting up the program with the path to file of ".txt" format. All three coeffs shoud be separated by one space.). <br />
 [Wrong Commit](https://github.com/MrSampy/Software-development-methodologies/commit/9f655150b9e9dc1ac0f7324f6ac3ea123a4237f7)<br />
 [Revert Commit](https://github.com/MrSampy/Software-development-methodologies/commit/44430e8524a44911326ef4f2c06516eabc2b8a3b)

## Lab №2 - "One Way Linked Ring List"
An application can be used to store data in an ordered list, where elements are accessed by traversing from one node to the next. Thanks to the ring structure, it is also possible to efficiently perform operations that require iterating through all elements of the list. <br />
My number in the list: <b>8</b> <br />
Variant: <b>8 % 4 = 0</b> <br />
[Reference to the commit on which the tests failed](https://github.com/MrSampy/Software-development-methodologies/commit/0ff5977d36f6cb2144b98bd30932acb01e99161d)<br />
[WorkFlow with failed tests](https://github.com/MrSampy/Software-development-methodologies/actions/runs/4335531187)<br />



# Instruction, how to build and run .NET project
To build and run a .NET project, you need to follow these steps:

- Install the .NET SDK on your computer. You can download it from the official .NET website: https://dotnet.microsoft.com/download (.NET 6.0)

- Open a terminal or command prompt and navigate to the directory containing your project.

- Run the dotnet restore command to install all the project dependencies from the internet or local NuGet caches.

- Run the dotnet build command to compile the project and create the executable file. If the project is successfully compiled, the executable file will be located in the bin/Debug or bin/Release folder, depending on the build mode.

- If your project is a console application, you can run it using the dotnet run command. If your project has an executable file, you can run it by executing the file from the command prompt or double-clicking on it in the file explorer.

