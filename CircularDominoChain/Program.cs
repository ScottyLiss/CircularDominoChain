using CircularDominoChain.Models;
using CircularDominoChain.Services;

DominoChainService dominoChainService = new DominoChainService();

Domino[] dominosA = [new(2, 1), new(2, 3), new(1, 3)];
Domino[] dominosB = [new(1, 2), new(4, 1), new(2, 3)];
Domino[] dominosC = [new(4, 1), new(2, 1), new(2, 4)];

// == Predefined Domino Chains ==
// A will be circular
Console.WriteLine($"Domino chain A is {dominoChainService.GetCircularDominoChain(dominosA)}");
// B will not be circular
Console.WriteLine($"Domino chain B is {dominoChainService.GetCircularDominoChain(dominosB)}");
// C will be circular
Console.WriteLine($"Domino chain C is {dominoChainService.GetCircularDominoChain(dominosC)}");

// Random amount between 1-10 
Random random = new Random();
var amount = random.Next(1, 10);
Console.WriteLine($"Next Domino chain has {amount} of dominos");
Console.WriteLine($"Domino chain Random is {dominoChainService.GetCircularDominoChain(GenerateRandomDominos(amount))}");

static Domino[] GenerateRandomDominos(int count)
{
    Random random = new();
    Domino[] dominos = new Domino[count];

    for (int i = 0; i < count; i++)
    {
        int left = random.Next(1, 6);
        int right = random.Next(1, 6);
        dominos[i] = new Domino(left, right);
    }

    return dominos;
}