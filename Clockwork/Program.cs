using Clockwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clockwork
{
    public static class Program
    {
        public static void Main()
        {
            /*
             * *** CLOCKWORK - Auxiliar para apontamento de horas ***
             * 
             * A ideia é que seja gerado um json nos moldes de:
              
                { dia: 19-12, horas_lancadas: 08:30, falta_lancar: 00:00 }
                { dia: 22-12, horas_lancadas: 08:30, falta_lancar: 00:00 }
                { dia: 23-12, horas_lancadas: 01:00, falta_lancar: 07:30 }
             
             * ...e o Clockwork fica com a tarefa de manter esse json (ler, editar, gravar, etc) para auxiliar no controle de apontamento de horas.
             * Futuramente ele poderia emitir notificações para lembrar de registrar apontamentos, etc.
             * 
             * Próximos passos: 
             *  > Testes unitários do modelo
             *  > Leitura/Gravação do Json
             *  > Emissão de lembretes
             
             */
            var json = new CronogramaJson();
            var cronograma = json.CarregarCronograma();

            cronograma = cronograma.LancarApontamento(new Apontamento(DateTime.Today, new TimeSpan(5, 30, 0)));

            json.Salvar(cronograma);
        }
    }
}
