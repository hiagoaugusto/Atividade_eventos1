using Atividade_eventos1.Models;
using Microsoft.EntityFrameworkCore;


namespace Atividade_eventos1.Models

{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)

        {

            //associa os dados ao contexto

            Context context = app.ApplicationServices.GetRequiredService<Context>();

            //inserir os dados nas entidades do contexto

            context.Database.Migrate();

            //se o contexto estiver vazio

            if (!context.Eventos.Any())

            //inserir os produtos iniciais

            {

                context.Eventos.AddRange(

                new Evento { EventoNome = "Join", Duracao = 20 },

                new Evento { EventoNome = "Hackaton", Duracao = 40 }
                );

                context.Participantes.AddRange(

                new Participante { ParticipanteName = "Hiago" },

                new Participante { ParticipanteName = "Geovana" }
                );

                context.SaveChanges();

            }
        
        }

    }

}