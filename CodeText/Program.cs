class Program
{   
    // Used for disabling security measures
    public static bool disableSecurity;

    private static int Main(string[] args)
    {   
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\u2022 Type \\? for instruction");

        Console.ResetColor();
        while (true){
            int length = Input();
            PasswordGenerator(length);
        }
    }

    public static int Input(){

        // Password length
        Console.Write("Choose your Password Length (Recommended 20): ");
        string? userInput = Console.ReadLine();
        Console.ResetColor();
        if (Int16.TryParse(userInput, out short length))
        {

            // User can disable password length requirement here
            // disableSecurity is true if user has disabled security measures
            // Password length must be longer then 3, only if disableSecurity == false
            if (length < 4 && disableSecurity == false){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError occurred: Passwod length must be bigger than 3\n");
                Console.ResetColor();

                return Input();
                
            }
        }
        else return Instructions.DisplayInstructions(userInput);
   
        return length;
    }
  

    private static void PasswordGenerator(int length){
        Random random = new Random();

        // Decimal table (ASCII Table)
        HashSet<int> exclude = new HashSet<int> {32, 127};
        
        // Password
        string password = "";
        bool isStrongPassword = false;
        
        do 
        {   
            // Password reset
            password = "";          

            for (int i = 0; i < length; i++)
            {   
                int numberGenerator;
                do{
                    numberGenerator = random.Next(32, 127); // random numbers between 32 and 127
                } while (exclude.Contains(numberGenerator)); // Generate a new number until numberGenerator doesn't Contain any number from exclude
                
                char character = Convert.ToChar(numberGenerator); // Converts the intgers to chars
                password += character; // Add char to password (str)
            }

            // is true if password security measures are meet
            isStrongPassword = PasswordSecurityMeasures(password);
            
        } while (isStrongPassword == false && disableSecurity == false);

        // Password print
        Console.WriteLine("\nPassword: " + password + "\n");
    }

    private static bool PasswordSecurityMeasures(string password){

        // Used to check if the password contains a symbols
        HashSet<int> symbols = new HashSet<int> {33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 58, 59, 60, 61, 62, 63, 64, 91, 92, 93, 94, 95, 96, 123, 124, 125, 126};

        // All the passwordRequirements must be true for the password to be valid
        bool[] passwordRequirements = new bool[4];

        // Resets all the passwordRequirements to false
        foreach (var index in Enumerable.Range(0, passwordRequirements.Length)){
            passwordRequirements[index] = false;
        }

        // Loop through every character in password
        foreach(char character in password){

            // Converts character (char) to int
            int characterNumber = Convert.ToInt16(character);

            // Uppercase letters
            if (characterNumber >= 65 && characterNumber <= 90 && passwordRequirements[0] != true){
                passwordRequirements[0] = true;
            }
            // Lowercase letters
            if (characterNumber >= 97 && characterNumber <= 122 && passwordRequirements[1] != true){
                passwordRequirements[1] = true;
            }
            // Numbers
            if (characterNumber >= 48 && characterNumber <= 57 && passwordRequirements[2] != true){
                passwordRequirements[2] = true;
            }

            if (symbols.Contains(characterNumber) && passwordRequirements[3] != true){
                passwordRequirements[3] = true;
            }

        }
        
        // Is true if all passwordRequirements is true
        return passwordRequirements.All(b => b);
    }
}

