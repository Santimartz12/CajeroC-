using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea5_SantiagoMartinez
{
    internal class Cuenta
    {
        private double saldo, limite = 2000000;
        private int puntos, id, password;

        public Cuenta(int id, int password, double saldo, int puntos)
        {
            this.saldo = saldo;
            this.puntos = puntos;
            this.id = id;
            this.password = password;
        }

        public Cuenta(){}

        override
        public string ToString()
        {
            return ("Saldo disponible: " + this.saldo.ToString());
        } 

        public int GetId()
        {
            return this.id;
        }

        public int GetPs()
        {
            return this.password;
        }

        public double ConsultarDinero()
        {
            return this.saldo;
        }

        public int ConsultarPuntos()
        {
            return this.puntos;
        }

        public void Transferir(Cuenta cuentaAEnviar, double saldo)
        {
            Console.WriteLine("Se ha enviado $" + saldo + " pesos al numero de cuenta " + cuentaAEnviar.GetId());
            cuentaAEnviar.AgregarDinero(saldo);
            RestarDinero(saldo);

            Console.WriteLine("Su saldo actual es de: " + ConsultarDinero());

        }

        private void AgregarDinero(double saldo)
        {
            this.saldo += saldo;
        } 

        private void RestarDinero(double saldo)
        {
            this.saldo -= saldo;
        }

        public void RetirarDinero()
        {
            Console.Write("Cuanto dinero desea retirar?: ");
            double dineroARetirar = Convert.ToDouble(Console.ReadLine());

            while( (this.saldo - dineroARetirar) < 0)
            {
                Console.Write("No tienes suficiente dinero para retirar esta cantidad, intenta nuevamente: ");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Cuanto dinero desea retirar?: ");
                dineroARetirar = Convert.ToDouble(Console.ReadLine()); ;
            }

            while ((this.limite - dineroARetirar) < 0)
            {
                Console.Write("No puedes retirar mas de dos millones al dia");
                Console.Write("\nTu saldo permitido a retirar el dia de hoy es de " + this.limite + " pesos");
                Console.ReadKey();
                Console.Clear();
                Console.Write("Cuanto dinero desea retirar?: ");
                dineroARetirar = Convert.ToDouble(Console.ReadLine());
            }

            this.limite -= dineroARetirar;
            RestarDinero(dineroARetirar);
            Console.Write("Has retirado " + dineroARetirar + " pesos");
        }

        public void CanjearPuntos()
        {
            Console.WriteLine("Cada 5 puntos equivale 1 peso a tu saldo");
            Console.WriteLine("Actualmente tienes "+ ConsultarPuntos() + " puntos");
            Console.Write("Cuantos puntos desear canjear?: ");
            int puntosCanjeo = Convert.ToInt32(Console.ReadLine());

            while( this.puntos - puntosCanjeo < 0)
            {
                Console.Write("No cuentas con la cantidad de puntos suficientes para canjear");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Cada 5 puntos equivale 1 peso a tu saldo");
                Console.WriteLine("Actualmente tienes " + ConsultarPuntos() + " puntos");
                Console.Write("Cuantos puntos desear canjear?: ");
                puntosCanjeo = Convert.ToInt32(Console.ReadLine());
            }

            this.puntos -= puntosCanjeo;
            AgregarDinero(puntosCanjeo / 5);
            Console.WriteLine("Has canjeado " + (puntosCanjeo / 5) + " pesos");
            Console.WriteLine("Te quedan " + ConsultarPuntos() + " puntos");
        }

    }
}
