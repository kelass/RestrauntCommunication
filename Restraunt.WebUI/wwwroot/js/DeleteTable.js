$(document).ready(() => {
    $('#Delete').click(async () => await Delete());
});

async function Delete() {
    var accessToken = $("#access").val();

    const data =
    {
        Id: $("#TableId").val()

    };
    const response = await fetch("https://localhost:7167/api/Table", {

        method: "DELETE",
        body: JSON.stringify(data),
        headers: {
            Authorization: `Bearer ${accessToken}`,
            "Accept": "application/json",
            "Content-Type": "application/json"
        }
    });

}


