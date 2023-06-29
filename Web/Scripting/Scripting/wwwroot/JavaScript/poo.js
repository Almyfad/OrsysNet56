
"use strict";
/* Créer un constructeur d'objet avec une fonction (casse Pascal) 
   dont les arguments sont mémorisés en Ptés publiques avec le mot réservé this 
   alors que les variables locales sont privées.
   ----------------------------------------------------------- */
function Contact(nom, prenom, age) {
    this.nom = nom;
    this.prenom = prenom;
    this.age = age;

    this.descriptif = function () {
        return this.prenom + " " + this.nom + " a " + this.age + " ans ";
    }
}

// Création d'instances avec new 
var contact1 = new Contact("Martin", "Jean", 27);
//afficherMessage("Contact1 avec ctor : " + contact1.descriptif());

var contact2 = new Contact("Doo", "John", 34);
//afficherMessage("Contact2 avec ctor : " + contact2.descriptif());

Contact.membreStatique = "valeur de la Pté statique" + "";
//afficherMessage("Contact.membreStatique : " +  Contact.membreStatique);

/* Créer un prototype d'objet : objet dont 
  les membres sont partagés par toutes les instances
  ---------------------------------------------------- */

function ContactAvecProto(nom, prenom, age) {
    this.nom = nom;
    this.prenom = prenom;
    this.age = age;
}

ContactAvecProto.prototype = {
    descriptif: function () {
        return this.prenom + " " + this.nom + " a " + this.age + " ans";
    },
    ste: "Orsys"
}

var contact1 = new ContactAvecProto("Martin", "Jean", 27);
//afficherMessage("Contact1 avec proto : " + contact1.descriptif());

var contact2 = new ContactAvecProto("Doe", "John", 34);
//afficherMessage("Contact2 avec proto : " + contact2.descriptif());

//afficherMessage("Sté contact2 avec proto : " + contact2.ste);

/* Définir une pté en lecture seule 
   ----------------------------------------*/

function ContactAvecPteLectureSeule(nom) {
    var _nom = nom;
    Object.defineProperty(this, "nom", {
        get: function () { return _nom; }
        // Syntaxe du setter
        //,
        //set: function (value) {_nom = value; }
    });
}

var contactPLS = new ContactAvecPteLectureSeule("Martin");

// Exception si le mode Strict est activé
contactPLS.nom = "Dupont";
//afficherMessage("Contact avec nom en lecture seule : " + contactPLS.nom);

/* Héritage
   ------------------------------------- */

function Employe(nom, prenom, age, poste) {
    // 2. Invoquer le Ctor de la classe de base
    Contact.call(this, nom, prenom, age);
    // Définir une valeur par défaut au poste si elle n'est pas fournie par l'appelant
    this.poste = poste || "Développeur";
}

// 1. Héritage par affectation du prototype de la classe de base
//    ce qui a pour effet d'affecter le Ctor de Contact à Employe
Employe.prototype = Object.create(Contact.prototype);

// 3. Mais on peut finalement réaffecter le bon Ctor
Employe.prototype.constructor = Employe;

var emp1 = new Employe("Martin", "Jean", 27, "Testeur");
var emp2 = new Employe("Durand", "Pierre", 27);

//afficherMessage("Employe dérivé de Contact : " + emp1.descriptif() + " et occupe le poste de " + emp1.poste);
//afficherMessage("Employe dérivé de Contact : " + emp2.descriptif() + " et occupe le poste de " + emp2.poste);

// L'opérateur instanceof
//console.log(emp1 instanceof Employe); // true
//console.log(emp1 instanceof Contact); // true
