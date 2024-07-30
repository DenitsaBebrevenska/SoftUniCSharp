function solve(input){
    /* receiving as input array of strings:
    first string is the number of characters, 
    followed by that many strings describing the characters: their name, health and bullet count
    the rest of the array is commands consisting of: action, char. name and shooter name */
    const maximumBulletCapacity = 6;
    const maximumHp = 100;
    let characterCount = Number(input.shift());
    let characters = input.slice(0, characterCount)
        .map(character => {
            let charDetails = character.split(' ');
            return {
                name: charDetails[0],
                hp: Number(charDetails[1]),
                bulletCount: Number(charDetails[2])
            }
        });
    let actions = input.slice(characterCount);

    for (const action of actions) {
        let actionTokens = action.split('-')
            .map(element => element.trim());
        let indexCharacter = characters.findIndex(c => c.name === actionTokens[1]);
        let character = characters[indexCharacter];
        if(actionTokens[0] === 'FireShot'){
            if(character.bulletCount > 0){
                character.bulletCount--;
                console.log(`${character.name} has successfully hit ${actionTokens[2]} and now has ${character.bulletCount} bullets!`);
            } else {
                console.log(`${character.name} doesn't have enough bullets to shoot at ${actionTokens[2]}!`);
            }
        } else if (actionTokens[0] === 'TakeHit'){
            character.hp  -= Number(actionTokens[2]);
            if(character.hp > 0){
                console.log(`${character.name} took a hit for ${actionTokens[2]} HP from ${actionTokens[3]} and now has ${character.hp} HP!`);
            }else {
                characters = characters.slice(0, indexCharacter).concat(characters.slice(indexCharacter + 1));
               console.log(`${character.name} was gunned down by ${actionTokens[3]}!`);
            }
        } else if (actionTokens[0] === 'Reload'){
            if(character.bulletCount < maximumBulletCapacity){
                let bulletReloaded = maximumBulletCapacity - character.bulletCount
                character.bulletCount = maximumBulletCapacity;
                console.log(`${character.name} reloaded ${bulletReloaded} bullets!`); 
            } else {
                console.log(`${character.name}'s pistol is fully loaded!`);
            }
        } else if(actionTokens[0] === 'PatchUp'){
            if(character.hp === maximumHp){
                console.log(`${character.name} is in full health!`)
            } else {
                let oldHp = character.hp;
                character.hp += Number(actionTokens[2]);

                if(character.hp > maximumHp){
                    character.hp = maximumHp;
                }

                console.log(`${character.name} patched up and recovered ${character.hp - oldHp} HP!`)
            }
        } else {
            //Ride off into sunset
            for (const character of characters) {
                console.log(character.name);
                console.log(` HP: ${character.hp}`);
                console.log(` Bullets: ${character.bulletCount}`);
            }
        }
    }
}

solve(["2",
    "Gus 100 4",
    "Walt 100 5",
    "FireShot - Gus - Bandit",
    "TakeHit - Walt - 100 - Bandit",
    "Reload - Gus",
    "Ride Off Into Sunset"])
 ;