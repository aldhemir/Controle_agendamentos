import { createRouter, createWebHistory } from 'vue-router';
import CreateAgendamento from '../components/CreateAgendamento.vue';
import ListAgendamentos from '../components/ListAgendamentos.vue';

const routes = [
  {
    path: '/',
    name: 'ListAgendamentos',
    component: ListAgendamentos,
  },
  {
    path: '/create',
    name: 'CreateAgendamento',
    component: CreateAgendamento,
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
