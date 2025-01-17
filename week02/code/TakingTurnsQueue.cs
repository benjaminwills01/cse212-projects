public class TakingTurnsQueue
{
    private readonly Queue<Person> _people = new();

    public int Length => _people.Count;

    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    public Person GetNextPerson()
    {
        if (_people.Count == 0)
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        var person = _people.Dequeue();

        if (person.Turns == 0 || person.Turns < 0) // Infinite turns
        {
            _people.Enqueue(person);
        }
        else if (person.Turns > 1) // Has remaining turns
        {
            person.Turns -= 1;
            _people.Enqueue(person);
        }

        return person;
    }

    public override string ToString()
    {
        return string.Join(", ", _people.Select(p => $"{p.Name} ({p.Turns})"));
    }
}
