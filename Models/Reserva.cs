namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

          public void CadastrarHospedes(List<Pessoa> hospedes)
        {
           
            if (Suite != null && hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
               
                throw new Exception($"A capacidade da suíte ({Suite?.Capacidade ?? 0} pessoas) é menor " +
                                    $"que o número de hóspedes ({hospedes.Count}).");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

          public int ObterQuantidadeHospedes()
        {
           
            return Hospedes?.Count ?? 0;
        }

   
        public decimal CalcularValorDiaria()
        {
            
            if (Suite == null)
            {
                throw new InvalidOperationException("Não é possível calcular o valor da diária sem uma suíte cadastrada.");
            }
            if (DiasReservados <= 0)
            {
                return 0; 
            }

            decimal valor = DiasReservados * Suite.ValorDiaria;

          
            if (DiasReservados >= 10)
            {
                
                valor *= 0.90M; 
            }

            return valor;
        }
    }
}