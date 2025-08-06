using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using SAM.Core;
using SAM.Core.Grasshopper;
using SAM.Core.Grasshopper.Python.Properties;
using SAM.Core.Python;
using System;
using System.Collections.Generic;

namespace SAM.Analytical.Grasshopper
{
    public class SAMPythonExecute : GH_SAMVariableOutputParameterComponent
    {
        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid => new Guid("433b6f8e-9816-4a67-8bd7-e375d268bb34");

        /// <summary>
        /// The latest version of this component
        /// </summary>
        public override string LatestComponentVersion => "1.0.0";

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon => Resources.SAM3;

        /// <summary>
        /// Initializes a new instance of the SAM_point3D class.
        /// </summary>
        public SAMPythonExecute()
          : base("SAMPython.Execute", "SAMPython.Execute",
              "Execute script",
              "SAM", "Phyton")
        {
        }

        protected override GH_SAMParam[] Inputs
        {
            get
            {
                List<GH_SAMParam> result = new List<GH_SAMParam>();
                result.Add(new GH_SAMParam(new global::Grasshopper.Kernel.Parameters.Param_String() { Name = "_script", NickName = "_script", Description = "Python script", Access = GH_ParamAccess.item }, ParamVisibility.Binding));
                result.Add(new GH_SAMParam(new GooInputParam() { Name = "inputs_", NickName = "inputs_", Description = "Inputs", Access = GH_ParamAccess.list, Optional = true }, ParamVisibility.Binding));
                result.Add(new GH_SAMParam(new GooVariableTypeParam() { Name = "outputVarriableTypes_", NickName = "outputVarriableTypes_", Description = "Output Varriable Types", Access = GH_ParamAccess.list, Optional = true }, ParamVisibility.Binding));

                return result.ToArray();
            }
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override GH_SAMParam[] Outputs
        {
            get
            {
                List<GH_SAMParam> result = new List<GH_SAMParam>();
                result.Add(new GH_SAMParam(new global::Grasshopper.Kernel.Parameters.Param_Boolean() { Name = "succedded", NickName = "succedded", Description = "Succedded", Access = GH_ParamAccess.item }, ParamVisibility.Binding));
                result.Add(new GH_SAMParam(new GooOutputParam() { Name = "outputs", NickName = "outputs", Description = "SAM Outputs", Access = GH_ParamAccess.list }, ParamVisibility.Binding));
                return result.ToArray();
            }
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="dataAccess">
        /// The DA object is used to retrieve from inputs and store in outputs.
        /// </param>
        protected override void SolveInstance(IGH_DataAccess dataAccess)
        {
            int index = -1;

            string script = null;
            index = Params.IndexOfInputParam("_script");
            if (index == -1 || !dataAccess.GetData(index, ref script) || script == null)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Invalid data");
                return;
            }

            List<Input> inputs = new List<Input>();
            index = Params.IndexOfInputParam("inputs_");
            if (index != -1)
            {
                dataAccess.GetDataList(index, inputs);
            }

            List<VariableType> outputVariableTypes = new List<VariableType>();
            index = Params.IndexOfInputParam("outputVarriableTypes_");
            if (index != -1)
            {
                dataAccess.GetDataList(index, outputVariableTypes);
            }

            bool succeeded = SAM.Core.Python.Modify.Execute(script, inputs, outputVariableTypes, out List<Output> outputs);

            index = Params.IndexOfOutputParam("succedded");
            if (index != -1)
            {
                dataAccess.SetData(index, succeeded);
            }

            index = Params.IndexOfOutputParam("outputs");
            if (index != -1)
            {
                dataAccess.SetDataList(index, outputs?.ConvertAll(x => new GooOutput(x)));
            }

        }
    }
}