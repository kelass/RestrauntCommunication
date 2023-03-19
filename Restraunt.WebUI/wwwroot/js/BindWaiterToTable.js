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
    $('#tbody').on('click', '#UnBindBtn', async (event) => {

        const input = event.target;

        const data =
        {
            Id: $(input).val(),
        };

        try {
            await UnBind(data);
        } catch (error) {
            console.error(error);
        }
    });
});



async function send(data) {
    var accessToken = $("#access").val();
    const url = "https://localhost:7167/api/Table"
    const response = await fetch(url, {
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
    else {
        
        $(document).ready(function () {
            $('#exampleModal').modal('show'); // Показываем модальное окно
            setTimeout(function () {
                $('#exampleModal').modal('hide'); // Скрываем модальное окно через 2 секунды
            }, 2000);
        });
        setTimeout(function () {
            window.location.replace('/Table/WaiterTables');
        }, 1800);
        
    }
}

async function UnBind(data) {
    var accessToken = $("#access").val();
    const url = `https://localhost:7167/api/Table/${data.Id}`
    const response = await fetch(url, {
        method: "PUT",
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


        $(document).ready(function () {
            $('#Modal').modal('show'); // Показываем модальное окно
            setTimeout(function () {
                $('#Modal').modal('hide'); // Скрываем модальное окно через 2 секунды
            }, 2000);
        });
        setTimeout(function () {
            window.location.replace('/Table/WaiterTables');
        }, 1800);


    }
}