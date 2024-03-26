let expiredDateValue;
function getCurrentClientName(clientsISP) {
    let presentationElement = document.getElementById("demo");

    var clientId = document.getElementById("clientId").value;

    presentationElement.innerHTML = "";

    let findedClient = clientsISP.find(c => c.Id === clientId);

    if (findedClient) {

        document.getElementById("clientName").value = findedClient.FullName;
        document.getElementById("clientPhone").value = findedClient.Phone;
        document.getElementById("clientEmail").value = findedClient.Email;
        document.getElementById("clientAddress").value = findedClient.Address;

        expiredDateValue = findedClient.ExpiredDate.split("T")[0];
        let today = new Date().toISOString().split("T")[0];

        fetch("Api/Get")
            .then(response => response.json())
            .then(data => {

                if (data.find(x => x.clientId === clientId)) {

                    let token = document.querySelector('input[name="X-CSRF-TOKEN"]').value

                    let message = "The Client: " + findedClient.FullName +
                        "is already exist in the database. You can add a payment to it."

                    $.ajax({
                        type: "POST",
                        url: 'Home/SetTempData?data=' + message,
                        headers: {
                            "X-CSRF-TOKEN": token
                        },
                        success: function (r) {
                            window.location.href = "Clients/Details/" + clientId;
                        }
                    });
                }
                else {
                    $("#monthSelect option").prop("selected", function () {
                        return this.defaultSelected;
                    });
                    let monthsToAdd = document.getElementById("monthSelect");
                    monthsToAdd.removeAttribute("hidden");
                    let hiddenElements = document.querySelectorAll(".hidden");
                    hiddenElements.forEach(element => {
                        element.removeAttribute("hidden");
                    });

                    presentationElement.removeAttribute("hidden");
                    let div = domCreator("div", "", presentationElement, "", ["border-primary"])
                    div.setAttribute("style", "padding:10px")
                    domCreator("h6", "Replay from ISP Router: ", div, "", ["font-weight-bold"])
                    domCreator("hr", "", div);
                    domCreator("h6", "Activated: " + findedClient.ActivationDate.split("T")[0], div, "", ["fw-bold"])
                    if (today > expiredDateValue) {
                        domCreator("h6", "Expired on: " + findedClient.ExpiredDate.split("T")[0], div, "", ["text-danger", "fw-bold"], { style: "padding-top: 1px" })
                    }
                    else {
                        domCreator("h6", "Expires: " + findedClient.ExpiredDate.split("T")[0], div, "", ["text-success", "fw-bold"], { style: "padding-top: 1px" })
                    }
                    domCreator("h6", "Tel: " + findedClient.Phone, div, "", ["card-title"]);
                    domCreator("hr", "", div);
                }
            })

    }

}

function editExpiredDate() {
    let monthsToAdd = document.getElementById("month");
    let date = new Date(expiredDateValue);
    let newDate = date.setMonth(date.getMonth() + parseInt(monthsToAdd.value));
    let finalDate = new Date(newDate).toISOString().split("T")[0];
    let dateNow = new Date().toISOString().split("T")[0];

    if (expiredDateValue > dateNow) {
        document.getElementById("expiredDate").value = finalDate;
    }
}

function printInvoice() {


    var formData = {};
    var inputElements = document.querySelectorAll("input");
    inputElements.forEach(function (inputElement) {
        formData[inputElement.id] = inputElement.value;
    });


    window.print();


    for (var key in formData) {
        if (formData.hasOwnProperty(key)) {
            var inputElement = document.getElementById(key);
            if (inputElement) {
                inputElement.value = formData[key];
            }
        }
    }



}

function showElement() {
    var element = document.getElementById("bancAccount");
    if (element.style.display === "none" || element.style.display === "") {
        element.style.display = "block";
    } else {
        element.style.display = "none";
    }
}



setTimeout(function () {
    $('#alert').fadeOut(1000);
}, 10000);

