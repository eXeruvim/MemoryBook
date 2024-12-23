
namespace MemoryBook.Models;


public class MemoryViewModel
{
    public string Title { get; set; }
    public List<MemoryPhoto> Photos { get; set; }
    public string Text { get; set; }
}

public class MemoryPhoto
{
    public string ImageUrl { get; set; }
    public string Caption { get; set; }
}


