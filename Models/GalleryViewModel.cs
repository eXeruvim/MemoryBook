namespace MemoryBook.Models;

public class GalleryImage
{
    public required string Url { get; set; }
    public string? Description { get; set; }
}

public class GalleryViewModel
{
    public List<string> Categories { get; set; }
    public string Category { get; set; }
    public List<GalleryImage> Images { get; set; }

    public GalleryViewModel()
    {
        Categories =
        [
            "Фотографии военных лет",
            "Документы военных лет"
        ];
        Category = Categories.First();
        Images = [];
    }
}
