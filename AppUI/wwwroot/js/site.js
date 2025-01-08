// JavaScript para funcionalidades dinâmicas do portfólio

// Seletores
const menuToggle = document.querySelector(".menu-toggle");
const navLinks = document.querySelector(".nav-links");
const backToTopButton = document.createElement("button");

// Função para alternar menu mobile
menuToggle.addEventListener("click", () => {
    navLinks.classList.toggle("active");
    menuToggle.classList.toggle("active");
});

// Botão Voltar ao Topo
document.body.appendChild(backToTopButton);
backToTopButton.className = "back-to-top";
backToTopButton.innerHTML = "<i class='fas fa-arrow-up'></i>";

window.addEventListener("scroll", () => {
    if (window.scrollY > 300) {
        backToTopButton.classList.add("visible");
    } else {
        backToTopButton.classList.remove("visible");
    }
});

backToTopButton.addEventListener("click", () => {
    window.scrollTo({ top: 0, behavior: "smooth" });
});

// Scroll suave para links do menu
const navItems = document.querySelectorAll(".nav-links a");
navItems.forEach((item) => {
    item.addEventListener("click", (e) => {
        e.preventDefault();
        const targetId = item.getAttribute("href").slice(1);
        const targetSection = document.getElementById(targetId);

        if (targetSection) {
            window.scrollTo({
                top: targetSection.offsetTop - 60, // Ajusta o deslocamento
                behavior: "smooth",
            });
        }
    });
});

// Animações com ScrollReveal
ScrollReveal().reveal(".hero-section", {
    origin: "left",
    distance: "100px",
    duration: 1000,
    reset: true,
});

ScrollReveal().reveal(".about-section, .projects-section, .knowledge-section, .contact-section", {
    origin: "bottom",
    distance: "50px",
    duration: 1000,
    interval: 200,
    reset: true,
});
