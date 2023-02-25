var connection = new signalR.HubConnectionBuilder().withUrl("/chathub").build();

connection.on("ReceiveMessage", function (table, message) {
    var msg = table + ": " + message;
    var li = document.createElement("li");
    li.textContent = msg;
    $('#list').prepend(li);
});

connection.start();

$('#btnSend').on('click', function () {
    var table = $('#txtTable').val();
    var message = $('#txtMsg').val();

    connection.invoke("SendMessage", table, message);
});