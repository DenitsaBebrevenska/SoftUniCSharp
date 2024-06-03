function attachGradientEvents() {
    let gradientElement = document.getElementById('gradient');
    let resultElement = document.getElementById('result');

    gradientElement.addEventListener('mousemove', function(event){
        let widthElement = event.target.clientWidth;
        let currentPosition = event.offsetX;
        resultElement.textContent = `${Math.floor(currentPosition / widthElement * 100)}%`;
    })
}