function getCurrentClientName(clientsISP) {

    let presentationElement = document.getElementById("demo");

    var clientId = document.getElementById("clientId").value;

    presentationElement.innerHTML = "";

    let findedClient = clientsISP.find(c => c.Id === clientId);

    if (findedClient) {
        let element = document.getElementById("clientName");
        element.value = findedClient.FullName;

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
                    presentationElement.removeAttribute("hidden");
                    let div = domCreator("div", "", presentationElement, "", ["border-primary"])
                    div.setAttribute("style", "padding:10px")
                    domCreator("p", "Replay from ISP Router: ", div, "", ["font-weight-bold"], { style: "padding-top: 5px" })
                    domCreator("hr", "", div);
                    domCreator("div", "FROM Date: " + findedClient.ActivationDate.split("T")[0], div, "", ["text-danger", "fw-bold"], { style: "padding-top: 5px" })
                    domCreator("div", "TO Date: " + findedClient.ExpiredDate.split("T")[0], div, "", ["text-danger", "fw-bold"], { style: "padding-top: 5px" })
                    domCreator("hr", "", div);
                }
            })

    }

}
setTimeout(function () {
    $('#alert').fadeOut(200);
}, 5000);

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


