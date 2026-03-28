using BankingApp;

var validator = new CardValidator();
var calculator = new DepositCalculator();

Console.WriteLine("Enter card number:");
var card = Console.ReadLine();

if (!validator.IsValid(card))
{
    Console.WriteLine("Invalid card!");
    return;
}

Console.WriteLine("Valid card!");

Console.WriteLine("Enter amount:");
decimal amount = decimal.Parse(Console.ReadLine());

Console.WriteLine("Enter months:");
int months = int.Parse(Console.ReadLine());

var result = calculator.Calculate(amount, months);

Console.WriteLine($"Final amount: {result}");