using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using SAM.Core;
using SAM.Core.Grasshopper;
using SAM.Core.Grasshopper.Python.Properties;
using SAM.Core.Python;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace SAM.Analytical.Grasshopper
{
    public class SAMPythonInput : GH_SAMVariableOutputParameterComponent
    {
        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid => new Guid("547c7ed2-4c31-481a-95e5-01d77dbda60d");

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
        public SAMPythonInput()
          : base("SAMPython.Input", "SAMPython.Input",
              "Create Input",
              "SAM", "Phyton")
        {
        }

        protected override GH_SAMParam[] Inputs
        {
            get
            {
                List<GH_SAMParam> result = new List<GH_SAMParam>();
                result.Add(new GH_SAMParam(new global::Grasshopper.Kernel.Parameters.Param_String() { Name = "_name", NickName = "_name", Description = "Name", Access = GH_ParamAccess.item }, ParamVisibility.Binding));
                result.Add(new GH_SAMParam(new global::Grasshopper.Kernel.Parameters.Param_GenericObject() { Name = "value_", NickName = "value_", Description = "Value", Access = GH_ParamAccess.item }, ParamVisibility.Binding));
                result.Add(new GH_SAMParam(new global::Grasshopper.Kernel.Parameters.Param_String() { Name = "parameterType_", NickName = "parameterType_", Description = "ParameterType", Access = GH_ParamAccess.item }, ParamVisibility.Voluntary));

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
                result.Add(new GH_SAMParam(new GooInputParam() { Name = "input", NickName = "input", Description = "SAM Input", Access = GH_ParamAccess.item }, ParamVisibility.Binding));
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

            object value = null;
            index = Params.IndexOfInputParam("value_");
            if (index != -1)
            {
                dataAccess.GetData(index, ref value);
            }

            if(value is IGH_Goo)
            {
                value = (value as dynamic).Value;
            }

            string stringParameterType = null;
            index = Params.IndexOfInputParam("_parameterType");
            if (index != -1 && dataAccess.GetData(index, ref stringParameterType))
            {
                ParameterType parameterType = Core.Query.Enum<ParameterType>(stringParameterType);
                switch (parameterType)
                {
                    case ParameterType.String:
                        if (Core.Query.TryConvert(value, out string @string))
                        {
                            value = @string;
                        }
                        break;

                    case ParameterType.Boolean:
                        if(Core.Query.TryConvert(value, out bool @bool))
                        {
                            value = @bool;
                        }
                        break;

                    case ParameterType.Color:
                        if (Core.Query.TryConvert(value, out Color @color))
                        {
                            value = color;
                        }
                        break;

                    case ParameterType.DateTime:
                        if (Core.Query.TryConvert(value, out DateTime @dateTime))
                        {
                            value = @dateTime;
                        }
                        break;

                    case ParameterType.Double:
                        if (Core.Query.TryConvert(value, out double @double))
                        {
                            value = @double;
                        }
                        break;

                    case ParameterType.Guid:
                        if (Core.Query.TryConvert(value, out Guid @guid))
                        {
                            value = @guid;
                        }
                        break;
                }

            }

            index = Params.IndexOfOutputParam("input");
            if (index != -1)
            {
                dataAccess.SetData(index, new GooInput(new Input(name, value as dynamic)));
            }

        }
    }
}