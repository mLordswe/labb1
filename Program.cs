using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;




internal class Program
{
    private static void Main(string[] args)
    {
        bool run = true;
        decimal totalCost = 0m;
        while (run)
        {
            Console.WriteLine("=================================");
            Console.WriteLine("VÄLKOMMEN TILL LASSES LAST 1.0\n");
            Console.WriteLine("1) Beräkna frakt för ett paket");
            Console.WriteLine("2) Beräkna frakt för flera paket från fil");
            Console.WriteLine("3) Avsluta\n");
            Console.Write("Val: ");
            string input = Console.ReadLine()!;
            if (input == "1")
            {
                Console.Clear();
                Package myPackage = PackageMenu();
                totalCost = CalculatePackage(myPackage);
                System.Console.WriteLine($"Totala priset: {totalCost}");
                receiptLog(myPackage.Name,
                           myPackage.Weight,
                           myPackage.Value,
                           myPackage.IsMember,
                           myPackage.IsInsured,
                           myPackage.WeightFee,
                           myPackage.HeavyFee,
                           myPackage.InsuranceFee,
                           myPackage.TotalCost);
            }
            else if (input == "2")
            {
                Console.WriteLine("DET HÄR VALET ÄR INTE IMPLEMENTERAT ÄNNU! GE MIG MER BETALT SÅ FIXAR JAG DET JAG LOVAR.");
            }
            else if (input == "3")
            {
                run = false;
                System.Console.WriteLine("Programmet Avslutas");
            }
        }
    }
    static bool ConsoleOption()
    {


        bool menu = false;
        bool runOption = true;
        while (runOption)
        {
            Console.SetCursorPosition(0, 1);
            System.Console.WriteLine((menu ? ">" : " ") + "Ja");
            System.Console.WriteLine((!menu ? ">" : " ") + "Nej");
            ConsoleKeyInfo userChoise = Console.ReadKey(intercept: true);




            if (userChoise.Key == ConsoleKey.UpArrow)
            {
                menu = true;
                Console.Write(">");

            }
            else if (userChoise.Key == ConsoleKey.DownArrow)
            {
                menu = false;

            }
            else if (userChoise.Key == ConsoleKey.Enter)
            {

                runOption = false;

            }
        }

        return menu;
    }
    static Package PackageMenu()
    {
        Package packageInfo = new Package();
        Console.Clear();
        Console.Write("Avsändare: ");
        packageInfo.Name = Console.ReadLine()!;
        Console.Clear();
        Console.Write("Vikt: ");
        packageInfo.Weight = decimal.Parse(Console.ReadLine()!);
        Console.Clear();
        Console.Write("Värde: ");
        packageInfo.Value = int.Parse(Console.ReadLine()!);
        Console.Clear();
        Console.Write("Är du medlem?: ");
        Console.Clear();
        System.Console.Write("Är du medlem?: ");
        packageInfo.IsMember = ConsoleOption();
        Console.Clear();
        Console.Write("Är paketet försäkrat?: ");
        packageInfo.IsInsured = ConsoleOption();

        return packageInfo;
    }
    static void receiptLog(string sender, decimal weight, decimal Value, bool IsMember, bool IsInsured, decimal weightFee, decimal heavyFee, decimal insuranceFee, decimal totalCost)
    {
        System.Console.WriteLine("FRAKTKVITTO");
        System.Console.WriteLine("-----------------------------");
        System.Console.WriteLine($"Avsändare: {sender}");
        System.Console.WriteLine($"Vikt: {weight}");
        System.Console.WriteLine($"Innehållets värde: {Value} kr");
        System.Console.WriteLine("Medlem: " + (IsMember ? "Ja" : "Nej")); // IsMember ? 5.0m : 2.0m
        System.Console.WriteLine("Försäkring: " + (IsInsured ? "Ja" : "Nej"));
        System.Console.WriteLine();
        System.Console.WriteLine("Grundavgift:          49 kr");
        System.Console.WriteLine($"Viktavgift:          {weightFee} kr");
        System.Console.WriteLine($"Tunggodstillägg:      {heavyFee} kr");
        System.Console.WriteLine($"Försäkringsavgift:    {insuranceFee} kr");
        System.Console.WriteLine("-----------------------------");
        System.Console.WriteLine($"Totalt att betala:   {totalCost} kr");
    }
    static decimal CalculatePackage(Package p)
    {
        decimal freeCost = p.IsMember ? 5.0m : 2.0m;

        p.WeightFee = Math.Max(0m, p.Weight - freeCost) * 10m;
        p.HeavyFee = Math.Max(0m, p.Weight - 20m) * 30m;
        p.InsuranceFee = p.IsInsured ? p.Value * 0.01m : 0m;
        p.TotalCost = p.BaseFee + p.WeightFee + p.HeavyFee + p.InsuranceFee;
        return p.TotalCost;
    }
}

class Package
{
    public string Name;
    public decimal Weight;
    public int Value;
    public bool IsMember;
    public bool IsInsured;

    public decimal BaseFee { get; set; } = 49m;
    public decimal WeightFee { get; set; }
    public decimal HeavyFee { get; set; }
    public decimal InsuranceFee { get; set; }
    public decimal TotalCost { get; set; }
};




