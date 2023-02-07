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

    dishes.forEach(function (element) {
        var div = document.createElement('div');
        //div.classList('col')
        var Name = document.createElement('h1');
        var Price = document.createElement('h2');
        var Desc = document.createElement('h3');
        var input = document.createElement('input');
        
        
        input.append('Order');
        //input.className('btn-dark btn');

        Name.append(element.name);
        Price.append(element.price);
        Desc.append(element.description);

        div.appendChild(Name)
        div.appendChild(Desc)
        div.appendChild(Price)
        div.appendChild(input);
        document.getElementById('menuPage').appendChild(div)
    });

}
