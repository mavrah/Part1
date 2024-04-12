using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE
{
    internal class RecipeManager
    {
        private List<Ingredient> ingredients;
        private List<string> steps;
        private double scaleFactor = 1.0;

        public void EnterRecipe()
        {
            ingredients = new List<Ingredient>();
            steps = new List<string>();

            Console.Write("Enter the number of ingredients: ");
            int numIngredients = GetUserInputInt();

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Ingredient {i + 1}:");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Quantity: ");
                double quantity = GetUserInputDouble();
                Console.Write("Unit of Measurement: ");
                string unit = Console.ReadLine();
                ingredients.Add(new Ingredient(name, quantity, unit));
            }

            Console.Write("Enter the number of steps: ");
            int numSteps = GetUserInputInt();

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Step {i + 1}:");
                Console.Write("Description: ");
                string description = Console.ReadLine();
                steps.Add(description);
            }

            scaleFactor = 1.0;
        }
        public void DisplayRecipe()
        {
            if (ingredients == null || steps == null || ingredients.Count == 0 || steps.Count == 0)
            {
                Console.WriteLine("No recipe has been entered yet.");
                return;
            }

            Console.WriteLine("Recipe:");
            Console.WriteLine("Ingredients:");
            foreach (Ingredient ingredient in ingredients)
            {
                Console.WriteLine($"- {ingredient.Quantity * scaleFactor} {ingredient.Unit} of {ingredient.Name}");
            }
            Console.WriteLine("Steps:");
            for (int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }

        public void ScaleRecipe()
        {
            if (ingredients == null || steps == null || ingredients.Count == 0 || steps.Count == 0)
            {
                Console.WriteLine("No recipe has been entered yet.");
                return;
            }

            Console.WriteLine("Select a scaling factor:");
            Console.WriteLine("1. 0.5 (half)");
            Console.WriteLine("2. 2 (double)");
            Console.WriteLine("3. 3 (triple)");

            int choice = GetUserChoice();
            switch (choice)
            {
                case 1:
                    scaleFactor = 0.5;
                    break;
                case 2:
                    scaleFactor = 2;
                    break;
                case 3:
                    scaleFactor = 3;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Scaling canceled.");
                    return;
            }

            Console.WriteLine($"Recipe scaled by a factor of {scaleFactor}.");
        }

        private int GetUserChoice()
        {
            throw new NotImplementedException();
        }

        public void ResetRecipe()
        {
            scaleFactor = 1.0;
            Console.WriteLine("Recipe quantities have been reset to the original values.");
        }

        public void ClearRecipe()
        {
            ingredients = null;
            steps = null;
            scaleFactor = 1.0;
            Console.WriteLine("Recipe has been cleared.");
        }
        private int GetUserInputInt()
        {
            int value;
            while (!int.TryParse(Console.ReadLine(), out value) || value < 1)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
            }
            return value;
        }

        private double GetUserInputDouble()
        {
            double value;
            while (!double.TryParse(Console.ReadLine(), out value) || value < 0)
            {
                Console.WriteLine("Invalid input. Please enter a non-negative number.");
            }
            return value;
        }
    }
}
