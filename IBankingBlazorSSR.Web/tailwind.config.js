/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        './Components/*.razor',
        './Components/**/*.razor'
    ],
    theme: {
        extend: {
            colors: {
                skin: {
                    base: 'var(--color-base)',
                    base2: 'var(--color-base2)',
                    muted: 'var(--color-muted)',
                    inverted: 'var(--color-inverted)',
                    fill: 'var(--color-fill)',
                    fill_accent: 'var(--color-fill-accent)',
                    button_accent: 'var(--color-button-accent)',
                    button_accent_hover: 'var(--color-button-accent-hover)',
                    button_muted: 'var(--color-button-muted)',
                },
            },
            textColor: {
                skin: {
                    base: 'var(--color-base)',
                    base2: 'var(--color-base2)',
                    muted: 'var(--color-muted)',
                    inverted: 'var(--color-inverted)',
                    accent: 'var(--color-text-accent)',
                },
            },
            backgroundColor: {
                skin: {
                    base: 'var(--color-base)',
                    base2: 'var(--color-base2)',
                    muted: 'var(--color-muted)',
                    inverted: 'var(--color-inverted)',
                    fill: 'var(--color-fill)',
                    fill_accent: 'var(--color-fill-accent)',
                    button_accent: 'var(--color-button-accent)',
                    button_accent_hover: 'var(--color-button-accent-hover)',
                    button_muted: 'var(--color-button-muted)',
                },
            },
        },
    },
    plugins: [],
}