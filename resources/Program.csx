using System;

class _Empty { }

class _Int1 {
    int a = 100;
}

class _String1 {
    string a = "";
}

class _Float1 {
    float a = 0;
}

class _Double1 {
    double a = 0;
}

class _String2 {
    string a = "";
    string b = "";
}

class Program {
    public static void Main(String[] args) {
        new _Empty();
        new _Empty();
        new _Int1();
        new _String1();
        new _String2();
        new _Float1();
        new _Double1();
        Console.WriteLine("Hello, world!");
    }
}