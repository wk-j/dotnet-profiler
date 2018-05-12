using System;

class A {
    public string AA() { return "AA"; }
    public string BB() { return "BB"; }
    public string CC() => "CC";
}

class Program {
    public static void Main(String[] args) {
        var a = new A();
        var x = a.AA();
        var y = a.BB();
        Console.WriteLine("Hello, world!");
    }
}