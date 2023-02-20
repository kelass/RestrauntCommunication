$(document).ready(() => {

    $('#menuPage').on('click', '#submit', async (event) => {

        const input = event.target;


       

        const data =
        {
            Id: $(input).siblings('h3').text(),
            Name: $(input).siblings('h5').text(),
            Quantity:1,
            Price: $(input).siblings('h2').text()
        };

        try {
            await send(data);
            console.log(`Блюдо ${data.Name} добавлено в корзину`);
        } catch (error) {
            console.error(error);
        }
    });
});



async function send(data) {

    const response = await fetch("https://localhost:7167/api/Basket", {
        method: "POST",
        body: JSON.stringify(data),
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        }
    });

    if (!response.ok) {
        throw new Error("Failed to send request");
    }

    
}