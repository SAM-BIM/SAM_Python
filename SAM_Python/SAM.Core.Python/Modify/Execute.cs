using Microsoft.Scripting.Actions.Calls;
using Microsoft.Scripting.Hosting;
using System.Collections.Generic;

namespace SAM.Core.Python
{
    public static partial class Modify
    {
        public static bool Execute(this string code, IEnumerable<Input> inputs, IEnumerable<VariableType> outputVariableTypes, out List<Output> outputs)
        {
            outputs = null;

            if(string.IsNullOrWhiteSpace(code))
            {
                return false;
            }

            ScriptEngine scriptEngine = IronPython.Hosting.Python.CreateEngine();

            ScriptScope scriptScope = scriptEngine.CreateScope();
            if (inputs != null)
            {
                foreach(Input input in inputs)
                {
                    if(string.IsNullOrWhiteSpace(input?.Name))
                    {
                        continue;
                    }

                    scriptScope.SetVariable(input.Name, input.Value);
                }
            }

            scriptEngine.Execute(code, scriptScope);

            if(outputVariableTypes != null)
            {
                outputs = new List<Output>();
                foreach(VariableType outputVariableType in outputVariableTypes)
                {
                    if (string.IsNullOrWhiteSpace(outputVariableType?.Name))
                    {
                        continue;
                    }

                    if(!scriptScope.TryGetVariable(outputVariableType.Name, out dynamic value))
                    {
                        continue;
                    }

                    outputs.Add(new Output(outputVariableType, value));
                }
            }

            return true;
        }
    }
}
