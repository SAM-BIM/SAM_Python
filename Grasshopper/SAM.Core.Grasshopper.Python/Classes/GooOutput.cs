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
    public class GooOutput : GooJSAMObject<Output>
    {
        public GooOutput()
            : base()
        {
        }

        public GooOutput(Output output)
            : base(output)
        {
        }

        public override IGH_Goo Duplicate()
        {
            return new GooOutput(Value);
        }
    }

    public class GooOutputParam : GH_PersistentParam<GooOutput>
    {
        public override Guid ComponentGuid => new Guid("a97c8d68-4d9c-470d-b557-af4167eed221");

        protected override System.Drawing.Bitmap Icon => Resources.SAM3;

        public GooOutputParam()
            : base(typeof(Output).Name, typeof(Output).Name, typeof(Output).FullName.Replace(".", " "), "Params", "SAM")
        {
        }

        protected override GH_GetterResult Prompt_Plural(ref List<GooOutput> values)
        {
            throw new NotImplementedException();
        }

        protected override GH_GetterResult Prompt_Singular(ref GooOutput value)
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