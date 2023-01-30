document.getElementById("submit").addEventListener("click", send);

const data = {
    Id: document.getElementById("DishId").value,
    Name: document.getElementById("DishName").value,
    Description: document.getElementById("DishDescription").value,
    Price: document.getElementById("DishPrice").value
};


async function send(data)
{
    const response = async (data) => await fetch("https://localhost:7167/api/Dish", {

        method: "POST",
        body: JSON.stringify({ data }),
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        }

    });
    
}



