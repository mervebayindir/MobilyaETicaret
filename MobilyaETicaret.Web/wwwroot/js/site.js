

document.addEventListener("DOMContentLoaded", function () {
    function adjustMenu() {
        var width = window.innerWidth;
        var menu = document.querySelector('.sub-menu');
        if (width < 768) {
            menu.classList.add('sub-menu-m');
            menu.classList.remove('sub-menu');
        } else {
            menu.classList.add('sub-menu');
            menu.classList.remove('sub-menu-m');
        }
    }

    adjustMenu();
    window.onresize = adjustMenu;
});