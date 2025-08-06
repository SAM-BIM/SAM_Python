using Newtonsoft.Json.Linq;
using System;

namespace SAM.Core.Python
{
    public class VariableType : IJSAMObject
    {
        private string name;
        private Type type;

        public VariableType(VariableType variableType)
        {
            if(variableType != null)
            {
                type = variableType.type;
                name = variableType.name;
            }
        }
        public VariableType(JObject jObject)
        {
            FromJObject(jObject);
        }

        public VariableType(Type type, string name)
        {
            this.type = type;
            this.name = name;
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public bool FromJObject(JObject jObject)
        {
            if (jObject == null)
            {
                return false;
            }

            if (jObject.ContainsKey("Name"))
            {
                name = jObject.Value<string>("Name");
            }

            if (jObject.ContainsKey("Type"))
            {
                type = Query.Type(jObject.Value<string>("Type"), true);
            }

            return true;
        }

        public JObject ToJObject()
        {
            JObject jObject = new JObject();
            jObject.Add("_type", Query.FullTypeName(this));

            if (name != null)
            {
                jObject.Add("Name", name);
            }

            if (type != null)
            {
                jObject.Add("Type", Query.FullTypeName(type));
            }

            return jObject;
        }
    }
}
