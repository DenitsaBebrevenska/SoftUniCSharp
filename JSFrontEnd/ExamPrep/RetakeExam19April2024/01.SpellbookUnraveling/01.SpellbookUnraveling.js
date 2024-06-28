function solve(commandArray){

    let getEvenPositions = function(word){
        let newWord = '';

        for(let i = 0; i < word.length; i += 2){
            newWord += word[i];
        }

        return newWord;
    };

    let spell = commandArray.shift();
    let currentAction = commandArray.shift();

    while(currentAction !== 'End'){
        
        if(currentAction === 'RemoveEven'){
            spell = getEvenPositions(spell);
            console.log(spell);
        } else if (currentAction.includes('TakePart')){
            let tokens = currentAction.split('!');
            spell = spell.slice(Number(tokens[1]), Number(tokens[2]));
            console.log(spell);
        } else {
            let tokens = currentAction.split('!');
            let searchedPart = tokens[1];
            
            if(spell.includes(searchedPart)){
                spell = spell.replace(searchedPart, Array.from(searchedPart).reverse().join(''))
                console.log(spell);
            } else {
                console.log('Error');
            }
        }

        currentAction = commandArray.shift();
    }

    console.log(`The concealed spell is: ${spell}`);
}

solve(["hZwemtroiui5tfone1haGnanbvcaploL2u2a2n2i2m", 
    "TakePart!31!42",
    "RemoveEven",
    "Reverse!anim",
    "Reverse!sad",
    "End"]);