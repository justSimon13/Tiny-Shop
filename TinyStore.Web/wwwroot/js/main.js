import { initNavigationToggle } from './navigation.js';
import { initSearchSuggestions } from './search-suggestions.js';
import { initHero } from './hero.js';

document.addEventListener('DOMContentLoaded', () => {
    initNavigationToggle();
    initSearchSuggestions();
    initHero();
});
