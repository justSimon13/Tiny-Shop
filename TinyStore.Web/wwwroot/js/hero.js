export function initHero() {
    // Get all hero sections
    const heroSections = document.querySelectorAll('.hero-section');

    // Get the header element which contains the navigation
    const header = document.querySelector('header');

    if (heroSections.length === 0 || !header) return;

    // Set standard height for all hero sections
    const standardHeight = '70vh';
    const minHeight = '40vh';

    // Variables for scroll handling
    let ticking = false;

    // Handle initial layout - use a dynamic approach with a container
    const headerHeight = header.offsetHeight;
    const headerContainer = document.createElement('div');
    headerContainer.style.height = `${headerHeight}px`;
    headerContainer.style.width = '100%';
    headerContainer.style.transition = 'height 0.3s ease-out';
    header.parentNode.insertBefore(headerContainer, header);
    headerContainer.appendChild(header);

    // No padding on main needed since we're using a container
    document.querySelector('main').style.paddingTop = '0';

    // Initialize all hero sections with the standard height
    heroSections.forEach(section => {
        section.style.height = standardHeight;
        section.style.transition = 'height 0.3s ease-out';
    });

    // Set initial header styles
    header.style.position = 'fixed';
    header.style.top = '0';
    header.style.left = '0';
    header.style.width = '100%';
    header.style.zIndex = '50';
    header.style.backgroundColor = 'white';
    header.style.boxShadow = '0 2px 4px rgba(0,0,0,0.1)';
    header.style.transition = 'transform 0.3s ease-out';

    function updateHeaderAndHero() {
        const scrollY = window.scrollY;

        // We'll use the same threshold for both the header and hero
        // Trigger on a very small scroll amount
        const scrollThreshold = 20; // Just 20px of scrolling
        const shouldShrink = scrollY > scrollThreshold;

        // Update hero sections
        heroSections.forEach(section => {
            section.style.height = shouldShrink ? minHeight : standardHeight;
        });

        // Update header position - use the exact same condition
        if (shouldShrink) {
            header.style.transform = 'translateY(-100%)';
            // Also shrink the header container to remove white space
            headerContainer.style.height = '0';
        } else {
            header.style.transform = 'translateY(0)';
            headerContainer.style.height = `${headerHeight}px`;
        }

        ticking = false;
    }

    // Handle scroll events with requestAnimationFrame for performance
    function onScroll() {
        if (!ticking) {
            requestAnimationFrame(updateHeaderAndHero);
            ticking = true;
        }
    }

    // Handle window resize
    function onResize() {
        const newHeaderHeight = header.offsetHeight;
        if (!shouldShrink) {
            headerContainer.style.height = `${newHeaderHeight}px`;
        }
        updateHeaderAndHero();
    }

    // Check for mobile menu toggle to ensure it still works with fixed header
    const menuToggle = document.getElementById('menuToggle');
    const navMenu = document.getElementById('navMenu');

    if (menuToggle && navMenu) {
        menuToggle.addEventListener('click', () => {
            navMenu.classList.toggle('hidden');

            // When menu is opened, ensure header is visible
            if (!navMenu.classList.contains('hidden')) {
                header.style.transform = 'translateY(0)';
            }
        });
    }

    // Add event listeners
    window.addEventListener('scroll', onScroll, { passive: true });
    window.addEventListener('resize', onResize);

    // Initialize
    updateHeaderAndHero();
}