using System;
using System.Collections.Generic;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        int choice = 0;

        while (choice != 7)
        {
            Console.WriteLine("\n--- Eternal Quest Menu ---");
            Console.WriteLine($"Your current score is: {_score}");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goal Names");
            Console.WriteLine("3. List Goal Details");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Record Event");
            Console.WriteLine("7. Quit");
            Console.Write("Choose an option: ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1: CreateGoal(); break;
                    case 2: ListGoalNames(); break;
                    case 3: ListGoalDetails(); break;
                    case 4: SaveGoals(); break;
                    case 5: LoadGoals(); break;
                    case 6: RecordEvent(); break;
                    case 7: Console.WriteLine("Goodbye!"); break;
                    default: Console.WriteLine("Invalid option."); break;
                }
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("\nGoals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nGoal Details:");
        foreach (Goal g in _goals)
        {
            Console.WriteLine(g.GetDetailsString());
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nWhich type of goal would you like to create?");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Enter choice: ");
        string choice = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter point value: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("Enter target completions: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("\nWhich goal did you accomplish?");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        Console.Write("Enter the number of the goal: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            _goals[index].RecordEvent();
            _score += 100; // Placeholder — can change based on goal points
            Console.WriteLine("Event recorded!");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("Enter the filename to save goals (e.g., goals.txt): ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            // 1. Save the total score
            outputFile.WriteLine(_score);

            // 2. Save each goal
            foreach (Goal g in _goals)
            {
                outputFile.WriteLine(g.GetStringRepresentation());
            }
        }

        Console.WriteLine($"Goals saved successfully to '{filename}'.");
    }

    public void LoadGoals()
    {
        Console.Write("Enter the filename to load goals from (e.g., goals.txt): ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found. Please check the filename and try again.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        _goals.Clear(); // Clear list before loading
        _score = int.Parse(lines[0]); // first line = score

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split(':');
            string type = parts[0];
            string[] details = parts[1].Split(',');

            if (type == "SimpleGoal")
            {
                string name = details[0];
                string description = details[1];
                int points = int.Parse(details[2]);
                bool isComplete = bool.Parse(details[3]);

                SimpleGoal goal = new SimpleGoal(name, description, points);

                // Update state
                if (isComplete)
                {
                    // Uses direct reflection on the private variable via method
                    goal.RecordEvent();
                }

                _goals.Add(goal);
            }
            else if (type == "EternalGoal")
            {
                string name = details[0];
                string description = details[1];
                int points = int.Parse(details[2]);

                EternalGoal goal = new EternalGoal(name, description, points);
                _goals.Add(goal);
            }
            else if (type == "ChecklistGoal")
            {
                string name = details[0];
                string description = details[1];
                int points = int.Parse(details[2]);
                int amountCompleted = int.Parse(details[3]);
                int target = int.Parse(details[4]);
                int bonus = int.Parse(details[5]);

                ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus);

                // Update progress
                for (int j = 0; j < amountCompleted; j++)
                {
                    goal.RecordEvent();
                }

                _goals.Add(goal);
            }
        }

        Console.WriteLine($"Goals loaded successfully from '{filename}'.");
    }
}