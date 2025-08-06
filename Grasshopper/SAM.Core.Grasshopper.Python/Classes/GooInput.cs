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
    public class GooInput : GooJSAMObject<Input>
    {
        public GooInput()
            : base()
        {
        }

        public GooInput(Input input)
            : base(input)
        {
        }

        public override IGH_Goo Duplicate()
        {
            return new GooInput(Value);
        }
    }

    public class GooInputParam : GH_PersistentParam<GooInput>
    {
        public override Guid ComponentGuid => new Guid("b619792b-054b-4abb-9a83-3cadab594e74");

        protected override System.Drawing.Bitmap Icon => Resources.SAM3;

        public GooInputParam()
            : base(typeof(Input).Name, typeof(Input).Name, typeof(Input).FullName.Replace(".", " "), "Params", "SAM")
        {
        }

        protected override GH_GetterResult Prompt_Plural(ref List<GooInput> values)
        {
            throw new NotImplementedException();
        }

        protected override GH_GetterResult Prompt_Singular(ref GooInput value)
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