﻿var Chats = document.querySelectorAll(".Chat");

for (var i = 0; i < Chats.length; i++) {
    Chats[i].onmousedown = function () { return false; };
    Chats[i].onselectstart = function () { return false; };
    //Chats[i].onmouseover = function () { this.querySelector(".Cross").style.display = "block"; };
    //Chats[i].onmouseout = function () { this.querySelector(".Cross").style.display = "none"; };
}

var ShowCreateChatButton = document.getElementById("ShowCreateChat");
var HideCreateChatLink = document.getElementById("HideCreateChat");
var Modal = document.getElementById("Modal");

ShowCreateChatButton.addEventListener("click", function () {
    Modal.style.display = "flex";
});

HideCreateChatLink.addEventListener("click", function () {
    Modal.style.display = "none";
});