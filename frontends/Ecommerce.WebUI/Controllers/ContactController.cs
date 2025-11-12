using Ecommerce.DtoLayer.CatalogDtos.ContactDtos;
using Ecommerce.WebUI.Services.CatalogServices.ContactServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Ecommerce.WebUI.Controllers
{
    
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            @ViewBag.directory1 = "Home Page";
            @ViewBag.directory2 = "Contact";
            @ViewBag.directory2 = "Send Message";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            createContactDto.IsRead = false;
            createContactDto.SendDate = DateTime.Now;
            await _contactService.CreateContactAsync(createContactDto);
            return RedirectToAction("Index", "Default");
          
        
           
        }
    }
}
