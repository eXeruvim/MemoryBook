using MemoryBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace MemoryBook.Controllers;
public class GalleryController : Controller
{
    public IActionResult Index(string category)
    {
        var model = new GalleryViewModel();

        if (!string.IsNullOrEmpty(category) && model.Categories.Contains(category))
        {
            model.Category = category;
        }

        model.Images = GetImagesForCategory(model.Category);


        return View(model);
    }

    private List<GalleryImage> GetImagesForCategory(string category)
    {
        return category switch
        {
            "Фотографии военных лет" => new List<GalleryImage>
        {
            new() { Url = "/images/war1.jpg", Description = "Солдат в окопе, 1941 год" },
            new() { Url = "/images/war2.jpg", Description = "Группа бойцов, фронтовая линия" },
            new() { Url = "/images/war3.jpg", Description = "Парад Победы, Москва, 1945" }
        },
            "Документы военных лет" => new List<GalleryImage>
        {
            new() { Url = "/images/doc1.jpg", Description = "Письмо с фронта" },
            new() { Url = "/images/doc2.jpg", Description = "Боевой приказ" },
            new() { Url = "/images/doc3.jpg", Description = "Архивная карта боевых действий" }
        },
            _ => []
        };
    }

}
