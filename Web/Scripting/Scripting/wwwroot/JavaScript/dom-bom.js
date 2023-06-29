"use strict";

var divMsg;
var lien;

function init() {
    divMsg = document.getElementById("msg");
    lien = document.getElementById("lien");
    document.getElementById("btnEventListener").addEventListener("click", eventListener);
}

function eventListener() {
    effacerMessage();
    afficherMessage("EventListener attaché par la méthode addEventListener");
}

function listeInputs() {
    var elements = document.getElementsByTagName("input");
    effacerMessage();

    for (var i = 0; i < elements.length; i++) {
        afficherMessage(elements[i].type + ' ' + elements[i].value);
    }
}

function creerElement() {
    var p = document.createElement("p");
    var texte = document.createTextNode("Paragraphe créé dynamiquement.");
    p.appendChild(texte);

    divMsg.appendChild(p);
}

function supprimerElement() {
    var p = divMsg.lastChild;
    if (p != null) {
        divMsg.removeChild(p);
    } else {
        effacerMessage();
        afficherMessage("L'élément à supprimer n'existe pas !");
    }
}

function ajouterAttribut() {
    lien.style.fontSize = "20px";
}

function supprimerAttribut() {
    lien.style.fontSize = "";
}

function ajouterStyle() {
    lien.className = "classeLien";
}

function supprimerStyle() {
    lien.className = "";
}

var timer;

function horloge() {
    var d = new Date();
    divMsg.innerHTML = d.toLocaleTimeString();
}

function demarrerHorloge() {
    timer = setInterval(horloge, 1000);
}

/* variante avec une fn anonyme (plus besoin de la fn. horloge())
timer = setInterval(function () {
    var d = new Date();
    divMsg.innerHTML = d.toLocaleTimeString();
}, 1000); */

function stopperHorloge() {
    clearInterval(timer);
}

function dialogConfirm() {
    var reponse = confirm("Confirmation ?");

    if (reponse === true) {
        divMsg.innerHTML = "Vous avez répondu Oui !";
    }
    else {
        divMsg.innerHTML = "Vous avez répondu Non !";
    }
}

function dialogPrompt() {
    var saisie = prompt("Entrez une info", "Info par défaut");
    if (saisie != null) {
        divMsg.innerHTML = "Votre info : " + saisie;
    }
    else {
        divMsg.innerHTML = "Saisie annulée";
    }
}

function afficherFenetre(titre, message, largeur, hauteur) {
    var fenetre = window.open("", "_blank", "toolbar=no,directories=no,status=no,scrollbars=yes,resizable=yes,copyhistory=no," + "width=" + largeur + ",height=" + hauteur);
    var page = "<html><head><title>" + titre + "</title></head><body>";

    page += message + "<br /><br />";
    page += "<input type='button' value='fermer' onclick='window.close();'>";
    page += "</body></html>";
    fenetre.document.write(page);
}
