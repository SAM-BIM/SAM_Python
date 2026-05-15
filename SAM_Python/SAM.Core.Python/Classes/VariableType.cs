using System.Text.Json.Nodes;
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
        public VariableType(JsonObject jObject)
        {
            FromJsonObject(jObject);
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

        public bool FromJsonObject(JsonObject jObject)
        {
            if (jObject == null)
            {
                return false;
            }

            if (jObject.ContainsKey("Name"))
            {
                name = jObject["Name"]?.GetValue<string>() ?? default(string);
            }

            if (jObject.ContainsKey("Type"))
            {
                type = Query.Type(jObject["Type"]?.GetValue<string>() ?? default(string), true);
            }

            return true;
        }

        public JsonObject ToJsonObject()
        {
            JsonObject jObject = new JsonObject();
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
