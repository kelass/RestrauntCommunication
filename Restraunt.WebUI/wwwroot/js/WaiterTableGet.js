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
     
        var Nametd = document.createElement('td');
        var Usertd = document.createElement('td');
        var tr = document.createElement('tr');

        if (element.user === null) {
            element.user = "CLEAR";
        }
       
        Nametd.append(element.name);
        Usertd.append(element.user);

       

        

        
        tr.appendChild(Nametd);
        tr.appendChild(Usertd);
        


        document.getElementById('tbody').appendChild(tr)
    });
}