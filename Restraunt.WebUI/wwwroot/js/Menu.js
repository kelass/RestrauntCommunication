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
        col = document.createElement('div');
        col.setAttribute('class', 'col-sm-3 mb-3')
        var div = document.createElement('div');
        var divBody = document.createElement('div')



        var Price = document.createElement('h2')
        Price.append(element.price)
        Price.hidden = true;

        var Id = document.createElement('h3')
        Id.append(element.id)
        Id.hidden = true;

        divBody.setAttribute('class', 'card-body')
        div.setAttribute('class', 'card');
        var Name = document.createElement('h5');
        Name.setAttribute('class', 'card-title')

        var Desc = document.createElement('p');
        Desc.setAttribute('class', 'card-text')

        var input = document.createElement('button');
        input.setAttribute('class', 'btn-dark btn');
        input.append(element.price);
        input.setAttribute('id', "submit");
        input.setAttribute('value', element.id);

        Name.append(element.name);
        Desc.append(element.description);
        col.appendChild(div);
       
        div.appendChild(divBody);
       
        divBody.appendChild(Name);
        divBody.appendChild(Desc);
        divBody.appendChild(input);
        divBody.appendChild(Price);
        divBody.appendChild(Id);
        document.getElementById('menuPage').appendChild(col)
    });

}
