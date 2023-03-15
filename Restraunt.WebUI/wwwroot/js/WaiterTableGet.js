﻿$(document).ready(send());

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
        
        

        var Nametd = document.createElement('td');
        var Usertd = document.createElement('td');
        var tr = document.createElement('tr');
       

        var unBindBtn = document.createElement('button');
        unBindBtn.setAttribute('type', 'submit');
        unBindBtn.setAttribute('class', 'btn btn-danger m-1');
        unBindBtn.setAttribute('value', element.id);
        unBindBtn.setAttribute('id', 'UnBindBtn');
        unBindBtn.append('Clear')


        var UserName = document.createElement('button');
        UserName.setAttribute('type', 'submit');
        UserName.setAttribute('class', 'btn btn-dark')
        UserName.setAttribute('value', element.id)
        UserName.setAttribute('id', 'Id')

        if (element.user === null) {
            UserName.append("CLEAR");
        }
        else {
            UserName.append(element.user.userName);
        }
        Nametd.append(element.name);
        Usertd.appendChild(UserName);
        Usertd.appendChild(unBindBtn);
        
       

        

        
        tr.appendChild(Nametd);
        tr.appendChild(Usertd);
        


        document.getElementById('tbody').appendChild(tr)
    });
}