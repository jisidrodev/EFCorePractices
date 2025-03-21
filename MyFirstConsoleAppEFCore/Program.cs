// See https://aka.ms/new-console-template for more information
using MyFirstConsoleAppEFCore;

Console.WriteLine("Commands: l (list), u (change url) and e (exit)");
var option = Console.ReadLine();
switch (option)
{
	case "l":
		Commands.ListAll();
		break;
	case "u":
		Commands.ChangeWebUrl();
		break;
	case "e":
		break;
	default:
		break;
}

Console.ReadKey();
