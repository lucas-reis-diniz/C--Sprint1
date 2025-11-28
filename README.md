# 🏃 Health Tracker - Rastreador de Atividades de Saúde

Uma aplicação de console em C# para registrar e acompanhar suas atividades de saúde diárias.

## 📋 Descrição

O **Health Tracker** é uma aplicação simples e intuitiva que permite aos usuários:

- Registrar diferentes tipos de atividades de saúde (exercícios, consumo de água, horas de sono, etc.)
- Visualizar todos os registros de forma organizada
- Obter estatísticas detalhadas sobre suas atividades

A aplicação utiliza **arrays internos** para armazenamento de dados, não requerendo banco de dados ou arquivos externos.

## 🚀 Como Rodar

### Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) instalado na máquina

### Passos para Execução

1. **Clone ou baixe** o projeto para sua máquina

2. **Navegue até a pasta do projeto** no terminal:
   ```bash
   cd HealthTracker
   ```

3. **Execute a aplicação** com o comando:
   ```bash
   dotnet run
   ```

### Build (Opcional)

Para criar um executável:

```bash
dotnet build
```

O executável será gerado na pasta `bin/Debug/net10.0/`

## 🎯 Funcionalidades

### 1. Adicionar Registro
- Informe o **tipo de atividade** (ex: Caminhada, Água, Sono)
- Informe a **data** do registro (formato dd/MM/yyyy ou deixe em branco para hoje)
- Informe o **valor numérico** (minutos, litros, horas, etc.)
- Validação automática para garantir valores não-negativos

### 2. Listar Registros
- Exibe todos os registros em formato de tabela organizada
- Mostra: número do registro, atividade, data e valor
- Contador total de registros

### 3. Exibir Estatísticas
- **Resumo geral**: total de registros e tipos de atividades diferentes
- **Por tipo de atividade**:
  - Soma total dos valores
  - Média dos valores
  - Quantidade de registros
- **Estatísticas gerais**:
  - Soma total de todos os valores
  - Média geral de todos os valores

### 4. Sair do Programa
- Encerra a aplicação de forma amigável

## 💻 Tecnologias Utilizadas

- **Linguagem**: C# 12
- **Framework**: .NET 10.0
- **Tipo de Aplicação**: Console Application
- **Armazenamento**: Arrays internos (sem banco de dados)

## 📁 Estrutura do Projeto

```
HealthTracker/
├── Program.cs           # Código fonte principal
├── HealthTracker.csproj # Arquivo de projeto
└── README.md            # Este arquivo
```

## 📝 Exemplos de Uso

### Registrando uma caminhada:
```
Tipo de atividade: Caminhada
Data: 28/11/2025
Valor: 45 (minutos)
```

### Registrando consumo de água:
```
Tipo de atividade: Água
Data: (deixar em branco para hoje)
Valor: 2.5 (litros)
```

### Registrando horas de sono:
```
Tipo de atividade: Sono
Data: 27/11/2025
Valor: 8 (horas)
```

## ✨ Características do Código

- ✅ **Código organizado em métodos** - Nenhuma lógica no Main
- ✅ **Validação de entradas** - Tratamento de erros e valores inválidos
- ✅ **Interface amigável** - Mensagens claras e formatação visual
- ✅ **Comentários XML** - Documentação completa do código
- ✅ **Uso correto de arrays** - Conforme requisitos do projeto
- ✅ **Boas práticas de programação** - Código limpo e legível

## 📊 Capacidade

A aplicação suporta até **100 registros** por sessão de execução.

## 🎨 Interface

A aplicação apresenta uma interface colorida e organizada com:
- Menus estilizados com bordas
- Tabelas formatadas para exibição de dados
- Mensagens de feedback coloridas (sucesso, erro, aviso)
- Emojis para melhor identificação visual

## 👥 Integrantes do Grupo

| Nome | RM |
|------|-----|
| Diana Letícia de Souza Inocencio | RM553562 |
| João Viktor Carvalho de Souza | RM552613 |
| Lucas Reis Diniz | RM552838 |
| Thiago Araújo Vieira | RM553477 |
| Victor Augusto Pereira dos Santos | RM553518 |
| Vitor de Moura Nascimento | RM553806 |

## 📄 Licença

Este projeto foi desenvolvido para fins educacionais.

---

**Desenvolvido com 💚 para promover uma vida mais saudável!**


