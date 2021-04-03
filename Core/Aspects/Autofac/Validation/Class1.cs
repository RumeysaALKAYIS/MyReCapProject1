using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception//using Core.Utilities.Interceptors;ile geliyo
    {//ValidationAspect atribute ve validatorTypever ProductMAnager da(typeof(Pro ductValidator
        private Type _validatorType;
        public ValidationAspect(Type validatorType)// atribute Tip atıyo
        {
            //atrıbute oldugu için bakendi kulanan validator değilse hata ver
            if (!typeof(IValidator).IsAssignableFrom(validatorType)) //gönderilen ValidatorType IValidar degilse kız
            {
                throw new System.Exception("Bu bir Doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)//Castle.DynamicProxy
        {
            //Activator.CreateInstanc bir reflaction
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//Çalışma anından dinamik instance üretiyo//Dönüş tipiIValidorden  IValidator ProductValidatorun referansını tutuyo//reflaction çalışma anında 
            // _validatorType=ProductValidaro base typeni bl
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//base bul (attribute)genericine bak parametrelerini bul 
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);//invocation=methot Validaterin tipine eşit olan tipi bul =product
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);//Her birini gez ValidationTool kullanark Validete metodu ile doğrula
            }
        }
    }
}
