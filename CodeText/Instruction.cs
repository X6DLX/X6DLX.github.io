
class Instructions{

    private static string? argumentText;

    public static int DisplayInstructions(string? userInput){
        switch (userInput){
             case "\\?":
                InstructionsTable(); // Method
                return Program.Input();

            case "\\exit":
                Environment.Exit(0); // Exits program
                return 0;
            
            case "\\disSec":
                Program.disableSecurity = true; // Is true if user hase disabled the security measures
                return Program.Input();
            
            case "\\enblSec":
                Program.disableSecurity = false; // Is false if user hase enabled the security measures
                return Program.Input();

            default: // Default is if none of the case statements are meet
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError occurred: Passwoed length cannot exceed 2^16, and password length cannot be an string\n");
                Console.ResetColor();
                return Program.Input();
        }
    }

    private static void InstructionsTable(){

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nSercurity:");
        Console.WriteLine("\u2022 The password generated must be longer than 3 for security reasons");
        Console.WriteLine("\u2022 The password generated will always contain Uppercase letter");
        Console.WriteLine("\u2022 The password generated will always contain lowercase letter");
        Console.WriteLine("\u2022 The password generated will always contain symbols");
        Console.WriteLine("\u2022 The password generated will always contain numbers\n");

        Console.WriteLine("Commands:");
        Console.WriteLine("\u2022 Type \\disSec to disable security measures mentioned above");
        Console.WriteLine("\u2022 Type \\enblSec to enable security measures mentioned above");
        Console.WriteLine("\u2022 Type \\? for instruction");
        Console.WriteLine("\u2022 Type \\exit to exit the program\n");
        
        Console.WriteLine("Control Panel:");
    
        Console.Write("\u2022 security measures are ");
        SecurityMeasures(Program.disableSecurity);

        Console.WriteLine();
        Console.ResetColor();
    }

    
    
    private static void SecurityMeasures(bool argument){
        switch (argument){
            case true:
                Console.ForegroundColor = ConsoleColor.Red;
                argumentText = "Disabled";
                break;

            case false:
                Console.ForegroundColor = ConsoleColor.Green;
                argumentText = "Enabled";
                break;
        }
        
        Console.WriteLine($"[{argumentText}]");
        Console.ResetColor();
    }
   
}
