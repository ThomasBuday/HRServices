using System.ComponentModel.DataAnnotations;

public class CreatePersonViewModel  // Creating a new person
{
    [Required]
    public string Name { get; set; } // Name is required

    [Required]
    [Phone]
    public string PhoneNumber { get; set; } // Phone number is required and must be in phone format

    [Required]
    public string City { get; set; } // City is required
}