/** @type {import('tailwindcss').Config} */

const colors = require("tailwindcss/colors");

export default {
  content: ["./src/**/*.{js,jsx,ts,tsx}"],
  theme: {
    colors:{
      ...colors,
      DARK_THEME: {
        BACKGROUND: '#000000',
        RED: '#AD1212'
      },
      THEME: {
        WHITE: '#f4f4f4',
        LIGHT_WHITE: '#f1f1f1',
        LIGHT_GRAY: '#efefef',
      },
    },
    extend: {
      fontFamily:{
        'open': ['Open Sans', 'sans-serif'],
        'mukta': ['Mukta', 'sans-serif'],
        'mooli': ['Mooli', 'sans-serif'],
      },
      backgroundImage: {
        'rs7': "url('/src/assets/RS7.jpg')",
      }
    }
  },
  plugins: [],
}

