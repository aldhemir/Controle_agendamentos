<template>
    <div>
      <h1>Bem-vindo ao Controle de Agendamentos!</h1>
      <router-view></router-view> <!-- Aqui o componente da rota será renderizado -->
    </div>
  </template>
  
  <script>
  export default {
    name: "App",
  };
  </script>
  
  <style>
  h1 {
    color: #42b983;
    margin-bottom: 20px;
  }
  </style>
  