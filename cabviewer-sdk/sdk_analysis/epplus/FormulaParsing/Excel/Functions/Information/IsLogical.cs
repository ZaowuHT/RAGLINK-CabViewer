using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CabViewerSDKOfficeOpenXml.FormulaParsing.ExpressionGraph;

namespace CabViewerSDKOfficeOpenXml.FormulaParsing.Excel.Functions.Information
{
    public class IsLogical : ExcelFunction
    {
        public override CompileResult Execute(IEnumerable<FunctionArgument> arguments, ParsingContext context)
        {
            var functionArguments = arguments as FunctionArgument[] ?? arguments.ToArray();
            ValidateArguments(functionArguments, 1);
            var v = GetFirstValue(arguments);
            return CreateResult(v is bool, DataType.Boolean);
        }
    }
}
