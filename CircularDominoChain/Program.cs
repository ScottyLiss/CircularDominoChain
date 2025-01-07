using CircularDominoChain.Models;
using CircularDominoChain.Services;

DominoChainService dominoChainService = new DominoChainService();

Domino[] dominosA = [new (2, 1), new (2, 3), new (1, 3)];
Domino[] dominosB = [new (1, 2), new (4, 1), new (2, 3)];
Domino[] dominosC = [new (5, 1), new (2, 5), new (2, 3)];
Console.WriteLine($"Domino chain A is {dominoChainService.GetCircularDominoChain(dominosA)}");
Console.WriteLine($"Domino chain B is {dominoChainService.GetCircularDominoChain(dominosB)}");
Console.WriteLine($"Domino chain C is {dominoChainService.GetCircularDominoChain(dominosC)}");
