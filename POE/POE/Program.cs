internal class Program
{
    private static void Main(string[] args)
    {
        POE.RecipeManager recipeManager = new POE.RecipeManager();

        while (true)
        {
            //User menu
            Console.WriteLine("Welcome to the Recipe App!");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Enter a new recipe");
            Console.WriteLine("2. Display the current recipe");
            Console.WriteLine("3. Scale the recipe");
            Console.WriteLine("4. Reset the recipe quantities");
            Console.WriteLine("5. Clear the recipe");
            Console.WriteLine("6. Exit");

            int choice = GetUserChoice();

            switch (choice)
            {
                case 1:
                    recipeManager.EnterRecipe();
                    break;
                case 2:
                    recipeManager.DisplayRecipe();
                    break;
                case 3:
                    recipeManager.ScaleRecipe();
                    break;
                case 4:
                    recipeManager.ResetRecipe();
                    break;
                case 5:
                    recipeManager.ClearRecipe();
                    break;
                case 6:
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static int GetUserChoice()
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 6)
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 6.");
        }
        return choice;
    }
}
    
