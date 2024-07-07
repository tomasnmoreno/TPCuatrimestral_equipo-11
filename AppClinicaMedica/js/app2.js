/*console.log('hola');*/

document.addEventListener("DOMContentLoaded", () => {

    //selec de elementosdel DOM//
    const toggleButton = document.querySelector(".navbar__toggle-btn");
    const mobileMenu = document.querySelector(".navbar__mobile-menu");

    //console.log(mobileMenu)

    //si el menu esta 
    const toggleMenu = () => {
        event.preventDefault();
        mobileMenu.style.display =
            mobileMenu.style.display === "none" || mobileMenu.style.display === ""
                ? "flex"
                : "none";
    };

    const hideMenuResize = () => {
        mobileMenu.style.display = "none"
    }

    toggleButton.addEventListener("click", toggleMenu);
    window.addEventListener("resize", hideMenuResize);
    window.addEventListener("load", hideMenuResize);

});

//function abrirVentanaEmergente() {
//    window.open("NuevoMedico.aspx", "MiVentanaEmergente", "width=400,height=300");
//}
