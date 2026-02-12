namespace SistemaGestaoAlunos.Domain.Entities
{
    public class Aluno
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public decimal Altura { get; private set; }
        public decimal Peso { get; private set; }

        // Construtor vazio exigido pelo EF Core
        protected Aluno() { }

        // Construtor usado pela aplicação
        public Aluno(string nome, DateTime dataNascimento, decimal altura, decimal peso)
        {
            Id = Guid.NewGuid();

            // Centraliza validação + atribuição
            AtualizarDados(nome, dataNascimento, altura, peso);
        }

        // Método responsável por validar e atualizar os dados
        public void AtualizarDados(
            string nome,
            DateTime dataNascimento,
            decimal altura,
            decimal peso)
        {
            // Validação do nome
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome é obrigatório.");

            if (nome.Length < 3)
                throw new ArgumentException("Nome deve ter no mínimo 3 caracteres.");

            // Validação da data de nascimento
            if (dataNascimento > DateTime.Today)
                throw new ArgumentException("Data de nascimento não pode ser no futuro.");

            // Validação da altura
            if (altura <= 0)
                throw new ArgumentException("Altura deve ser maior que zero.");

            // Validação do peso
            if (peso <= 0)
                throw new ArgumentException("Peso deve ser maior que zero.");

            // Se passou por todas as validações, atualiza
            Nome = nome;
            DataNascimento = dataNascimento;
            Altura = altura; 
            Peso = peso;
        }
    }
}
