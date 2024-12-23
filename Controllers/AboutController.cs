using Microsoft.AspNetCore.Mvc;

namespace MemoryBook.Controllers;

public class AboutController : Controller
{
    public IActionResult Index()
    {
        var viewModel = new AboutViewModel
        {
            ImageTitle = "Члены общественной редколлегии и рабочей группы Книги Памяти РК, 1991 г.",
            ProjectDescription = "Проект Книга памяти был инициирован для сохранения и передачи памяти о подвиге солдат СССР...",
            EditorialBoardMembers =
            [
                new() { FullName = "Иванов Иван Иванович", PhotoUrl = "/images/editorial1.jpg" },
                new() { FullName = "Петров Петр Петрович", PhotoUrl = "/images/editorial2.jpg" },
            ],
            ProjectObjectives =
            [
                new() { Icon = "fas fa-book", Description = "Сбор и каталогизация информации о участниках ВОВ" },
                new() { Icon = "fas fa-search", Description = "Изучение архивных данных и документов" },
                new() { Icon = "fas fa-globe", Description = "Общение с общественными организациями" }
            ],
            MediaLinks =
            [
                new() { Name = "Сайт Книги Памяти", Url = "https://www.kniha-pamiati.ru" },
                new() { Name = "Facebook группа", Url = "https://www.facebook.com/groups/kniha-pamiati" }
            ],
            SocialMediaWidget = "<div class='vk-subscribe'><a href='https://vk.com/bookmemory' class='vk-subscribe-link'>Подписаться на VK</a></div>",
            Acknowledgement = "Благодарим всех, кто участвовал в создании этого проекта.",
            Partners = ["Комитет по делам молодежи Республики Коми", "Музей Великой Отечественной войны", "Общественные организации"]
        };

        return View(viewModel);
    }
}
