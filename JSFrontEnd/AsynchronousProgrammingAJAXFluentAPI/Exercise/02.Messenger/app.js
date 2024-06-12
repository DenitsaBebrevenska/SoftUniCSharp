function attachEvents() {
    let textAreaElement = document.getElementById('messages');
    let nameElement = document.querySelector('#controls > div > input[name=author]');
    let messageElement = document.querySelector('#controls > div > input[name=content]');
    let sendButtonElement = document.getElementById('submit');
    let refreshButtonElement = document.getElementById('refresh');
    let url = 'http://localhost:3030/jsonstore/messenger';

    sendButtonElement.addEventListener('click', async function() {
        try{
            let jsonObj = JSON.stringify({
                author: nameElement.value,
                content: messageElement.value
            })

            nameElement.value = '';
            messageElement.value = '';

            let postRequestOptions = {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: jsonObj
            }

            const response = await fetch(url, postRequestOptions);
            const data  = await response.json();
        
        } catch(error) {
            console.log(error);
        }
    })

    refreshButtonElement.addEventListener('click', async function(){
        textAreaElement.textContent = '';

        const response = await fetch(url);
        const data = await response.json();

        textAreaElement.textContent = Object.values(data).map(element => `${element.author}: ${element.content}`).join('\n')
    })

}

attachEvents();