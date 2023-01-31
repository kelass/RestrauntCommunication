$(document).ready(() => {
    $('#submit').click(async () => await send());
});

async function send() {
    const data =
    {
        Id: $("#TableId").val(),
        Name: $("#TableName").val(),
        Link: "LinkText",
        UserId: null
        
    };

    const response = await fetch("https://localhost:7167/api/Table", {

        method: "POST",
        body: JSON.stringify(data),
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        }

    });

}