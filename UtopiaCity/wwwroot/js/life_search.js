function addOptions(data) {
    var r = $('#selectEvent').children().length;
console.log(r);
    if ($('#selectEvent').children().length == 1) {
        let list = JSON.parse(data);
        for (let i = 0; i < list.length; i++) {
            $('#selectEvent').append(`<option value="${list[i].Id}">${list[i].Name}</option>`);
        }
    }    
}