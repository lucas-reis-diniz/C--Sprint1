/*
 * ============================================================================
 * HEALTH TRACKER - Aplicação de Rastreamento de Atividades de Saúde
 * ============================================================================
 * 
 * Descrição: Esta aplicação permite ao usuário registrar e acompanhar 
 *            atividades de saúde como exercícios, consumo de água, sono, etc.
 *            Utiliza arrays internos para armazenamento dos dados.
 * 
 * Autor: Health Tracker Team
 * Versão: 1.0
 * .NET Version: 8.0
 * ============================================================================
 */

namespace HealthTracker;

/// <summary>
/// Classe principal da aplicação Health Tracker
/// </summary>
class Program
{
    // ========================================================================
    // CONSTANTES E VARIÁVEIS GLOBAIS
    // ========================================================================
    
    /// <summary>
    /// Capacidade máxima de registros que podem ser armazenados
    /// </summary>
    private const int CAPACIDADE_MAXIMA = 100;

    /// <summary>
    /// Array para armazenar os tipos de atividade (ex: "Caminhada", "Água")
    /// </summary>
    private static string[] tiposAtividade = new string[CAPACIDADE_MAXIMA];

    /// <summary>
    /// Array para armazenar as datas dos registros
    /// </summary>
    private static DateTime[] datasRegistro = new DateTime[CAPACIDADE_MAXIMA];

    /// <summary>
    /// Array para armazenar os valores numéricos (minutos, litros, etc.)
    /// </summary>
    private static double[] valoresRegistro = new double[CAPACIDADE_MAXIMA];

    /// <summary>
    /// Contador de registros atualmente armazenados
    /// </summary>
    private static int totalRegistros = 0;

    // ========================================================================
    // MÉTODO PRINCIPAL
    // ========================================================================
    
    /// <summary>
    /// Ponto de entrada da aplicação - apenas chama o método de execução
    /// </summary>
    static void Main(string[] args)
    {
        // Delega toda a lógica para métodos específicos
        ExecutarAplicacao();
    }

    // ========================================================================
    // MÉTODOS DE CONTROLE DA APLICAÇÃO
    // ========================================================================

    /// <summary>
    /// Executa o loop principal da aplicação
    /// </summary>
    private static void ExecutarAplicacao()
    {
        // Exibe mensagem de boas-vindas
        ExibirBoasVindas();

        // Loop principal do menu
        bool executando = true;
        while (executando)
        {
            // Exibe o menu e obtém a opção escolhida
            int opcao = ExibirMenuEObterOpcao();

            // Processa a opção selecionada
            executando = ProcessarOpcaoMenu(opcao);
        }

        // Exibe mensagem de despedida
        ExibirDespedida();
    }

    /// <summary>
    /// Exibe a mensagem de boas-vindas ao usuário
    /// </summary>
    private static void ExibirBoasVindas()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                                                              ║");
        Console.WriteLine("║         🏃 HEALTH TRACKER - Rastreador de Saúde 🏃          ║");
        Console.WriteLine("║                                                              ║");
        Console.WriteLine("║     Acompanhe suas atividades de saúde de forma simples!     ║");
        Console.WriteLine("║                                                              ║");
        Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    /// <summary>
    /// Exibe o menu principal e retorna a opção escolhida pelo usuário
    /// </summary>
    /// <returns>Número da opção selecionada</returns>
    private static int ExibirMenuEObterOpcao()
    {
        Console.Clear();
        
        // Cabeçalho do menu
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("┌──────────────────────────────────────┐");
        Console.WriteLine("│          📋 MENU PRINCIPAL           │");
        Console.WriteLine("├──────────────────────────────────────┤");
        Console.ResetColor();
        
        // Opções do menu
        Console.WriteLine("│                                      │");
        Console.WriteLine("│  [1] ➕ Adicionar Registro           │");
        Console.WriteLine("│  [2] 📄 Listar Registros             │");
        Console.WriteLine("│  [3] 📊 Exibir Estatísticas          │");
        Console.WriteLine("│  [4] 🚪 Sair do Programa             │");
        Console.WriteLine("│                                      │");
        Console.WriteLine("└──────────────────────────────────────┘");
        Console.WriteLine();

        // Exibe contagem atual de registros
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"📝 Registros armazenados: {totalRegistros}/{CAPACIDADE_MAXIMA}");
        Console.ResetColor();
        Console.WriteLine();

