using Clockwork.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clockwork.Persistence
{
    public class CronogramaJson
    {
        private readonly string _jsonPath;

        public CronogramaJson(string jsonPath = @"C:\Clockwork\horas.json")
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
            string json = JsonConvert.SerializeObject(cronograma.Apontamentos);
            using (StreamWriter sw = File.CreateText(_jsonPath))
            {
                sw.Write(json);
            }
        }

       
    }
}
