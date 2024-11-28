<template>
  <div>
    <h1>Criar Agendamento</h1>
    <v-form ref="form" @submit.prevent="saveAgendamento">
      <v-text-field label="Nome Cliente" v-model="agendamento.nomeCliente" required />
      <v-text-field label="Serviço" v-model="agendamento.servico" required />
      <v-datetime-picker label="Data e Hora" v-model="agendamento.dataHora" required />
      <v-date-picker v-model="agendamento.dataHora" label="Data e Hora" />
      <v-textarea label="Observações" v-model="agendamento.observacoes" />
      <v-btn type="submit" color="primary">Salvar</v-btn>
    </v-form>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  data() {
    return {
      agendamento: {
        nomeCliente: '',
        servico: '',
        dataHora: '',
        observacoes: ''
      }
    };
  },
  methods: {
    async saveAgendamento() {
      try {
        await axios.post('http://localhost:5122/api/agendamentos', this.agendamento);
        this.$router.push({ name: 'list-agendamentos' }); // Redirecionar para a listagem
      } catch (error) {
        console.error("Erro ao salvar agendamento:", error);
      }
    }
  }
};
</script>
