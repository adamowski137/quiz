using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using backend.models;


namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuizController : ControllerBase
    {

        private readonly ILogger<QuizController> _logger;
        private MySqlConnection _connection;

        public QuizController(ILogger<QuizController> logger)
        {
            _logger = logger;
            _connection = new MySqlConnection("server=localhost;port=3306; user=root;password=PASSWORD;database=quiz");

        }

        [HttpGet("")]
        public IEnumerable<Quiz> GetUserQuiz([FromHeader(Name = "user_id")] int user)
        {
            _connection.Open();
            MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM quizzes WHERE id = user_id");
            MySqlDataReader reader = mySqlCommand.ExecuteReader();

            List<Quiz> quizzes = new List<Quiz>();

            while (reader.Read())
            {
                Quiz quiz = new Quiz();
                quiz.id = Convert.ToInt32(reader["id"]);
                quiz.name = Convert.ToString(reader["name"]);
                quiz.user_id = Convert.ToInt32(reader["user_id"]);
                quizzes.Add(quiz);
            }

            return quizzes.ToArray();
        }

        [HttpGet("Questions")]
        public Quiz GetQuestions([FromHeader(Name="user_id")] int user_id, [FromHeader(Name = "id")] int id)
        {
            _connection.Open();
            Quiz quiz = new Quiz();
            List<Question> questions = new List<Question>();
            MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM questions WHERE quiz_id = " + id, _connection);
            MySqlDataReader reader = mySqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Question question = new Question();
                question.id = Convert.ToInt32(reader["id"]);
                question.question = Convert.ToString(reader["question"]);
                question.anwser = Convert.ToString(reader["anwser"]);
                question.quiz_id = Convert.ToInt32(reader["quiz_id"]);

                questions.Add(question);
            }
            reader.Close();

            mySqlCommand = new MySqlCommand("SELECT * FROM quizzes WHERE id = " + id, _connection);

            reader = mySqlCommand.ExecuteReader();

            while (reader.Read())
            {
                quiz.name = Convert.ToString(reader["name"]);
            }

            quiz.questions = questions.ToArray();
            quiz.user_id = Convert.ToInt32(user_id);
            quiz.id = Convert.ToInt32(id);

            _connection.Close();

            return quiz;
        }
    }
}