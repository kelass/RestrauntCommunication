$(document).ready(send());
var connection = new signalR.HubConnectionBuilder().withUrl("/chathub").build();


async function send() {

    var url = location.href;
    var id = url.substring(url.lastIndexOf('/') + 1);
    const urlApi = `https://localhost:7167/api/Table/${id}`
    const response = await fetch(urlApi, {

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

connection.on("ReceiveMessage", function (order) {
    var msg =order.message;
    var li = document.createElement("li");
    li.textContent = msg;
    $('#list').prepend(li);
});



connection.start().then(() => {
    console.log("Connection established");
});



$('#btnSend').on('click', async function () {

    

    var userId = $('#btnSend').val();
    var tableName = $('#TableName').val();
    var message = "";
    DishGet.forEach(function (element)
    {
        message += element.name + `(${element.quantity})`
    });

    const data =
    {
        Id: $('#id').val(),
        Message: message,
        TableName: $('#TableName').val(),
        UserId: $('#btnSend').val()
    };

    connection.invoke("SendMessage", data);

   
        console.log(message);
        window.location.replace('/Dish/Completed');
    
    
    
  });