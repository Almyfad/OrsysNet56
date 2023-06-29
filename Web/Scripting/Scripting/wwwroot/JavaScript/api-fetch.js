"use strict";

const request = new Request('/images/oiseau.jpg');
const image = document.querySelector('#image');

var btnRequete = document.getElementById("btnChargerImage");
btnRequete.addEventListener('click', () => { chargerImage(); });

function chargerImage() {

    fetch(request)
        .then(
            response => {
                if (response.status === 200) {
                    return response.blob();
                } else {
                    console.log('Le fichier n\'existe pas !');
                }
            }
        )
        .then(blob => {
            const objectURL = URL.createObjectURL(blob);
            image.src = objectURL;
            btnRequete.hidden = true;
        }).catch(error => {
            console.log(error + "!!!");
        });
}



