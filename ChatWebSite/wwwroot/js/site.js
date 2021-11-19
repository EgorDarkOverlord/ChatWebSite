var userMenuButton = document.querySelector("#user-menu-button");
var userMenu = document.querySelector("#user-menu");

function toggleMenu() {
    userMenu.classList.toggle("visible");
}

var userMenuButtonRect = userMenuButton.getBoundingClientRect();
userMenu.style.width = userMenuButton.clientWidth + "px";
userMenu.style.left = userMenuButtonRect.left + "px"
userMenu.style.top = userMenuButtonRect.bottom + "px"

userMenuButton.addEventListener("click", function (e) {
    e.stopPropagation();
    toggleMenu();
});

document.addEventListener("click", function (e) {
    var target = e.target;
    var its_userMenu = target == userMenu || userMenu.contains(target);
    var its_userMenuButton = target == userMenuButton;
    var menu_is_active = userMenu.classList.contains("visible");

    if (!its_userMenu && !its_userMenuButton && menu_is_active) {
        toggleMenu();
    }
});
