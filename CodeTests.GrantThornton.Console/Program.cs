using CodeTests.GrantThornton.Application.Extensions;
using CodeTests.GrantThornton.Application.Integrations.GrantThornton;
using CodeTests.GrantThornton.Application.Services;
using CodeTests.GrantThornton.Application.Types;
using CodeTests.GrantThornton.Console;

var parameters = new ConsoleParameters();

// Task one
Console.WriteLine($"Executing task 1, with n = {parameters.TaskOneN}");
var taskOneResult = new FibonacciSequenceService().GetFibonacciNumber(parameters.TaskOneN);
Console.WriteLine($"Result: {taskOneResult}");

// Task two
Console.WriteLine($"Executing task 2, with n = {parameters.TaskTwoN}");
var taskTwoResult = new DiagonalSquare(parameters.TaskTwoN);
Console.WriteLine($"Result: \n{taskTwoResult}");

// Task three
if (parameters.TaskThreeArray.Length == 0)
{
    var random = new Random();
    parameters.TaskThreeArray = Enumerable.Range(0, 10)
        .Select(_ => random.Next(100))
        .ToArray();
}

Console.WriteLine($"Executing task 3, with array = {string.Join(", ", parameters.TaskThreeArray)}");
parameters.TaskThreeArray.BubbleSort();
Console.WriteLine($"Result: {string.Join(", ", parameters.TaskThreeArray)}");

// Task four
var grantThorntonClient = new GrantThorntonClient(
    "https://gt-code-test.azurewebsites.net/api/",
    "DRuQSdrjDG_syswkTpRhz2l0wt_tDoOmFTGLhCCni_MDAzFuYF6Bkg==");

var taskFourData = await grantThorntonClient.GetPalindromeTestDataAsync(parameters.TaskFourName);
Console.WriteLine($"Executing task 4 with data: {string.Join(", ", taskFourData)}");
var checkResult = new PalindromeCheckService().CheckForPalindromes(taskFourData);

Console.WriteLine("Submitting result:");
Console.WriteLine($"Palindromes: {string.Join(", ", checkResult.Palindromes)}");
Console.WriteLine($"Non palindromes: {string.Join(", ", checkResult.NonPalindromes)}");

await grantThorntonClient.SubmitPalindromesAsync(
    parameters.TaskFourName,
    new() { NonPalindromes = checkResult.NonPalindromes, Palindromes = checkResult.Palindromes });

Console.WriteLine("Submit complete.");