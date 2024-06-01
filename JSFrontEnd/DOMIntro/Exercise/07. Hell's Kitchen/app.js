function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick () {
      let inputElement = document.querySelector('#inputs > textarea');
      let bestRestaurantElement = document.querySelector('#bestRestaurant > p');
      let bestWorkersElement = document.querySelector('#workers > p');
      let input = JSON.parse(inputElement.value);
      let restaurants = [];
   

      for(const line of input){
         console.log(line);
         let tokens = line.split(' - ').filter(string => string !== '');
         let restaurantName = tokens[0];
         let workersInfo = tokens[1].split(', ').filter(string => string !== '');
         let targetedRestaurant = restaurants.find(r => r.name === restaurantName);

         if(!targetedRestaurant){
            targetedRestaurant = {
               name: restaurantName,
               highestSalary: 0,
               totalSalaryAmount: 0,
               workers: []
            }
            restaurants.push(targetedRestaurant);
         }

         for(const worker of workersInfo){
            let tokens = worker.split(' ').filter(string => string !== '');;
            let name = tokens[0];
            let salary = Number(tokens[1]);
            targetedRestaurant.workers.push({
               name,
               salary
            });
            targetedRestaurant.totalSalaryAmount += salary;

            if(targetedRestaurant.highestSalary < salary){
               targetedRestaurant.highestSalary = salary;
            }
         }
      }

      restaurants.sort((a, b) => b.totalSalaryAmount / b.workers.length - a.totalSalaryAmount / a.workers.length);
      let bestRestaurant = restaurants[0];
      let averageSalary = bestRestaurant.totalSalaryAmount / bestRestaurant.workers.length;
      bestRestaurantElement.textContent = 
         `Name: ${bestRestaurant.name} Average Salary: ${averageSalary.toFixed(2)} Best Salary: ${bestRestaurant.highestSalary.toFixed(2)}`;

      bestRestaurant.workers.sort((a, b) => b.salary - a.salary);
      let workersResult = bestRestaurant.workers.map(worker => `Name: ${worker.name} With Salary: ${worker.salary}`);
      bestWorkersElement.textContent = workersResult.join(' ');
   }
}

