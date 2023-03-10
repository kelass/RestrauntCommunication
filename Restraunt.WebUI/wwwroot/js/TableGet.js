$(document).ready(send());

async function send() {
    const url = "https://localhost:7167/api/Table"
    const response = await fetch(url, {

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
        LinkTd.setAttribute('id', 'links')

        var EditLink = document.createElement('button');
        var DeleteLink = document.createElement('button');
        var Nametd = document.createElement('td');
        var Usertd = document.createElement('td');
        var tr = document.createElement('tr');

        var a = document.createElement('a');

        

        if (element.user === null) {
            element.user = "CLEAR";
            Usertd.append(element.user);
        }
        else {
            Usertd.append(element.user.userName);
        }
        


        Idtd.append(element.id)
        Nametd.append(element.name);
        

        a.href ="/Table/Edit/" +element.id

        EditLink.setAttribute('value', linkEdit)
        EditLink.setAttribute('class', 'btn btn-primary m-1')
        EditLink.setAttribute('id', 'Edit')
        EditLink.append('Edit');



        
        DeleteLink.setAttribute('value', linkDelete)
        DeleteLink.setAttribute('id', 'Delete')
        DeleteLink.setAttribute('class', 'btn btn-danger')
        DeleteLink.append('Delete');



        LinkTd.appendChild(a);
        a.appendChild(EditLink);

        LinkTd.appendChild(DeleteLink);

        tr.appendChild(Idtd);
        tr.appendChild(Nametd);
        tr.appendChild(Usertd);
        tr.appendChild(LinkTd);


        document.getElementById('tbody').appendChild(tr)
    });
}