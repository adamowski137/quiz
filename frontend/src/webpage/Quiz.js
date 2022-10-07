import React from "react";
import { useState, useEffect } from "react";
import { useParams } from 'react-router-dom';

import "./Quiz.css";

import QuestionCard from "../components/QuestionCard";

function Quiz(){

    const {id} = useParams();

    const [questions, setQuestions] = useState([]);
    const [current, setCurrent] = useState(1);
    const [IsLoading, SetLoading] = useState(true);


     
    const getData = () =>{
        fetch('http://localhost:5126/Quiz/', 
        {
            method: 'GET',    
            headers: {
            'Content-Type': 'application/json',
            'user_id': 1,
            'id': Number(id)
            }
        })
            .then((res) => res.json())
            .then((res) => {
                setQuestions(res);
                SetLoading(false);
            })
    }

    useEffect(() => {
        getData();
    }, [])
    

    console.log(questions);

    if (IsLoading) {
        return <div>Loading...</div>;
    }
    
    return(
        <div className="quiz">
            <div className="quiz-title-container">
                <h1 className="quiz-title">{questions.name}</h1>
            </div>
            <div className="quiz-container">
                <QuestionCard question={questions.questions[current]}/>
            </div>
        </div>
    )
}

export default Quiz;