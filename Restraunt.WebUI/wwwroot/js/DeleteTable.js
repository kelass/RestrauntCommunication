$(document).on('click', '#Delete',async function(event)
{
    var input = event.target;

    await Delete(input);
});


async function Delete(input) {
    var accessToken = $("#access").val();
    const url = "https://localhost:7167/api/Table"
    const response = await fetch(url, {

        method: "DELETE",
       
        headers: {
            Authorization: `Bearer ${accessToken}`,
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
        body: JSON.stringify($(input).val())
    });

    if (response.ok) {
        $(document).ready(function () {
            $('#exampleModal').modal('show'); // Показываем модальное окно
            setTimeout(function () {
                $('#exampleModal').modal('hide'); // Скрываем модальное окно через 2 секунды
            }, 2000);
        });
        setTimeout(function () {
            window.location.replace('/Table/Tables');
        }, 1800);
    }

}


