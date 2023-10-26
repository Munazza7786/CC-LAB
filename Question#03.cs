using System;
using System.Text;

class PasswordGenerator
{
    static void Main(string[] args)
    {
        string firstName = "Munazza";
        string lastName = "Israr";
        string reg_Number = "FA20-BCS-059";

        string password = GeneratePassword(firstName, lastName, reg_Number);
        Console.WriteLine("Generated Password: " + password);
    }

    static string GeneratePassword(string firstName, string lastName, string reg_Number)
    {
        
        char firstInitial = char.ToUpper(firstName[0]);
        char lastInitial = char.ToUpper(lastName[0]);

        
        string lastTwoDigits = reg_Number.Substring(reg_Number.Length - 2);

        
        string specialCharacters = "!@#$%^&*()_+";

        
        string numbers = "0123456789";

        int maxLength = 20;

   
        Random random = new Random();

       
        StringBuilder password = new StringBuilder();
        password.Append(firstInitial);
        password.Append(lastInitial);
        password.Append(lastTwoDigits);
        password.Append(specialCharacters[random.Next(specialCharacters.Length)]);
        password.Append(specialCharacters[random.Next(specialCharacters.Length)]);
        for (int i = 0; i < 2; i++)
        {
            password.Append(numbers[random.Next(numbers.Length)]);
        }
        int remainingLength = maxLength - password.Length;

        while (remainingLength > 0)
        {
            password.Append(GetRandomCharacter(random));
            remainingLength--;
        }

        password = ShuffleString(password.ToString());

        return password.ToString();
    }

    static char GetRandomCharacter(Random random)
    {
        string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        return characters[random.Next(characters.Length)];
    }

    static StringBuilder ShuffleString(string input)
    {
        char[] array = input.ToCharArray();
        Random random = new Random();

        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);

            char temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        return new StringBuilder(new string(array));
    }
}