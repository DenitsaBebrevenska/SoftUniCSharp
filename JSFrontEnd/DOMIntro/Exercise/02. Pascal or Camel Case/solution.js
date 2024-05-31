function solve() {
  function convertToCamelCase(text){
    let tokens = text.toLowerCase().split(' ');
    let result = tokens[0];
    for(let i = 1; i < tokens.length; i++){
      result += tokens[i].replace(tokens[i][0], tokens[i][0].toUpperCase());
    }

    return result;
  }

  function convertToPascalCase(text){
    let tokens = text.toLowerCase().split(' ');
    let result = tokens.map(token => token.replace(token[0],token[0].toUpperCase()))
    return result.join('');
  }

  let textContent = document.getElementById('text').value;
  let namingConvention = document.getElementById('naming-convention').value;
  let result;

  if(namingConvention === 'Camel Case'){
    result = convertToCamelCase(textContent);
  } else if (namingConvention === 'Pascal Case'){
    result = convertToPascalCase(textContent);
  } else {
    result = 'Error!';  
  }

  document.getElementById('result').textContent = result;
}
