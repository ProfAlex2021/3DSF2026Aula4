namespace Aula4.Models
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }

        public static List<Pessoa> Lista
        {
            get
            {
                //var lista = new List<Pessoa>();
                //lista.Add(new Pessoa { Nome = "Helder", Idade = 30 });
                //lista.Add(new Pessoa { Nome = "Thiago", Idade = 28 });
                //lista.Add(new Pessoa { Nome = "Benir", Idade = 35 });

                var lista = new List<Pessoa>
                {
                    new() { Nome = "Helder" , Idade = 30},
                    new() { Nome = "Thiago" , Idade = 28},
                    new() { Nome = "Benir" , Idade = 35}
                };

                return lista;
            }
        }

    }
}
