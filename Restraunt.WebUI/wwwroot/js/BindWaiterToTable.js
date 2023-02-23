$(document).ready(() => {
    $('#tbody').on('click', '#Id', async (event) => {

        const input = event.target;

        const data =
        {
            Id: $(input).val(),
            UserId: $('#userId').val()
        };

        try {
            await send(data);
            console.log(`Пользователь ${data.UserId} добавлен`);
        } catch (error) {
            console.error(error);
        }
    });
});



async function send(data) {
    var accessToken = $("#access").val();
    
    const response = await fetch("https://localhost:7167/api/Table", {
        method: "PATCH",
        body: JSON.stringify(data),
        headers: {
            Authorization: `Bearer ${accessToken}`,
            "Accept": "application/json",
            "Content-Type": "application/json"
        }
    });

    if (!response.ok) {
        throw new Error("Failed to send request");
    }


}