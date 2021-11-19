var Chats = document.querySelectorAll(".chat");

for (var i = 0; i < Chats.length; i++) {
    Chats[i].onmousedown = function () { return false; };
    Chats[i].onselectstart = function () { return false; };
    //Chats[i].onmouseover = function () { this.querySelector(".Cross").style.display = "block"; };
    //Chats[i].onmouseout = function () { this.querySelector(".Cross").style.display = "none"; };
}