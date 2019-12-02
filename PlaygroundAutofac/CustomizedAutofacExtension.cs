using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Autofac.Features.Scanning;

namespace PlaygroundAutofac
{
    public static class CustomizedAutofacExtension
    {
        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle>
            MultiKeyed<TService>(
                this IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> registration,
                Func<Type, IEnumerable<string>> serviceKeyMapping)
        {
            var serviceType = typeof(TService);
            return registration
                .AssignableTo(serviceType)
                .As(t => serviceKeyMapping(t).Select(key => new KeyedService(key, serviceType)));
        }
    }
}