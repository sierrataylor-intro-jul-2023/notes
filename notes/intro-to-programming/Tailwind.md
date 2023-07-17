installation- [Installation - Tailwind CSS](https://tailwindcss.com/docs/installation)

tailwind config
```js
/** @type {import('tailwindcss').Config} */

module.exports = {

  content: ["./src/**/*.{html,ts}"],

  theme: {

    extend: {},

  },

  plugins: [

    require('@tailwindcss/forms'),

    require('@tailwindcss/typography'),

    require('daisyui')

  ],

  daisyui: {

    themes: ['synthwave', 'cyberpunk', 'cupcake']

  }

}
```
