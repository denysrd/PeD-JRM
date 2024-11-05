namespace PeD_JRM.Models
{
    public class FornecedorModel
    {
        // Chave primária
        public int Id_Fornecedor { get; set; }

        // Campo para o CNPJ do fornecedor, obrigatório e com limite de caracteres
        public string Documento { get; set; } = string.Empty;

        // Nome do fornecedor, obrigatório e com limite de caracteres
        public string Nome { get; set; } = string.Empty;

        // Email do fornecedor, opcional mas com limite de caracteres
        public string Email { get; set; } = string.Empty;

        // Telefone do fornecedor, opcional mas com limite de caracteres
        public string Telefone { get; set; } = string.Empty;
    }
}
