import React, { useEffect, useState } from 'react';
import styled from 'styled-components';
import IconButton from '@mui/material/IconButton';
import DeleteIcon from '@mui/icons-material/Delete';
import Edit from '@mui/icons-material/Edit';
import AddReaction from '@mui/icons-material/AddReaction';
import { indigo } from '@mui/material/colors';


//SentimentNeutral, SentimentSatisfied, SentimentSatisfiedAlt, SentimentVerySatisfied,
//SentimentDissatisfied, SentimentVeryDissatisfied

const OneTrainingDiv = styled.div`
 width: 100%;
 flex: 1 0;
 flex-grow: 3;
`;

const OneTrainingBorder = styled.div`
 border-radius: 10px;
 height: calc(100% - 5px);
 margin: 4px;
 border: 2px solid;
 border-color: ${indigo[300]};
`;

const TopIconDiv = styled.div`
    ${props => props.visibility ? '' : 'visibility: collapse;'};
    justify-content: flex-end;
    background: ${indigo[500]};
    display: flex;
`;

export const TrainingDay = ({training}) => {
  const [hover, setHover] = useState(false);

    const onMouseEnter = () => {
        setHover(true);
    };

    const onMouseLeave = () => {
        setHover(false);
    };
    useEffect(() => {
      }, []);
    return (<OneTrainingDiv>
        <OneTrainingBorder onMouseEnter={onMouseEnter} onMouseLeave={onMouseLeave}>
        <div>{training.name}</div>
        <div>{training.description}</div>

      <TopIconDiv visibility={hover}>
        <IconButton fontSize="medium" aria-label="addReaction" disabled color="primary">
        <AddReaction fontSize="medium" />
      </IconButton>
      <IconButton fontSize="small" aria-label="edit" disabled color="primary">
        <Edit  fontSize="small" />
      </IconButton>
      <IconButton fontSize="small" aria-label="delete" disabled color="primary">
        <DeleteIcon  fontSize="small" />
      </IconButton>
      </TopIconDiv>

      </OneTrainingBorder>
    </OneTrainingDiv>);
};

export default TrainingDay;