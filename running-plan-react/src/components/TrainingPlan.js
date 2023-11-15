import React, { useEffect, useState } from 'react';
import axios from "axios";
import styled from 'styled-components';
import TrainingDay from './TrainingDay';

const TrainingPlanDiv = styled.div`
 width: 100%;
 height: 100%;
`;

const TrainingTable = styled.div`
 width: 100%;
 height: 100%;
 background: transparent;
 display: flex;
 flex-wrap: wrap;
`;

const baseURL = "https://localhost:7292/getPlan"

export const TrainingPlan = () => {
    const [post, setPost] = useState(null);
    const [trainingDaysLenght, setTrainingDaysLenght] = useState(0);
    const [error, setError] = useState(null);

    useEffect(() => {
        axios.get(baseURL).then((response) => {
          setPost(response.data);
          console.log(response.data.trainingDays);
          console.log(response.data.trainingDays.length);
          setTrainingDaysLenght(response.data.trainingDays.length);
        }).catch(error => {
            setError(error);
          });
      }, []);

      if (!post) return null;

      if (error) return "Error!";

    return (
    <TrainingPlanDiv>
        <TrainingTable>
            {post.trainingDays.map((trainingDay, i ) => {
                return <TrainingDay trainingDay={trainingDay} key={i}/>
                }
            )}
        </TrainingTable>
    </TrainingPlanDiv>);
};

export default TrainingPlan;