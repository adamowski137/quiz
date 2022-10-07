namespace backend.models
{
    public class Quiz
    {
        public int id { get; set; }
        public IEnumerable<Question>? questions { get; set; }
        public string? name { get; set; }
        public int user_id { get; set; }
    }
}
