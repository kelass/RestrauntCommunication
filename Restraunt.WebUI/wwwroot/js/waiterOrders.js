$(document).ready(send());

async function send() {
    var Id = $('#userId').val();
    const response = await fetch(`https://localhost:7167/api/Order/${Id}`, {

        method: "POST",
        body:JSON.stringify(Id),
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        }

    }).then(r => r.json());

    var orders = await response;

    await Table(orders);


}

async function Table(orders) {
    orders.forEach(function (element) {
        var button = document.createElement('button')
        button.setAttribute('class', 'btn btn-danger')
        button.append('Delete')
        button.setAttribute('id', 'btnDelete')
        button.setAttribute('value', element.id)
        var Nametd = document.createElement('td');
        var MessageTd = document.createElement('td');
        var tr = document.createElement('tr');
        var deleteTd = document.createElement('td');

        deleteTd.appendChild(button);
        Nametd.append(element.tableName)
        MessageTd.append(element.message)

        tr.appendChild(Nametd);
        tr.appendChild(MessageTd);
        tr.appendChild(deleteTd);
        
        document.getElementById('tbody').appendChild(tr)
    });
}