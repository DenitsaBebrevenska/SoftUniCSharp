function extract(content) {
    let textContent = document.getElementById(content).textContent;
    const regex = /\((?<word>[A-Za-z ]+)\)/g;
    let words = [...textContent.matchAll(regex)]
        .map(match => match[1]);
    return words.join('; ');
}