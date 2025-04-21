export function initSearchSuggestions() {
    const input = document.querySelector('.search-input');
    const suggestions = document.querySelector('.suggestions');

    if (!input || !suggestions) return;

    input.addEventListener('input', async () => {
        const query = input.value.trim();
        if (query.length < 2) {
            suggestions.classList.add('hidden');
            return;
        }

        const res = await fetch(`/Product/Suggestions?term=${encodeURIComponent(query)}`);
        const data = await res.json();

        if (!data.length) {
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
}
