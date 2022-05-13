namespace C1System.Dtos.Project
{
    public class GetProjectDto
    {
        public Guid ProjectId { get; set; }
        public string Picture { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Desc { get; set; }
        public bool IsDelete { get; set; }
        public string Media { get; set; }
    }
    public class AddUpdateProjectDto
    {
        public string Picture { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Desc { get; set; }
        public bool IsDelete { get; set; }
        public string Media { get; set; }
    }

}
