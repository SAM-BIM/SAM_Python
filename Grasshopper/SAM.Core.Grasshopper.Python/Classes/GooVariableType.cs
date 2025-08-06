using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using SAM.Core.Grasshopper;
using SAM.Core.Grasshopper.Python.Properties;
using SAM.Core.Python;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SAM.Analytical.Grasshopper
{
    public class GooVariableType : GooJSAMObject<VariableType>
    {
        public GooVariableType()
            : base()
        {
        }

        public GooVariableType(VariableType variableType)
            : base(variableType)
        {
        }

        public override IGH_Goo Duplicate()
        {
            return new GooVariableType(Value);
        }
    }

    public class GooVariableTypeParam : GH_PersistentParam<GooVariableType>
    {
        public override Guid ComponentGuid => new Guid("5829a575-0566-48ba-a498-e5cd062f63ec");

        protected override System.Drawing.Bitmap Icon => Resources.SAM3;

        public GooVariableTypeParam()
            : base(typeof(VariableType).Name, typeof(VariableType).Name, typeof(VariableType).FullName.Replace(".", " "), "Params", "SAM")
        {
        }

        protected override GH_GetterResult Prompt_Plural(ref List<GooVariableType> values)
        {
            throw new NotImplementedException();
        }

        protected override GH_GetterResult Prompt_Singular(ref GooVariableType value)
        {
            throw new NotImplementedException();
        }

        public override void AppendAdditionalMenuItems(ToolStripDropDown menu)
        {
            Menu_AppendItem(menu, "Save As...", Menu_SaveAs, Resources.SAM3, VolatileData.AllData(true).Any());

            //Menu_AppendSeparator(menu);

            base.AppendAdditionalMenuItems(menu);
        }

        private void Menu_SaveAs(object sender, EventArgs e)
        {
            Query.SaveAs(VolatileData);
        }
    }
}