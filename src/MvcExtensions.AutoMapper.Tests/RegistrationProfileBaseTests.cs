namespace MvcExtensions.AutoMapper.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Xunit;

    public class RegistrationProfileBaseTests
    {
        
        private sealed class DefaultProfileRegistration : MvcExtensions.AutoMapper.RegisterProfileBase
        {
            protected override IEnumerable<Assembly> GetAutoMapperProfileAssemblyList()
            {
                return null;
            }
        }


        [Fact]
        public void Should_be_throw_argument_exception()
        {
            DefaultProfileRegistration defaultProfileRegistration = new DefaultProfileRegistration();
            Assert.Throws<ArgumentNullException>(() => { defaultProfileRegistration.Execute(); });
        }
    }
}