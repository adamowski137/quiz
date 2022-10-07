namespace backend.models
{
    public class Question
    {
        public int id { get; set; }
        public string? question { get; set; }
        public string? anwser { get; set; }
        public int quiz_id { get; set; }
    }
}
