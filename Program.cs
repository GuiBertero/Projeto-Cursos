using System;

namespace ProjetoCursos
{
    internal class Program
    {
        static Escola escola = new Escola();

        static void Main(string[] args)
        {
            int opcao;

            do
            {
                Console.Clear();

                Console.WriteLine("======================================");
                Console.WriteLine("          SISTEMA DA ESCOLA");
                Console.WriteLine("======================================");
                Console.WriteLine("1 - Adicionar curso");
                Console.WriteLine("2 - Pesquisar curso");
                Console.WriteLine("3 - Remover curso");
                Console.WriteLine("4 - Adicionar disciplina no curso");
                Console.WriteLine("5 - Pesquisar disciplina");
                Console.WriteLine("6 - Remover disciplina do curso");
                Console.WriteLine("7 - Matricular aluno na disciplina");
                Console.WriteLine("8 - Remover aluno da disciplina");
                Console.WriteLine("9 - Pesquisar aluno");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("======================================");

                opcao = LerInteiro("Digite uma opção: ");

                Console.Clear();

                switch (opcao)
                {
                    case 1:
                        AdicionarCurso();
                        break;

                    case 2:
                        PesquisarCurso();
                        break;

                    case 3:
                        RemoverCurso();
                        break;

                    case 4:
                        AdicionarDisciplina();
                        break;

                    case 5:
                        PesquisarDisciplina();
                        break;

                    case 6:
                        RemoverDisciplina();
                        break;

                    case 7:
                        MatricularAluno();
                        break;

                    case 8:
                        RemoverAluno();
                        break;

                    case 9:
                        PesquisarAluno();
                        break;

                    case 0:
                        Console.WriteLine("Programa encerrado.");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                if (opcao != 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Pressione ENTER para continuar...");
                    Console.ReadLine();
                }

            } while (opcao != 0);
        }

        // ==========================================
        // 1 - ADICIONAR CURSO
        // ==========================================

        static void AdicionarCurso()
        {
            Console.WriteLine("======================================");
            Console.WriteLine("           ADICIONAR CURSO");
            Console.WriteLine("======================================");

            int id = LerInteiro("ID do curso: ");

            Curso existente =
                escola.pesquisarCurso(
                    new Curso(id, "")
                );

            if (existente != null)
            {
                Console.WriteLine("Já existe um curso com esse ID.");
                return;
            }

            Console.Write("Descrição do curso: ");
            string descricao = Console.ReadLine();

            Curso curso = new Curso(id, descricao);

            if (escola.adicionarCurso(curso))
            {
                Console.WriteLine("Curso adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Não foi possível adicionar o curso.");
                Console.WriteLine("A escola já possui 5 cursos.");
            }
        }

        // ==========================================
        // 2 - PESQUISAR CURSO
        // ==========================================

        static void PesquisarCurso()
        {
            Console.WriteLine("======================================");
            Console.WriteLine("           PESQUISAR CURSO");
            Console.WriteLine("======================================");

            int id = LerInteiro("ID do curso: ");

            Curso curso =
                escola.pesquisarCurso(
                    new Curso(id, "")
                );

            if (curso == null)
            {
                Console.WriteLine("Curso não encontrado.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("ID: " + curso.Id);
            Console.WriteLine("Descrição: " + curso.Descricao);

            Console.WriteLine();
            Console.WriteLine("Disciplinas:");

            bool possuiDisciplinas = false;

            for (int i = 0; i < 12; i++)
            {
                Disciplina disciplina = curso.getDisciplina(i);

                if (disciplina != null)
                {
                    possuiDisciplinas = true;

                    Console.WriteLine(
                        "ID: " + disciplina.Id +
                        " - " + disciplina.Descricao
                    );
                }
            }

            if (!possuiDisciplinas)
            {
                Console.WriteLine("Nenhuma disciplina cadastrada.");
            }
        }

        // ==========================================
        // 3 - REMOVER CURSO
        // ==========================================

        static void RemoverCurso()
        {
            Console.WriteLine("======================================");
            Console.WriteLine("            REMOVER CURSO");
            Console.WriteLine("======================================");

            int id = LerInteiro("ID do curso: ");

            Curso curso =
                escola.pesquisarCurso(
                    new Curso(id, "")
                );

            if (curso == null)
            {
                Console.WriteLine("Curso não encontrado.");
                return;
            }

            if (curso.quantidadeDisciplinas() > 0)
            {
                Console.WriteLine(
                    "Não é possível remover o curso."
                );

                Console.WriteLine(
                    "O curso possui disciplinas associadas."
                );

                return;
            }

            if (escola.removerCurso(curso))
            {
                Console.WriteLine("Curso removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Não foi possível remover o curso.");
            }
        }

        // ==========================================
        // 4 - ADICIONAR DISCIPLINA
        // ==========================================

        static void AdicionarDisciplina()
        {
            Console.WriteLine("======================================");
            Console.WriteLine("       ADICIONAR DISCIPLINA");
            Console.WriteLine("======================================");

            int idCurso = LerInteiro("ID do curso: ");

            Curso curso =
                escola.pesquisarCurso(
                    new Curso(idCurso, "")
                );

            if (curso == null)
            {
                Console.WriteLine("Curso não encontrado.");
                return;
            }

            int idDisciplina =
                LerInteiro("ID da disciplina: ");

            Disciplina existente =
                curso.pesquisarDisciplina(
                    new Disciplina(idDisciplina, "")
                );

            if (existente != null)
            {
                Console.WriteLine(
                    "Já existe uma disciplina com esse ID no curso."
                );

                return;
            }

            Console.Write("Descrição da disciplina: ");
            string descricao = Console.ReadLine();

            Disciplina disciplina =
                new Disciplina(idDisciplina, descricao);

            if (curso.adicionarDisciplina(disciplina))
            {
                Console.WriteLine(
                    "Disciplina adicionada com sucesso!"
                );
            }
            else
            {
                Console.WriteLine(
                    "Não foi possível adicionar a disciplina."
                );

                Console.WriteLine(
                    "O curso já possui 12 disciplinas."
                );
            }
        }

        // ==========================================
        // 5 - PESQUISAR DISCIPLINA
        // ==========================================

        static void PesquisarDisciplina()
        {
            Console.WriteLine("======================================");
            Console.WriteLine("       PESQUISAR DISCIPLINA");
            Console.WriteLine("======================================");

            int idCurso =
                LerInteiro("ID do curso: ");

            Curso curso =
                escola.pesquisarCurso(
                    new Curso(idCurso, "")
                );

            if (curso == null)
            {
                Console.WriteLine("Curso não encontrado.");
                return;
            }

            int idDisciplina =
                LerInteiro("ID da disciplina: ");

            Disciplina disciplina =
                curso.pesquisarDisciplina(
                    new Disciplina(idDisciplina, "")
                );

            if (disciplina == null)
            {
                Console.WriteLine("Disciplina não encontrada.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("ID: " + disciplina.Id);
            Console.WriteLine(
                "Descrição: " + disciplina.Descricao
            );

            Console.WriteLine();
            Console.WriteLine("Alunos matriculados:");

            bool possuiAlunos = false;

            for (int i = 0; i < 15; i++)
            {
                Aluno aluno = disciplina.getAluno(i);

                if (aluno != null)
                {
                    possuiAlunos = true;

                    Console.WriteLine(
                        "ID: " + aluno.Id +
                        " - " + aluno.Nome
                    );
                }
            }

            if (!possuiAlunos)
            {
                Console.WriteLine(
                    "Nenhum aluno matriculado."
                );
            }
        }

        // ==========================================
        // 6 - REMOVER DISCIPLINA
        // ==========================================

        static void RemoverDisciplina()
        {
            Console.WriteLine("======================================");
            Console.WriteLine("        REMOVER DISCIPLINA");
            Console.WriteLine("======================================");

            int idCurso =
                LerInteiro("ID do curso: ");

            Curso curso =
                escola.pesquisarCurso(
                    new Curso(idCurso, "")
                );

            if (curso == null)
            {
                Console.WriteLine("Curso não encontrado.");
                return;
            }

            int idDisciplina =
                LerInteiro("ID da disciplina: ");

            Disciplina disciplina =
                curso.pesquisarDisciplina(
                    new Disciplina(idDisciplina, "")
                );

            if (disciplina == null)
            {
                Console.WriteLine("Disciplina não encontrada.");
                return;
            }

            if (disciplina.quantidadeAlunos() > 0)
            {
                Console.WriteLine(
                    "Não é possível remover a disciplina."
                );

                Console.WriteLine(
                    "Existem alunos matriculados."
                );

                return;
            }

            if (curso.removerDisciplina(disciplina))
            {
                Console.WriteLine(
                    "Disciplina removida com sucesso!"
                );
            }
            else
            {
                Console.WriteLine(
                    "Não foi possível remover a disciplina."
                );
            }
        }

        // ==========================================
        // 7 - MATRICULAR ALUNO
        // ==========================================

        static void MatricularAluno()
        {
            Console.WriteLine("======================================");
            Console.WriteLine("        MATRICULAR ALUNO");
            Console.WriteLine("======================================");

            int idCurso =
                LerInteiro("ID do curso: ");

            Curso curso =
                escola.pesquisarCurso(
                    new Curso(idCurso, "")
                );

            if (curso == null)
            {
                Console.WriteLine("Curso não encontrado.");
                return;
            }

            int idDisciplina =
                LerInteiro("ID da disciplina: ");

            Disciplina disciplina =
                curso.pesquisarDisciplina(
                    new Disciplina(idDisciplina, "")
                );

            if (disciplina == null)
            {
                Console.WriteLine("Disciplina não encontrada.");
                return;
            }

            int idAluno =
                LerInteiro("ID do aluno: ");

            Console.Write("Nome do aluno: ");
            string nome = Console.ReadLine();

            Aluno aluno = new Aluno(idAluno, nome);

            // Verifica se o aluno já está matriculado
            // em alguma disciplina da escola.
            if (!aluno.podeMatricular(escola))
            {
                Console.WriteLine(
                    "O aluno já está matriculado em 6 disciplinas."
                );

                return;
            }

            if (disciplina.matricularAluno(aluno))
            {
                Console.WriteLine(
                    "Aluno matriculado com sucesso!"
                );
            }
            else
            {
                Console.WriteLine(
                    "Não foi possível matricular o aluno."
                );

                Console.WriteLine(
                    "A disciplina pode estar cheia ou o aluno já está matriculado."
                );
            }
        }

        // ==========================================
        // 8 - REMOVER ALUNO
        // ==========================================

        static void RemoverAluno()
        {
            Console.WriteLine("======================================");
            Console.WriteLine("        REMOVER ALUNO");
            Console.WriteLine("======================================");

            int idCurso =
                LerInteiro("ID do curso: ");

            Curso curso =
                escola.pesquisarCurso(
                    new Curso(idCurso, "")
                );

            if (curso == null)
            {
                Console.WriteLine("Curso não encontrado.");
                return;
            }

            int idDisciplina =
                LerInteiro("ID da disciplina: ");

            Disciplina disciplina =
                curso.pesquisarDisciplina(
                    new Disciplina(idDisciplina, "")
                );

            if (disciplina == null)
            {
                Console.WriteLine("Disciplina não encontrada.");
                return;
            }

            int idAluno =
                LerInteiro("ID do aluno: ");

            Aluno aluno = new Aluno(idAluno, "");

            if (disciplina.desmatricularAluno(aluno))
            {
                Console.WriteLine(
                    "Aluno removido da disciplina com sucesso!"
                );
            }
            else
            {
                Console.WriteLine(
                    "Aluno não encontrado na disciplina."
                );
            }
        }

        // ==========================================
        // 9 - PESQUISAR ALUNO
        // ==========================================

        static void PesquisarAluno()
        {
            Console.WriteLine("======================================");
            Console.WriteLine("          PESQUISAR ALUNO");
            Console.WriteLine("======================================");

            int idAluno =
                LerInteiro("ID do aluno: ");

            bool encontrou = false;
            string nomeAluno = "";

            Console.WriteLine();
            Console.WriteLine("Disciplinas do aluno:");

            for (int i = 0; i < 5; i++)
            {
                Curso curso = escola.getCurso(i);

                if (curso != null)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        Disciplina disciplina =
                            curso.getDisciplina(j);

                        if (disciplina != null)
                        {
                            Aluno aluno =
                                disciplina.procurarAluno(idAluno);

                            if (aluno != null)
                            {
                                encontrou = true;
                                nomeAluno = aluno.Nome;

                                Console.WriteLine(
                                    "- " + disciplina.Descricao +
                                    " (Curso: " +
                                    curso.Descricao + ")"
                                );
                            }
                        }
                    }
                }
            }

            if (!encontrou)
            {
                Console.WriteLine(
                    "Aluno não encontrado."
                );
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine(
                    "Nome: " + nomeAluno
                );
            }
        }

        // ==========================================
        // MÉTODO AUXILIAR
        // ==========================================

        static int LerInteiro(string mensagem)
        {
            int valor;

            while (true)
            {
                Console.Write(mensagem);

                if (int.TryParse(Console.ReadLine(), out valor))
                {
                    return valor;
                }

                Console.WriteLine(
                    "Digite um número inteiro válido."
                );
            }
        }
    }
}
