// get all accounts
async function GetAccounts() {
    const response = await fetch("/ResidentAccountApi", {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        const accounts = await response.json();
        let rows = document.querySelector("tbody");
        accounts.forEach(account => {
            rows.append(row(account));
        });
    }
}
 
// delete account
async function DeleteAccount(id) {
    const response = await fetch("/ResidentAccountApi/" + id, {
        method: "DELETE",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        const account = await response.json();
        document.querySelector("tr[data-rowid='" + account.id + "']").remove();
    }
}

// make row for table
function row(account) {

    const tr = document.createElement("tr");
    tr.setAttribute("data-rowid", account.id);

    const nameTd = document.createElement("td");
    nameTd.append(account.firstName + " " + account.familyName);
    tr.append(nameTd);

    const birthDateTd = document.createElement("td");
    birthDateTd.append(String(account.birthDate).substring(0, 10));
    tr.append(birthDateTd);

    const marriageTd = document.createElement("td");
    marriageTd.append(marriage());
    tr.append(marriageTd);

    function marriage() {
        if (account.marriageId == null)
            return "";
        if (account.id == account.marriage.firstPersonId) {
            return account.marriage.secondPersonData;
        }
        else {
            return account.marriage.firstPersonData;
        }
    }

    const emailTd = document.createElement("td");
    emailTd.append(account.email);
    tr.append(emailTd);

    const phoneTd = document.createElement("td");
    phoneTd.append(account.phone);
    tr.append(phoneTd);

    const linksTd = document.createElement("td");

    const editLink = document.createElement("a");
    editLink.setAttribute("data-id", account.id);
    editLink.setAttribute("style", "cursor:pointer;padding:10px;width:70px;margin:3px;color:white;");
    editLink.setAttribute("class", "btn btn-primary")
    editLink.append("Edit");
    editLink.addEventListener("click", e => {
        e.preventDefault();
        location.href = "/CityAdministration/Edit.html?Id=" + account.id;
    });
    linksTd.append(editLink);

    const removeLink = document.createElement("a");
    removeLink.setAttribute("data-id", account.id);
    removeLink.setAttribute("style", "cursor:pointer;padding:10px;width:70px;margin:3px;color:white;");
    removeLink.setAttribute("class", "btn btn-danger")
    removeLink.append("Delete");
    removeLink.addEventListener("click", e => {
        if (confirm("Do you want to delete?")) {
            e.preventDefault();
            DeleteAccount(account.id);
        }
    });

    linksTd.append(removeLink);
    tr.appendChild(linksTd);
    return tr;
}