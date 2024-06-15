public class PeopleViewModel    // ViewModel for displaying a list of people and search/filter options
{
    public List<Person> People { get; set; } // List of people to display
    public string SearchTerm { get; set; } // Search term for filtering
    public bool CaseSensitive { get; set; } // Case-sensitive search
    public bool ExactMatch { get; set; } // Exact match search
    public bool SearchByCity { get; set; } // Searching by city instead of name
}