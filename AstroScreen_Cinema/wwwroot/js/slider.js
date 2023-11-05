//var swiper = new Swiper(".mySwiper"), {
//    slidesPerView: 3,
//    spaceBetween:30,
//    slidesPerGroup:3,
//    loop:true,
//    loopfillGroupWithBlank:true,
//    pagination: {
//        el: ".swiper-pagination",
//        clickable:true,

//    },
//    navigation:
//    {
//        nextE1: ".swiper-button-next",
//        prevE1: ".swiper-button-prev",

//    },

//};

document.addEventListener("DOMContentLoaded", function () {
    // Pobieramy linki i zawartość strony
    const homeLink = document.getElementById('home-link');
    const nowShowingLink = document.getElementById('now-showing-link');
    const offersLink = document.getElementById('offers-link');
    const loginLink = document.getElementById('login-link');
    const content = document.getElementById('content');

    // Dodajemy obsługę kliknięcia na link "Home"
    homeLink.addEventListener('click', function (e) {
        e.preventDefault(); // Zapobiegamy domyślnej nawigacji
        content.innerHTML = 'Jesteś na stronie głównej'; // Aktualizacja zawartości strony
    });

    // Dodajemy obsługę kliknięcia na link "Now showing"
    nowShowingLink.addEventListener('click', function (e) {
        e.preventDefault(); // Zapobiegamy domyślnej nawigacji
        content.innerHTML = 'Aktualnie grane filmy'; // Aktualizacja zawartości strony
    });

    // Dodajemy obsługę kliknięcia na link "Offers"
    offersLink.addEventListener('click', function (e) {
        e.preventDefault(); // Zapobiegamy domyślnej nawigacji
        content.innerHTML = 'Nasze aktualne promocje'; // Aktualizacja zawartości strony
    });

    // Dodajemy obsługę kliknięcia na link "Log In"
    loginLink.addEventListener('click', function (e) {
        e.preventDefault(); // Zapobiegamy domyślnej nawigacji
        content.innerHTML = 'Zaloguj się na swoje konto'; // Aktualizacja zawartości strony
    });
});