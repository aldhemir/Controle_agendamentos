const API_URL = 'http://localhost:5122/api/agendamentos';

async function getAgendamentos() {
  try {
    const response = await fetch(`${API_URL}`);
    const data = await response.json();
    return data;
  } catch (error) {
    console.error('Erro ao buscar agendamentos:', error);
  }
}

async function createAgendamento(agendamento) {
  try {
    const response = await fetch(`${API_URL}`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(agendamento),
    });
    const data = await response.json();
    return data;
  } catch (error) {
    console.error('Erro ao criar agendamento:', error);
  }
}

// Exemplos de chamadas para testar
getAgendamentos().then(data => console.log(data));
createAgendamento({ nomeCliente: 'João', servico: 'Corte de cabelo', dataHora: '2024-11-27T14:00:00Z' }).then(data => console.log(data));
