<template>
    <div>
      <h1>Editar Agendamento</h1>
      <v-form ref="form" @submit.prevent="updateAgendamento">
        <v-text-field label="Nome Cliente" v-model="agendamento.nomeCliente" required />
        <v-text-field label="Serviço" v-model="agendamento.servico" required />
        <v-datetime-picker label="Data e Hora" v-model="agendamento.dataHora" required />
        <v-textarea label="Observações" v-model="agendamento.observacoes" />
        <v-btn type="submit" color="primary">Atualizar</v-btn>
      </v-form>
    </div>
  </template>
  
  <script>
  import axios from 'axios';
  
  export default {
    data() {
      return {
        agendamento: {
          id: this.$route.params.id,
          nomeCliente: '',
          servico: '',
          dataHora: '',
          observacoes: ''
        }
      };
    },
    methods: {
      async loadAgendamento() {
        try {
          const response = await axios.get(`http://localhost:5122/api/agendamentos/${this.agendamento.id}`);
          this.agendamento = response.data;
        } catch (error) {
          console.error("Erro ao carregar agendamento:", error);
        }
      },
      async updateAgendamento() {
        try {
          await axios.put(`http://localhost:5122/api/agendamentos/${this.agendamento.id}`, this.agendamento);
          this.$router.push({ name: 'list-agendamentos' });
        } catch (error) {
          console.error("Erro ao atualizar agendamento:", error);
        }
      }
    },
    mounted() {
      this.loadAgendamento();
    }
  };
  </script>
  