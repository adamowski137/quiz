import './QuestionCard.css';

function QuestionCard({question}){
    return(
        <div className="question-card">
            <div className="question-card-question">
                <h3>{question.question}</h3>
            </div>
            {/* <div className="question-card-anwser">
                <h3>{question.anwser}</h3>
            </div> */}
        </div>
    )
}

export default QuestionCard;