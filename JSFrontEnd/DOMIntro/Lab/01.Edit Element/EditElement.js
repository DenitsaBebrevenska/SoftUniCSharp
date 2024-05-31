function editElement(elementReference, match, replacer) {
      let elementContent = elementReference.textContent;
    //cannot use replaceAllIn Judge
      while(elementContent.includes(match)){
        elementContent = elementContent.replace(match, replacer);
      }

      elementReference.textContent = elementContent;
}