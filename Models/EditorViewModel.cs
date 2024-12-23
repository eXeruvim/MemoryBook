using System.Collections.Generic;

namespace MemoryBook.Models
{
    public class EditorViewModel
    {
        public List<Member> Members { get; set; }
    }

    public class Member
    {
        public string Position { get; set; }
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
    }
}
