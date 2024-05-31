function colorize() {
    let evenTrElements = document.querySelectorAll('tr:nth-child(even)');
    for(const element of evenTrElements){
        element.style.background = 'teal';
    }
}