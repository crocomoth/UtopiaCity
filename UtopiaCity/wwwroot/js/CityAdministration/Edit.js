window.onload = function () {
    var id = window.location.search?.substring(4);
    const form = document.forms["accountForm"];
    form.elements["id"].value = id;
    if (id != 0)
        GetAccount(id);
    else reset();
}

//get account by id
async function GetAccount(id) {
    const response = await fetch("/ResidentAccountApi/" + id, {
        method: "GET",
        headers: { "Accept": "application/json" }
    });
    if (response.ok === true) {
        const account = await response.json();
        const form = document.forms["accountForm"];
        form.elements["id"].value = account.id;
        form.elements["firstName"].value = account.firstName;
        form.elements["familyName"].value = account.familyName;
        form.elements["birthDate"].value = String(account.birthDate).substring(0, 10);
        form.elements["gender"].value = account.gender;
        form.elements["marriageId"].value = account.marriageId;
        form.elements["birthPlace"].value = account.birthPlace;
        form.elements["registrationAddress"].value = account.registrationAddress;
        form.elements["medicalRecords"].value = account.medicalRecords;
        form.elements["property"].value = account.property;
        form.elements["motorTransport"].value = account.motorTransport;
        form.elements["email"].value = account.email;
        form.elements["phone"].value = account.phone;
    }
}

// send form
document.forms["accountForm"].addEventListener("submit", e => {
    e.preventDefault();
    const form = document.forms["accountForm"];
    const id = form.elements["id"].value;
    const firstName = form.elements["firstName"].value;
    const familyName = form.elements["familyName"].value;
    const birthDate = form.elements["birthDate"].value;
    const gender = form.elements["gender"].value == "0" ? 0 : 1;
    const marriageId = form.elements["marriageId"].value == "" ? null : form.elements["marriageId"].value;
    const birthPlace = form.elements["birthPlace"].value;
    const registrationAddress = form.elements["registrationAddress"].value;
    const medicalRecords = form.elements["medicalRecords"].value;
    const property = form.elements["property"].value;
    const motorTransport = form.elements["motorTransport"].value;
    const email = form.elements["email"].value;
    const phone = form.elements["phone"].value;
    const dataCreate = {
        firstName: firstName,
        familyName: familyName,
        birthDate: birthDate,
        birthPlace: birthPlace,
        gender: gender,
        registrationAddress: registrationAddress,
        property: property,
        motorTransport: motorTransport,
        medicalRecords: medicalRecords,
        phone: phone,
        email: email
    };
    const dataEdit = {
        id: id,
        firstName: firstName,
        familyName: familyName,
        birthDate: birthDate,
        gender: gender,
        marriageId: marriageId,
        birthPlace: birthPlace,
        registrationAddress: registrationAddress,
        medicalRecords: medicalRecords,
        property: property,
        motorTransport: motorTransport,
        email: email,
        phone: phone
    };
    if (id == 0)
        CreateAccount(dataCreate);
    else
        EditAccount(dataEdit);
});

// add account
async function CreateAccount(dataCreate) {

    const response = await fetch("/ResidentAccountApi/", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify(dataCreate)
    });
    if (response.ok === true) {
        location.href = "/CityAdministration/Index.html";
    }
    else {
        const errorData = await response.json();
        var errorMsg = "(server side validation) <br>";
        console.log("errors", errorData);
        if (errorData.errors) {
            if (errorData.errors["FirstName"]) {
                errorMsg += errorData.errors["FirstName"] + "<br>";
            }
            if (errorData.errors["FamilyName"]) {
                errorMsg += errorData.errors["FamilyName"] + "<br>";
            }
            if (errorData.errors["Email"]) {
                errorMsg += errorData.errors["Email"] + "<br>";
            }
            document.getElementById("errors").style.display = "block"
            document.getElementById("errors").innerHTML = errorMsg;
        }
    }
}

// edit account
async function EditAccount(dataEdit) {
    const response = await fetch("/ResidentAccountApi/", {
        method: "PUT",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify(dataEdit)
    });
    if (response.ok === true) {
        location.href = "/CityAdministration/Index.html";
    }
}

// reset form
function reset() {
    const form = document.forms["accountForm"];
    form.reset();
    form.elements["id"].value = null;
    document.getElementById("errors").style.display = "none";
}