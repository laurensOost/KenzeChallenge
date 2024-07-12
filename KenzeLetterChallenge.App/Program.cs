using Microsoft.Extensions.DependencyInjection;
using KenzeLetterChallenge.BL.Interfaces;
using KenzeLetterChallenge.BL.Repositories;
using KenzeLetterChallenge.BL.Services;

var serviceProvider = new ServiceCollection()
    .AddSingleton<IWordRepository>(provider => new WordRepository("input.txt"))
    .AddTransient<WordCombinationFinder>()
    .BuildServiceProvider();

var wordCombinationFinder = serviceProvider.GetService<WordCombinationFinder>();
var combinations = wordCombinationFinder.FindSixLetterCombinations();

foreach (var combination in combinations)
{
    Console.WriteLine(combination);
}