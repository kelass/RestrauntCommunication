//$(document).ready(() => {
//    $('#submit').click(async () => await send());
//});
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

    tables.forEach(function (element) {
        var Idtd = document.createElement('td');
        var LinkTd = document.createElement('td');
        
        var EditLink = document.createElement('a');
        var DeleteLink = document.createElement('a');
        var Nametd = document.createElement('td');
        var Usertd = document.createElement('td');
        var tr = document.createElement('tr');

        if (element.user === null) {
            element.user = "CLEAR";
        }
        Idtd.append(element.id)
        Nametd.append(element.name);
        Usertd.append(element.user);

        EditLink.append('Edit');
        //EditLink.href:"https://localhost:45591/Table/Edit/" + element.id;
        DeleteLink.append('Delete');
        //DeleteLink.href: "https://localhost:45591/Table/Delete/" + element.id;
       
        LinkTd.appendChild(EditLink);
        LinkTd.appendChild(DeleteLink);

        tr.appendChild(Idtd);
        tr.appendChild(Nametd);
        tr.appendChild(Usertd);
        tr.appendChild(LinkTd);
        

        document.getElementById('tbody').appendChild(tr)
    });
}