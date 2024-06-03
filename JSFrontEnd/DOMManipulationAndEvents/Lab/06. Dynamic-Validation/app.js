function validate() {
    let inputElement = document.getElementById('email');
    inputElement.addEventListener('change', function(){
        let validEmailPattern = /^[a-z]+@[a-z]+\.[a-z]+$/;
        if(!validEmailPattern.test(inputElement.value)){
            inputElement.classList.add('error');
        } else{
            inputElement.classList.remove('error');
        }
    })
}