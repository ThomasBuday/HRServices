public class PeopleService : IPeopleService     // Service with IPeopleService
{
    private readonly IPeopleRepo _peopleRepo;

    public PeopleService(IPeopleRepo peopleRepo)
    {
        _peopleRepo = peopleRepo;
    }

    public Person Add(CreatePersonViewModel personViewModel)
    {
        var person = new Person
        {
            Name = personViewModel.Name,
            PhoneNumber = personViewModel.PhoneNumber,
            City = personViewModel.City
        };
        return _peopleRepo.Create(person); // Create a new person
    }

    public List<Person> All()
    {
        return _peopleRepo.Read(); // Return all people
    }

    public List<Person> Search(string search, bool caseSensitive, bool exactMatch, bool searchByCity)
    {
        var people = _peopleRepo.Read();
        StringComparison comparison = caseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;

        List<Person> result = new List<Person>();

        foreach (var person in people)
        {
            bool match = false;

            if (searchByCity)
            {
                if (exactMatch)
                {
                    match = string.Equals(person.City, search, comparison); // Exact match for city
                }
                else
                {
                    match = person.City.IndexOf(search, comparison) >= 0; // Partial match for city
                }
            }
            else
            {
                if (exactMatch)
                {
                    match = string.Equals(person.Name, search, comparison); // Exact match for name
                }
                else
                {
                    match = person.Name.IndexOf(search, comparison) >= 0; // Partial match for name
                }
            }

            if (match)
            {
                result.Add(person); // Add matching person to result
            }
        }

        return result; // Return search results
    }

    public Person FindById(int id)
    {
        return _peopleRepo.Read(id); // Find and return person by ID
    }

    public bool Edit(int id, CreatePersonViewModel personViewModel)
    {
        var person = _peopleRepo.Read(id);
        if (person == null)
        {
            return false;
        }

        person.Name = personViewModel.Name;
        person.PhoneNumber = personViewModel.PhoneNumber;
        person.City = personViewModel.City;

        return _peopleRepo.Update(person); // Update person's details
    }

    public bool Remove(int id)
    {
        return _peopleRepo.Delete(id); // Delete person by ID
    }
}