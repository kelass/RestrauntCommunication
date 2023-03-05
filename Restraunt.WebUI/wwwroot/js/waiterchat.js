var connection = new signalR.HubConnectionBuilder().withUrl("/chathub").build();

connection.on("ReceiveMessage", function (order) {
    var button = document.createElement('button')
    button.setAttribute('class', 'btn btn-danger')
    button.append('Delete')
    button.setAttribute('id', 'btnDelete')
    button.setAttribute('value', order.id)
    var Nametd = document.createElement('td');
    var MessageTd = document.createElement('td');
    var tr = document.createElement('tr');
    var deleteTd = document.createElement('td');

    deleteTd.appendChild(button);
    Nametd.append(order.tableName)
    MessageTd.append(order.message)

    tr.appendChild(Nametd);
    tr.appendChild(MessageTd);
    tr.appendChild(deleteTd);

    $('#tbody').prepend(tr);
});



connection.start().then(() => {
    console.log("Connection established");
});


$(document).on('click', '#btnDelete', async (event) => {

    const input = event.target;

    const data = $(input).val();




    try {
        await sendData(data);

    }
    catch (error) {
        console.error(error);
    }
});


async function sendData(data) {
    

    const response = await fetch("https://localhost:7167/api/Order", {
        method: "DELETE",
        body: JSON.stringify(data),
        headers: {
            
            "Accept": "application/json",
            "Content-Type": "application/json"
        }
    });

    if (!response.ok) {
        throw new Error("Failed to send request");
    }
    else {
        location.reload();
    }
}
