using System;

class __Empty {

}

class __A {
    __Empty a = new __Empty();
    __Empty b = new __Empty();
}

public class A {
    public static void Main(String[] _) {
        var a = new __A();
        Console.WriteLine("Hello");
    }
}
