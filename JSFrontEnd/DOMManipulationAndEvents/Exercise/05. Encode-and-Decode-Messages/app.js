function encodeAndDecodeMessages() {
    let decodedMessageElement = document.querySelector('#main > div:first-child > textarea');
    let encodedMessageElement = document.querySelector('#main > div:last-child > textarea');
    let decodingButton = document.querySelector('#main > div:first-child > button');
    let encodingButton = document.querySelector('#main > div:last-child > button');
    
    const encodeMessage = function(text){
       let asciiValues = text.split('')
            .map(char => char.charCodeAt(0) + 1);
        return String.fromCharCode(...asciiValues);
    }

    const decodeMessage = function(text){
        let asciiValues = text.split('')
            .map(char => char.charCodeAt(0) - 1);
        return String.fromCharCode(...asciiValues);
    }

    decodingButton.addEventListener('click', function(){
        let text = encodeMessage(decodedMessageElement.value);
        encodedMessageElement.value = text;
        decodedMessageElement.value= '';
    })

    encodingButton.addEventListener('click', function(){
        let text = decodeMessage(encodedMessageElement.value);
        encodedMessageElement.value = text;
    })
}