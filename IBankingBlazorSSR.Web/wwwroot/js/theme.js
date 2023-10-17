window.detectAndApplyTheme = function() {
    const storedTheme = localStorage.getItem('theme');
    const prefersDark = window.matchMedia('(prefers-color-scheme: dark)').matches;

    if (storedTheme) {
        document.documentElement.classList.add(`theme-${storedTheme}`);
    } else if (prefersDark) {
        document.documentElement.classList.add('theme-monokai');
    } else {
        document.documentElement.classList.remove('theme-monokai');
    }
}
