import React, { useEffect, useState } from 'react';
import styled from 'styled-components';
import OneTraining from './OneTraining';
import IconButton from '@mui/material/IconButton';
import Info from '@mui/icons-material/Info';
import Edit from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import { indigo } from '@mui/material/colors';

const TrainingDayContainer = styled.div`
    width: 14%;
    max-width: calc(100% / 7);
    overflow: hidden;
    border: 0px;
    flex: 1 0 14%;
`;

const TrainingDayDiv = styled.div`
    height: 100%;
    display: flex;
    flex-direction: column;
    margin: 4px;
    height: 340px;
    border-radius: 10px;
    background: ${indigo[400]};
    overflow: hidden;
    border: 0px;
`;


const TopIconDiv = styled.div`
    ${props => props.visibility ? '' : 'visibility: collapse;'};
    height: 10%;
    justify-content: flex-end;
    background: ${indigo[500]};
    display: flex;
`;

const TrainingDayContentDiv = styled.div`
   ${props => props.hover ? 'height: 90%;' : 'height: 100%;'};
    display: flex;
    flex-direction: column;
    align-items: stretch;
`;


export const TrainingDay = ({trainingDay}) => {
    const [hover, setHover] = useState(false);
    useEffect(() => {
      }, []);

    const onMouseEnter = () => {
        setHover(true);
    };

    const onMouseLeave = () => {
        setHover(false);
    };

    return (<TrainingDayContainer onMouseEnter={onMouseEnter} onMouseLeave={onMouseLeave}>
        <TrainingDayDiv>
        <TopIconDiv visibility={hover}>
            <IconButton aria-label="delete" color="primary">
                <Info fontSize="small" />
            </IconButton>
            <IconButton aria-label="delete" color="primary">
                <DeleteIcon fontSize="small" />
            </IconButton>
            <IconButton aria-label="edit" color="primary">
                <Edit fontSize="small" />
            </IconButton>
        </TopIconDiv>
        <TrainingDayContentDiv hover={hover}>
        {trainingDay.trainings.map((training, i ) => {
                return <OneTraining training={training} key={i}/>
                }
            )}
        </TrainingDayContentDiv>
        </TrainingDayDiv>
    </TrainingDayContainer>);
};

export default TrainingDay;