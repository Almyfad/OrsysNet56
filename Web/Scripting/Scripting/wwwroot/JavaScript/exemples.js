function afficherMessage(message) {
    var msg = document.getElementById("msg");
    msg.innerHTML += message + "<br/>";
}

function effacerMessage() {
    var msg = document.getElementById("msg");
    msg.innerHTML = "";
}

