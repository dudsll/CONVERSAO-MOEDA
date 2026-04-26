using System;
//using System.Drawing;
//using System.Globalization;
//using System.Threading;

class Program
{

    static async Task Main()
    {
        int opcao = Menu();

        Console.WriteLine("Valor: ");
        double valor = Convert.ToDouble(Console.ReadLine());

        double cotacao = await OpcaoDeCambio(opcao);

        double resultado = ConverterMoeda(valor, cotacao, opcao);

        Console.WriteLine($"Resultado: {resultado}");
    }

    static int Menu()
    {
        Console.WriteLine("Conversão de Moedas");
        Console.WriteLine("1 - Real para Dólar");
        Console.WriteLine("2 - Real para Dirham");
        Console.WriteLine("3 - Dirham para Real");
        Console.Write("Digite a opção desejada: ");

        int opcao = Convert.ToInt32(Console.ReadLine());
        return opcao;
    }

    static async Task<double> OpcaoDeCambio(int opcao)
    {
        switch (opcao)
        {
            case 1:
                return await ObterCotacaoDolar();
                break;
            case 2:
                return await ObterCotacaoDirham();
            case 3:
                return await ObterCotacaoDirham();
            default:
                Console.WriteLine("Opção inválida");
                break;
        }
    



        if (opcao == 1)
            return await ObterCotacaoDolar();

        else if (opcao == 2 || opcao == 3)
            return await ObterCotacaoDirham();

        else
            return 0;
    }

    static double ConverterMoeda(double valor, double cotacao, int opcao)
    {
        if (opcao == 1 || opcao == 2)
            return valor / cotacao;

        else if (opcao == 3)
            return valor * cotacao;

        else
            return 0;
    }
    
    static async Task<double> ObterCotacaoDolar()
    {
        HttpClient client = new HttpClient();

        string url = "https://economia.awesomeapi.com.br/json/last/USD-BRL";

        string resposta = await client.GetStringAsync(url);

        string valor = resposta.Split("bid\":\"")[1].Split("\"")[0];

        return Convert.ToDouble(valor, System.Globalization.CultureInfo.InvariantCulture);
    }

    static async Task<double> ObterCotacaoDirham()
    {
        HttpClient client = new HttpClient();

        string url = "https://economia.awesomeapi.com.br/json/last/AED-BRL";

        string resposta = await client.GetStringAsync(url);

        string valor = resposta.Split("bid\":\"")[1].Split("\"")[0];

        return Convert.ToDouble(valor, System.Globalization.CultureInfo.InvariantCulture);
    }

}
