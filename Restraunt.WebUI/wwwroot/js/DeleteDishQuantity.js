
    $(document).on('click', '#buttonDelete', async (event) => {

        const input = event.target;

        const data = $(input).val();
        
       
        
       
        try {
            await send(data);
           
        } catch (error) {
            console.error(error);
        }
    });


async function send(data) {
    var accessToken = $("#access").val();

    const response = await fetch("https://localhost:7167/api/Basket", {
        method: "DELETE",
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
    else {
        location.reload();
    }
}