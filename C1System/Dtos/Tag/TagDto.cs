namespace C1System.Dtos.Tag
{
    public class GetTagDto
    {
        public Guid TagId { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
    }

    public class AddUpdateTagDto
    {
        public string Title { get; set; }
        public string Link { get; set; }
    }
}
