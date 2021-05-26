namespace GroupMe.Models
{
    public class Group : DbItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }

        public string CreatorId { get; set; }
        public Profile Creator { get; set; }
    }

}