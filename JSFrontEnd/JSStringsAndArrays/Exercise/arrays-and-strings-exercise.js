//1. Array Rotation
function rotateArray(array, rotateCount){

    for(let i = 0; i < rotateCount; i++){
        let firstElement = array.shift();
        array.push(firstElement);
    }

    console.log(array.join(' '));
}

//rotateArray([32, 21, 61, 1], 4);

//2. Print every N-th Element from an Array
function getEveryNthElement(array, step){
    let newArray = [];
    for(let i = 0; i < array.length; i += step){
        newArray.push(array[i]);
    }
    
    return newArray;
}

//getEveryNthElement(['5', '20', '31', '4', '20'], 2);

//3. List Of Names
function printSortedNames(names){
    names.sort((a, b) => a.localeCompare(b));
    let count = 1;
    names.forEach(name => console.log(`${count++}.${name}`));
}

//printSortedNames(["John", "Bob", "Christina", "Ema"]);

//4. Sorting Numbers
function sortNumbers(numbers){
    numbers.sort((a, b) => a - b);
    let sortedArray = [];

    for(let i = 0; i < numbers.length / 2; i++){
        sortedArray.push(numbers[i]);
        sortedArray.push(numbers[numbers.length - i - 1]);
    }

    if(numbers.length % 2 !== 0){
        sortedArray.pop();
    }

    return sortedArray;
}

//sortNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18]);

//5. Reveal Words
function revealWords(words, text){
    let wordsArray = words.split(', ');
    let textArray = text.split(' ');

    for(let i = 0; i < textArray.length; i++){

        if(textArray[i].startsWith('*')){

            let replaceWord = wordsArray.filter(word => word.length === textArray[i].length);
            textArray[i] = replaceWord;
        }
    }

    console.log(textArray.join(' '));
}

//revealWords('great, learning','softuni is ***** place for ******** new programming languages');

//6. Modern Times of #(HashTag)

function printSpecialWords(text){
    let pattern = /\B#(?<word>[A-Za-z]+)\b/gm;
    let specialWords = text.match(pattern);
    let trimmedWords = specialWords.map(word => word.slice(1));
    console.log(trimmedWords.join('\n'));
}

//printSpecialWords('Nowadays everyone uses # to tag a #special word in #socialMedia');

//7.String Substring

function solve(word, text){

    let textArray = text.split(' ').map(element => element.toLowerCase());
    if(textArray.includes(word.toLowerCase())){
        console.log(word);
    } else{
        console.log(`${word} not found!`);
    }
}

//solve('javascript','JavaScript is the best programming language');

//8. Pascal-Case Splitter

function getWords(text){
    let pattern = /[A-Z]{1}[a-z]*/gm;
    let matches = text.match(pattern);
    console.log(matches.join(', '));
}

//getWords('SplitMeIfYouCanHaHaYouCantOrYouCan');