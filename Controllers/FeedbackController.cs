using Microsoft.AspNetCore.Mvc;

using MemoryBook.Models;
using MemoryBook.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;

namespace MemoryBook.Controllers
{
    public class FeedbackController(IRepository<FeedbackMessage> repository, IWebHostEnvironment environment, ILogger<FeedbackController> logger) : Controller
    {
        private readonly IRepository<FeedbackMessage> _repository = repository;
        private readonly IWebHostEnvironment _environment = environment;
        private readonly ILogger<FeedbackController> _logger = logger;

        [HttpGet]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmSend(FeedbackViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    if (model.File == null)
                    {
                        ModelState.AddModelError("File", "Файл обязателен.");
                        return View("Index");
                    }

                    if (model.File != null && model.File.Length > 20 * 1024 * 1024)
                    {
                        ModelState.AddModelError("File", "Файл превышает допустимый размер (20 МБ)");
                        return View("Index");
                    }

                    if (model.File != null && model.File.Length > 0)
                    {
                        string[] allowedExtensions = [".rar", ".7z", ".tar", ".zip"];
                        var fileExtension = Path.GetExtension(model.File.FileName).ToLower();
                        if (!allowedExtensions.Contains(fileExtension))
                        {
                            ModelState.AddModelError("File", "Недопустимый формат файла.");
                            return View("Index");
                        }

                        var uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";
                        var uploadsFolder = Path.Combine(_environment.ContentRootPath, "App_Data", "Uploads");

                        if (!Directory.Exists(uploadsFolder)) Directory.CreateDirectory(uploadsFolder);

                        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        using (var stream = new FileStream(filePath, FileMode.Create)) await model.File.CopyToAsync(stream);

                        var feedback = new FeedbackMessage
                        {
                            Email = model.Email,
                            Msg = model.Message,
                            FilePath = filePath,
                            OriginalFileName = model.File.FileName,
                            SubmissionDate = DateTime.Now
                        };

                        await _repository.AddAsync(feedback);

                        TempData["SuccessMessage"] = "Успешно отправлено";
                        return View("Index");
                    }
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", $"Не удалось отправить обращение. Ошибка: {e.Message}");
                    _logger.LogError("Failed to confirm send-form: {e}", e);
                    return View("Index", model);

                }
            }

            TempData["ErrorMessage"] = "Не удалось отправить обращение";
            return View("Index");
        }
    }
}