var DishGet = ["1","2"];

$(document).ready(send());



async function send() {
    const url = "https://localhost:7167/api/Basket"
    const response = await fetch(url, {

        method: "GET",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        }

    }).then(r => r.json());


    var dishes = await response;
    DishGet = dishes;
    await Table(dishes);
   
    return dishes;

}



async function Table(dishes)
{
    dishes.forEach(function (element) {
        var tr = document.createElement('tr')

        var Nametd = document.createElement('td');
        var Pricetd = document.createElement('td');
        var Counttd = document.createElement('td');
        var Deletetd = document.createElement('td');
       

        Nametd.append(element.name)
        Pricetd.append(element.price)
        Counttd.append(element.quantity)

        var Button = document.createElement('button');
       
        Button.append('Delete');
        Button.setAttribute('id', 'buttonDelete')
        Button.setAttribute('value', element.id)
        Button.setAttribute('class', 'btn btn-danger');
        var th = document.createElement('th');
        th.setAttribute('class', 'text-nowrap')
        th.scope = HTMLTableRowElement;

        Deletetd.appendChild(Button);


        tr.appendChild(Nametd);
        tr.appendChild(Pricetd);
        tr.appendChild(Counttd);
        tr.appendChild(Deletetd);
        
        

        document.getElementById('tbody').appendChild(tr)

    });
}


