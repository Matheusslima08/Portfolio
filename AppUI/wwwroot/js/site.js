function showModal(id) {
    var modal = document.getElementById(id);
    modal.style.display = "flex";
    modal.hidden = false;
}

function closeModal(id) {
    var modal = document.getElementById(id);
    modal.style.display = "none";
    modal.hidden = true;
}

function showOrCloseModal(id) {
    let modal = document.getElementById(id);
    let displayed = modal.style.display;
    let hidden = modal.hidden;
    if (displayed == "none" || hidden == true) {
        showModal(modal.id);
    }
    else {
        closeModal(modal.id);
    }
}

function showLoading() {
    showModal('loading-square');
}

function hideLoading() {
    closeModal('loading-square');
}

function setItemInDropdown(dropdownId, value) {
    var dropdown = document.getElementById(dropdownId);
    for (var i = 0; i < dropdown.options.length; i++) {
        if (dropdown.options[i].value == value) {
            dropdown.selectedIndex = i;
            break;
        }
    }
}

function showToast(type, message) {
    const toastContainer = document.getElementById("toast-container");

    const toast = document.createElement("div");
    toast.className = `toast-notification ${type}`;

    const icon = document.createElement("span");
    icon.className = "icon";
    icon.innerHTML = getIcon(type);

    const text = document.createElement("span");
    text.textContent = message;

    const closeBtn = document.createElement("button");
    closeBtn.className = "close-btn";
    closeBtn.innerHTML = "&times;";
    closeBtn.onclick = () => removeToast(toast);

    const progress = document.createElement("div");
    progress.className = "progress";

    toast.append(icon, text, closeBtn, progress);
    toastContainer.appendChild(toast);

    let progressWidth = 100;
    const interval = setInterval(() => {
        progressWidth -= 1;
        progress.style.width = `${progressWidth}%`;
        if (progressWidth <= 0) {
            clearInterval(interval);
            removeToast(toast);
        }
    }, 20);
}

function removeToast(toast) {
    toast.style.animation = "slideOut 0.5s forwards"; // Animação de saída
    setTimeout(() => toast.remove(), 500); // Remove após a animação
}

function getIcon(type) {
    switch (type) {
        case "success":
            return "✅";
        case "error":
            return "❌";
        case "warning":
            return "⚠️";
        case "info":
            return "ℹ️";
        default:
            return "";
    }

    // 1. Menu Responsivo (Hamburger Menu)
    const menuToggle = document.querySelector(".menu-toggle");
    const navMenu = document.querySelector(".nav-menu");

    menuToggle.addEventListener("click", () => {
        navMenu.classList.toggle("active");
    });

    // 2. Scroll Suave para os links do menu
    const menuLinks = document.querySelectorAll('.nav-menu a[href^="#"]');

    menuLinks.forEach(link => {
        link.addEventListener("click", function (e) {
            e.preventDefault();
            const targetId = this.getAttribute("href");
            const targetElement = document.querySelector(targetId);

            if (targetElement) {
                window.scrollTo({
                    top: targetElement.offsetTop - 50, // Ajusta o scroll para não sobrepor o header
                    behavior: "smooth",
                });
            }
            // Fechar o menu no mobile após clicar
            navMenu.classList.remove("active");
        });
    });

    // 3. ScrollReveal para animações ao rolar a página
    const revealElements = document.querySelectorAll(".reveal");

    function revealOnScroll() {
        revealElements.forEach((el) => {
            const windowHeight = window.innerHeight;
            const elementTop = el.getBoundingClientRect().top;
            const revealPoint = 150;

            if (elementTop < windowHeight - revealPoint) {
                el.classList.add("active");
            } else {
                el.classList.remove("active");
            }
        });
    }

    window.addEventListener("scroll", revealOnScroll);

    // 4. Botão "Voltar ao Topo"
    const backToTopButton = document.querySelector(".back-to-top");

    window.addEventListener("scroll", () => {
        if (window.scrollY > 500) {
            backToTopButton.classList.add("show");
        } else {
            backToTopButton.classList.remove("show");
        }
    });

    backToTopButton.addEventListener("click", () => {
        window.scrollTo({
            top: 0,
            behavior: "smooth",
        });
    });

}