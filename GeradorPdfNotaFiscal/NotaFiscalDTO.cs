namespace GeradorPdfNotaFiscal
{
    public class NotaFiscalDTO
    {
        public string Numero { get; set; }
        public string Serie { get; set; }
        public DateTime DataPrestacao { get; set; }
        public DateTime DataEmissao { get; set; }
        public string CodigoVerificacao { get; set; }

        // Cabeçalho
        public string Incidencia { get; set; }
        public string IssReter { get; set; }
        public string Exigibilidade { get; set; }
        public string RPS { get; set; }

        // Prestador
        public string PrestadorRazao { get; set; }
        public string PrestadorCNPJ { get; set; }
        public string PrestadorReg { get; set; }
        public string PrestadorEndereco { get; set; }
        public string PrestadorTelefone { get; set; }
        public string PrestadorMunicipio { get; set; }
        public string PrestadorPais { get; set; }
        public string PrestadorInscMun { get; set; }
        public string PrestadorCodMob { get; set; }
        public string PrestadorInscEst { get; set; }
        public string PrestadorEmail { get; set; }
        public string PrestadorFantasia { get; set; }

        // Tomador
        public string TomadorRazao { get; set; }
        public string TomadorCNPJ { get; set; }
        public string TomadorReg { get; set; }
        public string TomadorEndereco { get; set; }
        public string TomadorTelefone { get; set; }
        public string TomadorMunicipio { get; set; }
        public string TomadorPais { get; set; }
        public string TomadorInscMun { get; set; }
        public string TomadorInscEst { get; set; }
        public string TomadorEmail { get; set; }

        // Serviço
        public string CodigoServico { get; set; }
        public string DescricaoServico { get; set; }
        public decimal Aliquota { get; set; }
        public string DescricaoItem { get; set; }
        public decimal ValorUnitario { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotal { get; set; }

        // Observações
        public string Observacoes { get; set; }

        // Tributos
        public decimal PIS { get; set; }
        public decimal INSS { get; set; }
        public decimal CSLL { get; set; }
        public decimal IRRF { get; set; }
        public decimal COFINS { get; set; }

        // Detalhamento de valores
        public decimal ValorIss { get; set; }
        public decimal DescontoCondicional { get; set; }
        public decimal BaseCalculo { get; set; }
        public decimal OutrasRetencoes { get; set; }
        public decimal ValorLiquido { get; set; }
    }
}
