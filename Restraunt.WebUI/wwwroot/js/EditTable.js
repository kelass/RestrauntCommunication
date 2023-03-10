$(document).ready(() => {
    $('#submit').click(async () => await send());
});

async function send() {
    var accessToken = $("#access").val();
    const url = "https://localhost:7167/api/Table"
    const data =
    {
        Id: $('#Id').val(),
        Name: $("#TableName").val()


    };
    
    const response = await fetch(url, {

        method: "PUT",
        body: JSON.stringify(data),
        headers: {
            Authorization: `Bearer ${accessToken}`,
            "Accept": "application/json",
            "Content-Type": "application/json"
        }

    });

    if (response.ok) {
        window.location.replace('/Table/Tables');
    }

}