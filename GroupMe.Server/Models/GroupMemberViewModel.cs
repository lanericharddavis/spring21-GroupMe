namespace GroupMe.Models
{
    public class GroupMemberViewModel : Profile
    {
        public string AccountId { get; set; }
        public int GroupId { get; set; }
        public string Role { get; set; } = "member";
    }


}