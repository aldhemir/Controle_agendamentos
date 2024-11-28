<template>
    <div>
        <h1>Criar Agendamento</h1>
        <form @submit.prevent="handleSubmit">
            <div>
                <label for="nome">Nome:</label>
                <input type="text" id="nome" v-model="form.nome" required />
            </div>
            <div>
                <label for="data">Data:</label>
                <input type="datetime-local" id="data" v-model="form.data" required />
            </div>
            <div>
                <label for="descricao">Descrição:</label>
                <textarea id="descricao" v-model="form.descricao"></textarea>
            </div>
            <button type="submit">Salvar</button>
        </form>
    </div>
</template>

<script>
import { criarAgendamento } from '../api'; // Importe a função da API

export default {
    data() {
        return {
            form: {
                nome: '',        // Nome do agendamento
                data: '',        // Data e hora do agendamento
                descricao: '',   // Descrição do agendamento
            },
        };
    },
    methods: {
        async handleSubmit() {
            try {
                // Envia os dados do formulário para a API
                const resultado = await criarAgendamento(this.form);
                alert('Agendamento criado com sucesso!');
                console.log('Resultado da API:', resultado);
                // Limpar o formulário
                this.form = { nome: '', data: '', descricao: '' };
            } catch (error) {
                alert('Erro ao salvar agendamento. Verifique os dados e tente novamente.');
                console.error(error);
            }
        },
    },
};
</script>
