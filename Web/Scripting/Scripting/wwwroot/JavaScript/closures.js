/* Exemple de présentation */
function fonctionParente(argClos) {
    // Mémoriser l'argument reçu (argClos pourrait être utilisé directement par la sousFonction)
    var varLocale = argClos;
    // Fn imbriquée (closure) qui utilise et mémorise les données (arguments et variables locales) de la fn parente
    function sousFonction(argSF) {
        return varLocale + argSF;
    }

    // retour de la fn imbriquée
    return sousFonction;
}

// Référence de la sous-fonction retournée par la fonction parente avec
// mémorisation des variables de la fn parente au moment de l'appel, dans
// une closure (la variable sousFn dans l'exemple ci-dessous).
var sousFn = fonctionParente(1);

// Appel de la sous-fonction par le biais de la closure avec des valeurs réceptionnées
// par argSF et additionnées à argClos dont la valeur 1 a été mémorisée.

// Exemple : ajouter successivement 10 et 20 à 1

//afficherMessage("sousFn(10) : " + sousFn(10)); // 11
//afficherMessage("sousFn(20) : " + sousFn(20)); // 21

/* Décalage horaire : même principe, pour monter que l'on peut créer plusieurs contextes */

function decalageHoraire(decalage) {
    // Rendre la closure explicite avec déclaration d'une variable locale
    var d = decalage;
    return function (heure) {
        return (heure + d) % 24;
    };
}

var decalage2 = decalageHoraire(2);
var decalage10 = decalageHoraire(10);

//afficherMessage(decalage2(1));  // 3
//afficherMessage(decalage2(5));  // 7
//afficherMessage(decalage10(1)); // 11
//afficherMessage(decalage10(5)); // 15
//afficherMessage(decalage10(13)); // 23
//afficherMessage(decalage10(14)); // 0
//afficherMessage(decalage10(15)); // 1

/* Gestion de stock : contexte partagé par plusieurs méthodes */
var gestionStock = (function () {
    var nbrArticles = 0;
    function mouvement(qte) {
        nbrArticles += qte;
    }
    return {
        entrees: function (qte) {
            mouvement(qte);
        },
        sorties: function (qte) {
            mouvement(-qte);
        },
        qteDispo: function () {
            return nbrArticles;
        }
    };
})();

gestionStock.entrees(50);
//afficherMessage(gestionStock.qteDispo()); /* Affiche 50 */
gestionStock.sorties(10);
//afficherMessage(gestionStock.qteDispo()); /* Affiche 40 */
