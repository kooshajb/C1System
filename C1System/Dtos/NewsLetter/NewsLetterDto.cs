namespace C1System.Dtos.NewsLetter
{
   public class GetNewsLetterDto
    {
        public Guid NewsLetterId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }

    public class AddUpdateNewsLetterDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
    }

}
