var connection = null;

setupConnection = () => {
    connection = new signalR.HubConnectionBuilder()
        .withUrl('/coffeehub')
        .build();

    connection.on('ReceiveOrderUpdate',
        (update) => {
            document.getElementById('status').innerHTML = update;
        });

    connection.on('NewOrder',
        function(order) {
            document.getElementById('status').innerHTML = `Someone ordered a ${order.product}`;
        });

    connection.on('Finished',
        function() {
            //connection.stop();
        });

    connection.start()
        .catch(err =>
            console.error(err.toString()));
}

setupConnection();

document.getElementById('submit').addEventListener('click', e => {
    e.preventDefault();
    var product = document.getElementById('product').value;
    var size = document.getElementById('size').value;

    fetch('/Coffee/OrderCoffee',
            {
                method: 'POST',
                body: JSON.stringify({ product, size }),
                headers: {
                    'Content-Type': 'application/json'
                }
            })
        .then(response => response.text())
        .then(id => connection.invoke('GetUpdateForOrder', Number(id)));
});