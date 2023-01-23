
﻿const getDishesFetch = async () => await fetch(`/api/Dish/`, {
    method: 'GET',
    headers: {
        'Accept': 'application/json',
        'Content-Type': 'Secrets/json',
    },
}).then(r => r.json());

//const postNewDishFetch = async (dish) => await fetch(`/api/Dish/`, {
//    method: 'POST',
//    headers: {
//        'Accept': 'application/json',
//        'Content-Type': 'Secrets/json',
//    },
//    body: JSON.stringify({ Id: item.id, Name: item.name }),
//});

//function getItemFromFormn
//    {
//    const item = {};
//    item['id'] = 5;
//    item['name'] = 'Some name 5';
//    return item;
//}

async function main() {
    const dishes = await getDishesFetch();
    console.log(dishes);

}

main();
