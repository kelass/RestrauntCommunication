//document.getElementById("submit").addEventListener("click", send);

//async function send() {
//    const response = await fetch("https://localhost:7167/api/Dish", {
       
//        method: "POST",
//        headers: {
//            "Accept": "application/json",
//            "Content-Type": "application/json"
//        },
//        body: JSON.stringify({
//            name: document.getElementById("DishName").value,
//            Price: document.getElementById("DishPrice").value
//        })
//    });
//    const message = await response.json();
//    document.getElementById("message").innerText = message.text;
//}
document.getElementById("D").addEventListener("click", sendGet);
async function sendGet()
{
    let response = await fetch("https://localhost:7167/api/Dish");

    if (response.ok) {
        let json = await response.json();
        alert(json);
        console.log(json);

    } else {
        alert("Trouble HTTP:" + response.status);
    }
}

