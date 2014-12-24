using Clockwork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clockwork
{
    public class Program
    {
        public void Main()
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

            var apontamento = new Apontamento(DateTime.Today, new TimeSpan(2, 0, 0));
            var cronograma = new Cronograma(new List<Apontamento>()); // Poderia ser lido do json e populado um cronograma.
        }
    }
}
