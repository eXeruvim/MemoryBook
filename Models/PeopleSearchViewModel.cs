namespace MemoryBook.Models
{
    public class PeopleSearchViewModel
    {
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? BirthPlace { get; set; }
        public string? ConscriptionPlace { get; set; }
        public string? Rank { get; set; }
        public DateTime? DeathDate { get; set; }
        public string? BurialPlace { get; set; }
        public string? DischargePlace { get; set; }
        public string? ReburialFrom { get; set; }
        public string? CapturePlace { get; set; }

        // Результаты поиска
        public IEnumerable<MemBook>? Heroes { get; set; }
    }
}