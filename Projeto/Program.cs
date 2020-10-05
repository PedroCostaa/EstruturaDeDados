using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto{
    class Program{
        static void Main(string[] args){
            CircularList lista = new CircularList();
            int opcao=0;
            String name;
            String email;
            String telephone;
            do
            {
            Console.Write("---------------------------------------------\n");
            Console.Write("DIGITE [0] PARA ENCERRAR O PROGRAMA\n");
            Console.Write("DIGITE [1] PARA ADICIONAR UM CONTATO NA LISTA\n");
            Console.Write("DIGITE [2] PARA REMOVER ALGUM CONTATO DA LISTA\n");
            Console.Write("DIGITE [3] PARA ATUALIZAR A LISTA\n");
            Console.Write("DIGITE [4] PARA RECUPERAR UM CONTATO EXSTENTE\n");
            Console.Write("DIGITE [5] PARA ORDENAR A LISTA POR NOME\n");
            Console.Write("DIGITE [6] PARA PRINTAR A LISTA\n");
            Console.WriteLine("DIGITE [7] PARA SALVAR O ARQUIVO");
            Console.WriteLine("DIGITE [8] PARA ENTRAR NO MODO NAVEGACAO");
            Console.Write("DIGITE SUA OPCAO:\n");
            opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                Console.Clear();
                Console.Write("DIGITE O NOME DO CONTATO:\n");
                name = Console.ReadLine();
                Console.Write("DIGITE O EMAIL DO CONTATO:\n");
                email = Console.ReadLine();
                Console.Write("DIGITE O TELEFONE DO CONTATO:\n");
                telephone = Console.ReadLine();
                Contatos cont = new Contatos(); 
                cont.setName(name);
                cont.setEmail(email);
                cont.setTelephoneN(telephone);
                lista.Add(cont);
                break;

                case 2:
                Console.WriteLine("---------------------------------------------");
                CircularList.RemoveSelect(lista);
                break;
                
                case 3:
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("DIGITE O NOME QUE DESEJA ATUALIZAR");
                name = Console.ReadLine();
                lista.Atualizar(name);
                break;

                case 4:
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("DIGITE O NOME QUE DESEJA BUSCAR");
                name = Console.ReadLine();
                lista.Recuperar(name);
                break;

                case 5:
                lista.BubbleSort("name");
                Console.WriteLine("---------------------------------------------");
                Console.Write("LISTA ORDENADA COM SUCESSO\n");
                break;

                case 6:
                Console.WriteLine("---------------------------------------------");
                lista.Print();
                break;

                case 7:
                Console.WriteLine("---------------------------------------------");
                CircularList.SalvarEmArquivo(lista);
                Console.WriteLine("ARQUIVO SALVO COM SUCESSO");
                break;

                case 8:
                CircularList.Navegacao(lista);
                break;
                }
            }while(opcao!=0);
        }
    }
}
