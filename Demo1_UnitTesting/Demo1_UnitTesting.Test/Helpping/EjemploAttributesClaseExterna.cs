using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo1_UnitTesting.PruebasUnitarias.Model;
using Demo1_UnitTesting.PruebasUnitarias.BLL;

namespace Demo1_UnitTesting.Test.Helpping
{
    class EjemploAttributesClaseExterna
    {
        /// <summary>
        /// No existen referencias!!!
        /// </summary>
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(12, 3).Returns(4);
                yield return new TestCaseData(12, 2).Returns(6);
                yield return new TestCaseData(12, 4).Returns(3);
                yield return new TestCaseData(0, 0)
                           //.Throws(typeof(DivideByZeroException))
                  .SetName("DivideByZero")
                  .SetDescription("An exception is expected");
            }
        }
    }
}
