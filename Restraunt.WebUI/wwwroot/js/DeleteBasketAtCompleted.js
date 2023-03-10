$(document).ready(async function () {
    await Delete();
});


async function Delete() {
    const url = "https://localhost:7167/api/Basket"
    const response = await fetch(url, {

        method: "PATCH",

        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        }

    });

    if (response.ok) {
        console.log("Dishes at basket deleted!")
    }

}