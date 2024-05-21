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
