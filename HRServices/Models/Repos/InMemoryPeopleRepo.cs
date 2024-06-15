public class InMemoryPeopleRepo : IPeopleRepo   // Implementation of the IPeopleRepo interface
{
    private static List<Person> _people = new List<Person>(); // Static list to store people
    private static int _idCounter = 1; // Static counter for generating unique IDs

    public Person Create(Person person)
    {
        person.Id = _idCounter++; // Assign a unique ID to the new person
        _people.Add(person); // Add the person to the list
        return person;
    }

    public List<Person> Read()
    {
        return _people; // Return all people
    }

    public Person Read(int id)
    {
        return _people.FirstOrDefault(p => p.Id == id); // Find and return person by ID
    }

    public bool Update(Person person)
    {
        var existingPerson = Read(person.Id); // Find the existing person
        if (existingPerson == null) return false;

        existingPerson.Name = person.Name; // Update details
        existingPerson.PhoneNumber = person.PhoneNumber;
        existingPerson.City = person.City;
        return true;
    }

    public bool Delete(int id)
    {
        var person = Read(id); // Find the person by ID
        return person != null && _people.Remove(person); // Remove the person if found
    }
}