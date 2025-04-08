public class ProgressGoal : Goal
{
    private int _currentProgress;
    private int _targetProgress;

    public ProgressGoal(string name, string description, int pointsPerUnit, int targetProgress)
        : base(name, description, pointsPerUnit)
    {
        _targetProgress = targetProgress;
        _currentProgress = 0;
    }

    public override int RecordEvent()
    {
        if (!IsComplete())
        {
            _currentProgress++;
            return _points;
        }
        return 0;
    }

    public override bool IsComplete()
    {
        return _currentProgress >= _targetProgress;
    }

    public override string GetStatus()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {_name} ({_description}) -- Progress: {_currentProgress}/{_targetProgress}";
    }

    public override string GetStringRepresentation()
    {
        return $"ProgressGoal:{_name}|{_description}|{_points}|{_currentProgress}|{_targetProgress}";
    }

    public static ProgressGoal FromString(string data)
    {
        var parts = data.Split('|');
        return new ProgressGoal(parts[0], parts[1], int.Parse(parts[2]), int.Parse(parts[4]))
        {
            _currentProgress = int.Parse(parts[3])
        };
    }
}
