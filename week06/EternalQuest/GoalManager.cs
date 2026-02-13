using System;
using System.Collections.Generic;
using System.IO;

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
            else
            {
                Console.WriteLine("Please enter a valid number.");
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
            Console.WriteLine($"{i + 1}. {_goals[i].ShortName}"); // note: _shortName is protected but this class is same assembly - if needed change getter
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
        if (!int.TryParse(Console.ReadLine(), out int points))
        {
            Console.WriteLine("Invalid points. Using 0.");
            points = 0;
        }

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
                if (!int.TryParse(Console.ReadLine(), out int target))
                {
                    Console.WriteLine("Invalid target. Using 1.");
                    target = 1;
                }
                Console.Write("Enter bonus points: ");
                if (!int.TryParse(Console.ReadLine(), out int bonus))
                {
                    Console.WriteLine("Invalid bonus. Using 0.");
                    bonus = 0;
                }
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available. Create a goal first.");
            return;
        }

        Console.WriteLine("\nWhich goal did you accomplish?");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        Console.Write("Enter the number of the goal: ");
        if (!int.TryParse(Console.ReadLine(), out int index))
        {
            Console.WriteLine("Invalid number.");
            return;
        }

        index = index - 1;

        if (index >= 0 && index < _goals.Count)
        {
            int earned = _goals[index].RecordEvent();
            _score += earned;
            Console.WriteLine($"Event recorded! You earned {earned} points. Total: {_score}");
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

        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                // 1. Save the total score (line 1)
                outputFile.WriteLine(_score);

                // 2. Save each goal (one line per goal)
                foreach (Goal g in _goals)
                {
                    outputFile.WriteLine(g.GetStringRepresentation());
                }
            }

            Console.WriteLine($"Goals saved successfully to '{filename}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
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

        try
        {
            string[] lines = File.ReadAllLines(filename);

            if (lines.Length == 0)
            {
                Console.WriteLine("File is empty.");
                return;
            }

            _goals.Clear();

            // First line = score
            if (!int.TryParse(lines[0], out _score))
            {
                Console.WriteLine("Invalid score in file; setting score to 0.");
                _score = 0;
            }

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                if (string.IsNullOrEmpty(line)) continue;

                int colon = line.IndexOf(':');
                if (colon < 0)
                {
                    Console.WriteLine($"Skipping invalid line (no type): {line}");
                    continue;
                }

                string type = line.Substring(0, colon);
                string data = line.Substring(colon + 1);
                string[] parts = data.Split(',');

                try
                {
                    if (type == "SimpleGoal")
                    {
                        // Expect: Name,Description,Points,IsComplete
                        string name = parts[0];
                        string description = parts[1];
                        int points = int.Parse(parts[2]);
                        bool isComplete = bool.Parse(parts[3]);

                        SimpleGoal sg = new SimpleGoal(name, description, points, isComplete);
                        _goals.Add(sg);
                    }
                    else if (type == "EternalGoal")
                    {
                        // Expect: Name,Description,Points
                        string name = parts[0];
                        string description = parts[1];
                        int points = int.Parse(parts[2]);

                        EternalGoal eg = new EternalGoal(name, description, points);
                        _goals.Add(eg);
                    }
                    else if (type == "ChecklistGoal")
                    {
                        // Expect: Name,Description,Points,AmountCompleted,Target,Bonus
                        string name = parts[0];
                        string description = parts[1];
                        int points = int.Parse(parts[2]);
                        int amountCompleted = int.Parse(parts[3]);
                        int target = int.Parse(parts[4]);
                        int bonus = int.Parse(parts[5]);

                        ChecklistGoal cg = new ChecklistGoal(name, description, points, amountCompleted, target, bonus);
                        _goals.Add(cg);
                    }
                    else
                    {
                        Console.WriteLine($"Unknown goal type '{type}' on line: {line}");
                    }
                }
                catch (Exception exLine)
                {
                    Console.WriteLine($"Failed to parse line: {line}  —  {exLine.Message}");
                }
            }

            Console.WriteLine($"Goals loaded successfully from '{filename}'. Current score: {_score}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
    }
}