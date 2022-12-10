using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Nombre: Santiago Martínez Martínez
//Grupo: 213023_90
//Programa: Ingeniería Multimedia (107601)
//Código Fuente: Autoría Propia


namespace Tarea5_SantiagoMartinez
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Cuentas inscritas para el testeo del codigo:

                                            //Id     //Password   //Saldo    //Puntos
            Cuenta cuenta1 = new Cuenta(    12345,      4321,     8000000,     7000);
            Cuenta cuenta2 = new Cuenta(    54321,      1234,      200000,    20000);
            Cuenta cuenta3 = new Cuenta(    11111,      1111,     5000000,     1505);
            Cuenta cuenta4 = new Cuenta(    22222,      2222,     4000500,     9000);

            List<Cuenta> cuentas = new List<Cuenta>();

            cuentas.Add(cuenta1);
            cuentas.Add(cuenta2);
            cuentas.Add(cuenta3);
            cuentas.Add(cuenta4);

            //Variables de control
            bool controlUser = true, hayError;
            int menuOpcion = 1, ubicacion = -1;


            //Menu inicial
            do
            {
                //Manejo de errores
                try
                {

                    do
                    {
                        // Verificacion de cuenta
                        Console.Clear();
                        Console.WriteLine("BIENVENIDO AL BANCO VIVECOLOMBIA");
                        Console.Write("\n\nPor favor ingrese su ID: ");
                        int idUser = Convert.ToInt32(Console.ReadLine());

                        for (int i = 0; i < cuentas.Count; i++)
                        {
                            if (idUser == cuentas[i].GetId())
                            {
                                ubicacion = i;
                            }
                        }

                        if(ubicacion == -1)
                        {
                            Console.WriteLine("No se encuentra ninguna cuenta con este ID, intente nuevamente");
                            Console.ReadKey();
                        }

                    } while (ubicacion == -1);

                    //Verificacion de password
                    bool noPassword = true;
                    do
                    {
                        Console.Write("Por favor ingrese su contraseña: ");
                        int passwordUser = Convert.ToInt32(Console.ReadLine());

                        if(passwordUser == cuentas[ubicacion].GetPs())
                        {
                            noPassword = false;
                        }

                        if(noPassword == true)
                        {
                            Console.WriteLine("No coincide la contraseña, intente nuevamente");
                        }

                    }
                    while (noPassword);
                    hayError = false;

                }
                catch( Exception )
                {
                    Console.WriteLine("Por favor escriba una respuesta valida");
                    Console.Write("Presione una tecla para continuar: ");
                    Console.ReadKey();
                    hayError = true;
                }

                menu:

                try
                {
                    //TODO: Comprobacion del usuario
                    if (!hayError)
                    {
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Que desea hacer?:");
                            Console.WriteLine("\n\n1. Consultar dinero");
                            Console.WriteLine("2. Consultar puntos");
                            Console.WriteLine("3. Transferir");
                            Console.WriteLine("4. Retirar dinero");
                            Console.WriteLine("5. Canjear puntos");
                            Console.WriteLine("6. Salir");
                            menuOpcion = Convert.ToInt32(Console.ReadLine());

                            switch (menuOpcion)
                            {
                                case 1:
                                    //Consultar Dinero
                                    Console.Clear();
                                    Console.Write("Su saldo es de: " + cuentas[ubicacion].ConsultarDinero());
                                    Console.ReadKey();
                                    break;

                                case 2:
                                    //Consultar Puntos
                                    Console.Clear();
                                    Console.Write("Sus puntos son: " + cuentas[ubicacion].ConsultarPuntos());
                                    Console.ReadKey();
                                    break;

                                case 3:
                                    //Transferir
                                    Console.Clear();
                                    bool userFound = false;
                                    Console.Write("Escribe el Id de la cuenta a la que deseas transferir: ");
                                    int cuentaATransferir = Convert.ToInt32(Console.ReadLine());

                                    for (int i = 0; i < cuentas.Count; i++)
                                    {
                                        if (cuentaATransferir == cuentas[i].GetId())
                                        {
                                            userFound = true;
                                            Console.Write("Cuanto deseas transferir?: ");
                                            double precio = Convert.ToDouble(Console.ReadLine());

                                            while ((cuentas[ubicacion].ConsultarDinero() - precio) < 0)
                                            {
                                                Console.Write("No cuentas con el dinero suficiente para hacer esta transacción");
                                                Console.Write("\nIntente nuevamente: ");
                                                precio = Convert.ToDouble(Console.ReadLine());
                                            }

                                            cuentas[ubicacion].Transferir(cuentas[i], precio);
                                        }
                                    }

                                    if (userFound == false)
                                    {
                                        Console.WriteLine("No se encuentra un usuario con este ID");
                                    }

                                    Console.ReadKey();
                                    break;

                                case 4:
                                    //Retirar Dinero
                                    Console.Clear();
                                    cuentas[ubicacion].RetirarDinero();
                                    Console.ReadKey();
                                    break;

                                case 5:
                                    //Canjear Puntos
                                    Console.Clear();
                                    cuentas[ubicacion].CanjearPuntos();
                                    Console.ReadKey();
                                    break;
                            }

                        } while (menuOpcion > 0 && menuOpcion < 6);

                        ubicacion = -1;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Ingrese una respuesta válida");
                    Console.ReadKey();
                    Console.Clear();
                    goto menu;
                }
                
            }
            while(controlUser);
        }
    }
}
