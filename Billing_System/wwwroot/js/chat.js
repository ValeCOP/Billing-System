"use strict";

let connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

let sendButton = document.getElementById("sendButton").disabled = true;

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("ReceiveMessage", function (user, message) {

    addMessageToChat(user, message);
});
connection.on("UserConnected", function (user) {

    if (user !== null) {

        let statusElement = document.getElementById("status");
        statusElement.className = "alert alert-success";
        statusElement.textContent = `${user} has joined the chat`;
        statusElement.style.display = "block";

        setTimeout(function () {
            $('#status').fadeOut(1000);
        }, 10000);

        let token = document.querySelector('input[name="__RequestVerificationToken"]').value

        let data = { user: user, message: `${user} has joined the chat` };

        saveChat(token, data);
    }
});
connection.on("UserDisconnected", function (user) {

    if (user !== null) {
        let statusElement = document.getElementById("status");

        statusElement.className = "alert alert-danger";
        statusElement.textContent = `${user} has left the chat`;
        statusElement.style.display = "block";
        setTimeout(function () {
            $('#status').fadeOut(1000);
        }, 10000);


        let token = document.querySelector('input[name="__RequestVerificationToken"]').value

        let data = { user: user, message: `${user} has left the chat` };

        saveChat(token, data);

    }
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    let user = document.getElementById("userInput").value;
    let message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
    document.getElementById("messageInput").value = "";
});

var isTyping = false;
connection.on("UserTyping", function (user, isTyping) {
    if (isTyping) {
        let statusElement = document.getElementById("status");
        statusElement.className = "alert alert-warning";
        statusElement.textContent = `${user} is typing...`;
        statusElement.style.display = "block";
        setTimeout(function () {
            $('#status').fadeOut(2000);
        }, 5000);

    }
});
document.getElementById("messageInput").addEventListener("input", function () {

    let user = document.getElementById("userInput").value;
    if (!isTyping) {
        isTyping = true;
        connection.invoke("StartTyping", user).catch(function (err) {
            return console.error(err.toString());
        });
    }
    setTimeout(function () {
        isTyping = false;
    }, 5000);
});
document.getElementById("messageInput").addEventListener("keypress", function (event) {
    if (event.keyCode === 13) {
        event.preventDefault();
        document.getElementById("sendButton").click();
        document.getElementById("messageInput").focus();
        return false;
    }
});
function addMessageToChat(user, message) {

    var message = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    let chat = document.getElementById("messagesList");
    let dateTimeNow = new Date().toLocaleString();

    let div1 = document.createElement("div");
    div1.textContent = `${user} ${dateTimeNow}`;
    chat.insertBefore(div1, chat.children[0]);

    let div = document.createElement("div");
    div.textContent = `${message}`;
    div.className = "alert alert-info";
    chat.insertBefore(div, chat.children[1]);

    if (chat.children.length >= 10) {
        chat.removeChild(chat.children[9]);
        chat.removeChild(chat.children[9]);
    };
    let allMessages = JSON.parse(localStorage.getItem("chatMessages")) || [];
    allMessages.push(user + ": " + message);
    localStorage.setItem("chatMessages", JSON.stringify(allMessages));
}
function saveChat(token, data) {
    fetch('/Chat/SaveChat/', {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
            '__RequestVerificationToken': token
        },
        //body: JSON.stringify(data)
    })
        .then(r => console.log(r))
        .catch(error => console.error('Unable to update item.', error));
}