export function initNavigationToggle() {
    const toggleBtn = document.getElementById('menuToggle');
    const navMenu = document.getElementById('navMenu');

    if (!toggleBtn || !navMenu) return;

    let menuOpen = false;

    toggleBtn.addEventListener('click', () => {
        menuOpen = !menuOpen;
        navMenu.classList.toggle('hidden', !menuOpen);
        navMenu.classList.toggle('flex', menuOpen);
    });
}
