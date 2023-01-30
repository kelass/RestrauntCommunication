const getTablesFetch = async () => await fetch(`https://localhost:7167/api/Dish`, {
    method: 'GET',
    headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json',
    },
}).then(r => r.json());

async function main() {
    const tables = await getTablesFetch();
    console.log(tables);
}

main();