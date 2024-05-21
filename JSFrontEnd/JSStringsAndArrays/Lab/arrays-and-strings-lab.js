//1.	Sum First and Last Array Elements
function sumFirstAndLastNumber(numbers){
    let sum = numbers[0] + numbers[numbers.length - 1];
    console.log(sum);
}

//sumFirstAndLastNumber([10, 17, 22, 33]);

//2. Reverse an Array of Numbers
function solve(count, numbers){
    let result = numbers.slice(0, count)
    .reverse();
    console.log(result.join(' '));
}

//solve(4, [-1, 20, 99, 5]);

//3. Even and Odd Subtraction
function solve(numbers){
    let oddNumbersSum = numbers.filter(number => number % 2 !== 0)
    .reduce((sum, num) => sum += num, 0);
    let evenNumbersSum = numbers.filter(number => number % 2 === 0)
    .reduce((sum, num) => sum += num, 0);
    console.log(evenNumbersSum - oddNumbersSum);
}

//solve([2,4,6,8,10]);

//4. Substring

function extractSubstring(text, start, count){
    let result = text.substring(start, start + count);
    console.log(result);
}

//extractSubstring('SkipWord', 4, 7);

function censorWord(text, word){
    let censoredWord = '*'.repeat(word.length);

    while(text.includes(word)){
        text = text.replace(word, censoredWord);
    }

    console.log(text);
}

//censorWord('A small sentence with some words', 'small');

//6. Count String Occurrences

function getWordOccurences(text, word){
    const delimiter = /[\s,]+/;
    let splitText = text.split(delimiter);
    let count = splitText.filter(w => w === word).length;

    console.log(count);
}

//getWordOccurences('This is a word and it also is a sentence','is');