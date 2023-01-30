document.getElementById("submit").addEventListener("click", send);

//const data = {
//    DishId = document.getElementById("DishId").value,
//    DishName = document.getElementById("DishName").value,
//    DishDescription = document.getElementById("DishDescription").value,
//    DishPrice = document.getElementById("DishPrice").value
//};


async function send() {
    const response = await fetch("https://localhost:7167/api/Dish", {

        method: "POST",
        body: JSON.stringify(
            {
                DishId = document.getElementById("#DishId"),
                DishName = "kk",
                DishDescription = "string",
                DishPrice = 1;
            }),
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            name: document.getElementById("DishName").value,
            Price: document.getElementById("DishPrice").value
        })
    });
    const message = await response.json();
    document.getElementById("message").innerText = message.text;
}
