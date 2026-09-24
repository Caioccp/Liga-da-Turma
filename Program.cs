using System;

class Program
{
    static void Main(string[] args)
    {
        Sistema sistema = new Sistema();

        Menu menu = new Menu(sistema);

        menu.Exibir();
    }
}