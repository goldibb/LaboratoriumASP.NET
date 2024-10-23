using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Models;

public class ContactModel
{
    [HiddenInput]
    public int Id{ get; set; }
    [Required(ErrorMessage = "First name is required")]
    [MaxLength(length: 20, ErrorMessage = "First name cannot be longer than 20 characters")]
    [MinLength(length: 2, ErrorMessage = "First name cannot be less than 2 characters")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Last name is required")]
    [MaxLength(length: 50, ErrorMessage = "Last name cannot be longer than 50 characters")]
    [MinLength(length: 2, ErrorMessage = "Last name cannot be less than 2 characters")]
    public string LastName { get; set; }
    
    [EmailAddress]
    public string Email { get; set; }
    
    [Phone]
    [RegularExpression("\\d{3} \\d{3}\\d{3}",ErrorMessage = "Wpisz numer według wzoru XXX XXX XXX")]
    public string phoneNumber { get; set; }
    
    [DataType(DataType.Date)]
    public DateOnly Birthday { get; set; }
    
}