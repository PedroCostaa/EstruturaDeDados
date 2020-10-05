using System;
public class Node
{
    public Contatos data;
    public Node next;
    public Node temp;
    public Node(Contatos cont)
    {
        data = cont;
        this.temp = this.next = null;
    }
}
