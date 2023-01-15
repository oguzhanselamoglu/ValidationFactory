using System;
using System.Reflection;

namespace ValidationFactory.Validators
{
    public record StringValidator<T>() : IValidator<T>
    {
        public List<(bool, Exception)> Validate(T value, int? max, int? param2, string source, PropertyInfo? pi, object? model)
        {
            var errorList = new List<(bool, Exception)>();
            if (!typeof(T).IsValueType && typeof(T) != typeof(String))
            {
                throw new ArgumentException("T must be a value type or System.String.");
            }
            string stringValue = value.ToString();

            List<string> invalidChars = new List<string>() { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-" };
            // Check for length
            //1. Control
            if (stringValue.Length > max)
            {
                Console.WriteLine("String too Long");
                errorList.Add((false, new Exception($"String too Long. Text Must Shorter Than < {max}") { Source = source }));
            }
            //2. Control
            if (!(!stringValue.Equals(stringValue.ToLower())))
            {
                //Check for min 1 uppercase
                Console.WriteLine("Requres at least one uppercase");
                errorList.Add((false, new Exception("Requres at least one uppercase") { Source = source }));
            }
            //Iterate your list of invalids and check if input has one
            //3. Control
            foreach (string s in invalidChars)
            {
                if (stringValue.Contains(s))
                {
                    Console.WriteLine("String contains invalid character: " + s);
                    Exception exception = new Exception("String contains invalid character: " + s) { Source = source };
                    errorList.Add((false, exception));
                    //pi.SetValue(model, "Bora Kasmer");
                    break;
                }
            }
            if (errorList.Count == 0) Console.WriteLine("All tests succesful");
            return errorList;
        }
    }
}

