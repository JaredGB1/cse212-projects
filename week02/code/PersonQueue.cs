/// <summary>
/// A basic implementation of a Queue
/// </summary>
public class PersonQueue
{
    private readonly List<Person> _queue = new();

    public int Length => _queue.Count;

    /// <summary>
    /// Add a person to the queue
    /// </summary>
    /// <param name="person">The person to add</param>
    public void Enqueue(Person person)
    {
        //Checking if the queue has a person
        if (_queue.Count == 0)
        {
            _queue.Insert(0, person); //If the queue doesn't have a person, add the person to the first index
        }
        else
        {
            _queue.Insert(_queue.Count, person);//If the queue has an item, the person is added to the end of the queue.
        }
    }

    public Person Dequeue()
    {
        var person = _queue[0];
        _queue.RemoveAt(0);
        return person;
    }

    public bool IsEmpty()
    {
        return Length == 0;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}