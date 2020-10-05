using System;

public class Contatos{
    public String name;
    public String telephoneN;
    public String email;


    public String toString() {
        return  "Name: " + name + ", Telefone: " + telephoneN + ", Email: " + email;
    }
    public void setName(String name){
        this.name = name;
    }
    public void setTelephoneN(String telephoneN){
        this.telephoneN = telephoneN;
    }
    public void setEmail(String email){
        this.email = email;
    }

    public String getName(){
        return name;
    }
    public String getTelephoneN(){
        return telephoneN;
    }
    public String getEmail(){
        return email;
    }




    

} 