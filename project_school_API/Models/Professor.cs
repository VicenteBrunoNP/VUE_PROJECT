using System.Collections.Generic;

namespace project_school_API.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Aluno> Alunos { get; set; }
    }
}