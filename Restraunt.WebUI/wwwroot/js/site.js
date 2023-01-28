//document.getElementById("submit").addEventListener("click", send);

//const data = {
//    DishId = document.getElementById("DishId"),
//    DishName = document.getElementById("DishName"),
//    DishDescription = document.getElementById("DishDescription"),
//    DishPrice = document.getElementById("DishPrice")
//};


//async function send() {
//    const response = await fetch("https://localhost:7167/api/Dish", {
       
//        method: "POST",
//        body: JSON.stringify(data),
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
    let response = await fetch("https://localhost:7167/api/Dish", {
        method: "GET",
        
        headers: {
            "Accept": "Secrets/json",
            "Content-Type": "application/json"
        }
    });

    if (response.ok) {
        let json = await response.json();
        console.log(json);

    } else {
        console.log(response.status);
    }
}

