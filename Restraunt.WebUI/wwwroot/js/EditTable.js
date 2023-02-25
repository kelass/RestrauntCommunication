$(document).ready(() => {
    $('#submit').click(async () => await send());
});

async function send() {
    var accessToken = $("#access").val();

    const data =
    {
        Id: $('#Id').val(),
        Name: $("#TableName").val()


    };

    const response = await fetch("https://localhost:7167/api/Table", {

        method: "PUT",
        body: JSON.stringify(data),
        headers: {
            Authorization: `Bearer ${accessToken}`,
            "Accept": "application/json",
            "Content-Type": "application/json"
        }

    });

}