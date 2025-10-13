using GeradorPdfNotaFiscal;
using System.Text;

namespace GeradorNotaFiscal
{
    internal class Program
    {
        static void Main()
        {
            var nota = new NotaFiscalDTO
            {
                Numero = "262",
                Serie = "NFS-E",
                DataPrestacao = new DateTime(2025, 9, 3),
                DataEmissao = new DateTime(2025, 9, 3, 16, 38, 45),
                CodigoVerificacao = "10MS.J9YD.56IW.SICY",
                Incidencia = "Valinhos (SP)",
                IssReter = "Sim",
                Exigibilidade = "Exigível",
                RPS = "12345",

                PrestadorRazao = "I9 SOLUCOES LOGISTICAS LTDA",
                PrestadorCNPJ = "37.781.461/0001-59",
                PrestadorReg = "Faturamento",
                PrestadorEndereco = "R. CURITIBA, 87 - Bairro: PARQUE DOS ESTADOS - Cep: 13290162",
                PrestadorTelefone = "38787979",
                PrestadorMunicipio = "Louveira - SP",
                PrestadorPais = "Brasil",
                PrestadorInscMun = "012275",
                PrestadorCodMob = "012275",
                PrestadorInscEst = "",
                PrestadorEmail = "jessica.cardoso@f2log.com.br",
                PrestadorFantasia = "I9 SOLUCOES LOGISTICAS",

                TomadorRazao = "CRIVELLARO & FILHOS LTDA",
                TomadorCNPJ = "51.284.743/0002-52",
                TomadorReg = "",
                TomadorEndereco = "R. Aristides Crivellaro, 580 - Bairro: MORRO DAS PEDRAS - Cep: 13279-813",
                TomadorTelefone = "1138693388",
                TomadorMunicipio = "Valinhos - SP",
                TomadorPais = "Brasil",
                TomadorInscMun = "",
                TomadorInscEst = "708.213.598.117",
                TomadorEmail = "fiscal@crivellaro.com.br",

                CodigoServico = "16.02",
                DescricaoServico = "OUTROS SERVIÇOS DE TRANSPORTE DE NATUREZA MUNICIPAL",
                Aliquota = 3.00m,
                DescricaoItem = "Prestação de Serviço",
                ValorUnitario = 2850.00m,
                Quantidade = 1,
                ValorTotal = 2850.00m,

                Observacoes = "Salto/SP (MK) x Vinhedo/SP (Unilever) x Valinhos/SP (Crivellaro)\nData de Carregamento:03/09/2025\nPlaca Cavalo: DPF 6A74\nPlaca Carreta: CVP 5B65",

                PIS = 0.00m,
                INSS = 0.00m,
                CSLL = 0.00m,
                IRRF = 0.00m,
                COFINS = 0.00m,

                ValorIss = 85.50m,
                DescontoCondicional = 0.00m,
                BaseCalculo = 2850.00m,
                OutrasRetencoes = 0.00m,
                ValorLiquido = 2764.50m
            };

            string htmlTemplate = File.ReadAllText("nota_fiscal_template.html", Encoding.UTF8);
            string htmlGerado = PreencherTemplate(htmlTemplate, nota);
            File.WriteAllText("nota.html", htmlGerado, Encoding.UTF8);

            Console.WriteLine("✅ HTML gerado com sucesso: nota.html");
        }

        /// <summary>
        /// Substitui todos os placeholders {{Campo}} automaticamente pelos valores do DTO
        /// </summary>
        static string PreencherTemplate(string template, object dados)
        {
            var tipo = dados.GetType();
            var propriedades = tipo.GetProperties();

            foreach (var prop in propriedades)
            {
                var marcador = "{{" + prop.Name + "}}";
                var valor = prop.GetValue(dados);

                string valorTexto = "";

                if (valor == null)
                {
                    valorTexto = "";
                }
                else if (valor is DateTime data)
                {
                    valorTexto = data.ToString("dd/MM/yyyy HH:mm:ss");
                }
                else if (valor is decimal dec)
                {
                    valorTexto = dec.ToString("N2");
                }
                else if (valor is int i)
                {
                    valorTexto = i.ToString();
                }
                else
                {
                    valorTexto = valor.ToString()
                        .Replace("\n", "<br/>")
                        .Replace("\r", "");
                }

                template = template.Replace(marcador, valorTexto);
            }

            return template;
        }

    }
}
