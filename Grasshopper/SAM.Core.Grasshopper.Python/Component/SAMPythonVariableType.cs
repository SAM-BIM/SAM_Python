using Grasshopper.Kernel;
using SAM.Core;
using SAM.Core.Grasshopper;
using SAM.Core.Grasshopper.Python.Properties;
using SAM.Core.Python;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace SAM.Analytical.Grasshopper
{
    public class SAMPythonVariableType : GH_SAMVariableOutputParameterComponent
    {
        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid => new Guid("160dc59e-6951-414a-85ce-7af7b56b96b2");

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
        public SAMPythonVariableType()
          : base("SAMPython.VariableType", "SAMPython.VariableType",
              "Create VariableType",
              "SAM", "Phyton")
        {
        }

        protected override GH_SAMParam[] Inputs
        {
            get
            {
                List<GH_SAMParam> result = new List<GH_SAMParam>();
                result.Add(new GH_SAMParam(new global::Grasshopper.Kernel.Parameters.Param_String() { Name = "_name", NickName = "_name", Description = "Name", Access = GH_ParamAccess.item }, ParamVisibility.Binding));
                result.Add(new GH_SAMParam(new global::Grasshopper.Kernel.Parameters.Param_String() { Name = "_parameterType", NickName = "_parameterType", Description = "ParameterType", Access = GH_ParamAccess.item }, ParamVisibility.Binding));

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
                result.Add(new GH_SAMParam(new GooVariableTypeParam() { Name = "variableType", NickName = "variableType", Description = "SAM VariableType", Access = GH_ParamAccess.item }, ParamVisibility.Binding));
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

            string name = null;
            index = Params.IndexOfInputParam("_name");
            if (index == -1 || !dataAccess.GetData(index, ref name) || string.IsNullOrWhiteSpace(name))
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Invalid data");
                return;
            }

            string stringParameterType = null;
            index = Params.IndexOfInputParam("_parameterType");
            if (index == -1 || !dataAccess.GetData(index, ref stringParameterType))
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Invalid data");
                return;
            }

            ParameterType parameterType = Core.Query.Enum<ParameterType>(stringParameterType);

            Type type = typeof(object);
            switch(parameterType)
            {
                case ParameterType.Boolean:
                    type = typeof(bool);
                    break;

                case ParameterType.Color:
                    type = typeof(Color);
                    break;

                case ParameterType.DateTime:
                    type = typeof(DateTime);
                    break;

                case ParameterType.Double:
                    type = typeof(double);
                    break;

                case ParameterType.Guid:
                    type = typeof(Guid);
                    break;

                case ParameterType.String:
                    type = typeof(string);
                    break;
            }

            index = Params.IndexOfOutputParam("variableType");
            if (index != -1)
            {
                dataAccess.SetData(index, new GooVariableType(new VariableType(type, name)));
            }

        }
    }
}