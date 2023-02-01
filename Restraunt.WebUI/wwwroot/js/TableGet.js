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

    
}