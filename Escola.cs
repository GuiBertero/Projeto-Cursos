using System;

namespace ProjetoCursos
{
    public class Escola
    {
        private Curso[] cursos;

        public Escola()
        {
            cursos = new Curso[5];
        }

        public bool adicionarCurso(Curso curso)
        {
            // Verifica se o curso já existe
            for (int i = 0; i < 5; i++)
            {
                if (cursos[i] != null &&
                    cursos[i].Id == curso.Id)
                {
                    return false;
                }
            }

            // Procura espaço
            for (int i = 0; i < 5; i++)
            {
                if (cursos[i] == null)
                {
                    cursos[i] = curso;
                    return true;
                }
            }

            return false;
        }

        public Curso pesquisarCurso(Curso curso)
        {
            for (int i = 0; i < 5; i++)
            {
                if (cursos[i] != null &&
                    cursos[i].Id == curso.Id)
                {
                    return cursos[i];
                }
            }

            return null;
        }

        public bool removerCurso(Curso curso)
        {
            for (int i = 0; i < 5; i++)
            {
                if (cursos[i] != null &&
                    cursos[i].Id == curso.Id)
                {
                    // Curso não pode possuir disciplinas
                    if (cursos[i].quantidadeDisciplinas() > 0)
                    {
                        return false;
                    }

                    cursos[i] = null;
                    return true;
                }
            }

            return false;
        }

        public Curso getCurso(int posicao)
        {
            if (posicao >= 0 && posicao < 5)
            {
                return cursos[posicao];
            }

            return null;
        }
    }
}
