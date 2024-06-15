public interface IPeopleService     // Interface for People service operations
{
    Person Add(CreatePersonViewModel person); // Add a new person
    List<Person> All(); // Get all people
    List<Person> Search(string search, bool caseSensitive, bool exactMatch, bool searchByCity); // Search people
    Person FindById(int id); // Find a person by ID
    bool Edit(int id, CreatePersonViewModel person); // Edit a person's details
    bool Remove(int id); // Remove a person by ID
}