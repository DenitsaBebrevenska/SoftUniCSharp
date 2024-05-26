//01. Person Info
function solve(firstName, lastName, age) {
  return (person = {
    firstName,
    lastName,
    age,
  });
}

//console.log(solve("Peter", "Pan","20"));

//02. City
function solve(cityDetails) {
  for (const property in cityDetails) {
    console.log(`${property} -> ${cityDetails[property]}`);
  }
}

// solve({
//     name: "Sofia",
//     area: 492,
//     population: 1238438,
//     country: "Bulgaria",
//     postCode: "1000"
// });

//03. Convert to Object

function convertToObject(json) {
  let object = JSON.parse(json);

  for (const property in object) {
    console.log(`${property}: ${object[property]}`);
  }
}

//convertToObject('{"name": "George", "age": 40, "town": "Sofia"}');

//04. Convert to JSON

function convertToJSON(firstName, lastName, hairColor) {
  let object = {
    name: firstName,
    lastName,
    hairColor,
  };

  let json = JSON.stringify(object);
  console.log(json);
}

//convertToJSON('George', 'Jones', 'Brown');

//05. Phone Book

function solve(namesAndPhones) {
  let phonebook = {};

  for (const entry of namesAndPhones) {
    let [name, phoneNumber] = entry.split(" ");
    phonebook[name] = phoneNumber;
  }

  for (const kvp in phonebook) {
    console.log(`${kvp} -> ${phonebook[kvp]}`);
  }
}

// solve(['Tim 0834212554',
// 'Peter 0877547887',
// 'Bill 0896543112',
// 'Tim 0876566344']
// );

//06. Meetings

function scheduleMeetings(meetingsArray) {
  let schedule = {};

  for (const line of meetingsArray) {
    let [day, name] = line.split(" ");

    if (schedule[day]) {
      console.log(`Conflict on ${day}!`);
    } else {
      console.log(`Scheduled for ${day}`);
      schedule[day] = name;
    }
  }

  for (const day in schedule) {
    console.log(`${day} -> ${schedule[day]}`);
  }
}

// scheduleMeetings(['Monday Peter',
// 'Wednesday Bill',
// 'Monday Tim',
// 'Friday Tim']);

//07. Address Book

function solve(namesAndAddresses) {
  let addressBook = {};

  for (const line of namesAndAddresses) {
    let [name, address] = line.split(":");
    addressBook[name] = address;
  }

  Object.entries(addressBook)
    .sort(([firstPersonName], [secondPersonName]) =>
      firstPersonName.localeCompare(secondPersonName)
    )
    .forEach(([name, address]) => console.log(`${name} -> ${address}`));
}

// solve([
//   "Tim:Doe Crossing",
//   "Bill:Nelson Place",
//   "Peter:Carlyle Ave",
//   "Bill:Ornery Rd",
// ]);

//08. Cats
function solve(catsDetails) {
  class Cat {
    constructor(name, age){
        this.name = name,
        this.age = age
    }

    meow() {
        console.log(`${this.name}, age ${this.age} says Meow`);
    };
  }

  let cats = [];

  for(const entry of catsDetails){
    let tokens = entry.split(' ');
    cats.push(new Cat(tokens[0], Number(tokens[1])));
  }

  cats.forEach(cat => cat.meow());
}

//solve(['Mellow 2', 'Tom 5']);

//9. Songs

function solve(input){
    class Song{
        constructor(name, time, typeList){
        this.name = name,
        this.time = time,
        this.typeList = typeList
        }
    }

    let songs = [];
    let songCount = input.shift();
    let chosenPlaylist = input.pop();

    for(let i = 0; i < songCount; i++){
        let tokens = input[i].split('_');
        let [playlistName, songName, songDuration] = [tokens[0], tokens[1], tokens[2]];
        songs.push(new Song(songName, songDuration, playlistName));
    }

    if(chosenPlaylist === 'all'){
        songs.forEach(song => console.log(song.name));
    } else {
        songs.filter(song => song.typeList === chosenPlaylist).forEach(song => console.log(song.name));
    }
}

// solve([4,
//     'favourite_DownTown_3:14',
//     'listenLater_Andalouse_3:24',
//     'favourite_In To The Night_3:58',
//     'favourite_Live It Up_3:48',
//     'listenLater']);
