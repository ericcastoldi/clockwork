using Clockwork;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clockwork
{
    public class CronogramaJson
    {
        private readonly string _jsonPath;

        public CronogramaJson()
        {
            _jsonPath = @"C:\Clockwork\horas.json";
        }
        
        public CronogramaJson(string jsonPath)
        {
            _jsonPath = jsonPath;
        }
        
        public Cronograma CarregarCronograma()
        {
            using (StreamReader sr = File.OpenText(_jsonPath))
            {
                var sb = new StringBuilder();
                var line = string.Empty;
                while ((line = sr.ReadLine()) != null)
                {
                    sb.Append(line);
                }

                var json = sb.ToString();
                var crono = JsonConvert.DeserializeObject<Apontamento[]>(json);
                if (crono != null)
                { 
                    return new Cronograma(crono.ToList());
                }

                return new Cronograma(new List<Apontamento>());
            }
        }

        public void Salvar(Cronograma cronograma)
        {
            if (cronograma == null
                || cronograma.Apontamentos == null
                || cronograma.Apontamentos.Count == 0)
            {
                throw new ArgumentException("O argumento passado está em um estado inválido. O cronograma não deve ser nulo e deve possuir uma lista de apontamentos não nula e não vazia.");
            }

            string json = JsonConvert.SerializeObject(cronograma.Apontamentos);
            using (StreamWriter sw = File.CreateText(_jsonPath))
            {
                sw.Write(json);
            }
        }

       
    }
}
