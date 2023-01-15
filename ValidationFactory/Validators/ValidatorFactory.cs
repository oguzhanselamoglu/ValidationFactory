using System;
namespace ValidationFactory.Validators
{
    public static class ValidatorFactory<T>
    {
        static Dictionary<string, IValidator<T>> validatorList = new();
        public static IValidator<T> GetValidator(Type attribute)
        {
            if (validatorList.Count == 0)
            {
                validatorList.Add("DateData", new DateValidator<T>());
                validatorList.Add("EmailData", new EmailValidator<T>());
                validatorList.Add("EncryptData", new EncryptValidator<T>());
                validatorList.Add("HashData", new HashValidator<T>());
                validatorList.Add("StringData", new StringValidator<T>());
                validatorList.Add("Default", new DefaultValidator<T>());
            }
            return validatorList.ContainsKey(attribute.Name) ? validatorList[attribute.Name] : validatorList["Default"];
        }
    }
}

