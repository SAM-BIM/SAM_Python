using Newtonsoft.Json.Linq;
using System;
using System.Drawing;

namespace SAM.Core.Python
{
    public abstract class Variable : IJSAMObject
    {
        private VariableType variableType;
        private object value;

        public Variable(VariableType variableType, object value)
        {
            this.variableType = variableType;
            this.value = value;
        }

        public Variable(string name, double value)
        {
            variableType = new VariableType(typeof(double), name);
            this.value = value;
        }

        public Variable(string name, string value)
        {
            variableType = new VariableType(typeof(string), name);
            this.value = value;
        }

        public Variable(string name, bool value)
        {
            variableType = new VariableType(typeof(bool), name);
            this.value = value;
        }

        public Variable(string name, Color value)
        {
            variableType = new VariableType(typeof(Color), name);
            this.value = value;
        }

        public Variable(string name, DateTime value)
        {
            variableType = new VariableType(typeof(DateTime), name);
            this.value = value;
        }

        public Variable(string name, Guid value)
        {
            variableType = new VariableType(typeof(Guid), name);
            this.value = value;
        }

        public string Name
        {
            get
            {
                return variableType?.Name;
            }
        }

        public object Value
        {
            get 
            { 
                return value; 
            }
        }

        public bool FromJObject(JObject jObject)
        {
            if (jObject == null)
            {
                return false;
            }

            if (jObject.ContainsKey("VariableType"))
            {
                variableType = new VariableType(jObject.Value<JObject>("VariableType"));
            }

            if (jObject.ContainsKey("Value"))
            {
                value = jObject.Value<object>("Value");
            }

            return true;
        }

        public JObject ToJObject()
        {
            JObject jObject = new JObject();
            jObject.Add("_type", Query.FullTypeName(this));

            if (variableType != null)
            {
                jObject.Add("VariableType", variableType.ToJObject());
            }

            if (value != null)
            {
                jObject.Add("Value", value as dynamic);
            }

            return jObject;
        }
    }
}
