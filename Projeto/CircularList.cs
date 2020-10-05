using System;
using System.IO;
using System.Text;
public class CircularList
{
    public int contador = 0;
    public Node head;
    public Contatos cont;
    public CircularList()
    {
        head = null;
    }
    public void Add(Contatos cont) {
        Node aux = head;
        var newNode = new Node(cont);
        if (head != null)
        {
            while (aux.next != head)
            {
                aux = aux.next;

            }
        }
        else
        {
            aux = newNode;
        }
        newNode.next = head;
        head = newNode;
        aux.next = head;
        contador++;
    }
    public static void RemoveSelect(CircularList list)
    {
        string nome;
        Console.WriteLine("Digite o nome: ");
        nome = Console.ReadLine();
        if(list.RemoveItem(nome))
        {
            Console.WriteLine("Contato deletado com sucesso");
        }
        else
        {
            Console.WriteLine("Não foi possível deletar o contato");
        }
    }
    public bool RemoveItem(string nome)
        {
            if(this.head == null) return false;

            Node iterador = this.head;
            Node ant = null;

            while(iterador.data.name != nome)
            {
                if(iterador.next == this.head) return false;

                ant = iterador;
                iterador = iterador.next;
            }

            if(iterador.next == this.head && ant == null)
            {
                this.head = null;
                this.contador--;
                return true;
            }

            if(iterador == this.head)
            {
                ant = this.head.temp;
                this.head = this.head.next;

                ant.next = this.head;
                this.head.next = ant;
            }
            else if(iterador.next == this.head)
            {
                ant.next = this.head;
                this.head.temp = ant;
            }
            else
            {
                Node aux = iterador.next;

                ant.next = aux;
                aux.temp = ant;
            }
            iterador = null;
            this.contador--;
            return true;
        }

    public void BubbleSort(string field)
        {
            bool swapped;
            Node temp;
            int length = contador;

            if(length <= 0)
            {
                Console.WriteLine("Lista Vazia.");
                return;
            }

            do
            {
                swapped = false;

                temp = head;
                for (int i = 0; i < length - 1; i++)
                {
                    string compareFieldA;
                    string compareFieldB;

                    if (field == "name")
                    {
                        compareFieldA = temp.data.name;
                        compareFieldB = temp.next.data.name;
                    }
                    else
                    {
                        compareFieldA = temp.data.email;
                        compareFieldB = temp.next.data.email;
                    }

                    if (String.Compare(compareFieldA, compareFieldB) > 0)
                    {
                        Contatos t = temp.data;
                        temp.data = temp.next.data;
                        temp.next.data = t;
                        swapped = true;
                    }
                    temp = temp.next;
                }
            } while (swapped);
        }

    public void Recuperar(String nome){
        String comparar;
        if (head == null)
        {
            Console.Write("Lista Vazia.");
        }
        var aux = head;
        do
        {
            comparar = aux.data.name;
            if(nome.Equals(comparar)){
                Console.WriteLine("CONTATO PROCURADO: " + aux.data.toString());
            }
            aux = aux.next;
        } while (aux != head);
    }

    public void Atualizar(String nome){
        String comparar;
        int opcao = 0;
        String newEmail;
        String newTelephone;
        if (head == null){
            Console.Write("Lista Vazia.");
        }
        var aux = head;
        do{
            comparar = aux.data.name;
            if(nome.Equals(comparar)){
                Console.WriteLine("DESEJA ATUALIZAR QUAIS CAMPOS?");
                Console.WriteLine("[1] EMAIL");
                Console.WriteLine("[2] NUMERO DE TELEFONE");
                Console.WriteLine("");
                opcao = int.Parse(Console.ReadLine());
                if(opcao==1){
                    Console.WriteLine("DIGITE O NOVO EMAIL:");
                    newEmail = Console.ReadLine();
                    aux.data.email = newEmail;
                }
                else{
                    Console.WriteLine("DIGITE O NOVO TELEFONE:");
                    newTelephone = Console.ReadLine();
                    aux.data.telephoneN = newTelephone;
                }
            }
            aux = aux.next;
        } while (aux != head);
    }
    public void Print()
    {
        if (head == null)
        {
            Console.Write("Lista Vazia.");
        }
        var aux = head;
        do
        {
            Console.WriteLine($"-> {aux.data.toString()}");
            aux = aux.next;
        } while (aux != head);
    }

   public static void SalvarEmArquivo(CircularList lista){
        try{
            using (FileStream fs = File.Create("lista.txt")){
                Node aux = lista.head;
                if(aux == null) return;
                    while(aux.next != lista.head){
                        AddText(fs, $"Nome:{aux.data.name}\n Email:{aux.data.email}\n Telefone:{aux.data.telephoneN}\n");
                        aux = aux.next;
                    }
                    AddText(fs, $"Nome: {aux.data.name}\nEmail: {aux.data.email}\nTelefone: {aux.data.telephoneN}");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    public static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }

    public static void Navegacao(CircularList lista)
        {
            Node iterador = lista.head;
            if(iterador == null) return;
            while(true)
            {
                Console.Clear();
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("SETA PARA ESQUERDA VAI PARA POSICAO ANTERIOR");
                Console.WriteLine("SETA PARA DIREITA VAI PARA A POSICAO SUCESSOR");
                Console.WriteLine("BARRA DE ESPACO SAI DA NAVEGAO");
                Console.WriteLine(iterador.data);
                string tecla = Console.ReadKey().Key.ToString();
                if(tecla == "LeftArrow")
                {
                    iterador = iterador.temp;
                }
                else if(tecla == "RightArrow")
                {
                    iterador = iterador.next;
                }
                else if(tecla == "Spacebar")
                {
                    break;
                }
            }
            Console.Clear();
        }
}

