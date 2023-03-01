$(document).ready(send());
var connection = new signalR.HubConnectionBuilder().withUrl("/chathub").build();


async function send() {

    var url = location.href;
    var id = url.substring(url.lastIndexOf('/') + 1);

    const response = await fetch(`https://localhost:7167/api/Table/${id}`, {

        method: "GET",
        
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        }

    }).then(r => r.json());

    var json = await response;
    var waiterId = json.user.id;
    $('#TableName').val(json.name);
    var btnSend = $('#btnSend').val(waiterId);
    return tableName;
}

connection.on("ReceiveMessage", function (message) {
    var msg =message;
    var li = document.createElement("li");
    li.textContent = msg;
    $('#list').prepend(li);
});



connection.start().then(() => {
    console.log("Connection established");
});



$('#btnSend').on('click',async function () {
    var userId = $('#btnSend').val();
    var tableName = $('#TableName').val();
    var message = `${tableName}:`;
    DishGet.forEach(function (element)
    {
        message += element.name + `(${element.quantity})`
    });

    connection.invoke("SendMessage", message, userId);

   
        console.log(message);
        window.location.replace('/Dish/Completed');
    
    
    
  });