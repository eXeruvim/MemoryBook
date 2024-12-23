using MemoryBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace MemoryBook.Controllers;

public class MemoryController : Controller
{
    public IActionResult Locations()
    {
        var viewModel = new MemoryViewModel
        {
            Title = "Граждане Коми АССР на фронтах Великой Отечественной",
            Photos = new List<MemoryPhoto>
            {
                new MemoryPhoto { ImageUrl = "path_to_photo1.jpg", Caption = "Описание фотографии 1" },
                new MemoryPhoto { ImageUrl = "path_to_photo2.jpg", Caption = "Описание фотографии 2" },
                new MemoryPhoto { ImageUrl = "path_to_photo3.jpg", Caption = "Описание фотографии 3" }
            },
            Text = "Здесь можно дополнить текстом о гражданах Коми АССР на фронтах Великой Отечественной войны, их истории и значении для победы."
        };
        return View(viewModel);
    }

    public IActionResult FrontlineActivity()
    {
        var viewModel = new MemoryViewModel
        {
            Title = "Фронтовая активность граждан Коми АССР",
            Photos = new List<MemoryPhoto>
            {
                new MemoryPhoto { ImageUrl = "path_to_frontline_photo1.jpg", Caption = "Описание фронтовой фотографии 1" },
                new MemoryPhoto { ImageUrl = "path_to_frontline_photo2.jpg", Caption = "Описание фронтовой фотографии 2" },
                new MemoryPhoto { ImageUrl = "path_to_frontline_photo3.jpg", Caption = "Описание фронтовой фотографии 3" }
            },
            Text = "Здесь можно рассказать о деятельности граждан Коми на фронтах Великой Отечественной войны, их ролях и значении в боевых действиях."
        };
        return View(viewModel);
    }

    public IActionResult LaborInRear()
    {
        var viewModel = new MemoryViewModel
        {
            Title = "Трудовые и боевые усилия на тыловом фронте",
            Photos = new List<MemoryPhoto>
            {
                new MemoryPhoto { ImageUrl = "path_to_homefront_photo1.jpg", Caption = "Описание тыловой фотографии 1" },
                new MemoryPhoto { ImageUrl = "path_to_homefront_photo2.jpg", Caption = "Описание тыловой фотографии 2" },
                new MemoryPhoto { ImageUrl = "path_to_homefront_photo3.jpg", Caption = "Описание тыловой фотографии 3" }
            },
            Text = "Здесь можно рассказать о трудовых и боевых усилиях граждан Коми на тыловом фронте, их вкладе в поддержание экономики и войска."
        };
        return View(viewModel);
    }
}