using System.Collections.Generic;

namespace webapi.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Materia { get; set; }
        public List<Aluno> Alunos { get; set; }
    }
}