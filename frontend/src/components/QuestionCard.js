import './QuestionCard.css';
import {useState} from "react";


function QuestionCard({question}){

    const [showAnwser, setShowAnwser] = useState(false);

    const handleCardClick = () => {
        setShowAnwser(!showAnwser);
        console.log(showAnwser);
    }

    function Content(){
        if(!showAnwser){
            return(
                <div className="question-card-question">
                    <h3>{question.question}</h3>
                </div>
            )
        }
        else return(
            <div className="question-card-anwser">
                <h3>{question.anwser}</h3>
            </div>
        )
    }

    return(
        <div className="question-card" onClick={handleCardClick}>
            <Content />
        </div>
    )
}

export default QuestionCard;