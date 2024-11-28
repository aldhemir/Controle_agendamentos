// plugins/vuetify.js
import 'vuetify/styles'; // Importando os estilos do Vuetify
import { createVuetify } from 'vuetify'; // Função para criar uma instância do Vuetify
import { aliases, mdi } from 'vuetify/iconsets/mdi'; // Usando os ícones Material Design

// Criação da instância do Vuetify
const vuetify = createVuetify({
  theme: {
    defaultTheme: 'light', // Definindo o tema padrão (pode ser 'dark' ou outro)
  },
  icons: {
    defaultSet: 'mdi', // Usando o conjunto de ícones do Material Design
    aliases, // Alias para ícones
    sets: {
      mdi, // Conjunto de ícones Material Design
    },
  },
});

export default vuetify;
