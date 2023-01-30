﻿$(document).ready(() => {
    $('#submit').click(async () => await send());
});

async function send()
{
    const data =
    {
        Id: $("#DishId").val(),
        Name: $("#DishName").val(),
        Description: $("#DishDescription").val(),
        Price: $("#DishPrice").val()
    };

    const response = await fetch("https://localhost:7167/api/Dish", {

        method: "POST",
        body: JSON.stringify(data),
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        }

    });

}