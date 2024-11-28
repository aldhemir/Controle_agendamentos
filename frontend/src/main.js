// main.js ou main.ts
import { createApp } from 'vue';
import App from './App.vue';
import { createVuetify } from 'vuetify';
import 'vuetify/styles'; // Importar os estilos do Vuetify
import * as components from 'vuetify/components'; // Importar os componentes
import * as directives from 'vuetify/directives'; // Importar as diretivas
import router from './router'; // Importa o Vue Router
import vuetify from './plugins/vuetify';  // Importando a configuração do Vuetify

const vuetify = createVuetify({
  components,
  directives,
});

const app = createApp(App);

app.use(vuetify);

app.mount('#app');

app.use(router); // Configura o Vue Router
