using System;
using System.Collections.Generic;

class Book{
    public int bookId;
    public string bookName;
    public Book(int bookId, string bookName){
        this.bookId=bookId;
        this.bookName=bookName;
    }
}

class Rental{
    public Book book;
    public DateTime dateRented;
    public DateTime dateDue;
    
    public Rental(Book book, DateTime dateDue){
        this.book=book;
        this.dateRented=DateTime.Today;
        this.dateDue=dateDue;
    }
}

class Person{
    public string firstName, lastName;
    public Person(string firstName, string lastName){
        this.firstName=firstName;
        this.lastName=lastName;
    }
}

class Patron : Person{
    string libraryId;
    DateTime startDate;
    DateTime endDate;
    bool isAccountActive;
    List<Rental> rentalCart;
    int fineAmountDue;
    
    public Patron(string firstName, string lastName, string libraryId):base(firstName, lastName){
        
        this.fineAmountDue=0;
        this.libraryId=libraryId;
        this.startDate=DateTime.Today;
        this.isAccountActive=true;
        rentalCart=new List<Rental>();
    }
    
    public void display(){
        Console.WriteLine("Patron Id="+this.libraryId+" Name="+base.firstName+" "+base.lastName);
    }
    
    public void addToRentalCart(Book book, DateTime dateDue){
        
        Rental obj=new Rental(book, dateDue);
        
        rentalCart.Add(obj);
        Console.WriteLine("Added to rental cart "+book.bookName+" Book "+book.bookId+" for Patron "+base.firstName+" "+base.lastName);
    }
    
    public void removeFromRentalCart(Book book){
        for(int i=0;i<rentalCart.Count;i++){
            if(rentalCart[i].book.bookId.Equals(book.bookId) && rentalCart[i].book.bookName.Equals(book.bookName)){
                
                rentalCart.RemoveAt(i);
                break;
            }
        } 
        Console.WriteLine("Removed from rental cart "+book.bookName+" Book "+book.bookId+" for Patron "+base.firstName+" "+base.lastName);
    }
}

class Test {
    static void Main() {
        
        Book book1=new Book(1,"Harry Potter");
        Book book2=new Book(2,"Harry Potter");
        Book book3=new Book(3,"Harry Potter");
        
        Patron p1=new Patron("Daryonne","Rollins", "1111");
        Patron p2=new Patron("Isaiah","Simpkins", "2222");
        Patron p3=new Patron("Jonie","Glenn", "5555");
        Patron p4=new Patron("Darryl","Rollins", "4444");
        Patron p5=new Patron("Lyrriah","Rollins", "0000");
        p1.addToRentalCart(book3, DateTime.Parse("12/08/2020"));
        
        p1.addToRentalCart(book1, DateTime.Parse("12/15/2020"));
        
        p1.removeFromRentalCart(book3);
        
        p1.display();
  }
}

