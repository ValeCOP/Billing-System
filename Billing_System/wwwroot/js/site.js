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


//<div class="card col-4" style="width: 20rem; ">
//    <div class="card-body">
//        <h4 class="card-title mt-1">@e.Topic</h4>
//        <h5 class="card-title mt-1">@e.Lecturer</h5>
//        <h5 class="card-title mt-1">@e.Category</h5>
//        <p class="mb-0"><span class="fw-bold">Starting Time: </span>@e.DateAndTime</p>
//    </div>
//</div>
function makeCardTechProblem(clientsISP) {
    let presentationElement = document.getElementById("demoCard");
    let clientId = document.getElementById("ClientId").value;
    presentationElement.innerHTML = "";
    let findedClient = clientsISP.find(c => c.Id === clientId);
    if (findedClient) {
        presentationElement.removeAttribute("hidden");
        presentationElement.className = "card col-12";
        let div = domCreator("div", "", presentationElement, "", ["card-body"]);
        domCreator("h4", findedClient.FullName, div, "", ["card-title", "mt-1"]);
        domCreator("h5", findedClient.Phone, div, "", ["card-title", "mt-1"]);
        domCreator("h5", findedClient.Address, div, "", ["card-title", "mt-1"]);
        domCreator("h5", findedClient.Email, div, "", ["card-title", "mt-1"]);
    }
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


