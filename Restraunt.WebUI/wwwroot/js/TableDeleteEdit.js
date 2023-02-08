$(document).ready(() => {
    $('#submitDelete').click(async () => await Delete());
});
$(document).ready(() => {
    $('#submitEdit').click(async () => await Edit());
});


async function Delete() {
    const data =
    {
        Id: $("#TableId").val()

    };
    const response = await fetch("https://localhost:7167/api/Table", {

        method: "DELETE",
        body: JSON.stringify(data),
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        }
    });

}