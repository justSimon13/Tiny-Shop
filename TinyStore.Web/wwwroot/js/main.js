import { initNavigationToggle } from './navigation.js';
import { initSearchSuggestions } from './search-suggestions.js';

document.addEventListener('DOMContentLoaded', () => {
    initNavigationToggle();
    initSearchSuggestions();
});
