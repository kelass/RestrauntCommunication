$(document).ready(() => {
    $('#submit').click(async () => await send());
});

const but = document.getElementById("submit");
const parent = but.parentNode;

async function send(parent) {
    

    const response = await fetch("https://localhost:7167/api/Basket", {

        method: "POST",
        body: JSON.stringify(data),
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        }

    });

}