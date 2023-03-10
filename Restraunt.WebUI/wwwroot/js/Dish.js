$(document).ready(() => {
    $('#submit').click(async () => await send());
});

async function send() {
    
    var accessToken = $("#access").val();

    const data =
    {
        Id: $("#DishId").val(),
        Name: $("#DishName").val(),
        Description: $("#DishDescription").val(),
        Price: $("#DishPrice").val()
    };
    const url = "https://localhost:7167/api/Dish"
    const response = await fetch(url, {

        method: "POST",
        body: JSON.stringify(data),
        headers: {
            Authorization: `Bearer ${accessToken}`,
            "Accept": "application/json",
            "Content-Type": "application/json"
        }

    });

    if (response.ok) {
        window.location.replace('/Dish/Dishes');
    }

}