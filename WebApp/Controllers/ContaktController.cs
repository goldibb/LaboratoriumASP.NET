using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class ContaktController : Controller
{
    private static Dictionary<int, ContactModel> _contacts = new()
    {
        {1,new ContactModel
            {
                Id = 1,
                FirstName = "Adam",
                LastName = "Kozak",
                phoneNumber = "111 222 333",
                Birthday = new DateOnly(1980,1,1)
            }
            
        },
        {2,new ContactModel
        {
            Id = 2,
            FirstName = "Bartosz",
            LastName = "Luzak",
            phoneNumber = "222 333 444",
            Birthday = new DateOnly(2002,4,20)
        }},
        {3,new ContactModel
            {
            Id = 3,
            FirstName = "Bartosz",
            LastName = "Guzak",
            phoneNumber = "333 444 555",
            Birthday = new DateOnly(2003,4,20)
            }
        }
    };

    private static int _currentId = 3;
    
    // Lista kontaktów
    public IActionResult Index()
    {
        return View(_contacts);
    }
    // formularz dodania kontatku
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    
    //Odebranie danych z formularza, zapis kontaktu i powrót do listy kontaków
    [HttpPost]
    public IActionResult Add(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        model.Id = ++_currentId;
        _contacts.Add(model.Id, model);
        return View("Index",_contacts);
    }
}