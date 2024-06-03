function focused() {
    let divElements = Array.from(document.querySelectorAll('div > div > input'));
    console.log(divElements);
    divElements.forEach(element => {
        element.addEventListener('focus', function(){
            element.parentElement.classList.add('focused');
        }),
        element.addEventListener('blur', function(){
            element.parentElement.classList.remove('focused');
        })
    });
}