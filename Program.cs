using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool finished = false;
            while (!finished)
            {
                try
                {
                    Console.Write("Enter Net amount: ");
                    double net = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter TFC amount: ");
                    double tfc = Convert.ToDouble(Console.ReadLine());
                    Gross Net = new Gross(net, tfc);
                    finished = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }

    class Gross
    {
        public double gross { get; set; }
        public double amount_taxed { get; set; }
        public double take_home_non_tfc { get; set; }
        public double tax_rate { get; set; }
        public double net_non_tfc { get; set; }

        public Gross(double net, double tfc) //Constructor
        {
            Console.WriteLine("Net amount is: " + net);
            Console.WriteLine("TFC amount is: " + tfc);
            Console.WriteLine("Tax rate is: " + tax_rate_Calc(net, tfc));
            Console.WriteLine("Amount taxed is: " + amount_taxed_Calc(tfc));
            Console.WriteLine("Take home of non TFC portion is: " + takehome_nontfc_Calc(net, tfc));
            Console.WriteLine("Net of non TFC portion is: " + net_non_tfc_Calc(tfc));
            Console.WriteLine("Gross amount is: " + gross_Calc(tfc));
        }

        public double takehome_nontfc_Calc(double net, double tfc)
        {
            take_home_non_tfc = net - tfc;
            return take_home_non_tfc;
        }

        public double gross_Calc(double tfc)
        {
            gross = 4 * tfc;
            return gross;
        }

        public double net_non_tfc_Calc(double tfc)
        {
            gross = gross_Calc(tfc);
            net_non_tfc = gross - tfc;
            return net_non_tfc;
        }

        public double tax_rate_Calc(double net, double tfc)
        {
            take_home_non_tfc = takehome_nontfc_Calc(net, tfc);
            net_non_tfc = net_non_tfc_Calc(tfc);
            tax_rate = (net_non_tfc - take_home_non_tfc) / (net_non_tfc);
            return tax_rate;
        }

        public double amount_taxed_Calc(double tfc)
        {
            gross = gross_Calc(tfc);
            amount_taxed = 0.2 * (gross - tfc);
            return amount_taxed;
        }
    }

}
