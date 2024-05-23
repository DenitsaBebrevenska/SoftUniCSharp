//01. Smallest of Three Numbers

function printSmallestNumber(a, b, c){

    function findSmallestNumber(a, b) {
        return a < b ? a : b};
    
    console.log(findSmallestNumber(findSmallestNumber(a, b), c));
}

//printSmallestNumber(2, 5, 3);

//02. Add and Subtract

function calculate(a, b, c){
    let addition = (a , b) => a + b;
    let subtraction = (a, b) => a - b;
    console.log(subtraction(addition(a, b), c));
}

//calculate(23, 6, 10);

//03. Characters in Range