        // Solicita a opção do usuário
        return LerOpcaoMenu(1, 4);
    }

    /// <summary>
    /// Lê e valida a opção do menu escolhida pelo usuário
    /// </summary>
    /// <param name="minimo">Valor mínimo aceito</param>
    /// <param name="maximo">Valor máximo aceito</param>
    /// <returns>Opção válida selecionada</returns>
    private static int LerOpcaoMenu(int minimo, int maximo)
    {
        int opcao;
        bool entradaValida = false;

        do
        {
            Console.Write("👉 Digite sua opção: ");
            string? entrada = Console.ReadLine();

            // Valida se a entrada é um número dentro do intervalo permitido
            if (int.TryParse(entrada, out opcao) && opcao >= minimo && opcao <= maximo)
            {
                entradaValida = true;
            }
            else
            {
                ExibirMensagemErro($"Opção inválida! Digite um número entre {minimo} e {maximo}.");
            }
        } while (!entradaValida);

        return opcao;
    }

    /// <summary>
    /// Processa a opção selecionada no menu
    /// </summary>
    /// <param name="opcao">Número da opção escolhida</param>
    /// <returns>True para continuar executando, False para sair</returns>
    private static bool ProcessarOpcaoMenu(int opcao)
    {
        switch (opcao)
        {
            case 1:
                AdicionarRegistro();
                return true;
            case 2:
                ListarRegistros();
                return true;
            case 3:
                ExibirEstatisticas();
                return true;
            case 4:
                return false; // Sair do programa
            default:
                return true;
        }
    }

    // ========================================================================
    // MÉTODOS DE FUNCIONALIDADES PRINCIPAIS
    // ========================================================================

    /// <summary>
    /// Adiciona um novo registro de atividade de saúde
    /// Coleta tipo de atividade, data e valor numérico do usuário
    /// </summary>
    private static void AdicionarRegistro()
    {
        Console.Clear();
        ExibirCabecalhoSecao("➕ ADICIONAR NOVO REGISTRO");

        // Verifica se há espaço para novos registros
        if (totalRegistros >= CAPACIDADE_MAXIMA)
        {
            ExibirMensagemErro("Capacidade máxima de registros atingida!");
            AguardarTecla();
            return;
        }

        // Coleta o tipo de atividade
        string tipoAtividade = LerTipoAtividade();

        // Coleta a data do registro
        DateTime data = LerDataRegistro();

        // Coleta o valor numérico (com validação de não-negativo)
        double valor = LerValorNumerico();

        // Armazena os dados nos arrays
        tiposAtividade[totalRegistros] = tipoAtividade;
        datasRegistro[totalRegistros] = data;
        valoresRegistro[totalRegistros] = valor;
        totalRegistros++;

        // Confirma o registro para o usuário
        Console.WriteLine();
        ExibirMensagemSucesso("✅ Registro adicionado com sucesso!");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("📋 Resumo do registro:");
        Console.WriteLine($"   • Atividade: {tipoAtividade}");
        Console.WriteLine($"   • Data: {data:dd/MM/yyyy}");
        Console.WriteLine($"   • Valor: {valor:F2}");
        Console.ResetColor();

        AguardarTecla();
    }

    /// <summary>
    /// Lista todos os registros cadastrados de forma organizada
    /// </summary>
    private static void ListarRegistros()
    {
        Console.Clear();
        ExibirCabecalhoSecao("📄 LISTA DE REGISTROS");

        // Verifica se existem registros
        if (totalRegistros == 0)
        {
            ExibirMensagemAviso("Nenhum registro encontrado. Adicione seu primeiro registro!");
            AguardarTecla();
            return;
        }

        // Exibe cabeçalho da tabela
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("┌─────┬────────────────────┬──────────────┬────────────────┐");
        Console.WriteLine("│  #  │     ATIVIDADE      │     DATA     │     VALOR      │");
        Console.WriteLine("├─────┼────────────────────┼──────────────┼────────────────┤");
        Console.ResetColor();

        // Exibe cada registro
        for (int i = 0; i < totalRegistros; i++)
        {
            // Formata os dados para exibição na tabela
            string numeroFormatado = (i + 1).ToString().PadLeft(3);
            string atividadeFormatada = FormatarTextoTabela(tiposAtividade[i], 18);
            string dataFormatada = datasRegistro[i].ToString("dd/MM/yyyy").PadLeft(12);
            string valorFormatado = valoresRegistro[i].ToString("F2").PadLeft(14);

            // Alterna cores para melhor visualização
            Console.ForegroundColor = (i % 2 == 0) ? ConsoleColor.White : ConsoleColor.Gray;
            Console.WriteLine($"│{numeroFormatado} │ {atividadeFormatada} │{dataFormatada} │{valorFormatado} │");
        }

        // Rodapé da tabela
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("└─────┴────────────────────┴──────────────┴────────────────┘");
        Console.ResetColor();

        // Exibe total de registros
        Console.WriteLine();
        Console.WriteLine($"📊 Total de registros: {totalRegistros}");

        AguardarTecla();
    }

    /// <summary>
    /// Exibe estatísticas dos registros: soma e média por tipo de atividade
    /// </summary>
    private static void ExibirEstatisticas()
    {
        Console.Clear();
        ExibirCabecalhoSecao("📊 ESTATÍSTICAS");

        // Verifica se existem registros
        if (totalRegistros == 0)
        {
            ExibirMensagemAviso("Nenhum registro encontrado para calcular estatísticas.");
            AguardarTecla();
            return;
        }

        // Arrays temporários para armazenar tipos únicos e suas estatísticas
        string[] tiposUnicos = new string[CAPACIDADE_MAXIMA];
        double[] somasPorTipo = new double[CAPACIDADE_MAXIMA];
        int[] contagemPorTipo = new int[CAPACIDADE_MAXIMA];
        int totalTiposUnicos = 0;

        // Processa cada registro para calcular estatísticas
        for (int i = 0; i < totalRegistros; i++)
        {
            // Busca se o tipo já existe no array de tipos únicos
            int indiceTipo = BuscarIndiceTipo(tiposUnicos, totalTiposUnicos, tiposAtividade[i]);

            if (indiceTipo == -1)
            {
                // Tipo novo - adiciona ao array
                tiposUnicos[totalTiposUnicos] = tiposAtividade[i];
                somasPorTipo[totalTiposUnicos] = valoresRegistro[i];
                contagemPorTipo[totalTiposUnicos] = 1;
                totalTiposUnicos++;
            }
            else
            {
                // Tipo existente - atualiza soma e contagem
                somasPorTipo[indiceTipo] += valoresRegistro[i];
                contagemPorTipo[indiceTipo]++;
            }
        }

        // Exibe estatísticas gerais
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("═══════════════════════════════════════════════════════");
        Console.WriteLine("                   RESUMO GERAL                        ");
        Console.WriteLine("═══════════════════════════════════════════════════════");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine($"  📝 Total de registros: {totalRegistros}");
        Console.WriteLine($"  🏷️  Tipos de atividades diferentes: {totalTiposUnicos}");
        Console.WriteLine();

        // Exibe estatísticas por tipo de atividade
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("═══════════════════════════════════════════════════════");
        Console.WriteLine("              ESTATÍSTICAS POR ATIVIDADE               ");
        Console.WriteLine("═══════════════════════════════════════════════════════");
        Console.ResetColor();
        Console.WriteLine();

        // Cabeçalho da tabela de estatísticas
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("┌────────────────────┬───────────┬───────────┬───────────┐");
        Console.WriteLine("│     ATIVIDADE      │   SOMA    │   MÉDIA   │   QTD.    │");
        Console.WriteLine("├────────────────────┼───────────┼───────────┼───────────┤");
        Console.ResetColor();

        // Exibe estatísticas de cada tipo
        for (int i = 0; i < totalTiposUnicos; i++)
        {
            double media = somasPorTipo[i] / contagemPorTipo[i];
            
            string atividadeFormatada = FormatarTextoTabela(tiposUnicos[i], 18);
            string somaFormatada = somasPorTipo[i].ToString("F2").PadLeft(9);
            string mediaFormatada = media.ToString("F2").PadLeft(9);
            string contagemFormatada = contagemPorTipo[i].ToString().PadLeft(9);

            Console.ForegroundColor = (i % 2 == 0) ? ConsoleColor.White : ConsoleColor.Gray;
            Console.WriteLine($"│ {atividadeFormatada} │{somaFormatada} │{mediaFormatada} │{contagemFormatada} │");
        }

        // Rodapé da tabela
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("└────────────────────┴───────────┴───────────┴───────────┘");
        Console.ResetColor();

        // Calcula e exibe média geral de todos os valores
        double somaTotal = CalcularSomaTotal();
        double mediaGeral = somaTotal / totalRegistros;
        
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"  📈 Soma total de todos os valores: {somaTotal:F2}");
        Console.WriteLine($"  📊 Média geral de todos os valores: {mediaGeral:F2}");
        Console.ResetColor();

        AguardarTecla();
    }

    // ========================================================================
    // MÉTODOS AUXILIARES DE ENTRADA DE DADOS
    // ========================================================================

    /// <summary>
    /// Lê e valida o tipo de atividade informado pelo usuário
    /// </summary>
    /// <returns>Tipo de atividade válido (não vazio)</returns>
    private static string LerTipoAtividade()
    {
        string? tipoAtividade;

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("💡 Exemplos de atividades: Caminhada, Corrida, Água, Sono, Meditação");
        Console.ResetColor();
        Console.WriteLine();

        do
        {
            Console.Write("📝 Digite o tipo de atividade: ");
            tipoAtividade = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(tipoAtividade))
            {
                ExibirMensagemErro("O tipo de atividade não pode estar vazio!");
            }
        } while (string.IsNullOrWhiteSpace(tipoAtividade));

        return tipoAtividade;
    }

    /// <summary>
    /// Lê e valida a data do registro
    /// Aceita formato dd/MM/yyyy ou usa a data atual se deixado em branco
    /// </summary>
    /// <returns>Data válida do registro</returns>
    private static DateTime LerDataRegistro()
    {
        DateTime data;
        bool dataValida = false;

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("💡 Formato da data: dd/MM/yyyy (ex: 28/11/2025)");
        Console.WriteLine("   Deixe em branco para usar a data de hoje.");
        Console.ResetColor();
        Console.WriteLine();

        do
        {
            Console.Write("📅 Digite a data do registro: ");
            string? entradaData = Console.ReadLine()?.Trim();

            // Se deixado em branco, usa a data atual
            if (string.IsNullOrWhiteSpace(entradaData))
            {
                data = DateTime.Today;
                dataValida = true;
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"   (Usando data de hoje: {data:dd/MM/yyyy})");
                Console.ResetColor();
            }
            // Tenta converter a data informada
            else if (DateTime.TryParseExact(entradaData, "dd/MM/yyyy", 
                     System.Globalization.CultureInfo.InvariantCulture,
                     System.Globalization.DateTimeStyles.None, out data))
            {
                dataValida = true;
            }
            else
            {
                ExibirMensagemErro("Data inválida! Use o formato dd/MM/yyyy.");
            }
        } while (!dataValida);

        return data;
    }

    /// <summary>
    /// Lê e valida o valor numérico (minutos, litros, etc.)
    /// Garante que o valor não seja negativo
    /// </summary>
    /// <returns>Valor numérico válido (>= 0)</returns>
    private static double LerValorNumerico()
    {
        double valor;
        bool valorValido = false;

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("💡 Informe o valor numérico da atividade");
        Console.WriteLine("   (ex: minutos de exercício, litros de água, horas de sono)");
        Console.ResetColor();
        Console.WriteLine();

        do
        {
            Console.Write("🔢 Digite o valor: ");
            string? entradaValor = Console.ReadLine();

            // Tenta converter para número
            if (double.TryParse(entradaValor, System.Globalization.NumberStyles.Any,
                               System.Globalization.CultureInfo.CurrentCulture, out valor))
            {
                // Valida se não é negativo
                if (valor >= 0)
                {
                    valorValido = true;
                }
                else
                {
                    ExibirMensagemErro("O valor não pode ser negativo!");
                }
            }
            else
            {
                ExibirMensagemErro("Valor inválido! Digite um número válido.");
            }
        } while (!valorValido);

        return valor;
    }

    // ========================================================================
    // MÉTODOS AUXILIARES DE CÁLCULO
    // ========================================================================

    /// <summary>
    /// Busca o índice de um tipo de atividade no array de tipos únicos
    /// </summary>
    /// <param name="tipos">Array de tipos únicos</param>
    /// <param name="totalTipos">Total de tipos no array</param>
    /// <param name="tipoBuscado">Tipo a ser buscado</param>
    /// <returns>Índice do tipo ou -1 se não encontrado</returns>
    private static int BuscarIndiceTipo(string[] tipos, int totalTipos, string tipoBuscado)
    {
        for (int i = 0; i < totalTipos; i++)
        {
            // Comparação case-insensitive para melhor usabilidade
            if (tipos[i].Equals(tipoBuscado, StringComparison.OrdinalIgnoreCase))
            {
                return i;
            }
        }
        return -1;
    }

    /// <summary>
    /// Calcula a soma total de todos os valores registrados
    /// </summary>
    /// <returns>Soma total dos valores</returns>
    private static double CalcularSomaTotal()
    {
        double soma = 0;
        for (int i = 0; i < totalRegistros; i++)
        {
            soma += valoresRegistro[i];
        }
        return soma;
    }

    // ========================================================================
    // MÉTODOS AUXILIARES DE INTERFACE
    // ========================================================================

    /// <summary>
    /// Exibe um cabeçalho estilizado para uma seção
    /// </summary>
    /// <param name="titulo">Título da seção</param>
    private static void ExibirCabecalhoSecao(string titulo)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("═══════════════════════════════════════════════════════");
        Console.WriteLine($"  {titulo}");
        Console.WriteLine("═══════════════════════════════════════════════════════");
        Console.ResetColor();
    }

    /// <summary>
    /// Exibe uma mensagem de erro formatada
    /// </summary>
    /// <param name="mensagem">Mensagem de erro</param>
    private static void ExibirMensagemErro(string mensagem)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"❌ {mensagem}");
        Console.ResetColor();
    }

    /// <summary>
    /// Exibe uma mensagem de sucesso formatada
    /// </summary>
    /// <param name="mensagem">Mensagem de sucesso</param>
    private static void ExibirMensagemSucesso(string mensagem)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(mensagem);
        Console.ResetColor();
    }

    /// <summary>
    /// Exibe uma mensagem de aviso formatada
    /// </summary>
    /// <param name="mensagem">Mensagem de aviso</param>
    private static void ExibirMensagemAviso(string mensagem)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"⚠️  {mensagem}");
        Console.ResetColor();
    }

    /// <summary>
    /// Formata um texto para caber em uma coluna de tabela
    /// </summary>
    /// <param name="texto">Texto original</param>
    /// <param name="tamanho">Tamanho máximo da coluna</param>
    /// <returns>Texto formatado com padding ou truncado</returns>
    private static string FormatarTextoTabela(string texto, int tamanho)
    {
        if (texto.Length > tamanho)
        {
            // Trunca e adiciona "..." se muito longo
            return texto.Substring(0, tamanho - 3) + "...";
        }
        else
        {
            // Adiciona espaços para preencher a coluna
            return texto.PadRight(tamanho);
        }
    }

    /// <summary>
    /// Aguarda o usuário pressionar uma tecla para continuar
    /// </summary>
    private static void AguardarTecla()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
        Console.ResetColor();
        Console.ReadKey();
    }

    /// <summary>
    /// Exibe a mensagem de despedida ao sair do programa
    /// </summary>
    private static void ExibirDespedida()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine();
        Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                                                              ║");
        Console.WriteLine("║        🙏 Obrigado por usar o Health Tracker! 🙏            ║");
        Console.WriteLine("║                                                              ║");
        Console.WriteLine("║           Continue cuidando da sua saúde! 💪                 ║");
        Console.WriteLine("║                                                              ║");
        Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
        Console.WriteLine();
        Console.ResetColor();
    }
}

