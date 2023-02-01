$(document).ready(send());

async function send() {

    const response = await fetch("https://localhost:7167/api/Dish", {

        method: "GET",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        }

    }).then(r => r.json());


}