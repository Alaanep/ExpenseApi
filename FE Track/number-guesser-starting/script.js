let humanScore = 0;
let computerScore = 0;
let currentRoundNumber = 1;

// Write your code below:

const generateTarget = ()=> Math.floor(Math.random()*10);

const compareGuesses = (human, computer, target)=>{
    const humanGuessDiff = getAbsoluteDistance(target, human);
    const computerGuessDiff = getAbsoluteDistance(target, computer);
    if(humanGuessDiff===computerGuessDiff) return true;
    else if(humanGuessDiff>computerGuessDiff) return false;
    else if(humanGuessDiff<computerGuessDiff) return true;
}

const getAbsoluteDistance = (target, guess)=>Math.abs(target-guess);

const updateScore=(winner)=>{
    if(winner==="human") humanScore++;
    else if(winner==="computer") computerScore++;
}

const advanceRound = ()=> {currentRoundNumber++;}


