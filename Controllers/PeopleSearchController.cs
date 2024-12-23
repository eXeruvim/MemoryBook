using MemoryBook.Models;
using MemoryBook.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MemoryBook.Controllers
{
    public class PeopleSearchController(IRepository<MemBook> repository, ILogger<PeopleSearchController> logger) : Controller
    {
        private readonly IRepository<MemBook> _repository = repository;
        private readonly ILogger<PeopleSearchController> _logger = logger;

        public async Task<IActionResult> Index(int? page)
        {
            try
            {
                _logger.LogInformation("Запрос на получение всех героев.");

                var heroes = await _repository.GetAllAsync();

                if (heroes == null)
                {
                    _logger.LogWarning("Метод GetAllAsync() вернул null.");
                }
                else
                {
                    _logger.LogInformation("Получено {HeroCount} героев.", heroes.Count());
                }

                heroes ??= [];

                _logger.LogInformation("Количество героев после инициализации: {HeroCount}", heroes.Count());

                var model = new PeopleSearchViewModel
                {
                    Heroes = heroes
                };
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка при получении данных героев.");
                TempData["ErrorMessage"] = "Произошла ошибка при загрузке данных. Пожалуйста, попробуйте снова.";
                return View();
            }
        }

        // [HttpGet]
        // public async Task<IActionResult> Search(PeopleSearchViewModel model)
        // {
        //     Expression<Func<MemBook, bool>> searchPredicate = hero =>
        //         (string.IsNullOrEmpty(model.LastName) || (hero.Family != null && hero.Family.Contains(model.LastName))) &&
        //         (string.IsNullOrEmpty(model.FirstName) || (hero.Name != null && hero.Name.Contains(model.FirstName))) &&
        //         (string.IsNullOrEmpty(model.MiddleName) || (hero.MiddleName != null && hero.MiddleName.Contains(model.MiddleName))) &&
        //         (string.IsNullOrEmpty(model.BirthPlace) || (hero.BirthPlace != null && hero.BirthPlace.Contains(model.BirthPlace))) &&
        //         (string.IsNullOrEmpty(model.ConscriptionPlace) || (hero.DraftPlace != null && hero.DraftPlace.Contains(model.ConscriptionPlace))) &&
        //         (string.IsNullOrEmpty(model.Rank) || (hero.Rank != null && hero.Rank.Contains(model.Rank))) &&
        //         (model.DeathDate == null || (hero.DateDeath != null && hero.DateDeath == model.DeathDate.ToString())) &&
        //         (string.IsNullOrEmpty(model.BurialPlace) || (hero.GravePlace != null && hero.GravePlace.Contains(model.BurialPlace))) &&
        //         (string.IsNullOrEmpty(model.DischargePlace) || (hero.PlaceOut != null && hero.PlaceOut.Contains(model.DischargePlace))) &&
        //         (string.IsNullOrEmpty(model.ReburialFrom) || (hero.FromGrave != null && hero.FromGrave.Contains(model.ReburialFrom))) &&
        //         (string.IsNullOrEmpty(model.CapturePlace) || (hero.Camp != null && hero.Camp.Contains(model.CapturePlace)));

        //     // Проверка на NULL, чтобы избежать SqlNullValueException
        //     var heroes = await _repository.FindAsync(searchPredicate);
        //     heroes ??= [];

        //     var resultModel = new PeopleSearchViewModel
        //     {
        //         Heroes = heroes
        //     };
        //     return View("Index", resultModel);

        // }
    }
}
