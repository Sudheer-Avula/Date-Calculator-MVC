using System.Web.Mvc;
using SudheerKumar.Avula.DateCalculator.Repository;
using Unity;
using Unity.Mvc5;

namespace SudheerKumar.Avula.DateCalculator
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IDaysCalculatorRepository, DaysCalculatorRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}