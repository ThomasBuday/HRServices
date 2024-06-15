public interface IPeopleRepo    // Repository operations related to Person
{
    Person Create(Person person); // Create a new person
    List<Person> Read(); // Read all people
    Person Read(int id); // Read a person by ID
    bool Update(Person person); // Update a person's details
    bool Delete(int id); // Delete a person by ID
}