using System;

namespace ProjetoCursos
{
    public class Disciplina
    {
        private int id;
        private string descricao;
        private Aluno[] alunos;

        public Disciplina(int id, string descricao)
        {
            this.id = id;
            this.descricao = descricao;
            this.alunos = new Aluno[15];
        }

        public int Id
        {
            get { return id; }
        }

        public string Descricao
        {
            get { return descricao; }
        }

        public bool matricularAluno(Aluno aluno)
        {
            for (int i = 0; i < 15; i++)
            {
                if (alunos[i] != null &&
                    alunos[i].Id == aluno.Id)
                {
                    return false;
                }
            }

            for (int i = 0; i < 15; i++)
            {
                if (alunos[i] == null)
                {
                    alunos[i] = aluno;
                    return true;
                }
            }

            return false;
        }

        public bool desmatricularAluno(Aluno aluno)
        {
            for (int i = 0; i < 15; i++)
            {
                if (alunos[i] != null &&
                    alunos[i].Id == aluno.Id)
                {
                    alunos[i] = null;
                    return true;
                }
            }

            return false;
        }

        public bool alunoMatriculado(Aluno aluno)
        {
            for (int i = 0; i < 15; i++)
            {
                if (alunos[i] != null &&
                    alunos[i].Id == aluno.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public Aluno procurarAluno(int id)
        {
            for (int i = 0; i < 15; i++)
            {
                if (alunos[i] != null &&
                    alunos[i].Id == id)
                {
                    return alunos[i];
                }
            }

            return null;
        }

        public int quantidadeAlunos()
        {
            int quantidade = 0;

            for (int i = 0; i < 15; i++)
            {
                if (alunos[i] != null)
                {
                    quantidade++;
                }
            }

            return quantidade;
        }

        public Aluno getAluno(int posicao)
        {
            if (posicao >= 0 && posicao < 15)
            {
                return alunos[posicao];
            }

            return null;
        }
    }
}
