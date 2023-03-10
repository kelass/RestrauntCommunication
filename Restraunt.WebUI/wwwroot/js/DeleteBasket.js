$(document).on('click', '#Delete', async function (event) {
    var input = event.target;

    await Delete(input);
});


async function Delete(input) {
    var accessToken = $("#access").val();
    const url = "https://localhost:7167/api/Basket"
    const response = await fetch(url, {

        method: "PATCH",

        headers: {
            Authorization: `Bearer ${accessToken}`,
            "Accept": "application/json",
            "Content-Type": "application/json"
        }
       
    });

    if (response.ok) {
        window.location.replace('/');
    }

}