namespace MvcExtensions.AutoMapper
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using MvcExtensions;
    using System.Linq;
    using global::AutoMapper;

    public abstract class RegisterProfileBase : BootstrapperTask
    {
        /// <summary>
        /// Execute the task; 
        /// </summary>
        /// <returns></returns>
        public override TaskContinuation Execute()
        {
            Registration();

            return TaskContinuation.Continue;
        }

        /// <summary>
        /// Registration Profile subclass
        /// </summary>
        protected void Registration()
        {
            foreach (var profile in GetProfiles())
                Mapper.AddProfile(profile);
        }

        /// <summary>
        /// Return all profiles on scaning assembles
        /// </summary>
        /// <returns></returns>
        protected IEnumerable<Profile> GetProfiles()
        {
            var assemblies = GetAutoMapperProfileAssemblyList();
            Invariant.IsNotNull(assemblies, "assemblies");

            return assemblies.SelectMany(assembly => assembly.GetTypes()
                                                             .Where(c => c.IsSubclassOf(typeof(Profile)))
                                                             .Select(Activator.CreateInstance)).Cast<Profile>();
        }

        /// <summary>
        /// Return assembles in which there is the automapper profiles
        /// </summary>
        /// <returns></returns>
        protected abstract IEnumerable<Assembly> GetAutoMapperProfileAssemblyList();

    }
}