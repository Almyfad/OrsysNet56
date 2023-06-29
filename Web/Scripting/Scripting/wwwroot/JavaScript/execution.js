function bonjourJS() {
    var msg = document.getElementById("divMsg");
    msg.innerHTML = "Bonjour JavaScript !";
}

function debogage() {
    console.clear();

    for (var i = 0; i < 10; i++) {
        console.log("Valeur " + i);
    }
}

function gestionErreur() {
    try {
        // La variable message n'existe pas
        alert(message);
    } catch (e) {
        // Afficher l'erreur
        alert("Erreur : " + e);
    }
}