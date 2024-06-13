function attachEvents() {
  let loadButtonElement = document.getElementById("btnLoad");
  let phonebookListElement = document.getElementById("phonebook");
  let createContactElement = document.getElementById("person");
  let createPhoneElement = document.getElementById("phone");
  let createButtonElement = document.getElementById("btnCreate");
  let url = "http://localhost:3030/jsonstore/phonebook";

  loadButtonElement.addEventListener("click", async function () {
    try {
      phonebookListElement.innerHTML = "";
      const postResponse = await fetch(url);
      const phonebookRecords = await postResponse.json();
      let fragment = document.createDocumentFragment();

      for (const record in phonebookRecords) {
        let entry = phonebookRecords[record];
        let liElement = document.createElement("li");
        liElement.textContent = `${entry.person}: ${entry.phone}`;
        let deleteButtonElements = document.createElement("button");
        deleteButtonElements.classList.add("btnDelete");
        deleteButtonElements.textContent = "Delete";
        liElement.appendChild(deleteButtonElements);
        deleteButtonElements.addEventListener("click", async function () {
          const requestOptions = {
            method: "DELETE",
            headers: {
              "Content-Type": "application/json",
            },
          };
          const deleteResponse = await fetch(url + `/${entry._id}`, requestOptions);
          const deleteJson = await deleteResponse.json();
          phonebookListElement.removeChild(liElement);
        });
        fragment.appendChild(liElement);
      }

      phonebookListElement.appendChild(fragment);
    } catch (error) {
      console.log(error);
    }
  });

  createButtonElement.addEventListener("click", async function () {
    try {
      let newContact = JSON.stringify({
        person: createContactElement.value,
        phone: createPhoneElement.value,
      });

      createContactElement.value = "";
      createPhoneElement.value = "";

      const requestOptions = {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: newContact,
      };

      const postResponse = await fetch(url, requestOptions);
      const postData = await postResponse.json();
    } catch (error) {
      console.log(error);
    }
  });
}

attachEvents();
