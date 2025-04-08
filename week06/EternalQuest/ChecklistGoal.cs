public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _currentCount = 0;
    }

    public override int RecordEvent()
    {
        if (_currentCount < _targetCount)
        {
            _currentCount++;
            if (_currentCount == _targetCount)
                return _points + _bonus;
            return _points;
        }
        return 0;
    }

    public override bool IsComplete() => _currentCount >= _targetCount;

    public override string GetStatus() => $"[{_currentCount}/{_targetCount}]";

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_name},{_description},{_points},{_bonus},{_targetCount},{_currentCount}";
    }

    public static ChecklistGoal FromString(string data)
    {
        var parts = data.Split(',');
        return new ChecklistGoal(parts[0], parts[1], int.Parse(parts[2]), int.Parse(parts[4]), int.Parse(parts[3]))
        {
            _currentCount = int.Parse(parts[5])
        };
    }
}
