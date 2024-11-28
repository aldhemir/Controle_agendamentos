# **Controle de Agendamentos**

## Descrição

Este projeto é um sistema simples de gerenciamento de agendamentos. Ele é composto por um front-end construído com Vue.js e um back-end que pode ser hospedado no Supabase, com a API acessível via HTTP. O front-end é hospedado no Netlify, e o back-end utiliza o Supabase para armazenamento de dados.

## Tecnologias Usadas

- **Front-end**:
  - Vue.js 3
  - Vuetify
  - Axios (para requisições HTTP)
  - Netlify (para hospedagem do front-end)

- **Back-end**:
  - Supabase (para banco de dados e API)
  - Configuração automática de CORS pelo Supabase

## Pré-requisitos

### Front-end:
- **Node.js** (recomendado versão 16 ou superior)
- **npm** ou **yarn** (gerenciador de pacotes)

### Back-end:
- **Supabase Account** (para criar o banco de dados e gerenciar a API)

---

## **Configuração do Projeto**

### 1. **Configuração do Back-end (Supabase)**

1. Crie uma conta no [Supabase](https://supabase.io/) caso ainda não tenha.
2. Crie um novo projeto no Supabase e configure o banco de dados conforme necessário.
3. Na seção de **API**, você pode configurar sua API REST para acessar os dados de agendamento.
4. Garanta que as permissões de **CORS** estejam configuradas para permitir que seu front-end (no Netlify) faça requisições à API.
    - Na interface do Supabase, vá até a configuração da API e adicione a URL do seu front-end como origem permitida, se necessário.
    
    **Exemplo de configuração de CORS no Supabase:**
    ```json
    {
      "Access-Control-Allow-Origin": "http://localhost:4173"
    }
    ```

### 2. **Configuração do Front-end**

#### Instalar Dependências

1. Clone o repositório:

   ```bash
   git clone https://github.com/seu-usuario/controle-agendamentos.git
   cd controle-agendamentos
   ```

2. Instale as dependências:

   Se estiver usando **npm**:

   ```bash
   npm install
   ```

   Ou se estiver usando **yarn**:

   ```bash
   yarn install
   ```

#### Variáveis de Ambiente

Adicione as configurações do seu **Supabase** em um arquivo `.env` no root do projeto (se necessário), com a URL da API e a chave de autenticação, como exemplo:

```bash
VUE_APP_SUPABASE_URL=seu_supabase_url
VUE_APP_SUPABASE_KEY=seu_supabase_key
```

#### Iniciar o Front-end

1. Execute o projeto localmente para desenvolvimento:

   Se estiver usando **npm**:

   ```bash
   npm run serve
   ```

   Ou **yarn**:

   ```bash
   yarn serve
   ```

2. O front-end estará disponível em `http://localhost:4173`.

---

## **Endpoints da API**

A API de agendamentos é acessível no endereço `http://localhost:5122/api/agendamentos` (ou pela URL configurada no Supabase).

### 1. **GET /api/agendamentos**

- **Descrição**: Retorna todos os agendamentos.
- **Resposta** (exemplo):

    ```json
    [
      {
        "nomeCliente": "João",
        "servico": "Corte de cabelo",
        "dataHora": "2024-11-27T14:00:00Z"
      },
      {
        "nomeCliente": "Maria",
        "servico": "Manicure",
        "dataHora": "2024-11-28T10:00:00Z"
      }
    ]
    ```

### 2. **POST /api/agendamentos**

- **Descrição**: Cria um novo agendamento.
- **Corpo da Requisição** (JSON):

    ```json
    {
      "nomeCliente": "João",
      "servico": "Corte de cabelo",
      "dataHora": "2024-11-27T14:00:00Z"
    }
    ```

- **Resposta** (exemplo):

    ```json
    {
      "nomeCliente": "João",
      "servico": "Corte de cabelo",
      "dataHora": "2024-11-27T14:00:00Z"
    }
    ```

---

## **Exemplo de Uso no Front-end**

A seguir está um exemplo de como realizar uma requisição ao back-end para obter e criar agendamentos:

### 1. **Obtendo Agendamentos**

```javascript
const API_URL = 'http://localhost:5122/api/agendamentos';

async function getAgendamentos() {
  try {
    const response = await fetch(API_URL);
    const data = await response.json();
    console.log(data);
  } catch (error) {
    console.error('Erro ao buscar agendamentos:', error);
  }
}

getAgendamentos();
```

### 2. **Criando um Novo Agendamento**

```javascript
async function createAgendamento(agendamento) {
  try {
    const response = await fetch(API_URL, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(agendamento),
    });
    const data = await response.json();
    console.log('Agendamento criado:', data);
  } catch (error) {
    console.error('Erro ao criar agendamento:', error);
  }
}

createAgendamento({
  nomeCliente: 'João',
  servico: 'Corte de cabelo',
  dataHora: '2024-11-27T14:00:00Z',
});
```

---

## **Hospedagem**

### Front-end no Netlify

Para hospedar o front-end no Netlify:

1. Crie uma conta no [Netlify](https://www.netlify.com/).
2. Faça o deploy do seu repositório para o Netlify, conectando o GitHub (ou outro sistema de controle de versão).
3. Configure a URL do seu front-end na plataforma de CORS do Supabase (caso necessário).

### Back-end no Supabase

Seu backend é hospedado automaticamente no Supabase, e você não precisa fazer deploy manualmente. Apenas configure os detalhes da sua API através do painel do Supabase.

---

## **Problemas Comuns**

1. **Erro de CORS**:
   - Verifique se a URL do seu front-end está configurada corretamente nas permissões de CORS no Supabase.
   - Certifique-se de que o CORS está habilitado no backend, se você estiver usando funções serverless no Netlify.

2. **Erro de Conexão com o Banco de Dados**:
   - Certifique-se de que você configurou corretamente as credenciais do Supabase no front-end.

---
