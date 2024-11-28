<template>
    <div>
      <h1>Agendamentos</h1>
      <v-container>
        <v-row>
          <v-col>
            <v-btn color="primary" @click="createAgendamento">Criar Agendamento</v-btn>
          </v-col>
        </v-row>
        <v-data-table
          :headers="headers"
          :items="agendamentos"
          item-key="id"
          class="elevation-1"
        >
          <template v-slot:item.actions="{ item }">
            <v-btn color="blue" text @click="editAgendamento(item.id)">Editar</v-btn>
            <v-btn color="red" text @click="deleteAgendamento(item.id)">Excluir</v-btn>
          </template>
        </v-data-table>
      </v-container>
    </div>
  </template>
  
  <script>
  import axios from "axios";
  
  export default {
    name: "Agendamentos",
    data() {
      return {
        agendamentos: [],
        headers: [
          { text: "Nome Cliente", align: "start", value: "nomeCliente" },
          { text: "Serviço", value: "servico" },
          { text: "Data e Hora", value: "dataHora" },
          { text: "Ações", value: "actions", sortable: false },
        ],
      };
    },
    methods: {
      // Função para carregar agendamentos da API
      async loadAgendamentos() {
        try {
          const response = await axios.get("http://localhost:5122/api/agendamentos");
          this.agendamentos = response.data;
        } catch (error) {
          console.error("Erro ao carregar os agendamentos:", error);
        }
      },
      // Navegar para criar novo agendamento
      createAgendamento() {
        this.$router.push({ name: "create-agendamento" });
      },
      // Navegar para editar agendamento existente
      editAgendamento(id) {
        this.$router.push({ name: "edit-agendamento", params: { id } });
      },
      // Excluir agendamento e recarregar lista
      async deleteAgendamento(id) {
        try {
          await axios.delete(`http://localhost:5122/api/agendamentos/${id}`);
          this.loadAgendamentos(); // Recarregar a lista após excluir
        } catch (error) {
          console.error("Erro ao excluir o agendamento:", error);
        }
      },
    },
    mounted() {
      this.loadAgendamentos();
    },
  };
  </script>
  
  <style scoped>
  h1 {
    color: #2c3e50;
    margin-bottom: 20px;
  }
  </style>
  