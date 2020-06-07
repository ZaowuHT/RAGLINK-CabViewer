using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CabViewerSDKOfficeOpenXml.FormulaParsing.Excel.Functions.DateTime.Workdays;
using CabViewerSDKOfficeOpenXml.FormulaParsing.ExpressionGraph;

namespace CabViewerSDKOfficeOpenXml.FormulaParsing.Excel.Functions.DateTime
{
    public class Networkdays : ExcelFunction
    {
        public override CompileResult Execute(IEnumerable<FunctionArgument> arguments, ParsingContext context)
        {
            var functionArguments = arguments as FunctionArgument[] ?? arguments.ToArray();
            ValidateArguments(functionArguments, 2);
            var startDate = System.DateTime.FromOADate(ArgToInt(functionArguments, 0));
            var endDate = System.DateTime.FromOADate(ArgToInt(functionArguments, 1));
            var calculator = new WorkdayCalculator();
            var result = calculator.CalculateNumberOfWorkdays(startDate, endDate);
            if (functionArguments.Length > 2)
            {
                result = calculator.ReduceWorkdaysWithHolidays(result, functionArguments[2]);
            }
            
            return new CompileResult(result.NumberOfWorkdays, DataType.Integer);
        }
    }
}
