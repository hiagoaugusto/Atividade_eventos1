namespace Atividade_eventos1.Models
{
    public class Evento
    {
        public int EventoID { get; set; }

        public string EventoNome { get; set; }

        public int Duracao { get; set; }

        public ICollection <Participante> Participantes { get; set; } = new List<Participante>();
    }
}
