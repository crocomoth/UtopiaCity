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
    const gender = form.elements["gender"].value;
    const marriageId = form.elements["marriageId"].value == "" ? null : form.elements["marriageId"].value;
    const birthPlace = form.elements["birthPlace"].value;
    const registrationAddress = form.elements["registrationAddress"].value;
    const medicalRecords = form.elements["medicalRecords"].value;
    const property = form.elements["property"].value;
    const motorTransport = form.elements["motorTransport"].value;
    const email = form.elements["email"].value;
    const phone = form.elements["phone"].value;
    if (id == 0)
        CreateAccount(firstName, familyName, birthDate, gender, birthPlace, registrationAddress, medicalRecords, property, motorTransport, email, phone);
    else
        EditAccount(id, firstName, familyName, birthDate, gender, marriageId, birthPlace, registrationAddress, medicalRecords, property, motorTransport, email, phone);
});

// add account
async function CreateAccount(accFirstName, accFamilyName, accBirthDate,
    accGender, accBirthPlace, accRegistrationAddress, accMedicalRecords,
    accProperty, accMotorTransport, accEmail, accPhone) {

    const response = await fetch("/ResidentAccountApi/", {
        method: "POST",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify({
            firstName: accFirstName,
            familyName: accFamilyName,
            birthDate: accBirthDate,
            gender: accGender,
            birthPlace: accBirthPlace,
            registrationAddress: accRegistrationAddress,
            medicalRecords: accMedicalRecords,
            property: accProperty,
            motorTransport: accMotorTransport,
            email: accEmail,
            phone: accPhone
        })
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
            if (errorData.errors["$.birthDate"]) {
                errorMsg += "Please enter the Birth Date" + "<br>";
            }
            document.getElementById("errors").style.display = "block"
            document.getElementById("errors").innerHTML = errorMsg;
        }
    }
}

// edit account
async function EditAccount(id, accFirstName, accFamilyName, accBirthDate,
    accGender, accMarriageId, accBirthPlace, accRegistrationAddress, accMedicalRecords,
    accProperty, accMotorTransport, accEmail, accPhone) {
    const response = await fetch("/ResidentAccountApi/", {
        method: "PUT",
        headers: { "Accept": "application/json", "Content-Type": "application/json" },
        body: JSON.stringify({
            id: id,
            firstName: accFirstName,
            familyName: accFamilyName,
            birthDate: accBirthDate,
            gender: accGender,
            marriageId: accMarriageId,
            birthPlace: accBirthPlace,
            registrationAddress: accRegistrationAddress,
            medicalRecords: accMedicalRecords,
            property: accProperty,
            motorTransport: accMotorTransport,
            email: accEmail,
            phone: accPhone,
        })
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