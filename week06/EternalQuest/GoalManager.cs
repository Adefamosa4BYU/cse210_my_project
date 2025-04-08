public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void AddGoal(Goal goal) => _goals.Add(goal);

    public void RecordGoalEvent(int index)
    {
        int points = _goals[index].RecordEvent();
        Console.WriteLine($"You earned {points} points!");
        _score += points;
    }

    public void ShowGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            // Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()} {_goals[i]._name}");
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()} {_goals[i].Name}");
        }
    }

    public void ShowScore()
    {
        Console.WriteLine($"Current Score: {_score}");
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals(string filename)
    {
        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);
        _goals.Clear();

        foreach (string line in lines.Skip(1))
        {
            string[] parts = line.Split(":");
            string type = parts[0];
            string data = parts[1];

            switch (type)
            {
                case "SimpleGoal":
                    _goals.Add(SimpleGoal.FromString(data));
                    break;
                case "EternalGoal":
                    _goals.Add(EternalGoal.FromString(data));
                    break;
                case "ChecklistGoal":
                    _goals.Add(ChecklistGoal.FromString(data));
                    break;
                case "ProgressGoal":
                    _goals.Add(ProgressGoal.FromString(data));
                    break;
                case "NegativeGoal":
                    _goals.Add(NegativeGoal.FromString(data));
                    break;
            }
        }
    }
}
