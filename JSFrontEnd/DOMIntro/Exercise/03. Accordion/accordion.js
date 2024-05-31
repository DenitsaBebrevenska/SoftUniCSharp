function toggle() {
    let buttonElement = document.getElementsByClassName('button')[0];
    let hiddenTextElement = document.getElementById('extra');

    if(buttonElement.textContent === 'More'){
        buttonElement.textContent = 'Less';
        hiddenTextElement.style.display = 'block';

    } else {
        buttonElement.textContent = 'More';
        hiddenTextElement.style.display = 'none';
    }
}