function makeCardTechProblem(clientsISP) {

    let presentationElement = document.getElementById("demoCard");
    let clientId = document.getElementById("ClientId").value;
    presentationElement.innerHTML = "";

    let findedClient = clientsISP.find(c => c.Id === clientId);

    document.getElementById("clientPhone").value = findedClient.Phone;
    document.getElementById("clientEmail").value = findedClient.Email;
    document.getElementById("clientAddress").value = findedClient.Address;

    let clientName = document.getElementById("ClientNameId");

    clientName.value = findedClient.FullName;
    if (findedClient) {
        presentationElement.removeAttribute("hidden");
        presentationElement.className = "card col-12";
        let div = domCreator("div", "", presentationElement, "", ["card-body"]);
        domCreator("h4", findedClient.FullName, div, "", ["card-title", "mt-1"]);
        domCreator("hr", "", div);
        domCreator("h5", "Tel: " + findedClient.Phone, div, "", ["card-title", "mt-1"]);
        domCreator("h5", "Addres: " + findedClient.Address, div, "", ["card-title", "mt-1"]);
        domCreator("h5", "Email: " + findedClient.Email, div, "", ["card-title", "mt-1"]);
    }
    let commentElement = document.getElementById("Description");
    let demoDesk = document.getElementById("demoDesc");
    demoDesk.removeAttribute("hidden");
    demoDesk.innerHTML = "";
    let h5 = domCreator("h5", "", demoDesk, "", ["card", "col-12", "p-3"]);
    commentElement.addEventListener("input", function () {
        h5.innerHTML = commentElement.value;
    });
}

function domCreator(type, content, parent, id, classes, attributes) {
    let newElement = document.createElement(type);

    if (content && type === "input") {
        newElement.value = content;
    }
    if (content && type !== "input") {
        newElement.textContent = content;
    }
    if (id) {
        newElement.id = id;
    }
    if (classes) {
        newElement.classList.add(...classes);
    }
    if (attributes) {
        for (const id in attributes) {
            newElement.setAttribute(id, attributes[id]);
        }
    }
    if (parent) {
        //console.log(parent);
        parent.appendChild(newElement);
    }
    return newElement;
}

$(function () {
    $("#clientId").select2();
});

$(function () {
    $("#ClientId").select2();
});
function loadFile(event) {
    var output = document.getElementById('output');
    output.src = URL.createObjectURL(event.target.files[0]);
    output.onload = function () {
        URL.revokeObjectURL(output.src) // free memory
    }
};

$("#name-input").focusout(function () {
    let name = $("#name-input").val();

    if (name.length != 0) {
        $('#output-name').text("Expense for: " + name);
    }
})

$("#value-input").focusout(function () {
    let value = $("#value-input").val();

    if (value.length != 0) {
        $('#output-value').text("Price: " + value);
    }
})

$("#description-input").focusout(function () {
    let description = $("#description-input").val();

    if (description.length != 0) {
        $('#output-description').text("Description: " + description);
    }
})


$("#showRandomRecord").click(function () {
    fetch("/Api/Get")
        .then(response => response.json())
        .then(data => {

            let random = Math.floor(Math.random() * data.length);

            while (data[random].pending) {
                random = Math.floor(Math.random() * data.length);
            }
            let clientName = data[random].fullName;
            let h4 = domCreator("h4", "", "", "", ["text-primary"]);
            let randomRecord = document.getElementById("randomRecord");
            randomRecord.innerHTML = "";
            randomRecord.appendChild(h4);

            let clientId = data[random].clientId;
            let token = document.querySelector('input[name="X-CSRF-TOKEN"]').value

            $.ajax({
                type: "POST",
                url: '/Home/SetTempData?data=' + clientName + " WIN one mounth FREE!!! Payment",
                headers: {
                    "X-CSRF-TOKEN": token
                },
                success: function (r) {
                    $.ajax({
                        type: "POST",
                        url: '/Promotion/Add',
                        headers: {
                            "X-CSRF-TOKEN": token
                        },
                        data: { clientId: clientId },
                        success: function (r) {
                            h4.innerHTML = "";
                            window.location.href = "/Clients/Details/" + clientId;
                        },
                        error: function (r) {
                            h4.textContent = "Error:  " + JSON.stringify(r.status);
                        }
                    })

                }
            });
        })
});
