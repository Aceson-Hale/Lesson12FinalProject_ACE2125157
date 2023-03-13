using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12FinalProject_ACE2125157
{
    internal class Fraction : IComparable
    {
        private int numerator = 0;
        private int denominator = 1;
        private string name = "unknown";
        private int arraysize = 0;

        public int CompareTo(object rightobject)
        {
            Fraction rightFrac = (Fraction)rightobject;
            // get both Fractions as (comparable) doubles
            double f1 = (double)(this.numerator) / (double)(this.denominator);
            double f2 = (double)(rightFrac.numerator) / (double)(rightFrac.denominator);

            // compare the 2 doubles
            int retVal = 0;
            if (f1 < f2)
                retVal = -1;
            else if (f1 == f2)
                retVal = 0;
            else
                retVal = 1;

            return retVal;
        }

        public override bool Equals(object obj)
        {
            bool equals = false;
            if (obj is Fraction)
                equals = (this == (Fraction)obj);  // assumes you have operator == overridden
            return equals;
        }
        public static Fraction Parse(string str)
        {

            Fraction result = new Fraction();
            int indexSlash = str.IndexOf("/");
            if (indexSlash == -1)
            {
                throw new ArgumentException("No '/' character in input. ");
            }
            result.numerator = int.Parse(str.Substring(0, indexSlash));
            result.denominator = int.Parse(str.Substring(indexSlash + 1));

            if (result.denominator == 0)
                throw new Exception("No 0 in denomiator!");

            return result;
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            Fraction sum = new Fraction();

            sum.numerator = (a.numerator * b.denominator) + (b.numerator * a.denominator);
            sum.denominator = a.denominator * b.denominator;

            return sum;
        }
        public static Fraction operator -(Fraction a, Fraction b)
        {
            Fraction diff = new Fraction();
            diff.numerator = (a.numerator * b.denominator) - (b.numerator * a.denominator);
            diff.denominator = (a.denominator * b.denominator);

            return diff;
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            Fraction result = new Fraction();
            result.numerator = a.numerator * b.numerator;
            result.denominator = a.denominator * b.denominator;
            return result;
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            Fraction quotient = new Fraction();
            if (b.numerator == 0)
            {
                Console.WriteLine("Error: Can't divide by zero. Please enter new numerator value not equal to zero.");
                b.numerator = int.Parse(Console.ReadLine());
            }
            quotient.numerator = a.numerator * b.denominator;
            quotient.denominator = a.denominator * b.numerator;
            return quotient;
        }

        public override string ToString()
        {
            return numerator.ToString() + "/" + denominator.ToString();

        }

        public static Fraction DisplayAnswer(Fraction A)
        {
            Console.WriteLine(A.numerator + "/" + A.denominator);
            return A;
        }

        public static Fraction SETFracNum (int num)
        {
            Fraction myFrac = new Fraction();
            myFrac.numerator = num;
            return myFrac;
        }


    }
}
