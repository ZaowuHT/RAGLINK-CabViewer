using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CabViewerSDK.OfficeOpenXml.FormulaParsing.ExpressionGraph;

namespace CabViewerSDK.OfficeOpenXml.FormulaParsing.Excel.Functions.Logical
{
    public class IfError : ExcelFunction
    {
        public override CompileResult Execute(IEnumerable<FunctionArgument> arguments, ParsingContext context)
        {
            ValidateArguments(arguments, 1);
            var firstArg = arguments.First();
            return GetResultByObject(firstArg.Value);
        }
    }
}
