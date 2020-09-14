using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CabViewerSDK.OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime.Workdays;
using CabViewerSDK.OfficeOpenXml.FormulaParsing.ExpressionGraph;
using CabViewerSDK.OfficeOpenXml.Utils;

namespace CabViewerSDK.OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime
{
    public class Workday : ExcelFunction
    {
        public override CompileResult Execute(IEnumerable<FunctionArgument> arguments, ParsingContext context)
        {
            var functionArguments = arguments as FunctionArgument[] ?? arguments.ToArray();
            ValidateArguments(functionArguments, 2);
            var startDate = System.DateTime.FromOADate(ArgToInt(functionArguments, 0));
            var nWorkDays = ArgToInt(functionArguments, 1);
            var resultDate = System.DateTime.MinValue;
            
            var calculator = new WorkdayCalculator();
            var result = calculator.CalculateWorkday(startDate, nWorkDays);
            if (functionArguments.Length > 2)
            {
                result = calculator.AdjustResultWithHolidays(result, functionArguments[2]);
            }
            return CreateResult(result.EndDate.ToOADate(), DataType.Date);
        }   
    }
}
