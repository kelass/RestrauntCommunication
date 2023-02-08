$(document).ready(send());

async function send() {

    const response = await fetch("https://localhost:7167/api/Dish", {

        method: "GET",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        }

    }).then(r => r.json());


    var dishes = await response;

    await Table(dishes);
    
}

async function Table(dishes) {
    dishes.forEach(function (element) {
        var Idtd = document.createElement('td');
        var Nametd = document.createElement('td');
        var Pricetd = document.createElement('td');
        var tr = document.createElement('tr');


        Idtd.append(element.id);
        Nametd.append(element.name);
        Pricetd.append(element.price);


        tr.appendChild(Idtd);
        tr.appendChild(Nametd);
        tr.appendChild(Pricetd);
        document.getElementById('tbody').appendChild(tr)
    });
}