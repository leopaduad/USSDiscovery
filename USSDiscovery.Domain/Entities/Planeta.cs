namespace USSDiscovery.Domain
{
    public class Planeta
    {
        public int ID { get; private set; }
        public string Nome { get; private set; }
        public decimal Tamanho { get; private set; }
        public Planeta()
        {
        }

        public Planeta(string nome, decimal tamanho)
        {
            Nome = nome;
            Tamanho = tamanho;
            CalcularDimensao();
        }

        public void CalcularDimensao()
        {
            this.Tamanho = 2 * 3.1416m * this.Tamanho;
        }
    }
}