using Prototype;

SandwichMenu menu = new SandwichMenu();

menu["BLT"] = new Sandwich("Wheat", "Bacon", "", "Lettuce, Tomato");
menu["PB&J"] = new Sandwich("White", "", "", "Peanut Butter, Jelly");
menu["Turkey"] = new Sandwich("Rye", "Turkey", "Swiss", "Lettuce, Onion, Tomato");

menu["LoadedBLT"] = new Sandwich("Wheat", "Turkey, Bacon", "American", "Lettuce, Tomato, Onion, Olives");
menu["ThreeMeatCombo"] = new Sandwich("Rye", "Turkey, Ham, Salami", "Provolone", "Lettuce, Onion");
menu["Vegetarian"] = new Sandwich("Wheat", "", "", "Lettuce, Onion, Tomato, Olives, Spinach");

Sandwich sandwich1 = menu["BLT"].Clone() as Sandwich;
Sandwich sandwich2 = menu["ThreeMeatCombo"].Clone() as Sandwich;
