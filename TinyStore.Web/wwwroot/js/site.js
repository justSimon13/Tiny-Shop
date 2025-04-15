// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const toggleBtn = document.getElementById('menuToggle');
const navMenu = document.getElementById('navMenu');

let menuOpen = false;

toggleBtn.addEventListener('click', () => {
    menuOpen = !menuOpen;
    
    if (menuOpen) {
        navMenu.classList.remove('hidden');
        navMenu.classList.add('flex');
    } else {
        navMenu.classList.add('hidden');
        navMenu.classList.remove('flex');
    }
});
