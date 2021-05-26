namespace GroupMe.Models
{
  public class Comment : DbItem
  {
    public string Body { get; set; } = "";

    public int GroupId { get; set; }
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }
  }
}