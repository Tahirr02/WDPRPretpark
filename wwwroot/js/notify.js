"use strict";

const NotifyConnection = new signalR.HubConnectionBuilder().withUrl("/notifyhub").build();
const attractieId = document.getElementById('Id').value;


NotifyConnection.on("ReceiveMessage", (beschikbaarPlekken) => {
    document.getElementById("plekkenInfo").textContent = beschikbaarPlekken;
    checkDisable(beschikbaarPlekken);
})

NotifyConnection.on("ReceiveLikes", (likes) => {
    document.getElementById("likes").textContent = likes;
    // document.getElementById("likeBtn").disabled = true;
})

NotifyConnection.on("LoadPlekken", (beschikbaarPlekken) => {
    checkDisable(beschikbaarPlekken);
})

NotifyConnection.start().then(function () {
    NotifyConnection.invoke('getAvailable', attractieId)
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("likeBtn").addEventListener("click", (event) => {
    
    NotifyConnection.invoke("SendLike", attractieId).catch( (err) => {
        return console.error.apply(err.toString());
    })
})


function checkDisable(beschikbaarPlekken){
    if(beschikbaarPlekken == 0){
        document.getElementById("bookBtn").disabled = true;
        document.getElementById("AantalPlekkenVak").disabled = true;
        document.getElementById("TijdslotVak").disabled = true;
    }
}