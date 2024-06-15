using Microsoft.AspNetCore.Mvc;
public class PeopleController : Controller
{
    private readonly IPeopleService _peopleService;

    public PeopleController(IPeopleService peopleService)
    {
        _peopleService = peopleService;
    }

    public IActionResult Index(string search, bool caseSensitive = false, bool exactMatch = false, bool searchByCity = false, string sortOrder = "")
    {
        var people = string.IsNullOrEmpty(search)   // Get people based on search settings
        ? _peopleService.All() : _peopleService.Search(search, caseSensitive, exactMatch, searchByCity);

        switch (sortOrder)  // Sort people based on sortOrder
        {
            case "name_asc":
                people = people.OrderBy(p => p.Name).ToList();
                break;
            case "name_desc":
                people = people.OrderByDescending(p => p.Name).ToList();
                break;
            case "city_asc":
                people = people.OrderBy(p => p.City).ToList();
                break;
            case "city_desc":
                people = people.OrderByDescending(p => p.City).ToList();
                break;
        }

        var peopleViewModel = new PeopleViewModel   // Prepare the view model
        {
            People = people,
            SearchTerm = search,
            CaseSensitive = caseSensitive,
            ExactMatch = exactMatch,
            SearchByCity = searchByCity
        };

        return View(peopleViewModel); // Return view with model
    }

    public IActionResult Details(int id)
    {
        var person = _peopleService.FindById(id); // Find person by ID
        if (person == null) return NotFound();
        return View(person); // Return details view
    }

    public IActionResult Create()
    {
        return View(); // Return create view
    }

    [HttpPost]
    public IActionResult Create(CreatePersonViewModel model)
    {
        _peopleService.Add(model); // Add new person
        return RedirectToAction("Index"); // Redirect to index
    }

    public IActionResult Delete(int id)
    {
        var person = _peopleService.FindById(id); // Find person by ID
        if (person == null) return NotFound();
        _peopleService.Remove(id); // Remove person
        return RedirectToAction("Index"); // Redirect to index
    }
}