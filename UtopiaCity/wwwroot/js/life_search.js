function search()
{
    const xhttp = new XMLHttpRequest();

    let word = document.getElementById('sword').value;
    let from = document.getElementById('sfrom').value;
    let to = document.getElementById('sto').value;
    let type = document.getElementById('stype').value;
    
    let form = new FormData();
    form.set('SearchWord', word);
    form.set('From', from);
    form.set('To', to);
    form.set('EventType', type);

    xhttp.addEventListener("load", onReceiving);

    xhttp.open('post', 'https://localhost:44375/Life/Search');
    xhttp.send(form);

    function onReceiving() {
        let res = JSON.parse(xhttp.responseText);
        let table = document.getElementById('table');

        let length = parseInt(table.rows.length);
        for (let i = 0; i < length; i++) {
            table.deleteRow(0);
        }

        for (let i = 0; i < res.length; i++) {
            let row = table.insertRow(i);
            let cell1 = row.insertCell(0);
            let cell2 = row.insertCell(1);
            let cell3 = row.insertCell(2);
            let cell4 = row.insertCell(3);
            let cell5 = row.insertCell(4);
            console.log(res[i].description);
            cell1 = res[i].date;
            cell2 = res[i].title;
            cell3 = res[i].description;
            cell4 = res[i].eventType;
        }
    }
}

