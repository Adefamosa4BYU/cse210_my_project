public class NegativeGoal : Goal
{
    private int _penaltyPoints;
    private int _failCount;

    public NegativeGoal(string name, string description, int penaltyPoints)
        : base(name, description, 0)
    {
        _penaltyPoints = penaltyPoints;
        _failCount = 0;
    }

    public override int RecordEvent()
    {
        _failCount++;
        return -_penaltyPoints;
    }

    public override bool IsComplete()
    {
        return false; // Negative goals are ongoing
    }

    public override string GetStatus()
    {
        return $"[!] {_name} ({_description}) -- Failures: {_failCount}";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{_name}|{_description}|{_penaltyPoints}|{_failCount}";
    }

    public static NegativeGoal FromString(string data)
    {
        var parts = data.Split('|');
        return new NegativeGoal(parts[0], parts[1], int.Parse(parts[2]))
        {
            _failCount = int.Parse(parts[3])
        };
    }
}
