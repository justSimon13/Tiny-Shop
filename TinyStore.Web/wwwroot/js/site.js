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

const input = document.querySelector('.search-input');
const suggestions = document.querySelector('.suggestions');

input.addEventListener('input', async () => {
    const query = input.value.trim();
    console.log(query);
    if (query.length < 2) {
        suggestions.classList.add('hidden');
    return;
}

const res = await fetch(`/Product/Suggestions?term=${encodeURIComponent(query)}`);
const data = await res.json();

if (data.length === 0) {
    suggestions.innerHTML = '';
    suggestions.classList.add('hidden');
    return;
}

suggestions.innerHTML = data.map(p =>
        `<a href="/Product/Details/${p.id}" class="block px-4 py-2 hover:bg-gray-100 text-left text-sm text-gray-800">${p.name}</a>`
    ).join('');

    suggestions.classList.remove('hidden');
});

document.addEventListener('click', (e) => {
    if (!suggestions.contains(e.target) && e.target !== input) {
    suggestions.classList.add('hidden');
    }
});

