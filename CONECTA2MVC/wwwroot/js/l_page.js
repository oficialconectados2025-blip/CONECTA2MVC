document.addEventListener("DOMContentLoaded", () => {
    const intro = document.getElementById("intro-screen");
    const landing = document.getElementById("landing-screen");

    // Duración de la animación de tu escena en Spline (ajustala si la animación dura más)
    const introDuration = 4300; // 4 segundos

    // Ocultar intro y mostrar landing automáticamente
    setTimeout(() => {
        intro.classList.add("intro-hidden");

        setTimeout(() => {
            landing.classList.add("landing-visible");
        }, 600); // Espera a que la intro se desvanezca
    }, introDuration);
});
