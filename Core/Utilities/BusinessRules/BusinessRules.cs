using Core.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.BusinessRules
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logies)
        {
            foreach (var logic in logies)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }

            return null;
        }
    }
}
