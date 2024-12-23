public class AboutViewModel
{
    public string ImageTitle { get; set; }
    public string ProjectDescription { get; set; }
    public List<Member> EditorialBoardMembers { get; set; }
    public List<Objective> ProjectObjectives { get; set; }
    public List<MediaLink> MediaLinks { get; set; }
    public string SocialMediaWidget { get; set; }
    public string Acknowledgement { get; set; }
    public List<string> Partners { get; set; }
}

public class Member
{
    public string FullName { get; set; }
    public string PhotoUrl { get; set; }
}

public class Objective
{
    public string Icon { get; set; }
    public string Description { get; set; }
}

public class MediaLink
{
    public string Name { get; set; }
    public string Url { get; set; }
}
