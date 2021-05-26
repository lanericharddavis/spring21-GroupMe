namespace GroupMe.Models
{
    public class GroupMember : DbItem
    {
        public string AccountId { get; set; }
        public int GroupId { get; set; }
        public string Role { get; set; } = "member";
    }


}