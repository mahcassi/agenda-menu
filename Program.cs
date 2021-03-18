using System;

namespace Agenda_Menu
{
    class Program
    {
        public struct dados
        {
            public int situacao;
            public string nome, telefone, empresa;
        }
        static void Main(string[] args)
        {
            int op;
            dados[] agenda = new dados[30];
            int num_pessoas = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("1- Adicionar Contato");
                Console.WriteLine("2 - Excluir Contato");
                Console.WriteLine("3- Listar todos contatos");
                Console.WriteLine("4- Alterar Contato");
                Console.WriteLine("5 - Sair");
                Console.Write("Digite sua opção: ");
                op = int.Parse(Console.ReadLine());
                valida(ref op);
                switch(op)
                {
                    case 1:
                        Console.WriteLine("Cadastro de contato: ");
                        if (num_pessoas > 30)
                            Console.WriteLine("Agenda cheia!");
                        else
                            entrada(ref num_pessoas, agenda);
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Excluir contato: ");
                        excluir(num_pessoas, agenda);
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Listagem de contatos: ");
                        listar(num_pessoas, agenda);
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine("Alteração de contato: ");
                        alterar(num_pessoas, agenda);
                        Console.ReadKey();
                        break;
                }
      
            } while (op != 5);
            Console.WriteLine("Pressione enter para encerrar!");
            Console.ReadKey();
        }
        static void valida(ref int x)
        {
            while(x < 1 || x > 5)
            {
                Console.WriteLine("Por favor, redigite um número entre 1 e 5: ");
                x = int.Parse(Console.ReadLine());
            }
        }
        static void entrada(ref int i, dados [] P)
        {
            Console.Write("Digite o nome: ");
            P[i].nome = Console.ReadLine();
            P[i].situacao = 1;
            Console.Write("Digite o telefone: ");
            P[i].telefone = Console.ReadLine();
            Console.Write("Digite o nome da empresa: ");
            P[i].empresa = Console.ReadLine();
            i++;

        }
        static void listar(int x, dados[] P)
        {
            for (int i = 0; i < x; i++)
            {
                if(P[i].situacao==1)// por conta da exclusão que coloca zero na situação.
                Console.WriteLine("Nome: {0}, Telefone: {1} e empresa:{2}", P[i].nome, P[i].telefone, P[i].empresa);
            } 
        }
        static void alterar(int x, dados[] P)
        {
            string pesquisa;
            char achou;
            achou = 'N';
            Console.Write("Digite o nome a ser alterado: ");
            pesquisa = Console.ReadLine();
            for( int i=0; i<x; i++)
            {
                if(pesquisa == P[i].nome && P[i].situacao == 1)
                {
                    Console.Write("Digite o novo nome: ");
                    P[i].nome = Console.ReadLine();
                    Console.Write("Digite o novo telefone: ");
                    P[i].telefone = Console.ReadLine();
                    Console.Write("Digite a nova empresa: ");
                    P[i].empresa = Console.ReadLine();
                    Console.WriteLine("Contato alterado com sucesso!");
                    achou = 'S';
                }
            }
            if (achou == 'N')
                Console.WriteLine("Contato não cadastrado");
        }
        static void excluir(int x, dados[] P)
        {
            string pesquisa;
            char achou;
            achou = 'N';
            Console.Write("Digite o nome a ser excluido: ");
            pesquisa = Console.ReadLine();
            for (int i = 0; i < x; i++)
            {
                if (pesquisa == P[i].nome && P[i].situacao == 1)
                { 
                    P[i].situacao = 0;
                    Console.WriteLine("Contato excluído com sucesso!");
                    achou = 'S';
                }
            }
            if (achou == 'N')
                Console.WriteLine("Contato não cadastrado");
        }
}
}

