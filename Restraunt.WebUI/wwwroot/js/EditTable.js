$(document).ready(() => {
    $('#submit').click(async () => await send());
});

async function send() {
    var accessToken = $("#access").val();
    const url = "https://localhost:7167/api/Table"
    const data =
    {
        Id: $('#Id').val(),
        Name: $("#TableName").val()


    };
    
    const response = await fetch(url, {

        method: "PUT",
        body: JSON.stringify(data),
        headers: {
            Authorization: `Bearer ${accessToken}`,
            "Accept": "application/json",
            "Content-Type": "application/json"
        }

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