//01. Login

function login(actions){
    const username = actions[0];
    const password = username.split('').reverse().join('');

    for(let i = 1; i < actions.length; i++){
        if(actions[i] === password){
            return console.log(`User ${username} logged in.`);
            }
        
        if(i === 4){
            return console.log(`User ${username} blocked!`);
        } else{
            console.log('Incorrect password. Try again.');
        }
    }
}

//login(['sunny','rainy','cloudy','sunny','not sunny']);

//02. Bitcoin "Mining"

function bitcoinMining(miningShift){
    const bitcoinPrice = 11949.16;
    const goldPricePerGram = 67.51;
    let bitcoinCount = 0;
    let money = 0;
    let firstPurchaseDay = 0;

    for(let i = 0; i < miningShift.length; i++){
        let currentGoldInGrams = miningShift[i];

        if((i + 1) % 3 === 0){
            currentGoldInGrams *= 0.7;
        }

        money += currentGoldInGrams * goldPricePerGram;

        while(money >= bitcoinPrice){
            money -= bitcoinPrice;
            bitcoinCount++;
        }

        if(firstPurchaseDay === 0 && bitcoinCount > 0){
            firstPurchaseDay = i + 1;
        }
    }

    console.log(`Bought bitcoins: ${bitcoinCount}`);

    if(bitcoinCount > 0){
        console.log(`Day of the first purchased bitcoin: ${firstPurchaseDay}`);
    }

    console.log(`Left money: ${money.toFixed(2)} lv.`);
}

//bitcoinMining([100, 200, 300]);

//03. The Pyramid Of King Djoser
function reportNeededMaterials(base, increment){
    let stepCount = Math.round(base / 2); 
    let height = Math.trunc(stepCount * increment);
    //each step area is decreased by 2 until it is >= 0

    let stoneCount = 0;
    let marbleCount = 0;
    let lapisLazuliCount = 0;
    let goldCount = 0;

    for(let i = 1; i <= stepCount; i++){

        if (i === stepCount){
            //last step is made out of gold entirely
            //needed material is base * base
            goldCount = Math.pow(base, 2);
        } else{
            //stone area = (base - 2) * (base - 2)
            stoneCount += Math.pow(base - 2, 2); 

            //surroding matterial = perimeter = (base * 4  - 4)
            if(i % 5 === 0){
                //every 5th step surrounding material is lapis lazuli
                lapisLazuliCount +=(base * 4  - 4);
            } else{ //otherwise it is marble
                marbleCount +=(base * 4  - 4);
            } 
        }

        base -= 2;
    }

    //multiplying by increment at the end because otherwise if done on each step the result vary from Judge
    console.log(`Stone required: ${Math.ceil(stoneCount * increment)}`);
    console.log(`Marble required: ${Math.ceil(marbleCount * increment)}`);
    console.log(`Lapis Lazuli required: ${Math.ceil(lapisLazuliCount * increment)}`);
    console.log(`Gold required: ${Math.ceil(goldCount * increment)}`);
    console.log(`Final pyramid height: ${height}`);
}


reportNeededMaterials(23,0.5);
