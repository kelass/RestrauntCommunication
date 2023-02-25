$(document).on('click', '#Delete',async function(event)
{
    var input = event.target;

    await Delete(input);
});


async function Delete(input) {
    var accessToken = $("#access").val();

    const response = await fetch("https://localhost:7167/api/Table", {

        method: "DELETE",
       
        headers: {
            Authorization: `Bearer ${accessToken}`,
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
        body: JSON.stringify($(input).val())
    });

    if (response.ok) {
        window.location.replace('/Table/Tables');
    }

}


