using System;

namespace ProjetoCursos
{
    public class Aluno
    {
        private int id;
        private string nome;

        public Aluno(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }

        public int Id
        {
            get { return id; }
        }

        public string Nome
        {
            get { return nome; }
        }

        public bool podeMatricular(Escola escola)
        {
            int quantidadeDisciplinas = 0;
            bool possuiCurso = false;

            for (int i = 0; i < 5; i++)
            {
                Curso curso = escola.getCurso(i);

                if (curso != null)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        Disciplina disciplina = curso.getDisciplina(j);

                        if (disciplina != null)
                        {
                            if (disciplina.alunoMatriculado(this))
                            {
                                quantidadeDisciplinas++;
                                possuiCurso = true;
                            }
                        }
                    }
                }
            }

            // O aluno pode estar em no máximo 6 disciplinas
            if (quantidadeDisciplinas >= 6)
            {
                return false;
            }

            return true;
        }
    }
}
