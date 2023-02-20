$(document).ready(send());

async function send() {

    const response = await fetch("https://localhost:7167/api/Table", {

        method: "GET",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        }

    }).then(r=>r.json());

    var tables = await response;

    await Table(tables);
    
    
}

async function Table(tables) {
    tables.forEach(function (element) {
        var linkEdit = element.id;
        var linkDelete = element.id;
        var Idtd = document.createElement('td');
        var LinkTd = document.createElement('td');

        var EditLink = document.createElement('button');
        var DeleteLink = document.createElement('button');
        var Nametd = document.createElement('td');
        var Usertd = document.createElement('td');
        var tr = document.createElement('tr');

        



        if (element.user === null) {
            element.user = "CLEAR";
        }
        Idtd.append(element.id)
        Nametd.append(element.name);
        Usertd.append(element.user);

        

        EditLink.setAttribute('value', linkEdit)
        EditLink.setAttribute('class', 'btn btn-primary')
        EditLink.setAttribute('id', 'Edit')
        EditLink.append('Edit');



        
        DeleteLink.setAttribute('value', linkDelete)
        DeleteLink.setAttribute('id', 'Delete')
        DeleteLink.setAttribute('class', 'btn btn-danger')
        DeleteLink.append('Delete');



        LinkTd.appendChild(EditLink);

        LinkTd.appendChild(DeleteLink);

        tr.appendChild(Idtd);
        tr.appendChild(Nametd);
        tr.appendChild(Usertd);
        tr.appendChild(LinkTd);


        document.getElementById('tbody').appendChild(tr)
    });
}